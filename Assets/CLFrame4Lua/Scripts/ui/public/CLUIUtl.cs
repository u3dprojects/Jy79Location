using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;

/// <summary>
/// Init cell delegate.
/// 列表单元的初始回调函数
/// </summary>
public delegate void InitCellDelegate(GameObject cell,object content);

public class CLUIUtl
{
	
	/// <summary>
	/// Appends the list.向列追加元素
	/// </summary>
	/// <param name='parent'>
	/// Parent.
	/// </param>
	/// <param name='prefabChild'>
	/// Prefab child.
	/// </param>
	/// <param name='list'>
	/// List.
	/// </param>
	/// <param name='itype'>
	/// Itype.
	/// </param>
	/// <param name='beforCount'>
	/// Befor count.之前已经有的元素个数
	/// </param>
	/// <param name='initCallback'>
	/// Init callback.
	/// </param>
	public static void appendList4Lua(UIGrid parent, GameObject prefabChild, ArrayList list,
	                        int beforCount, object initCallback)
	{
		appendList(parent, prefabChild, list, typeof(CLCellLua), beforCount, null, initCallback);
	}

	public static void appendList(UIGrid parent, GameObject prefabChild, ArrayList list,
	                        System.Type itype, int beforCount, object initCallback)
	{
		appendList(parent, prefabChild, list, itype, beforCount, null, initCallback);
	}

	public static void appendList(UIGrid parent, GameObject prefabChild, ArrayList list,
	                        System.Type itype, int beforCount, GameObject nextPage, object initCallback, float offset = 0)
	{
		if (list == null) {
			return;
		}
		
		if (parent == null) {
			return;
		}	
		
		parent.sorted = true;
		Transform go = null;
		string childName = "";
		for (int i = 0; i < list.Count; i++) {
			childName = NumEx.nStrForLen(beforCount + i, 5);
			go = parent.transform.Find(childName);
			if (go == null) {
				go = NGUITools.AddChild(parent.gameObject, prefabChild).transform;
				go.name = childName;
			}
			
			go.transform.localPosition = new Vector3(0, -(beforCount + i) * parent.cellHeight + offset, 0);
			NGUITools.SetActive(go.gameObject, true);
			if (initCallback != null) {
				if (typeof(LuaFunction) == initCallback.GetType()) {
					((LuaFunction)initCallback).Call(go.GetComponent<CLCellBase>(), list [i]);
				} else if (typeof(Callback) == initCallback.GetType()) {
					((Callback)initCallback)(go.GetComponent<CLCellBase>(), list [i]);
				}
			}
		}
		
		if (nextPage != null && go != null) {
			nextPage.transform.localPosition = Vector3.zero;
			nextPage.transform.parent = go;
			nextPage.transform.localPosition = new Vector3(0, -parent.cellHeight, 0);
		}
	}
	
	/// <summary>
	/// Resets the list.更新列表
	/// </summary>
	/// <param name='parent'>
	/// Parent.
	/// </param>
	/// <param name='prefabChild'>
	/// Prefab child.
	/// </param>
	/// <param name='list'>
	/// List.
	/// </param>
	/// <param name='itype'>
	/// Itype.
	/// </param>
	/// <param name='initCallback'>
	/// Init callback.
	/// </param>
	public static void resetList(UIGrid parent, GameObject prefabChild, object list,
	                             System.Type itype, object initCallback, bool isPlayTween, float tweenSpeed = 0.2f)
	{
		resetList(parent, prefabChild, list, itype, null, true, initCallback, isPlayTween, tweenSpeed);
	}
	
	public static void resetList4Lua(UIGrid parent, GameObject prefabChild, object list
	                                 , object initCallback)
	{
		resetList(parent, prefabChild, list, typeof(CLCellLua), initCallback, false, 0);
	}
	
	public static void resetList4Lua(UITable parent, GameObject prefabChild, object list
	                                 , object initCallback)
	{
		resetList(parent, prefabChild, list, typeof(CLCellLua), initCallback, false, 0);
	}
	public static void resetList4Lua(UIGrid parent, GameObject prefabChild, object list
	                                 , object initCallback, bool isPlayTween, float tweenSpeed = 0.2f)
	{
		resetList(parent, prefabChild, list, typeof(CLCellLua), initCallback, isPlayTween, tweenSpeed);
	}
	
	public static void resetList4Lua(UITable parent, GameObject prefabChild, object list
	                                 , object initCallback, bool isPlayTween, float tweenSpeed = 0.2f)
	{
		resetList(parent, prefabChild, list, typeof(CLCellLua), initCallback, isPlayTween, tweenSpeed);
	}
	
