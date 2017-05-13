using UnityEngine;
using System.Collections;
using System.IO;
using Toolkit;
using LuaInterface;

//程序入口
public class CLMain : CLBehaviour4Lua
{
	public static CLMain self;
	public string startPanel;

	public CLMain ()
	{
		self = this;
	}

	// Use this for initialization
	public override void Start ()
	{
		// 显示公司logo页面
		CLPanelBase panel = CLPanelManager.getPanel (startPanel);
		CLPanelManager.showPanel (panel);
//		SoundEx.playSound ("Coolape", 1);
		// 初始化
		Invoke ("init", 2);
	}

	void init() {
		StartCoroutine (gameInit ());
	}
	
	public IEnumerator gameInit ()
	{
		yield return null;
		//设置初始语言,Resource目录下的语言文件只需要包括刚开始加载页面需要的文字即可，
		//等更处理完成后，将会再次设置一次语言
		Localization.language = "Chinese";		//TODO: 根据保存的语文来设置
		//防止锁屏
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		//设置帧率
		Application.targetFrameRate = 30;
		// set fps, only none channel can show fps
		if(SCfg.self.fps != null) {
			if (SCfg.Channel == SCfg.ChlType.NONE
				|| SCfg.Channel == SCfg.ChlType.IOSDEMO) {
				SCfg.self.fps.isPrintFps = true;
			} else {
				SCfg.self.fps.enabled = false;
			}
		}
		//初始化streamingAssetsPackge,把包里的资源释放出来
		CLVerManager.self.initStreamingAssetsPackge ((Callback)onGetStreamingAssets);
	}

	// 当完成把数据从包里释放出来
	void onGetStreamingAssets (params object[] para)
	{
		//先加载一次atlas，以便可以显示ui
		CLUIInit.self.init ();

		//再次加载语言
		string languageFile = PStr.b (
			PathCfg.persistentDataPath, "/", PathCfg.self.localizationPath, 
			Localization.language, ".txt").e ();
		#if UNITY_EDITOR
		if(!SCfg.self.isNotEditorMode) {
			languageFile = languageFile.Replace("/upgradeRes/", "/upgradeResMedium/");
		}
		#endif
		byte[] buff = File.ReadAllBytes (languageFile);
		Localization.Load (Localization.language, buff);
		//设置lua
		setLua ();
	}

	public void reStart ()
	{
		CancelInvoke ();
		StopAllCoroutines ();
		Invoke("doRestart" , 0.5f); // 必须得用个invoke，否则unity会因为lua.desotry而闪退
	}
	public void doRestart() {
		CLPanelManager.destoryAllPanel ();
		FileEx.cleanCache ();
		if(mainLua != null) {
			mainLua.Destroy();
			mainLua = null;
			mainLua = new LuaScriptMgr();
		}
		lua = null;
		Start ();
	}

	public  void OnApplicationQuit() {
#if UNITY_EDITOR
		CLUIInit.self.emptAtlas.replacement = null;
#endif
		if (mainLua != null) {
			mainLua.Destroy ();
			mainLua = null;
		}
	}

//	public override void OnDestroy ()
//	{
//		base.OnDestroy ();
//	}
	public override void setLua ()
	{
		//set lua
		if (lua == null || CLVerManager.self.haveUpgrade) {
			CLPanelManager.destoryAllPanel ();
			if (lua == null) {
				lua = mainLua;
				lua.Start ();
				base.setLua ();
			}
		}
	}
	LuaFunction lfexitGmaeConfirm = null;
	public override void initGetLuaFunc ()
	{
		base.initGetLuaFunc ();
		lfexitGmaeConfirm = getLuaFunction ("exitGmaeConfirm");
	}
	
	// Update is called once per frame
	public override void Update ()
	{
		base.Update();
		if(Input.GetKeyUp(KeyCode.Escape)) {
			if(lfexitGmaeConfirm != null) {
				lfexitGmaeConfirm.Call();
			}
		}
		// proc net offline
		if (isOffLine) {
			isOffLine = false;
			doOffline ();
		}

        UpdateFuc();
	}

	bool isOffLine = false;
	//off line
	public void onOffline ()
	{
		isOffLine = true;
	}

	public void doOffline ()
	{
		if (lua == null) {
			return;
		}
		LuaFunction f = getLuaFunction ("onOffline");
		if (f != null) {
			f.Call ();
		}
	}

	// 放慢速度
	public  void slowDown (float rate, float stay)
	{
		setTimeScale (rate);
		Invoke ("normalSpeed", stay);
	}

	public void normalSpeed ()
	{
		setTimeScale (1);
	}

	public void setTimeScale (float rate)
	{
		Time.timeScale = rate;
	}

    new void UpdateFuc()
    {
        if (lua != null)
        {
            lua.Update();
        }
    }

    new void LateUpdate()
    {
        if (lua != null)
        {
            lua.LateUpate();
        }
    }

    new void FixedUpdate()
    {
        if (lua != null)
        {
            lua.FixedUpdate();
        }
    }
}
