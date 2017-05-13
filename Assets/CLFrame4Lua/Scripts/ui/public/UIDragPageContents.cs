using UnityEngine;
using System.Collections;

/// <summary>
/// User interface drag page.
/// 拖动滑动一页
/// 将脚本绑定在每个单元上
/// add by chenbin
/// 2014-02-05
/// </summary>
public class UIDragPageContents : UIDragScrollView
{
	Transform tr;
	public Transform transform {
		get {
			if(tr == null) {
				tr = gameObject.transform;
			}
			return tr;
		}
	}
	public UIGridPage _gridPage;

	public UIGridPage gridPage {
		get {
			if (_gridPage == null) {
				_gridPage = transform.parent.GetComponent<UIGridPage> ();
			}
			return _gridPage;
		}
	}

	public void OnPress (bool isPressed)
	{
		if(isPressed) {
			base.OnPress (isPressed);
		}
		gridPage.onPress (isPressed);
	}

	public void OnDrag (Vector2 delta)
	{
		base.OnDrag (delta);
		gridPage.onDrag (delta);
	}

	/// <summary>
	/// Init the specified obj.初始化页面数据
	/// </summary>
	/// <param name="obj">Object.</param>
	public virtual void init(object obj){}

	/// <summary>
	/// Refreshs the current.初始化当前页面数据
	/// </summary>
	/// <param name="pageIndex">Page index.</param>
	/// <param name="obj">Object.</param>
	public virtual void refreshCurrent(int pageIndex, object obj){}
}
