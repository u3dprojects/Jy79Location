using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

/**
 * 1、脚本放在Scroll View下面的UIGrid的那个物体上 
 * 2、Scroll View上面的UIPanel的Cull勾选上
 * 3、每一个Item都放上一个UIWidget，调整到合适的大小（用它的Visiable） ，设置Dimensions
 * 4、需要提前把Item放到Grid下，不能动态加载进去
 * 5、注意元素的个数要多出可视范围至少4个
 **/
[RequireComponent(typeof(UIGrid))]
public class CLUILoopGrid : MonoBehaviour
{
	[HideInInspector]
	public bool
		isPlayTween = true;
	public TweenType twType = TweenType.position;
	public  float tweenSpeed = 0.01f;
	public  float twDuration = 0.5f;
	public UITweener.Method twMethod = UITweener.Method.EaseOut;
	private List<UIWidget> itemList = new List<UIWidget> ();
	private Vector4 posParam;
	private Transform cachedTransform;
	UIGrid grid = null;
//	void Awake ()
//	{
//		cachedTransform = this.transform;
//		grid = this.GetComponent<UIGrid> ();
//		float cellWidth = grid.cellWidth;
//		float cellHeight = grid.cellHeight;
//		posParam = new Vector4 (cellWidth, cellHeight, 
//			grid.arrangement == UIGrid.Arrangement.Horizontal ? 1 : 0,
//			grid.arrangement == UIGrid.Arrangement.Vertical ? 1 : 0);
//	}
	
	bool isFinishInit = false;
	int times = 0;
	int RealCellCount = 0;
	Vector3 oldGridPosition = Vector3.zero;
	Vector3 oldScrollViewPos = Vector3.zero;
	Vector2 oldClipOffset = Vector2.zero;
	UIScrollView _scrollView;

	public UIScrollView scrollView {
		get {
			if (_scrollView == null) {
				_scrollView = NGUITools.FindInParents<UIScrollView> (transform);
				if (_scrollView != null) {
					oldScrollViewPos = _scrollView.transform.localPosition;
					oldClipOffset = _scrollView.panel.clipOffset;
				}
			}
			return _scrollView;
		}
	}
	
	public void init ()
	{
		if (isFinishInit)
			return;

		cachedTransform = this.transform;
		grid = this.GetComponent<UIGrid> ();
		oldGridPosition = grid.transform.localPosition;
		_scrollView = scrollView;
		float cellWidth = grid.cellWidth;
		float cellHeight = grid.cellHeight;
		posParam = new Vector4 (cellWidth, cellHeight, 
			grid.arrangement == UIGrid.Arrangement.Horizontal ? -1 : 0,
			grid.arrangement == UIGrid.Arrangement.Vertical ? 1 : 0);
		
		for (int i=0; i<cachedTransform.childCount; ++i) {
			Transform t = cachedTransform.GetChild (i);
			UIWidget uiw = t.GetComponent<UIWidget> ();
			uiw.name = string.Format ("{0:D5}", itemList.Count);
			itemList.Add (uiw);
		}
		RealCellCount = itemList.Count;
		grid.Reposition ();
		isFinishInit = true;		
		if (itemList.Count < 3) {
			Debug.LogError("The childCount < 3");
		}
	}

	public void resetClip ()
	{
		scrollView.panel.clipOffset = oldClipOffset;
		scrollView.transform.localPosition = oldScrollViewPos;
		grid.transform.localPosition = oldGridPosition;
	}
	
	object[] data = null;
	object initCellCallback;
	
	public void setList (object data, object initCellCallback)
	{
		setList (data, initCellCallback, true);
	}

	public void setList (object data, object initCellCallback, bool isNeedRePosition)
	{
		setList (data, initCellCallback, isNeedRePosition, isPlayTween);
	}
	
	public void setList (object data, object initCellCallback, bool isNeedRePosition, bool isPlayTween)
	{
		setList (data, initCellCallback, isNeedRePosition, isPlayTween, tweenSpeed);
	}

	public void setList (object data, object initCellCallback, bool isNeedRePosition, bool isPlayTween, 
	                     float tweenSpeed)
	{
		setList (data, initCellCallback, isNeedRePosition, isPlayTween, tweenSpeed, twDuration);
	}

	public void setList (object data, object initCellCallback, bool isNeedRePosition, bool isPlayTween, 
	                     float tweenSpeed, float twDuration)
	{
		setList (data, initCellCallback, isNeedRePosition, isPlayTween, tweenSpeed, twDuration, twMethod);
	}
	
	public void setList (object data, object initCellCallback, bool isNeedRePosition, bool isPlayTween, 
	                     float tweenSpeed, float twDuration, UITweener.Method twMethod)
	{
		setList (data, initCellCallback, isNeedRePosition, isPlayTween, tweenSpeed, twDuration, twMethod, twType);
	}

	public void setList (object data, object initCellCallback, bool isNeedRePosition, bool isPlayTween, 
	                     float tweenSpeed, float twDuration, UITweener.Method twMethod, TweenType twType)
	{
		if (data == null) {
			Debug.LogError ("Data is null");
			return;
		}
		object[] list = null;
		if (data is LuaTable) {
			list = ((LuaTable)data).ToArray<object> ();
		} else if (data is ArrayList) {
			list = ((ArrayList)data).ToArray ();
		} else if (data is object[]) {
			list = (object[])(data);
		}
		_setList (list, initCellCallback, isNeedRePosition, isPlayTween, tweenSpeed, twDuration, twMethod, twType);
	}
	
