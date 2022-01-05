using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections;
using System.IO.Compression;
using Toolkit;

/// <summary>
/// Coolape Publisher .
/// 库猿编译发布工具
/// 2013-11-16
/// create by chenbin
/// </summary>
using System.Collections.Generic;


public class CoolapePublisher : EditorWindow
{
	public delegate void OnClickCallback ();

	string[] AndroidIconsName = {
		"192x192",
		"144x144",
		"96x96",
		"72x72",
		"48x48",
		"36x36"
	};
	string[] IosIconsName = {
		"180x180",
		"152x152",
		"144x144",
		"120x120",
		"114x114",
		"76x76",
		"72x72",
		"57x57"
	};
	string configFile = "Coolape/Editor/CoolapeChannel.cfg";
	//渠道列表
	Hashtable channelMap = new Hashtable ();
	ArrayList channelEnum = new ArrayList ();
	ArrayList channelAliasEnum = new ArrayList ();
	Hashtable channelData = new Hashtable ();
	string cfgFilePath = "";
	UnityEngine.Object _CfgFile;

	UnityEngine.Object mCfgFile {
		get {
			if (_CfgFile == null && !string.IsNullOrEmpty (cfgFilePath)) {
				_CfgFile = AssetDatabase.LoadAssetAtPath (
					cfgFilePath, 
					typeof(UnityEngine.Object));
			}
			return _CfgFile;
		}
		set {
			_CfgFile = value;
			if (_CfgFile != null) {
				cfgFilePath = AssetDatabase.GetAssetPath (_CfgFile.GetInstanceID ());
			} else {
				cfgFilePath = "";
			}
			channelData ["cfgFile"] = cfgFilePath;
//			saveData ();
		}
	}

	bool isNewChannel = true;		//新增渠道
	bool isCfgChannel = false;		//配置渠道
	int channelCount = 0;
	int enumCount = 0;
	bool isFinishInit = false;
	string newChlName = "";
	string newChlAlias = "";
	bool isShowCfgChlDesc = false;
	int currChlIndex = -1;
	bool isComfireDelete = false;
	bool isShowHelpBox = false;
	bool isShowCfgFileDesc = false;
	string currChlName = "";
	ChlData currChlData = new ChlData ();
	Vector2 scrollPos = Vector2.zero;
	Vector2 scrollPos2 = Vector2.zero;
	bool isShowIcons = false;

