using UnityEngine;
using System.Collections;
using Toolkit;
using System.Collections.Generic;

public class SCfg : MonoBehaviour
{
	public static SCfg self;

	public SCfg()
	{
		self = this;
	}
	
    public string UUID = "";
    public string singinMd5Code = "";
    public bool isNotEditorMode = false;
	public bool isNetMode = true;
	public bool isUseEncodedLua = true;
	public bool isGuidMode = false;
	public bool isFullEffect = true;
    public bool useBio4Battle = true;
	public CLFPS fps;
	public Camera mainCamera;
	public Camera camera4Top; //显示到最顶层
	public Camera uiCamera;
	public AudioSource mainAudio;
	public AudioSource singletonAudio;
	public Transform mLookatTarget;
	public Transform mHUDRoot;
	public Transform mHUDRoot4Scene;
	public GameMode mode = GameMode.normal;
	public GameObject dragDropRoot;

	//是否是在编辑器下
	public bool isEditMode {
		get {
#if UNITY_EDITOR
			if(SCfg.self.isNotEditorMode) {
				return false;
			}else{
				return true;
			}
#else
			return false;
#endif
		}
	}

	//渠道=========================
#if CHL_NONE
	public static string Channel = ChlType.NONE;
#elif CHL_DEMO
    public static string Channel = ChlType.DEMO;
#elif CHL_IOSDEMO
	public static string Channel = ChlType.IOSDEMO;
#else
    public static string Channel = ChlType.DEMO;
#endif
	public static string PakageName = "com.ultralisk.guobao." + Channel;
	//******************************************************************
	
	public class ChlType
	{
		public const string NONE = "none";
		public const string DEMO = "demo";
		public const string IOSDEMO = "iosDemo";
	}
}
public enum GameMode
{
	normal,
	battle,
	map,
	explore,
}