	void _setList (object[] data, object initCellCallback, bool isNeedRePosition, bool isPlayTween, float tweenSpeed, 
	               float twDuration, UITweener.Method twMethod, TweenType twType)
	{
		try {
			this.data = data;
			if (data == null) {
				Debug.LogError ("Data is null");
				return;
			}
			this.initCellCallback = initCellCallback;
			if (!isFinishInit) {
				init ();
			}
			int tmpIndex = 0;
			if (isNeedRePosition) {
				times = 0;
				itemList.Clear ();
			}
			int offset = 0;
			if (!isNeedRePosition) {
				for (int i=0; i< cachedTransform.childCount; ++i) {
					tmpIndex = int.Parse (cachedTransform.GetChild (i).name);
					if (tmpIndex >= this.data.Length) {
						offset = 1;
						break;
					}
				}
				if (offset > 0) {
					for (int i=0; i< cachedTransform.childCount; ++i) {
						Transform t = cachedTransform.GetChild (i);
						tmpIndex = int.Parse (t.name);
						if (tmpIndex - offset < 0) {
							UIWidget uiw = t.GetComponent<UIWidget> ();
							if (uiw.isVisible) {
								offset = 0;
								isNeedRePosition = true;
								break;
							}
						}
					}
				}
			}

			for (int i=0; i< cachedTransform.childCount; ++i) {
				Transform t = cachedTransform.GetChild (i);
				UIWidget uiw = t.GetComponent<UIWidget> ();
				
				if (isNeedRePosition) {
					tmpIndex = i;
				} else {
					tmpIndex = int.Parse (uiw.name);
				}
				tmpIndex = tmpIndex - offset;
				uiw.name = string.Format ("{0:D5}", tmpIndex);
				if (tmpIndex >= 0 && tmpIndex < this.data.Length) {
					NGUITools.SetActive (t.gameObject, true);
					if (this.initCellCallback != null) {
						if (typeof(Callback) == this.initCellCallback.GetType ()) {
							((Callback)this.initCellCallback) (t.GetComponent<CLCellBase> (), data [tmpIndex]);
						} else if (typeof(LuaFunction) == this.initCellCallback.GetType ()) {
							((LuaFunction)this.initCellCallback).Call (t.GetComponent<CLCellBase> (), data [tmpIndex]);
						}
					}
				} else {
					NGUITools.SetActive (t.gameObject, false);
				}

				if (isNeedRePosition) {
					itemList.Add (uiw);
				}
			}
			if (isNeedRePosition) {
				resetClip ();
				if (!isPlayTween || twType == TweenType.alpha || twType == TweenType.scale) {
					grid.Reposition ();
					scrollView.ResetPosition ();	
				}
				if (isPlayTween) {
					for (int i=0; i < itemList.Count; i++) {
						CLUIUtl.resetCellTween (i, grid, itemList [i].gameObject, tweenSpeed, twDuration, twMethod, twType);
					}
				}
			}
		} catch (System.Exception e) {
			Debug.LogError (e);
		}
	}
	
	int sourceIndex = -1;
	int targetIndex = -1;
	int sign = 0;
	bool firstVislable = false;
	bool lastVisiable = false;
	UIWidget head;
	UIWidget tail;
	UIWidget checkHead;
	UIWidget checkTail;
	
//	void LateUpdate ()
	void Update ()
	{
		if (itemList.Count < 3) {
			return;
		}
		sourceIndex = -1;
		targetIndex = -1;
		sign = 0;
		head = itemList [0];
		tail = itemList [itemList.Count - 1];
		checkHead = itemList [1];
		checkTail = itemList [itemList.Count - 2];
		firstVislable = checkHead.isVisible;
		lastVisiable = checkTail.isVisible;
			
		// if first and last both visiable or invisiable then return	
		if (firstVislable == lastVisiable) {
			return;
		}
			
		if (firstVislable && int.Parse (head.name) > 0) {
			times--;
			// move last to first one
			sourceIndex = itemList.Count - 1;
			targetIndex = 0;
			sign = 1;
		} else if (lastVisiable && int.Parse (tail.name) < data.Length - 1) {
			times++;
			// move first to last one
			sourceIndex = 0;
			targetIndex = itemList.Count - 1;
			sign = -1;
		}
		if (sourceIndex > -1) {
			UIWidget movedWidget = itemList [sourceIndex];
			Vector3 offset = new Vector3 (sign * posParam.x * posParam.z, sign * posParam.y * posParam.w, 0);
			movedWidget.cachedTransform.localPosition = itemList [targetIndex].cachedTransform.localPosition + offset;
			if (sign < 0) {
				movedWidget.name = string.Format ("{0:D5}", ((times - 1) / RealCellCount + 1) * RealCellCount + int.Parse (movedWidget.name) % RealCellCount);
			} else {
				movedWidget.name = string.Format ("{0:D5}", ((times) / RealCellCount) * RealCellCount + int.Parse (movedWidget.name) % RealCellCount);
			}
				
			// change item index
			itemList.RemoveAt (sourceIndex);
			itemList.Insert (targetIndex, movedWidget);
				
			if (this.initCellCallback != null) {
				int index = int.Parse (movedWidget.name);
				if (typeof(Callback) == this.initCellCallback.GetType ()) {
					((Callback)this.initCellCallback) (movedWidget.GetComponent<CLCellBase> (), data [index]);
				} else if (typeof(LuaFunction) == this.initCellCallback.GetType ()) {
					((LuaFunction)this.initCellCallback).Call (movedWidget.GetComponent<CLCellBase> (), data [index]);
				}
			}
		}
	}
}