	void OnGUI ()
	{
		if (!isFinishInit) {
			isFinishInit = true;
			initData ();
		}
		//==========title============
		GUI.color = Color.yellow;
		GUILayout.Label ("coolape酷猿平台发布工具, 点击【Refresh】刷新加载数据\n如有问题请联系QQ:181752725");
		GUI.color = Color.white;
		GUILayout.BeginHorizontal ();
		{
			if (isNewChannel) {
				GUI.color = Color.yellow;
			} else {
				GUI.color = Color.white;
			}
			if (GUILayout.Button ("Channels(渠道)")) {
				refreshData ();
				isNewChannel = true;
				isCfgChannel = false;
			}
			if (isCfgChannel) {
				GUI.color = Color.yellow;
			} else {
				GUI.color = Color.white;
			}
			if (GUILayout.Button ("Config Channel(配置)")) {
				refreshData ();
				isCfgChannel = true;
				isNewChannel = false;
			}
			GUI.color = Color.white;
			if (GUILayout.Button ("Refresh")) {
				refreshData ();
			}
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.Space (5);

		
		//配置渠道
		if (isCfgChannel) {
			scrollPos = EditorGUILayout.BeginScrollView (scrollPos);
			{
				showCfgChannel ();
			}
			EditorGUILayout.EndScrollView();
			return;
		}

		GUI.color = Color.white;
		GUILayout.BeginHorizontal ();
		{
			//--------------------left------------------------------------
			scrollPos = EditorGUILayout.BeginScrollView (scrollPos, GUILayout.Width (245));
			{
				
				CLEditorTools.BeginContents();
				{
				//channel list
				GUI.color = Color.white;
				if (channelEnum != null) {
					channelCount = channelEnum.Count;
					for (int i = 0; i < channelCount; i++) {
						if (i == currChlIndex) {
							GUI.color = Color.yellow;
						} else {
							GUI.color = Color.white;
						}
						if (GUILayout.Button (channelEnum [i].ToString () + " (" + channelAliasEnum [i] + ")", GUILayout.Width (225))) {
							currChlName = channelEnum [i].ToString ();
							isComfireDelete = false;
							isShowHelpBox = false;
							isShowIcons = false;
							currChlIndex = i;
							getChlData (currChlName);
						}
					}
				}
				}
				CLEditorTools.EndContents();
			}
			EditorGUILayout.EndScrollView ();

			//========right========
			GUI.color = Color.white;
			GUILayout.BeginVertical ();
			{
				if (currChlIndex >= 0 && currChlIndex < channelEnum.Count) {
					GUILayout.Space (5);
					GUILayout.BeginHorizontal ();
					{
						if (!isComfireDelete && !isShowHelpBox) {
							GUI.color = Color.green;
							if (GUILayout.Button ("Save")) {
								saveChlBuildSetting ();
							}
							GUI.color = Color.green;
							if (GUILayout.Button ("Chg4Edit")) {
								chgChl4Edit ();
							}
							GUI.color = Color.green;
							if (GUILayout.Button ("Apply")) {
								applySetting ();
							}
							GUI.color = Color.green;
							if (GUILayout.Button ("Apply&Build")) {
								showMsgBox (currChlName + ":确认各参数是否正确!", MessageType.Warning, applyAndBuild);
							}
							GUI.color = Color.red;
							if (GUILayout.Button ("Clean")) {
								isComfireDelete = true;
							}
						} else if (isComfireDelete) {
							GUI.color = Color.white;
							EditorGUILayout.HelpBox ("确定要清除所选的渠道的配置信息？", MessageType.Warning);
							GUI.color = Color.green;
							if (GUILayout.Button ("Cancel")) {
								isComfireDelete = false;
							}
							GUI.color = Color.red;
							if (GUILayout.Button ("Clean Now")) {
								isComfireDelete = false;
								cleanChlSetting (currChlName);
							}
						} else if (isShowHelpBox) {
							GUI.color = Color.white;
							EditorGUILayout.HelpBox (msgBoxMsg, msgBoxType);
							GUI.color = Color.green;
							if (GUILayout.Button ("Okey")) {
								isShowHelpBox = false;
								if (onClickCallbak != null) {
									onClickCallbak ();
								}
							}
							GUI.color = Color.red;
							if (GUILayout.Button ("Cancel")) {
								isShowHelpBox = false;
								onClickCallbak = null;
							}
							GUI.color = Color.white;
						}
					}
					GUILayout.EndHorizontal ();
					GUI.color = Color.white;
				}
				GUILayout.Space (5);

				scrollPos2 = EditorGUILayout.BeginScrollView (scrollPos2);
				{
					if (currChlIndex >= 0) {
						CLEditorTools.BeginContents();
						{
							channelCell (currChlName, false);
							GUI.backgroundColor = Color.white;
						}
						CLEditorTools.EndContents();
					}
				}
				EditorGUILayout.EndScrollView ();
			}
			GUILayout.EndVertical ();
		}
		GUILayout.EndHorizontal ();
	}

	void showCfgChannel ()
	{
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Version Config File", GUILayout.Width (125));
			mCfgFile = EditorGUILayout.ObjectField (mCfgFile, typeof(UnityEngine.Object), GUILayout.Width (125));
			GUI.color = Color.yellow;
			if (GUILayout.Button ("Infor", GUILayout.Width (60f))) {
				isShowCfgFileDesc = !isShowCfgFileDesc;
			}
			GUI.color = Color.white;
		}
		GUILayout.EndHorizontal ();
		if (isShowCfgFileDesc) {
			GUI.color = Color.white;
			EditorGUILayout.HelpBox (
				"在些配置工程的版本信息代码，目前只支持c#代码，" +
				"且代码中只能以如下方式定义版本信息：\n" +
				"public static string version = \"0.91\"; \n" +
				"public static int versionCode = 2;"
				, MessageType.Info);
		}
		GUILayout.BeginHorizontal ();
		{
			GUI.color = Color.white;
			GUILayout.Label ("ID", GUILayout.Width (125));
			GUILayout.Label ("Symbols", GUILayout.Width (125));
			GUILayout.Label ("Alias", GUILayout.Width (125));
			GUI.color = Color.yellow;
			if (GUILayout.Button ("Infor", GUILayout.Width (60f))) {
				isShowCfgChlDesc = !isShowCfgChlDesc;
			}
		}
		GUILayout.EndHorizontal ();
		
		if (isShowCfgChlDesc) {
			GUI.color = Color.white;
			EditorGUILayout.HelpBox (
				"以下为渠道定义。注意当定义好渠道后，" +
				"需要在对应的渠道代码中加上宏的预编译判断，" +
				"例如小米渠道=“mi”，宏为：“CHL_MI”", 
				MessageType.Info);
		}
		
		GUI.color = Color.white;
		if (channelEnum != null) {
			enumCount = channelEnum.Count;
			for (int i = 0; i < enumCount; i++) {
				GUILayout.BeginHorizontal ();
				{
					channelEnum [i] = GUILayout.TextField (channelEnum [i].ToString (), GUILayout.Width (125));
					string symbols = "CHL_" + channelEnum [i].ToString ().ToUpper ();
					GUILayout.TextField (symbols, GUILayout.Width (125));
					if (i >= channelAliasEnum.Count) {
						channelAliasEnum.Add ("");
					}
					channelAliasEnum [i] = GUILayout.TextField (channelAliasEnum [i] == null ? "" : channelAliasEnum [i].ToString (), GUILayout.Width (125));
					
					if (GUILayout.Button ("Modify", GUILayout.Width (60f))) {
						channelData ["channelEnum"] = channelEnum;
						channelData ["channelAliasEnum"] = channelAliasEnum;
						//							saveData ();
						return;
					}
					GUI.color = Color.red;
					if (GUILayout.Button ("Delete", GUILayout.Width (60f))) {
						channelEnum.RemoveAt (i);
						channelAliasEnum.RemoveAt (i);
						channelData ["channelEnum"] = channelEnum;
						channelData ["channelAliasEnum"] = channelAliasEnum;
						//							saveData ();
						return;
					}
					GUI.color = Color.white;
				}
				GUILayout.EndHorizontal ();
			}
		}
		GUILayout.BeginHorizontal ();
		{
			newChlName = GUILayout.TextField (newChlName, GUILayout.Width (125));
			string symbols = "";
			if (!string.IsNullOrEmpty (newChlName)) {
				symbols = "CHL_" + newChlName.ToUpper ();
			}
			GUILayout.TextField (symbols, GUILayout.Width (125));
			newChlAlias = GUILayout.TextField (newChlAlias, GUILayout.Width (125));
			
			GUI.color = Color.yellow;
			if (GUILayout.Button ("Add", GUILayout.Width (60f))) {
				if (!string.IsNullOrEmpty (newChlName)) {
					channelEnum.Add (newChlName);
					channelAliasEnum.Add (newChlAlias);
					channelData ["channelEnum"] = channelEnum;
					channelData ["channelAliasEnum"] = channelAliasEnum;
					//						saveData ();
					newChlName = "";
				} else {
					Debug.LogWarning ("Please input the channel name!");
				}
			}
			
			GUI.color = Color.green;
			if (GUILayout.Button ("Save", GUILayout.Width (60f))) {
				saveData ();
			}
			GUI.color = Color.white;
		}
		GUILayout.EndHorizontal ();
	}

