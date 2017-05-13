using UnityEngine;
using System.Collections;
using Toolkit;

/// <summary>
/// S building lifebar.建筑上的血条、时间进度条
/// </summary>
public class SBSliderBar : CLCellLua
{
	public UIFollowTarget followTarget;
	HUDText _hudText;
	const string ConstName = "LifeBar";

	public HUDText hudText {
		get {
			if (_hudText == null) {
				_hudText = GetComponent<HUDText> ();
			}
			return _hudText;
		}
	}

	public static void init ()
	{
		init (5, 1);
	}

	public static void init (int num, int lbNum)
	{
		int[] orgs = {num, lbNum};
		CLUIOtherObjPool.setPrefab (ConstName, (Callback)onSetLifeBarPrefab, orgs);
	}

	static void onSetLifeBarPrefab (params object[] paras)
	{
		if (paras.Length > 1) {
//			GameObject bar = (GameObject)(paras [0]);
			int[] orgs = (int[])(paras [1]);
			int num = orgs [0];
			int lbNum = orgs [1];
			ArrayList list = new ArrayList ();
			SBSliderBar bar = null;
			for (int i = 0; i < num; i++) {
				bar = CLUIOtherObjPool.borrowObj (ConstName).GetComponent<SBSliderBar>();
				list.Add (bar.gameObject);
				bar.transform.parent = SCfg.self.mHUDRoot4Scene;
				bar.hudText.init (lbNum);
				NGUITools.SetActive (bar.gameObject, false);
			}
			int count = list.Count;
			for (int i =0; i < count; i++) {
				CLUIOtherObjPool.returnObj (ConstName, (GameObject)(list [i]));
			}
			list.Clear ();
			list = null;
		}
	}

	public static SBSliderBar instance (Transform targetTr, Vector3 offset)
	{
		if(!CLUIOtherObjPool.havePrefab(ConstName)) {
			Debug.LogError("Must set the lifebar prefab first!!!");
			return null;
		}
		SBSliderBar sb = CLUIOtherObjPool.borrowObj (ConstName).GetComponent<SBSliderBar>();
		if (sb.luaTable == null) {
			sb.setLua ();
		}
		sb.hudText.ignoreTimeScale = false;
		sb.transform.parent = SCfg.self.mHUDRoot4Scene;
		sb.transform.localEulerAngles = Vector3.zero;
		sb.transform.localPosition = Vector3.zero;
		sb.transform.localScale = Vector3.one;
		sb.followTarget.setTarget (targetTr, offset);
		sb.followTarget.setCamera (SCfg.self.mainCamera, SCfg.self.uiCamera);
		return sb;
	}

	public UILabel addHudtxt (object obj, Color color, float stayTime)
	{
		return addHudtxt (obj, color, stayTime, 1);
	}

	public UILabel addHudtxt (object obj, Color color, float stayTime, float fontSize)
	{
		return hudText.Add (obj, color, stayTime, fontSize);
	}
	
	public void hide ()
	{
		CLUIOtherObjPool.returnObj (name, gameObject);
		NGUITools.SetActive (gameObject, false);
	}
}

