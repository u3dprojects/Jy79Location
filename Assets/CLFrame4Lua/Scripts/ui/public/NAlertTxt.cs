using UnityEngine;
using System.Collections;

public class NAlertTxt : MonoBehaviour
{
	public static NAlertTxt self;
	HUDText hudText;
	public string hudBackgroundSpriteName = "public_dtouming";
	public Color hudBackgroundColor = Color.white;
	public static SpriteHudPool pool = new SpriteHudPool ();
	
	public NAlertTxt ()
	{
		self = this;
	}

	bool isFinishInit = false;

	void Start ()
	{
		if (isFinishInit)
			return;
		isFinishInit = true;
		hudText = GetComponent<HUDText> ();
	}

	static object beforeStr = "";
	static long beforeTime = 0;
	
	public static void add (object msg, Color color, float delayTime)
	{
		add (msg, color, delayTime, 1, true);
	}
	
	public static void add (object msg, Color color, float delayTime, float scaleOffset)
	{
		add (msg, color, delayTime, scaleOffset, true);
	}

	public static void add (object msg, Color color, float delayTime, float scaleOffset, bool needBackGround)
	{
		if (msg == null)
			return;
		if (beforeStr.Equals (msg) && beforeTime - System.DateTime.Now.ToFileTime () / 10000 > 0) {
			return;
		}
		self.Start ();
		beforeStr = msg;
		beforeTime = System.DateTime.Now.AddSeconds (2).ToFileTime () / 10000;
//		Debug.Log(self.hudText);
		UILabel label = self.hudText.Add (msg, color, delayTime, scaleOffset);
		if (needBackGround) {
			if (label.transform.childCount > 0) {
				Transform sp = label.transform.GetChild (0);
				NGUITools.SetActive (sp.gameObject, true);
			} else {
				UISprite sp = pool.borrowObject (self.hudBackgroundSpriteName);
				if (sp != null) {
					sp.transform.parent = label.transform;
					sp.transform.localScale = Vector3.one;
					sp.transform.localPosition = Vector3.zero;
					sp.color = self.hudBackgroundColor;
					sp.depth = -1;
					NGUITools.SetActive (sp.gameObject, true);
				}
			}
		} else {
			if (label.transform.childCount > 0) {
				Transform sp = label.transform.GetChild (0);
				NGUITools.SetActive (sp.gameObject, false);
			}
		}
	}
	
}

public class SpriteHudPool : AbstractObjectPool<UISprite>
{
    
	public override UISprite createObject (string name = null)
	{
		UISprite sp = NGUITools.AddSprite (HUDRoot.go, CLUIInit.self.emptAtlas, name);
		sp.type = UIBasicSprite.Type.Sliced;
		sp.SetDimensions (350, 60);
		return sp;
	}
    
	public override UISprite resetObject (UISprite t)
	{
		return t;
	}
}