	string msgBoxMsg = "";
	MessageType msgBoxType = MessageType.None;
	OnClickCallback onClickCallbak;

	void showMsgBox (string msg, MessageType type, OnClickCallback callbak = null)
	{
		msgBoxMsg = msg;
		msgBoxType = type;
		onClickCallbak = callbak;
		isShowHelpBox = true;
	}
	/// <summary>
	/// Inits the data.
	/// 初始化数据
	/// </summary>
	void initData ()
	{
		if (FileEx.FileExists (configFile)) {
			byte[] buffer = FileEx.ReadAllBytes (configFile);
			if (buffer.Length <= 0) {
				return;
			}
			MemoryStream ms = new MemoryStream ();
			ms.Write (buffer, 0, buffer.Length);
			ms.Position = 0;
			object obj = B2InputStream.readObject (ms);
			if (obj != null) {
				channelData = (Hashtable)obj;
				channelEnum = (ArrayList)(channelData ["channelEnum"]);
				channelEnum = channelEnum == null ? new ArrayList () : channelEnum;
				channelAliasEnum = (ArrayList)(channelData ["channelAliasEnum"]);
				channelAliasEnum = channelAliasEnum == null ? new ArrayList () : channelAliasEnum;
				channelMap = (Hashtable)(channelData ["channelMap"]);
				channelMap = channelMap == null ? new Hashtable () : channelMap;
				cfgFilePath = MapEx.getString (channelData, "cfgFile");
			}
		} else {
			channelMap = new Hashtable ();
			channelEnum = new ArrayList ();
			cfgFilePath = "";
		}
	}

	void refreshData ()
	{
		isFinishInit = false;
		isFinishInit = false;
		isShowIcons = false;
		isShowCfgChlDesc = false;
		currChlIndex = -1;
		isComfireDelete = false;
		isShowHelpBox = false;
		scrollPos = Vector2.zero;
		scrollPos2 = Vector2.zero;
	}

	void saveData ()
	{
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeObject (ms, channelData);
		FileEx.WriteAllBytes (configFile, ms.ToArray ());
	}

	/// <summary>
	/// Channels the cell.
	/// 渠道单元
	/// </summary>
	void channelCell (string chlName, bool canEdit)
	{
		if (currChlData == null) {
			return;
		}
		int width = 150;
		GUI.color = Color.white;
		//Product Name
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Product Name", GUILayout.Width (width));
			currChlData.mProductName = GUILayout.TextField (currChlData.mProductName);
		}
		GUILayout.EndHorizontal ();
		//Platform ios or android
		GUILayout.BeginHorizontal ();
		{
			currChlData.mPlatform = (ChlPlatform)EditorGUILayout.EnumPopup ("Select Platform", currChlData.mPlatform);
			if (currChlData.mPlatform == ChlPlatform.ios) {
				currChlData.mCreateEclipseProject = false;
			}
		}
		GUILayout.EndHorizontal ();
		//Default Icon

		GUILayout.BeginHorizontal ();
		{
			if (GUILayout.Button ("Icons")) {
				isShowIcons = !isShowIcons;
			}
		}
		GUILayout.EndHorizontal ();