	public static void resetList(UITable parent, GameObject prefabChild, object list,
	                             System.Type itype, object initCallback, bool isPlayTween, float tweenSpeed = 0.2f)
	{
		resetList(parent, prefabChild, list, itype, null, true, initCallback, isPlayTween, tweenSpeed);
	}
	
	public static void resetList(object parent, GameObject prefabChild,
	                       object data, System.Type itype, GameObject nextPage, bool isShowNoneContent,
	                       object initCallback, bool isPlayTween, float tweenSpeed = 0.2f)
	{

		object[] list = null;
		if(data is LuaTable) {
			list = ((LuaTable)data).ToArray<object>();
		} else if(data is ArrayList) {
			list = ((ArrayList)data).ToArray();
		}
		if ((list == null || list.Length == 0) && isShowNoneContent) {
			//mtoast = NGUIPublic.toast (mtoast, USWarnMsg.warnMsgNoContent ());
		}
		if (parent == null) {
			return;
		}	
		bool isTable = false;
		if (typeof(UIGrid) == parent.GetType()) {
			isTable = false;
		} else if (typeof(UITable) == parent.GetType()) {
			isTable = true;
		} else {
			return;
		}
			
		Transform parentTf = null;
		if (isTable) {
			((UITable)parent).sorting = UITable.Sorting.None;
			parentTf = ((UITable)parent).transform;
		} else {
			((UIGrid)parent).sorted = true;
			parentTf = ((UIGrid)parent).transform;
		}
		Transform go;
		int i = 0, j = 0;
		bool isNeedReposition = false;
		string childName = "";
		for (i = 0; i < parentTf.childCount && list != null && j < list.Length; i++) {
			childName = NumEx.nStrForLen(i, 5);
			go = parentTf.Find(childName);
			if (go != null) {
				if (go.GetComponent(itype) != null) {
					NGUITools.SetActive(go.gameObject, true);
//					initCallback (go.gameObject, list [j]);
					if (initCallback != null) {
						if (typeof(LuaFunction) == initCallback.GetType()) {
							((LuaFunction)initCallback).Call(go.GetComponent<CLCellBase>(), list [j]);
						} else if (typeof(Callback) == initCallback.GetType()) {
							((Callback)initCallback)(go.GetComponent<CLCellBase>(), list [j]);
						}
					}
					if (isPlayTween) { 
						resetCellTween(i, parent, go.gameObject, tweenSpeed);
					}
					
					if ((j + 1) == list.Length && nextPage != null) {
						nextPage.transform.localPosition = Vector3.zero;
						nextPage.transform.parent = go;
						if (!isTable) {
							nextPage.transform.localPosition = new Vector3(0, -((UIGrid)parent).cellHeight, 0);
						}
					}
					j++;
				}
			}
		}
		
		while (i < parentTf.childCount) {
			childName = NumEx.nStrForLen(i, 5);
			go = parentTf.Find(childName);
			if (go != null && go.gameObject.activeSelf) {
				if (go.GetComponent(itype) != null) {
					NGUITools.SetActive(go.gameObject, false);
					isNeedReposition = true;
				}
			}
			i++;
		}
		while (list != null && j < list.Length) {
			go = NGUITools.AddChild(parentTf.gameObject, prefabChild).transform;
			isNeedReposition = true;
			childName = NumEx.nStrForLen(j, 5);
			go.name = childName;
//			initCallback (go.gameObject, list [j]);
			if (initCallback != null) {
				if (typeof(LuaFunction) == initCallback.GetType()) {
					((LuaFunction)initCallback).Call(go.GetComponent<CLCellBase>(), list [j]);
				} else if (typeof(Callback) == initCallback.GetType()) {
					((Callback)initCallback)(go.GetComponent<CLCellBase>(), list [j]);
				}
			}
			if (isPlayTween) { 
				resetCellTween(j, parent, go.gameObject, tweenSpeed);
			}
			
			if ((j + 1) == list.Length && nextPage != null) {
				nextPage.transform.localPosition = Vector3.zero;
				nextPage.transform.parent = go;
				if (!isTable) {
					nextPage.transform.localPosition = new Vector3(0, -((UIGrid)parent).cellHeight, 0);
				}
			}
			j++;
		}
		
