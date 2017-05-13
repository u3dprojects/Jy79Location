using UnityEngine;
using System.Collections;
using System;

// 主城三维标签处理器(异步处理) CLSceneTitle3D
public class SBuildingTitle : MonoBehaviour {

	public string perfabHubName = "BuildingTitle";

	private BetterList<GameObject> instances = new BetterList<GameObject>();
	// Use this for initialization
	void Start () {
	
	}

	public void clear() {
		for (int i = 0; i < instances.size; ++i )
		{
			GameObject obj = instances[i];
			CLUIOtherObjPool.returnObj (perfabHubName, obj);
			NGUITools.SetActive (obj, false);	
		}
	}

	public void create(Transform targetTr,Transform anchor, Callback onCreatedCallbak)
	{
		object[] inparam = { anchor, targetTr, onCreatedCallbak };
		CLUIOtherObjPool.borrowObjAsyn (perfabHubName, (Callback)onCreateExFinished, inparam);
	}

	public void onCreateExFinished(params object[] param)
	{
		if (param.Length < 3)
		{
			Debug.LogWarning("borrowObjAsyn need correct param.");
			return;
		}
		// string name = param[0] as string;
		GameObject clone = param[1] as GameObject;
		object[] inparam = param[2] as object[];

		if (inparam.Length < 2) {
			Debug.LogWarning("onCreateExFinished callback need correct param.");
			return;
		}

		Transform anchor = inparam[0] as Transform;
		Transform buildtaf = inparam[1] as Transform;
		Callback createEndFunc = inparam[2] as Callback;
		Vector3 offset = Vector3.zero;

		clone.transform.parent = SCfg.self.mHUDRoot4Scene;
		clone.transform.localPosition = Vector3.zero;
		clone.transform.localScale = Vector3.one;
		
		UIFollowTarget ft = clone.GetComponent<UIFollowTarget>();
		ft.setTarget (anchor, offset);
		ft.setCamera (SCfg.self.mainCamera, SCfg.self.uiCamera);
		
		instances.Add(clone);
		NGUITools.SetActive (clone, true);

		if ( createEndFunc != null) {
			createEndFunc(clone, buildtaf);
		}
	}
}