		if (isShowIcons) {
			if (currChlData.mPlatform == ChlPlatform.android) {
				for (int i =0; i < AndroidIconsName.Length; i++) {
					currChlData.mDefaultIcon [AndroidIconsName [i]] = 
						EditorGUILayout.ObjectField (AndroidIconsName [i], 
						(Texture2D)(currChlData.mDefaultIcon [AndroidIconsName [i]]),
						typeof(Texture2D), false) as Texture2D;
				}
			} else if (currChlData.mPlatform == ChlPlatform.ios) {
				for (int i =0; i < IosIconsName.Length; i++) {
					currChlData.mDefaultIcon [IosIconsName [i]] = 
							EditorGUILayout.ObjectField (IosIconsName [i], 
							(Texture2D)(currChlData.mDefaultIcon [IosIconsName [i]]),
							typeof(Texture2D), false) as Texture2D;
				}
			}
		}
		//Splash Image
		GUILayout.BeginHorizontal ();
		{
			currChlData.mSplashImage = EditorGUILayout.ObjectField ("Splash Image", 
								currChlData.mSplashImage,
								typeof(Texture2D), false) as Texture2D;
		}
		GUILayout.EndHorizontal ();
		//Bundle Indentifier
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Bundle Indentifier", GUILayout.Width (width));
			currChlData.mBundleIndentifier = GUILayout.TextField (currChlData.mBundleIndentifier);
		}
		GUILayout.EndHorizontal ();
		//Bundle Version
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Bundle Version", GUILayout.Width (width));
			currChlData.mBundleVersion = GUILayout.TextField (currChlData.mBundleVersion);
		}
		GUILayout.EndHorizontal ();
		//Bundle Version Code
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Bundle Version Code", GUILayout.Width (width));
			currChlData.mBundleVersionCode = EditorGUILayout.IntField (currChlData.mBundleVersionCode);
		}
		GUILayout.EndHorizontal ();
		//Scripting Define Symbols
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Scripting Define Symbols", GUILayout.Width (width));
			GUILayout.Label (currChlData.mScriptingDefineSymbols);
		}
		GUILayout.EndHorizontal ();
		// Create Eclipse Project
		if (currChlData.mPlatform == ChlPlatform.android) {
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Create Eclipse Project", GUILayout.Width (width));
				currChlData.mCreateEclipseProject = GUILayout.Toggle (currChlData.mCreateEclipseProject, "");
			}
			GUILayout.EndHorizontal ();
		}
		
		//Build Location
		if (currChlData.mPlatform == ChlPlatform.ios ||
			currChlData.mCreateEclipseProject) {
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Build Location", GUILayout.Width (width));
				currChlData.mBuildLocation = GUILayout.TextField (currChlData.mBuildLocation);
			}
			GUILayout.EndHorizontal ();
			GUI.color = Color.yellow;
			GUILayout.Label ("***Build Location是相对于工程目录的路径，但是不包括“Assets/”目录!");
			GUI.color = Color.white;
		}
		GUI.color = Color.white;
		//copy files
		GUILayout.BeginHorizontal ();
		{
			GUILayout.Label ("Folder Copy to Plugin", GUILayout.Width (width));
			currChlData.mCopyDir = EditorGUILayout.ObjectField (currChlData.mCopyDir, typeof(UnityEngine.Object));
			currChlData.mUnZip = GUILayout.Toggle (currChlData.mUnZip, "And UnZip the Zip files");
		}
		GUILayout.EndHorizontal ();
		
		GUI.color = Color.white;
		//publishing settings
		if (currChlData.mPlatform == ChlPlatform.android) {
			GUILayout.Label ("Publishing settings", GUILayout.Width (width));
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Use Keystore", GUILayout.Width (width));
				currChlData.mLicenseVerification = GUILayout.Toggle (currChlData.mLicenseVerification, "");
			}
			GUILayout.EndHorizontal ();
			
			if (currChlData.mLicenseVerification) {
				GUILayout.BeginHorizontal ();
				{
					GUILayout.Label ("Keystore", GUILayout.Width (width));
					currChlData.mKeystoreName = EditorGUILayout.ObjectField (currChlData.mKeystoreName, typeof(UnityEngine.Object));
				}
				GUILayout.EndHorizontal ();
				
				GUILayout.BeginHorizontal ();
				{
					GUILayout.Label ("Keystore Pass", GUILayout.Width (width));
					currChlData.mKeystorePass = EditorGUILayout.TextField (currChlData.mKeystorePass);
				}
				GUILayout.EndHorizontal ();
				
				GUILayout.BeginHorizontal ();
				{
					GUILayout.Label ("Keyalias Name", GUILayout.Width (width));
					currChlData.mKeyaliasName = EditorGUILayout.TextField (currChlData.mKeyaliasName);
				}
				GUILayout.EndHorizontal ();
				
				GUILayout.BeginHorizontal ();
				{
					GUILayout.Label ("Keyalias Pass", GUILayout.Width (width));
					currChlData.mKeyaliasPass = EditorGUILayout.TextField (currChlData.mKeyaliasPass);
				}
				GUILayout.EndHorizontal ();
			}
		}
		//Be careful
		GUILayout.BeginHorizontal ();
		{
			GUI.color = Color.red;
			GUILayout.Label ("Special Instructions", GUILayout.Width (width));
			GUI.color = Color.white;
			GUI.contentColor = Color.yellow;
			currChlData.mAlertDesc = GUILayout.TextArea (currChlData.mAlertDesc, GUILayout.Height (50f));
			GUI.contentColor = Color.white;
		}
		GUILayout.EndHorizontal ();
	}
	
	void getChlData (string chlName)
	{
		currChlData = new ChlData ();
		if (channelMap == null) {
			return;
		}
		object tmpData = channelMap [chlName];
		currChlData = tmpData == null ? new ChlData () : ChlData.parse ((Hashtable)tmpData);
		currChlData.mChlName = chlName;
	}
	
	/// <summary>
	/// Saves the chl build setting.
	/// 保存渠道打包设置
	/// </summary>
	void saveChlBuildSetting ()
	{
		if (currChlData == null) {
			return;
		}
		currChlData.refreshData ();
		if (channelMap == null) {
			channelMap = new Hashtable ();
		}
		channelMap [currChlName] = currChlData.toMap ();
		channelData ["channelMap"] = channelMap;
		channelData ["channelAliasEnum"] = channelAliasEnum;
		saveData ();
	}
	
	/// <summary>
	/// Cleans the chl setting.
	/// 清空渠道打包设置
	/// </summary>
	/// <param name='chlName'>
	/// Chl name.
	/// </param>
	void cleanChlSetting (string chlName)
	{
		channelMap [chlName] = null;
		channelData ["channelMap"] = channelMap;
		channelData ["channelAliasEnum"] = channelAliasEnum;
		saveData ();
		getChlData (chlName);
	}

	void chgChl4Edit ()
	{
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Android, currChlData.mScriptingDefineSymbols);
#if UNITY_5
        PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.iOS, currChlData.mScriptingDefineSymbols);