		if (!isPlayTween) {
			if (isNeedReposition) {
				if (!isTable) {
					((UIGrid)parent).enabled = true;
					((UIGrid)parent).Start();
					((UIGrid)parent).Reposition();
					UIScrollView sv = ((UIGrid)parent).transform.parent.GetComponent<UIScrollView>();
					if(sv != null) {
						sv.ResetPosition();
					}
				}
			} else {
				if (!isTable) {
					((UIGrid)parent).Start();
					((UIGrid)parent).Reposition();
					UIScrollView sv = ((UIGrid)parent).transform.parent.GetComponent<UIScrollView>();
					if(sv != null) {
						sv.ResetPosition();
					}
				}
			}
			if (isTable) {
				((UITable)parent).Start();
				((UITable)parent).Reposition();
				UIScrollView sv = ((UITable)parent).transform.parent.GetComponent<UIScrollView>();
				if(sv != null) {
					sv.ResetPosition();
				}
			}
		}
	}

	/// <summary>
	/// Resets the cell tween.
	/// </summary>
	/// <param name="index">Index.</param>
	/// <param name="gridObj">Grid object.</param>
	/// <param name="cell">Cell.</param>
	public static void resetCellTween(int index, object gridObj, GameObject cell, 
	                                  float tweenSpeed, float duration = 0.5f, 
	                                  UITweener.Method method = UITweener.Method.EaseInOut, 
	                                  TweenType twType = TweenType.position)
	{
		switch(twType) {
		case TweenType.position:
			resetCellTweenPosition(index, gridObj, cell, tweenSpeed, duration, method);
			break;
		case TweenType.scale:
			resetCellTweenScale(index, gridObj, cell, tweenSpeed, duration, method);
			break;
		case TweenType.alpha:
			resetCellTweenAlpha(index, gridObj, cell, tweenSpeed, duration, method);
			break;
		}
	}

	public static void resetCellTweenPosition(int index, object gridObj, GameObject cell, 
	                                  float tweenSpeed, float duration = 0.5f, 
	                                  UITweener.Method method = UITweener.Method.EaseInOut)
	{
		if (gridObj.GetType() != typeof(UIGrid)) {
			Debug.LogWarning("The cell tween must have grid!");
			return;
		}
		UIGrid grid = (UIGrid)gridObj;
		if (grid.maxPerLine > 1) {
			Debug.LogWarning("The grid must have one line!");
			return;
		}
		UIPanel panel = grid.transform.parent.GetComponent<UIPanel>();
		float clippingWidth = panel == null ? 100 : panel.baseClipRegion.z;
		float clippingHeight = panel == null ? 100 : panel.baseClipRegion.w;
		Vector3 pos1 = Vector3.zero;
		Vector3 pos2 = Vector3.zero;
		if ((grid.arrangement == UIGrid.Arrangement.Horizontal &&
			grid.maxPerLine == 0) ||
			(grid.arrangement == UIGrid.Arrangement.Vertical &&
			grid.maxPerLine == 1)) {
			pos1 = new Vector3(index * grid.cellWidth, 0, 0);
			pos2 = new Vector3(index * grid.cellWidth, -clippingHeight, 0);
		} else if ((grid.arrangement == UIGrid.Arrangement.Horizontal &&
			grid.maxPerLine == 1) ||
			(grid.arrangement == UIGrid.Arrangement.Vertical &&
			grid.maxPerLine == 0)) {
			pos1 = new Vector3(0, -index * grid.cellHeight, 0);
			pos2 = new Vector3(-clippingWidth, -index * grid.cellHeight, 0);
		}

		TweenPosition tween = cell.GetComponent<TweenPosition>();
		tween = tween == null ? cell.AddComponent<TweenPosition>() : tween;
		tween.method = method;
		tween.enabled = false;
		tween.from = pos2;
		tween.to = pos1;
		tween.duration = duration;
		tween.ResetToBeginning();
		tween.delay = index * tweenSpeed;
		tween.Play();
	}

	
	public static void resetCellTweenScale(int index, object gridObj, GameObject cell, 
	                                          float tweenSpeed, float duration = 0.5f, 
	                                          UITweener.Method method = UITweener.Method.EaseInOut)
	{
		if (gridObj.GetType() != typeof(UIGrid)) {
			Debug.LogWarning("The cell tween must have grid!");
			return;
		}
		UIGrid grid = (UIGrid)gridObj;
		if (grid.maxPerLine > 1) {
			Debug.LogWarning("The grid must have one line!");
			return;
		}
//		UIPanel panel = grid.transform.parent.GetComponent<UIPanel>();
//		float clippingWidth = panel == null ? 100 : panel.baseClipRegion.z;
//		float clippingHeight = panel == null ? 100 : panel.baseClipRegion.w;
//		Vector3 pos1 = Vector3.zero;
//		Vector3 pos2 = Vector3.zero;
//		if ((grid.arrangement == UIGrid.Arrangement.Horizontal &&
//		     grid.maxPerLine == 0) ||
//		    (grid.arrangement == UIGrid.Arrangement.Vertical &&
//		 grid.maxPerLine == 1)) {
//			pos1 = new Vector3(index * grid.cellWidth, 0, 0);
//		} else if ((grid.arrangement == UIGrid.Arrangement.Horizontal &&
//		            grid.maxPerLine == 1) ||
//		           (grid.arrangement == UIGrid.Arrangement.Vertical &&
//		 grid.maxPerLine == 0)) {
//			pos1 = new Vector3(0, -index * grid.cellHeight, 0);
//		}
//		cell.transform.localPosition = pos1;

		TweenScale tween = cell.GetComponent<TweenScale>();
		tween = tween == null ? cell.AddComponent<TweenScale>() : tween;
		tween.method = method;
		tween.enabled = false;
		tween.from = Vector3.zero;
		tween.to = Vector3.one;
		tween.duration = duration;
		tween.ResetToBeginning();
		tween.delay = index * tweenSpeed;
		tween.Play();
	}
	
