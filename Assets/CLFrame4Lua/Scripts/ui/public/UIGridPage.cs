using UnityEngine;
using System.Collections;

/// <summary>
/// User interface grid page 滑动页面
/// 注意使用时，每个page都要继承UIDragPageContents(如果是lua时可以直接使用UIDragPage4Lua)
/// </summary>
using LuaInterface;


[ExecuteInEditMode]
[RequireComponent(typeof(UIMoveToCell))]
public class UIGridPage : UIGrid
{
	int cacheNum = 3;	//缓存数
	public bool isReverse = false;
	public float dragSensitivity = 10f;		//拖动敏感度
	public UIDragPageContents page1;
	public UIDragPageContents page2;
	public UIDragPageContents page3;
	[HideInInspector]
	public int currCell = 0;
	int oldCurrCell = -1;
	UIMoveToCell _moveToCell;
	LoopPage currPage;
	LoopPage pages;
	bool canDrag = true;
	int flag = 1;
	UIScrollView _scrollView;
	public UIScrollView scrollView{
		get {
			if(_scrollView == null) {
				_scrollView = GetComponent<UIScrollView>();
				if(_scrollView == null) {
					_scrollView = transform.parent.GetComponent<UIScrollView>();
				}
			}
			return _scrollView;
		}
	}
	
	public class LoopPage
	{
		public UIDragPageContents data;
		public LoopPage prev;
		public LoopPage next;
	}
	
	bool isFinishInit = false;

	public override void Start()
	{
		if (isFinishInit) {
			return;
		}
		base.Start();
		_init();
	}

	void _init()
	{
		if (isFinishInit) {
			return;
		}
		isFinishInit = true;
		dragSensitivity = dragSensitivity <= 0 ? 1 : dragSensitivity;
		pages = new LoopPage();
		pages.data = page1;
		pages.next = new LoopPage();
		pages.next.data = page2;
		pages.next.next = new LoopPage();
		pages.next.next.data = page3;
		pages.next.next.next = pages;
		
		pages.prev = pages.next.next;
		pages.next.prev = pages;
		pages.next.next.prev = pages.next;
		currPage = pages;
	}

	public UIMoveToCell moveToCell {
		get {
			if (_moveToCell == null) {
				_moveToCell = GetComponent<UIMoveToCell>();
			}
			return _moveToCell;
		}
	}
	
	object[] datas;
	object onRefreshCurrentPage;
	/// <summary>
	/// Init the specified pageList, initPage, initCell and defalt.初始化滑动页面
	/// </summary>
	/// <param name="pageList">Page list.
	/// 数据：是list里面套list，外层list是页面的数据，内层的数据是每个页面里面的数据
	/// </param>
	/// <param name="onRefreshCurrentPage">onRefreshCurrentPage.
	/// 当显示当前page时的回调
	/// </param>
	/// <param name="defaltPage">defaltPage.
	/// 初始化时默认页（0表示第一页，1表示第2页）
	/// </param>
	public void init(object pageList, object onRefreshCurrentPage, int defaltPage)
	{
		if (pageList == null) {
			Debug.LogError ("Data is null");
			return;
		}
		object[] list = null;
		if (pageList is LuaTable) {
			list = ((LuaTable)pageList).ToArray<object> ();
		} else if (pageList is ArrayList) {
			list = ((ArrayList)pageList).ToArray ();
		}
		_initList(list, onRefreshCurrentPage, defaltPage);
	}
	void _initList(object[] pageList, object onRefreshCurrentPage, int defaltPage)
	{
		Start();
		canDrag = true;
		if(isReverse) {
			flag = -1;
		}
		datas = pageList;
		this.onRefreshCurrentPage = onRefreshCurrentPage;
		if (defaltPage >= pageList.Length || defaltPage < 0) {
			return;
		}
		currCell = defaltPage;
		initCellPos(currCell);
	}
	
	void initCellPos(int index)
	{
		NGUITools.SetActive(page1.gameObject, true);
		NGUITools.SetActive(page2.gameObject, true);
		NGUITools.SetActive(page3.gameObject, true);
				
		Update();
		repositionNow = true;
		Update();
		
		currPage = pages;
				
		int pageCount = datas.Length;
		if (pageCount <= 3) {
			#region
			//些段处理是为了让ngpc这种三个页面显示的数据不同的那种，让三个页面的位置固定
			switch (currCell) { 
				case 0:
					currPage = pages;
					NGUITools.SetActive(page1.gameObject, true);
					break;
				case 1:
					currPage = pages.next;
					break;
				case 2:
					currPage = pages.prev;
					break;
				default:
					break;
			}
			
			switch (pageCount) {
				case 1:
					NGUITools.SetActive(page1.gameObject, true);
					NGUITools.SetActive(page2.gameObject, false);
					NGUITools.SetActive(page3.gameObject, false);
					break;
				case 2:
					NGUITools.SetActive(page1.gameObject, true);
					NGUITools.SetActive(page2.gameObject, true);
					NGUITools.SetActive(page3.gameObject, false);
					break;
				case 3:
					NGUITools.SetActive(page1.gameObject, true);
					NGUITools.SetActive(page2.gameObject, true);
					NGUITools.SetActive(page3.gameObject, true);
					break;
				default:
					NGUITools.SetActive(page1.gameObject, false);
					NGUITools.SetActive(page2.gameObject, false);
					NGUITools.SetActive(page3.gameObject, false);
					break;
			}
			#endregion
		} else {
			Vector3 toPos = Vector3.zero;
			if (arrangement == UIGrid.Arrangement.Horizontal) {
				toPos.x = flag*cellWidth * (index);
				currPage.data.transform.localPosition = toPos;
				toPos.x = flag*cellWidth * (index - 1);
				currPage.prev.data.transform.localPosition = toPos;
				toPos.x = flag*cellWidth * (index + 1);
				currPage.next.data.transform.localPosition = toPos;
			} else {
				toPos.y = -flag*cellHeight * index;
				currPage.data.transform.localPosition = toPos;
				toPos.y = -flag*cellHeight * (index - 1);
				currPage.prev.data.transform.localPosition = toPos;
				toPos.y = -flag*cellHeight * (index + 1);
				currPage.next.data.transform.localPosition = toPos;
			}
		}
		oldCurrCell = currCell;
		moveToCell.moveTo(index, isReverse, false);
		
		//刷新数据
		if (currCell <= 0) {
			NGUITools.SetActive(currPage.prev.data.gameObject, false);
		}
		if (currCell - 1 >= 0) {
			currPage.prev.data.init(datas [currCell - 1]);//刷新数据
		}
		if (currCell + 1 < pageCount) {
			currPage.next.data.init(datas [currCell + 1]);//刷新数据
		}
		currPage.data.refreshCurrent(currCell, datas [currCell]);//刷新数据(放在最后)
		doCallback();
	}