#else
        PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS, currChlData.mScriptingDefineSymbols);
#endif
		
		PlayerSettings.SetScriptingDefineSymbolsForGroup (BuildTargetGroup.Standalone, currChlData.mScriptingDefineSymbols);
	}
	/// <summary>
	/// Applies the setting.
	/// 应用渠道设置
	/// </summary>
	void applySetting ()
	{
		if (currChlData == null) {
			return;
		}
		PlayerSettings.productName = currChlData.mProductName;
		/*
		 * Most platforms support viewing icons in multiple sizes so Unity lets
		 * you specify multiple icon textures for each platform. The list will only 
		 * be assigned if it has the same length as the list of icon sizes returned
		 * by GetIconSizesForTargetGroup and if the specified platform is supported in this editor.
		 */
		List<Texture2D> icons = new List<Texture2D> ();
//		int[] iconSize = PlayerSettings.GetIconSizesForTargetGroup(currChlData.buildTargetGroup);
//		Debug.Log("iconSize==" + iconSize.Length);
//		for (int i = 0; i< iconSize.Length; i++) {
		//		}
		
		string[] iconNames = null;
		if (currChlData.buildTarget == BuildTarget.Android) {
			iconNames = AndroidIconsName;
#if UNITY_5
        } else if (currChlData.buildTarget == BuildTarget.iOS) {
#else
        }else if (currChlData.buildTarget == BuildTarget.iOS){
#endif
		
			iconNames = IosIconsName;
		}
		for (int i =0; i < iconNames.Length; i++) {
			icons.Add ((Texture2D)(currChlData.mDefaultIcon [iconNames [i]]));
		}
		PlayerSettings.SetIconsForTargetGroup (currChlData.buildTargetGroup, icons.ToArray ());
		//Splash imgae
		PlayerSettings.resolutionDialogBanner = currChlData.mSplashImage;
		//indentifier & version
		PlayerSettings.applicationIdentifier = currChlData.mBundleIndentifier;
		PlayerSettings.bundleVersion = currChlData.mBundleVersion;
		modifyCfgFile ();
		if (currChlData.buildTargetGroup == BuildTargetGroup.Android) {
			PlayerSettings.Android.bundleVersionCode = currChlData.mBundleVersionCode;
		}
		string symbols = PlayerSettings.GetScriptingDefineSymbolsForGroup (currChlData.buildTargetGroup);
		if (!string.IsNullOrEmpty (symbols)) {
			string[] symbolsList = symbols.Split (';');
			for(int i =0; i < symbolsList.Length; i++) {
				if(symbolsList[i].StartsWith("CHL_")) {
					symbolsList[i] = "";
				}
			}
			symbols = "";
			for(int i =0; i < symbolsList.Length; i++) {
				if(!string.IsNullOrEmpty(symbolsList[i])) {
					symbols += symbolsList[i] + ";";
				}
			}
		}
		symbols += (";" + currChlData.mScriptingDefineSymbols);
		PlayerSettings.SetScriptingDefineSymbolsForGroup (currChlData.buildTargetGroup, symbols);
		// copy files
		copyFilesToPlugin ();
		//
		if (currChlData.mPlatform == ChlPlatform.android) {
//			PlayerSettings.Android.licenseVerification = currChlData.mLicenseVerification;
//			PlayerSettings.Android
			if (currChlData.mLicenseVerification) {
				PlayerSettings.Android.keystoreName = currChlData.mKeystoreNamePath;
				PlayerSettings.Android.keystorePass = currChlData.mKeystorePass;
				PlayerSettings.Android.keyaliasName = currChlData.mKeyaliasName;
				PlayerSettings.Android.keyaliasPass = currChlData.mKeyaliasPass;
			} else {
				PlayerSettings.Android.keystoreName = "";
				PlayerSettings.Android.keystorePass = "";
				PlayerSettings.Android.keyaliasName = "";
				PlayerSettings.Android.keyaliasPass = "";
			}
		}
	}
	
	/// <summary>
	/// Applies the and build.
	/// 设置并编译
	/// </summary>
	void applyAndBuild ()
	{
		if (currChlData == null) {
			return;
		}
		applySetting ();
		
		//如果平台不一样，先切到
		if (EditorUserBuildSettings.activeBuildTarget != currChlData.buildTarget) {
//			EditorUserBuildSettings.SwitchActiveBuildTarget (currChlData.buildTarget);
			EditorUtility.DisplayDialog ("Alert", "The active build target is not the same with current build target!", null);
			return;
		}
		
		if (currChlData.mCreateEclipseProject) {
			Debug.LogWarning ("The channel need Create Eclipse Project!!");
			showMsgBox ("The channel need Create Eclipse Project!!", MessageType.Warning);
			return;
		}
		
		string[] levels = null;
		if (EditorBuildSettings.scenes.Length > 0) {
			levels = new string[EditorBuildSettings.scenes.Length];
			for (int i = 0; i < EditorBuildSettings.scenes.Length; i++) {
				levels [i] = EditorBuildSettings.scenes [i].path;
			}
		} else {
			levels = new string[1];
			levels [0] = EditorApplication.currentScene;
		}
		
		string locationName = currChlData.mPlatform.ToString () + "_" + currChlData.mBundleIndentifier + "_v" + currChlData.mBundleVersion + "_" + DateEx.format (DateEx.fmt_yyyy_MM_dd) + "_" + DateEx.nowMS;
		if (currChlData.mPlatform == ChlPlatform.android) {
			if (!currChlData.mCreateEclipseProject) {
				locationName += ".apk";
			} else {
				locationName = dataPath () + currChlData.mBuildLocation;
			}
#if UNITY_5
        } else if (currChlData.buildTarget == BuildTarget.iOS) {
#else
        }
        else if (currChlData.buildTarget == BuildTarget.iOS)
        {
#endif
//			EditorUserBuildSettings.appendProject = true;
			locationName = dataPath () + currChlData.mBuildLocation;
		}
		bool needApend = true;
		if (!string.IsNullOrEmpty (currChlData.mBuildLocation)) {
			if (!Directory.Exists (locationName)) {
				needApend = false;
				Directory.CreateDirectory (locationName);
			}
		}
		
		Debug.Log ("Publish path:" + locationName);
#if UNITY_5
                if (currChlData.buildTarget == BuildTarget.iOS && needApend) {
#else
        if (currChlData.buildTarget == BuildTarget.iOS && needApend) {
#endif
			BuildPipeline.BuildPlayer (levels, locationName, currChlData.buildTarget, BuildOptions.AcceptExternalModificationsToPlayer);
		} else {
			BuildPipeline.BuildPlayer (levels, locationName, currChlData.buildTarget, BuildOptions.None);
		}
	}

	void modifyCfgFile ()
	{
		if (string.IsNullOrEmpty (cfgFilePath)) {
			return;
		}
		string[] buffer = File.ReadAllLines (dataPath () + cfgFilePath);
		string line = "";
		bool finishModifyVer = false;
		bool finishModifyVerCoder = false;
		for (int i = 0; i < buffer.Length; i++) {
			line = buffer [i];
			if (line.IndexOf ("public static string version") >= 0) {
				buffer [i] = "    public static string version = \"" + currChlData.mBundleVersion + "\";";
				finishModifyVer = true;
			} else if (line.IndexOf ("public static int versionCode") >= 0) {
				buffer [i] = "    public static int versionCode = " + currChlData.mBundleVersionCode + ";";
				finishModifyVerCoder = true;
			}
			if (finishModifyVer && finishModifyVerCoder) {
				break;
			}
		}
		File.WriteAllLines (dataPath () + cfgFilePath, buffer);
	}
	
	/// <summary>
	/// Copies the files to plugin.
	/// 把文件拷贝到Plugin目录
	/// </summary>
	void copyFilesToPlugin ()
	{
		if (currChlData.mCopyDir == null) {
			return;
		}
		string toPath = "";
		if (currChlData.mPlatform == ChlPlatform.android) {
			toPath = "Assets/Plugins/Android/";
		} else if (currChlData.mPlatform == ChlPlatform.ios) {
			toPath = "Assets/Plugins/IOS/";
		}
		Debug.Log (dataPath ());
		doCopyFiles (dataPath () + currChlData.mCopyDirPath, dataPath () + toPath);
	}
	
	/// <summary>
	/// Datas the path.
	/// 取得工程路径，不带"/Assets/"
	/// </summary>
	/// <returns>
	/// The path.
	/// </returns>
	string dataPath ()
	{
		string tmpPath = Application.dataPath + "/";
		return tmpPath.Replace ("/Assets/", "/");
	}

	void doCopyFiles (string fromPath, string toPath)
	{
		string[] fileEntries = Directory.GetFiles (fromPath);
		string extension = "";
		string fileName = "";
		foreach (string filePath in fileEntries) {
			extension = Path.GetExtension (filePath);
			if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			fileName = Path.GetFileName (filePath);
			if (currChlData.mUnZip && extension.ToLower () == ".zip") {
				ZipEx.UnZip (filePath, toPath, 4096);
			} else {
				if (File.Exists (toPath + fileName)) {
					File.Delete (toPath + fileName);
				}
				File.Copy (filePath, toPath + fileName);
			}
		}
		string[] dirEntries = Directory.GetDirectories (fromPath);
		string dirName = "";
		string newToPath = "";
		foreach (string dir in dirEntries) {
			dirName = Path.GetFileName (dir);
			newToPath = toPath + dirName + "/";
			if (!Directory.Exists (newToPath)) {
				Directory.CreateDirectory (newToPath);
			}
			doCopyFiles (dir, newToPath);
		}
	}
}