	public static void resetCellTweenAlpha(int index, object gridObj, GameObject cell, 
	                                       float tweenSpeed, float duration = 0.5f, 
	                                       UITweener.Method method = UITweener.Method.EaseInOut)
	{
		TweenAlpha tween = cell.GetComponent<TweenAlpha>();
		tween = tween == null ? cell.AddComponent<TweenAlpha>() : tween;
		tween.method = method;
		tween.enabled = false;
		tween.from = 0;
		tween.to = 1;
		tween.duration = duration;
		tween.ResetToBeginning();
		tween.delay = index * tweenSpeed;
		tween.Play();
	}

	/// <summary>
	/// Resets the chat list.聊天列表
	/// </summary>
	public static void resetChatList(GameObject grid, GameObject prefabChild, ArrayList list,
	                       System.Type itype, float offsetY, object initCallback)
	{
		if (list == null) {
			return;
		}
		
		//NGUITools.SetActive(grid, true);
		int cellObjCount = grid.transform.childCount; //grid.GetComponentsInChildren(itype).Length;
		GameObject go = null;
		BoxCollider bc = null;
		float anchor = 0;
		Vector3 pos = Vector3.zero;
		int i = 0;
		for (i = list.Count - 1; i >= 0; i--) {
			if (i < cellObjCount) {
				go = grid.transform.Find(i.ToString()).gameObject;
				NGUITools.SetActive(go, true);
			} else {
				go = NGUITools.AddChild(grid.gameObject, prefabChild);
				go.name = i.ToString();
			}
//			initCallback (go, list [i]);		//先调用初始化方法
			if (initCallback != null) {
				if (typeof(LuaFunction) == initCallback.GetType()) {
					((LuaFunction)initCallback).Call(go.GetComponent<CLCellBase>(), list [i]);
				} else if (typeof(Callback) == initCallback.GetType()) {
					((Callback)initCallback)(go.GetComponent<CLCellBase>(), list [i]);
				}
			}
			
			NGUITools.AddWidgetCollider(go);		//设置collider是为了得到元素的高度以便计算，同时也会让碰撞区适合元素大小
			bc = go.GetComponent(typeof(BoxCollider)) as  BoxCollider;
			pos = go.transform.localPosition;
			anchor += (bc.size.y + offsetY);
			pos.y = anchor;
			go.transform.localPosition = pos;
		}
		for (i= list.Count; i < cellObjCount; i++) {
			go = grid.transform.Find(i.ToString()).gameObject;
			NGUITools.SetActive(go, false);
		}
	}
	
	/// <summary>
	/// Sets the tab selected.设置标签页面选中
	/// </summary>
	/// <param name='_tabRoot'>
	/// _tab root.
	/// </param>
	/// <param name='name'>
	/// Name.
	/// </param>
	public static void setTabSelected(Transform _tabRoot, string name)
	{
		Transform tab = _tabRoot.Find(name);
		UIToggle checkbox = tab.GetComponent<UIToggle>();
		if (checkbox != null) {
			checkbox.value = true;
		}
	}
	
