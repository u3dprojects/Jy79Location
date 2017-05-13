using UnityEngine;
using System.Collections;
using Toolkit;

/// <summary>
/// SBHUD text.
/// 3D场景中的头顶字
/// </summary>
public class SBHUDText : MonoBehaviour
{
	public HUDText hudText;
	public UILabel stayLabel;		//常驻显示用
	public UIFollowTarget followTarget;
	public static SBHUDTextPool hudTextPool = new SBHUDTextPool ();
	static bool isFinishInit = false;

	public static void init ()
	{
		if (isFinishInit)
			return;
		isFinishInit = true;
		for (int i = 0; i < 10; i++) {
			SBHUDText bt = hudTextPool.createObject ();
			hudTextPool.returnObject (bt);
			NGUITools.SetActive (bt.gameObject, false);
		}
	}
	
	public static SBHUDText instance (Transform targetTr, Vector3 offset)
	{
		SBHUDText sb = hudTextPool.borrowObject ();
		sb.transform.parent = HUDRoot.go.transform;
		sb.stayLabel.text = "";
		sb.stayLabel.transform.localScale = new Vector3 (40, 40, 1);
		sb.transform.localEulerAngles = Vector3.zero;
		sb.transform.localPosition = Vector3.zero;
		sb.transform.localScale = Vector3.one;
		sb.followTarget.setTarget (targetTr, offset);
		sb.followTarget.setCamera (SCfg.self.mainCamera.GetComponent<Camera>(), SCfg.self.uiCamera);
		return sb;
	}
	
	public void show (string text, Color cl, float delayTime)
	{
		if (delayTime >= 0) {
			hudText.Add (text, cl, delayTime);
			stayLabel.text = "";
		} else {
			stayLabel.text = text;
			stayLabel.color = cl;
			stayLabel.gameObject.SetActive (true);
		}
	}
	
	public void hide ()
	{
		hudTextPool.returnObject (this);
		for (int i = 0; i < transform.childCount; i++) {
			NGUITools.SetActive (transform.GetChild (i).gameObject, false);
		}
	}
}

public class SBHUDTextPool : AbstractObjectPool<SBHUDText>
{
	GameObject prefab;

	public override SBHUDText createObject (string key = null)
	{
		if (prefab == null) {
			string path = "prefab/ui/other/prefHUDText";
			prefab = Resources.Load (path) as GameObject;
		}
		GameObject go = Utl.cloneRes (prefab);
		
		return go.GetComponent<SBHUDText> ();
	}

	public override SBHUDText resetObject (SBHUDText t)
	{
		return t;
	}
}