/// <summary>
/// Chl platform.
/// 平台
/// </summary>
public enum ChlPlatform
{
	android,
	ios
}

/// <summary>
/// Chl data.
/// 渠道数据
/// </summary>
public class ChlData
{
	public string mChlName = "";
	public string mProductName = "";
	public ChlPlatform  mPlatform = ChlPlatform.android;

	public BuildTargetGroup buildTargetGroup {
		get {
			switch (mPlatform) {
			case ChlPlatform.android:
				return BuildTargetGroup.Android;
			case ChlPlatform.ios:
#if UNITY_5
                return BuildTargetGroup.iOS;
#else
                return BuildTargetGroup.iOS;
#endif
			}
			return BuildTargetGroup.Android;
		}
	}
	
	public BuildTarget buildTarget {
		get {
			switch (mPlatform) {
			case ChlPlatform.android:
				return BuildTarget.Android;
			case ChlPlatform.ios:
#if UNITY_5
                return BuildTarget.iOS;
#else
                return BuildTarget.iOS;
#endif
			}
			return BuildTarget.Android;
		}
	}
	
//	public BuildTarget  

	Hashtable _DefaultIcon; //Texture2D
	Texture2D _SplashImage;

	public Hashtable mDefaultIcon {
		get {
			if (_DefaultIcon == null && mDefaultIconPath != null) {
				_DefaultIcon = new Hashtable ();
				foreach (DictionaryEntry cell in mDefaultIconPath) {
					string iconPath = cell.Value.ToString ();
					_DefaultIcon [cell.Key] = (Texture2D)(AssetDatabase.LoadAssetAtPath ("Assets/" + iconPath, typeof(Texture2D)));
				}
			}
			if (_DefaultIcon == null) {
				_DefaultIcon = new Hashtable ();
			}
			return _DefaultIcon;
		}
	}
		