	void onFinishMoveto(params object[] paras) {
		canDrag = true;
	}

	void doCallback() {
		if (onRefreshCurrentPage != null) {
			if(onRefreshCurrentPage.GetType() == typeof(LuaFunction)) {
				((LuaFunction)onRefreshCurrentPage).Call(currCell, datas [currCell]);
			} else if(onRefreshCurrentPage.GetType() == typeof(Callback)) {
				((Callback)onRefreshCurrentPage)(currCell, datas [currCell]);
			}
		}
	}
	
	public void moveTo(bool force = false)
	{
		canDrag = false;
		Callback cb = onFinishMoveto;
		moveToCell.moveTo(currCell,  isReverse,false, cb);
		if (oldCurrCell != currCell || force) {
			resetCell(force);
			oldCurrCell = currCell;
		}
	}
	
	void resetCell(bool isForce)
	{
		if (currCell > 0) {
			NGUITools.SetActive(currPage.prev.data.gameObject, true);
		}
		//处理边界
		int pageCount = datas.Length;

		//移动位置
		if ((currCell != 0 && currCell != datas.Length - 1) || isForce) {
			UIDragPageContents cell;
			Vector3 toPos = Vector3.zero;
			if (oldCurrCell < currCell) {
				cell = currPage.prev.data;
				if (arrangement == UIGrid.Arrangement.Horizontal) {
					toPos = currPage.data.transform.localPosition;
					toPos.x += flag*cellWidth * 2;
				} else {
					toPos = currPage.data.transform.localPosition;
					toPos.y -= flag*cellHeight * 2;
				}
			} else {
				cell = currPage.next.data;
				if (arrangement == UIGrid.Arrangement.Horizontal) {
					toPos = currPage.data.transform.localPosition;
					toPos.x -= flag*cellWidth * 2;
				} else {
					toPos = currPage.data.transform.localPosition;
					toPos.y += flag*cellHeight * 2;
				}
			}
			cell.transform.localPosition = toPos;
		}
		if (oldCurrCell != -1 || currCell != 0) {
			if (oldCurrCell < currCell) {
				currPage = currPage.next;
			} else {
				currPage = currPage.prev;
			}
		}
		//刷新数据
		if (currCell - 1 >= 0) {
			currPage.prev.data.init(datas [currCell - 1]);//刷新数据
		}
		if (currCell + 1 < pageCount) {
			currPage.next.data.init(datas [currCell + 1]);//刷新数据
		}
		currPage.data.refreshCurrent(currCell, datas [currCell]);//刷新数据(放在最后)
		doCallback();
	}

	public void onPress(bool isPressed)
	{
		//===============
		if (!isPressed) {
			if(canDrag) {
				procMoveCell();
			}
		} else {
			totalDelta = Vector2.zero;
		}
	}

	Vector2 totalDelta = Vector2.zero;

	public void onDrag(Vector2 delta)
	{
		totalDelta += delta;
	}
	
	//处理移动单元
	public void procMoveCell()
	{
		int index = currCell;
		if (datas == null || datas.Length <= 0) {
			return;
		}
		float delta = 0;

		float sensitivity = dragSensitivity <= 0 ? 1 : dragSensitivity;
		if (arrangement == Arrangement.Horizontal) {
			delta = totalDelta.x;
			if (Mathf.Abs(delta) >= cellWidth / dragSensitivity) {
				if (flag* delta > 0) {
					index--;
				} else {
					index++;
				}
			}
		} else {
			delta = totalDelta.y;
			if (Mathf.Abs(delta) >= cellHeight / dragSensitivity) {
				if (flag*delta > 0) {
					index++;
				} else {
					index--;
				}
			}
		}
		if(scrollView.dragEffect == UIScrollView.DragEffect.Momentum) {
			if(index < 0 || index >= datas.Length) return;
		}
		moveTo(index);
	}
	
	public void moveTo(int index)
	{
		currCell = index;
		currCell = currCell < 0 ? 0 : currCell;
		currCell = currCell >= datas.Length ? datas.Length - 1 : currCell;
		moveTo();
	}
}
