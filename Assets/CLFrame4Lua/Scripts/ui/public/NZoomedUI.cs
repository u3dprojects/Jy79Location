using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class NZoomedUI : MonoBehaviour
{

	public float defaultX = 960;
	public float defaultY = 640;
	public static float zoomValue = 1;
	
	public enum ZoomType
	{
		zoomWhenLower,
		zoomWhenAll,
	}
	public ZoomType zoomType = ZoomType.zoomWhenAll;
	public enum Type
	{
		ratioOfEquality,
		fullScreen,
	}
	public Type type = Type.ratioOfEquality;
	public bool valueIs0To1 = true;
	
	// Use this for initialization
	void Start ()
	{
		float zoomValueX = Screen.width / defaultX;
		float zoomValueY = Screen.height / defaultY;
		
		if (zoomType == ZoomType.zoomWhenLower) {
			if (Screen.width < defaultX || Screen.height < defaultY) {
				zoomValue = zoomValueX > zoomValueY ? zoomValueY : zoomValueX;
			} else {
				zoomValue = 1;
			}
		} else {
			zoomValue = zoomValueX > zoomValueY ? zoomValueY : zoomValueX;
		}
#if UNITY_IPHONE
		if(Application.platform == RuntimePlatform.IPhonePlayer) {
			Debug.Log(iPhone.generation);
			if (iPhone.generation == iPhoneGeneration.iPad3Gen || 
				iPhone.generation == iPhoneGeneration.iPad4Gen ||
				iPhone.generation == iPhoneGeneration.iPad5Gen ||
				iPhone.generation == iPhoneGeneration.iPadUnknown ||
				iPhone.generation == iPhoneGeneration.iPadMini2Gen ||
				iPhone.generation == iPhoneGeneration.Unknown) {
				zoomValue = 1.4375f;
			}
		}
#endif
		if (type == Type.ratioOfEquality) {
			if (valueIs0To1) {
				transform.localScale = new Vector3 (zoomValue, zoomValue, zoomValue);
			} else {
				transform.localScale = new Vector3 (Screen.width * zoomValue, Screen.height * zoomValue, 1);
			}
		} else {
			if (valueIs0To1) {
				transform.localScale = new Vector3 (1 / zoomValue, 1 / zoomValue, 1 / zoomValue);
			} else {
				transform.localScale = new Vector3 (Screen.width / zoomValue, Screen.height / zoomValue, 1);
			}
		}
	}

//    void OnApplicationPause (bool isPause)
//    {
//        if(!isPause) {
//            Start ();
//        }
//    }
	
#if UNITY_EDITOR
	public bool refresh = true;
	void Update() {
		if(refresh) {
			refresh = false;
			Start();
		}
	}
#endif
}