	public Texture2D mSplashImage {
		get {
			if (_SplashImage == null && !string.IsNullOrEmpty (mSplashImagePath)) {
				_SplashImage = (Texture2D)(AssetDatabase.LoadAssetAtPath ("Assets/" + mSplashImagePath, typeof(Texture2D)));
					
			}
			return _SplashImage;
		}
		set {
			_SplashImage = value;
			if (value == null) {
				mSplashImagePath = "";
			}
		}
	}

	public Hashtable mDefaultIconPath = new Hashtable ();
	public string mSplashImagePath;
	public string mBundleIndentifier = "";
	public string mBundleVersion = "";
	public int mBundleVersionCode;
	public bool mCreateEclipseProject = false;
	public string mBuildLocation = "";

	public string mScriptingDefineSymbols {
		get {
			return "CHL_" + mChlName.ToUpper ();
		}
	}

	public string mAlertDesc = "";
	public string mCopyDirPath = "";
	UnityEngine.Object _CopyDir;

	public UnityEngine.Object mCopyDir {
		get {
			if (_CopyDir == null) {
				if (!string.IsNullOrEmpty (mCopyDirPath)) {
					_CopyDir = AssetDatabase.LoadAssetAtPath (
						mCopyDirPath, 
						typeof(UnityEngine.Object));
				}
			}
			return _CopyDir;
		}
		set {
			_CopyDir = value;
			if (value == null) {
				mCopyDirPath = ""; 
			} else {
				mCopyDirPath = AssetDatabase.GetAssetPath (_CopyDir.GetInstanceID ());
			}
		}
	}
	