	public static void showConfirm(string msg, object callback)
	{
		showConfirm(msg, true, Localization.Get("Okay"), callback, "", null);
	}

	public static void showConfirm(string msg, object callback1, object callback2)
	{
		showConfirm(msg, false, Localization.Get("Okay"), callback1, Localization.Get("Cancel"), callback2);
	}
	
	public static void showConfirm(string msg, bool isShowOneButton, string button1, 
		object callback1, string button2, object callback2)
	{
		
		CLPanelBase p = CLPanelManager.getPanel("PanelConfirm");
		if (p == null) {
			return;
		}
		ArrayList list = new ArrayList();
		list.Add(msg);
		list.Add(isShowOneButton);
		list.Add(button1);
		list.Add(callback1);
		list.Add(button2);
		list.Add(callback2);
		p.setData(list);
		CLPanelManager.showPanel(p);
	}
	
	
	/// <summary>
	/// Sets the sprite fit.设置ngui图片的原始大小
	/// </summary>
	/// <param name='sprite'>
	/// Sprite.
	/// </param>
	/// <param name='sprName'>
	/// Spr name.
	/// </param>
	public static void setSpriteFit(UISprite sprite, string sprName)
	{
        if(sprite.atlas.isBorrowSpriteMode) {
            Callback cb = onGetSprite;
            sprite.atlas.borrowSpriteByname(sprName, sprite, cb);
        } else {
            sprite.spriteName = sprName;
            UISpriteData sd = sprite.GetAtlasSprite();
            if (sd == null) {
                return;
            }
            sprite.SetDimensions(sd.width, sd.height);
        }
	}
	public static void onGetSprite(params object[] paras) {
		UISprite sprite = (UISprite)(paras[0]);
		string sprName = paras[1].ToString();
		sprite.spriteName = sprName;
		UISpriteData sd = sprite.GetAtlasSprite();
		if (sd == null) {
			return;
		}
//		sprite.MakePixelPerfect();
		sprite.SetDimensions(sd.width, sd.height);
//		sprite.Update();
	}
	
	public static void setSpriteFit(UISprite sprite, string sprName, int maxSize)
	{
        if(sprite.atlas.isBorrowSpriteMode) {
    		Callback cb = onGetSprite2;
    		sprite.atlas.borrowSpriteByname(sprName, sprite, cb, maxSize);
        } else {
            sprite.spriteName = sprName;
            UISpriteData sd = sprite.GetAtlasSprite();
            if (sd == null) {
                return;
            }
            float x = (float)(sd.width);
            float y = (float)(sd.height);
            float size = x > y ? x : y;
            float rate = 1;
            if (size > maxSize) {
                rate = maxSize / size;
            }
            //      sprite.MakePixelPerfect();
            sprite.SetDimensions((int)(sd.width * rate), (int)(sd.height * rate));
        }
	}
	public static void onGetSprite2(params object[] paras) {
		UISprite sprite = (UISprite)(paras[0]);
		string sprName = paras[1].ToString();
		int maxSize = NumEx.stringToInt(paras[2].ToString());
//		NGUITools.SetActive(sprite.gameObject, false);
		sprite.spriteName = sprName;
		UISpriteData sd = sprite.GetAtlasSprite();
		if (sd == null) {
			return;
		}
		float x = (float)(sd.width);
		float y = (float)(sd.height);
		float size = x > y ? x : y;
		float rate = 1;
		if (size > maxSize) {
			rate = maxSize / size;
		}
//		sprite.MakePixelPerfect();
		sprite.SetDimensions((int)(sd.width * rate), (int)(sd.height * rate));
//		NGUITools.SetActive(sprite.gameObject, true);
	}

	//设置所有图片是否灰色
	static public void setAllSpriteGray(GameObject gobj, bool isGray)
	{
		if (gobj == null) {
			return;
		}
		UISprite sprSelf = gobj.GetComponent<UISprite>();
		setSpriteGray(sprSelf, isGray);

		UISprite[] sprs = gobj.GetComponentsInChildren<UISprite>();
		if (sprs == null || sprs.Length == 0) {
			return;
		}
		int len = sprs.Length;
		for (int i = 0; i < len; i++) {
			setSpriteGray(sprs [i], isGray);
		}
	}

	static public void setSpriteGray(UISprite spr, bool isGray)
	{
		if (spr == null) {
			return;
		}
		if (isGray) {
			spr.setGray();
		} else {
			spr.unSetGray();
		}
	}
}

public enum TweenType {
	position,
	scale,
	alpha,
}