	public bool mUnZip;
	public bool mLicenseVerification;
	public string mKeystoreNamePath = "";
	UnityEngine.Object _KeystoreName;

	public UnityEngine.Object mKeystoreName {
		get {
			if (_KeystoreName == null) {
				if (!string.IsNullOrEmpty (mKeystoreNamePath)) {
					_KeystoreName = AssetDatabase.LoadAssetAtPath (
						mKeystoreNamePath, 
						typeof(UnityEngine.Object));
				}
			}
			return _KeystoreName;
		}
		set {
			_KeystoreName = value;
			if (value == null) {
				mKeystoreNamePath = ""; 
			} else {
				mKeystoreNamePath = AssetDatabase.GetAssetPath (_KeystoreName.GetInstanceID ());
			}
		}
	}

	public string mKeystorePass;
	public string mKeyaliasName;
	public string mKeyaliasPass;
	
	public Hashtable toMap ()
	{
		Hashtable r = new Hashtable ();
		r ["mChlNmae"] = mChlName;
		r ["mProductName"] = mProductName;
		r ["mPlatform"] = mPlatform.ToString ();
		r ["mDefaultIconPath"] = mDefaultIconPath;
		r ["mSplashImagePath"] = mSplashImagePath;
		r ["mBundleIndentifier"] = mBundleIndentifier;
		r ["mBundleVersion"] = mBundleVersion;
		r ["mBundleVersionCode"] = mBundleVersionCode;
		r ["mCreateEclipseProject"] = mCreateEclipseProject;
		r ["mBuildLocation"] = mBuildLocation;
		r ["mAlertDesc"] = mAlertDesc;
		r ["mCopyDir"] = mCopyDirPath;
		r ["mUnZip"] = mUnZip;
		
		r ["mLicenseVerification"] = mLicenseVerification;
		r ["mKeystoreNamePath"] = mKeystoreNamePath;
		r ["mKeystorePass"] = mKeystorePass;
		r ["mKeyaliasName"] = mKeyaliasName;
		r ["mKeyaliasPass"] = mKeyaliasPass;
		return r;
	}
		
	public void refreshData ()
	{
		if (_DefaultIcon != null) {
			foreach (DictionaryEntry cell in _DefaultIcon) {
				Texture2D icon = cell.Value == null ? null : (Texture2D)(cell.Value);
				if (icon == null)
					continue;
				string tmpPath = AssetDatabase.GetAssetPath (icon.GetInstanceID ());
				int startPos = 0;
				startPos = tmpPath.IndexOf ("Assets/");
				startPos += 7;
				tmpPath = tmpPath.Substring (startPos, tmpPath.Length - startPos);
				if (mDefaultIconPath == null) {
					mDefaultIconPath = new Hashtable ();
				}
				mDefaultIconPath [cell.Key] = tmpPath;
			}
		}
		if (_SplashImage != null) {
			string tmpPath = AssetDatabase.GetAssetPath (_SplashImage.GetInstanceID ());
			int startPos = 0;
			startPos = tmpPath.IndexOf ("Assets/");
			startPos += 7;
			tmpPath = tmpPath.Substring (startPos, tmpPath.Length - startPos);
			mSplashImagePath = tmpPath;
		}
	}
		
	public static ChlData parse (Hashtable map)
	{
		if (map == null) {
			return null;
		}
		ChlData r = new ChlData ();
		r.mChlName = MapEx.getString (map, "mChlNmae");
		r.mProductName = MapEx.getString (map, "mProductName");
		r.mDefaultIconPath = MapEx.getMap (map, "mDefaultIconPath");
		r.mSplashImagePath = MapEx.getString (map, "mSplashImagePath");
		r.mBundleIndentifier = MapEx.getString (map, "mBundleIndentifier");
		r.mBundleVersion = MapEx.getString (map, "mBundleVersion");
		r.mBundleVersionCode = MapEx.getInt (map, "mBundleVersionCode");
		string platform = MapEx.getString (map, "mPlatform");
		switch (platform) {
		case "android":
			r.mPlatform = ChlPlatform.android;
			break;
		case "ios":
			r.mPlatform = ChlPlatform.ios;
			break;
		}
		r.mCreateEclipseProject = MapEx.getBool (map, "mCreateEclipseProject");
		r.mBuildLocation = MapEx.getString (map, "mBuildLocation");
		r.mAlertDesc = MapEx.getString (map, "mAlertDesc");
		r.mAlertDesc = r.mAlertDesc == null ? "" : r.mAlertDesc;
		r.mCopyDirPath = MapEx.getString (map, "mCopyDir");
		r.mUnZip = MapEx.getBool (map, "mUnZip");
		r.mLicenseVerification = MapEx.getBool (map, "mLicenseVerification");
		r.mKeystoreNamePath = MapEx.getString (map, "mKeystoreNamePath");
		r.mKeystorePass = MapEx.getString (map, "mKeystorePass");
		r.mKeyaliasName = MapEx.getString (map, "mKeyaliasName");
		r.mKeyaliasPass = MapEx.getString (map, "mKeyaliasPass");
		return r;
	}
}
