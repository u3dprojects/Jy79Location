using UnityEngine;
using UnityEditor;
using System.Collections;
using Toolkit;
using System.IO;
using System.Collections.Generic;
using System;

public class CoolapeProject : EditorWindow
{
	string configFile = "Coolape/Editor/CoolapeProject.cfg";
	#if UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
	public const string ver4DevelopeMd5 = "Coolape/verControl/android/ver4DevelopeMd5.v";				// 开发中的版本文件
	public const string ver4Publish = "Coolape/verControl/android/ver4Publish.v";											//打包时的版本
	public const string ver4Upgrade = "Coolape/verControl/android/ver4Upgrade.v";											//每次更新时的版本
	public const string ver4UpgradeMd5 = "Coolape/verControl/android/ver4UpgradeMd5.v";					//每次更新时的版本
	#elif UNITY_IOS
	public const string ver4DevelopeMd5 = "Coolape/verControl/ios/ver4DevelopeMd5.v";				// 开发中的版本文件
	public const string ver4Publish = "Coolape/verControl/ios/ver4Publish.v";											//打包时的版本
	public const string ver4Upgrade = "Coolape/verControl/ios/ver4Upgrade.v";											//每次更新时的版本
	public const string ver4UpgradeMd5 = "Coolape/verControl/ios/ver4UpgradeMd5.v";					//每次更新时的版本
	#else
	public const string ver4DevelopeMd5 = "Coolape/verControl/android/ver4DevelopeMd5.v";				// 开发中的版本文件
	public const string ver4Publish = "Coolape/verControl/android/ver4Publish.v";											//打包时的版本
	public const string ver4Upgrade = "Coolape/verControl/android/ver4Upgrade.v";											//每次更新时的版本
	public const string ver4UpgradeMd5 = "Coolape/verControl/android/ver4UpgradeMd5.v";					//每次更新时的版本
	#endif
	public static ProjectData data = null;
	bool isFinishInit = false;
	string u3dfrom = "";
	string u3dto = "";
	string newProjName = "";
	List<string> cfgFiles = new List<string> ();
	Vector2 scrollPos = Vector2.zero;
	
	void OnGUI ()
	{
		if (SCfg.self == null) {
			GUI.color = Color.red;
			if (GUILayout.Button ("The scene is not ready, create it now?")) {
				createScene ();
			}
			GUI.color = Color.white;
			return;
		}
		if (!isFinishInit || data == null) {
			isFinishInit = true;
			initData ();
		}
		if (data == null) {
			return;
		}
		scrollPos = EditorGUILayout.BeginScrollView (scrollPos);
		GUILayout.BeginHorizontal ();
		{
			if (GUILayout.Button ("Refresh")) {
				initData ();
			}
			GUI.color = Color.yellow;
			if (GUILayout.Button ("Save")) {
				saveData ();
			}
			GUI.color = Color.white;
		}
		GUILayout.EndHorizontal ();
		
		GUILayout.Space (5);
		NGUIEditorTools.BeginContents ();
		{
			GUI.color = Color.yellow;
			GUILayout.Label ("Project init", GUILayout.Width (125));
			GUI.color = Color.white;
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Project Name:", GUILayout.Width (125));
				data.name = GUILayout.TextField (data.name, GUILayout.Width (300));
			}
			GUILayout.EndHorizontal ();
			if (GUILayout.Button ("Create Folders", GUILayout.Width (300))) {
				CreateFolders ();
			}
			
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("New Project Name:", GUILayout.Width (125));
				newProjName = GUILayout.TextField (newProjName, GUILayout.Width (200));
			}
			GUILayout.EndHorizontal ();
			
			if (GUILayout.Button ("Modify Project Name", GUILayout.Width (150))) {
				modifyProjectName ();
			}
		}
		NGUIEditorTools.EndContents ();
		
		//生成unity3d格式
		GUILayout.Space (5);
		NGUIEditorTools.BeginContents ();
		{
			GUI.color = Color.yellow;
			GUILayout.Label ("Create Cfg Data Files", GUILayout.Width (125));
			GUI.color = Color.white;
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Cfg data Folder", GUILayout.Width (125));
				data.cfgFolder = EditorGUILayout.ObjectField (data.cfgFolder, 
				                                              typeof(UnityEngine.Object), GUILayout.Width (125));
				
				//              if (GUILayout.Button("Refresh", GUILayout.Width(100))) {
				//                  refreshCfgFiles();
				//              }
			}
			GUILayout.EndHorizontal ();
			//          for (int i = 0; i < cfgFiles.Count; i++) {
			//              GUILayout.BeginHorizontal();
			//              {
			//                  GUI.color = Color.yellow;
			//                  if (GUILayout.Button("Create", GUILayout.Width(100))) {
			//                      string className = Path.GetFileNameWithoutExtension(cfgFiles [i]);
			//                      Debug.Log(className);
			//                      EditorUtility.DisplayDialog("success", "Create cfg data cuccess!\n" + createCfgBioData(className), "Okey");
			//                  }
			//                  GUI.color = Color.white;
			//                  GUILayout.Label(cfgFiles [i], GUILayout.Width(300));
			//              }
			//              GUILayout.EndHorizontal();
			//          }
		}
		NGUIEditorTools.EndContents ();
		
		GUI.color = Color.white;
		GUILayout.Space (5);
		NGUIEditorTools.BeginContents ();
		{
			GUI.color = Color.red;
			GUILayout.Label ("Refresh All AssetBundles", GUILayout.Width (155));
			
			if (GUILayout.Button ("One Key Refresh All AssetBundles", GUILayout.Width (300))) {
				if (EditorUtility.DisplayDialog ("Alert", "Really want to refresh all assetbundles!", "Okey", "cancel")) {
					refreshAllAssetbundles ();
				}
			}
			
			GUI.color = Color.yellow;
			if (GUILayout.Button ("PubshlishSetting\n(打包配置（每次打包前先执行一次）)", GUILayout.Width (300))) {
				if (EditorUtility.DisplayDialog ("Alert", "打包配置（每次打包前先执行一次）!", "Okey", "cancel")) {
					publishSetting ();
				}
			}
			
			if (GUILayout.Button ("Update & Publish All AssetBundles\n(每次更新执行)", GUILayout.Width (300))) {
				if (EditorUtility.DisplayDialog ("Alert", "Really want to Refresh & Publish all assetbundles!", "Okey", "cancel")) {
					if (EditorUtility.DisplayDialog ("Alert", "OKay, let me confirm again:)\n Really want to Refresh & Publish all assetbundles!", "Do it now!", "cancel")) {
						//						if (EditorUtility.DisplayDialog("Alert", refreshAllAssetbundles(true, true), "Do it now!", "cancel")) {
						//						GUIMsgBox.show ("", upgrade4Publish (), publishAllAssetbundle, null);
						upgrade4Publish ();
					}
				}
			}
		}
		NGUIEditorTools.EndContents ();
		GUI.color = Color.white;
		
		//		GUILayout.Space (5);
		//		NGUIEditorTools.BeginContents ();
		//		{
		//			GUI.color = Color.yellow;
		//			GUILayout.Label ("Create Version Files", GUILayout.Width (125));
		//            
		//			if (GUILayout.Button ("Create Version Files", GUILayout.Width (300))) {
		//				CreateVersionFiles ();
		//			}
		//		}
		//		NGUIEditorTools.EndContents ();
		
		GUI.color = Color.white;
		GUILayout.Space (5);
		NGUIEditorTools.BeginContents ();
		{
			GUILayout.Label ("Create StreamingAssets", GUILayout.Width (125));
			
			GUI.color = Color.red;
			GUILayout.Toggle (SCfg.self.isUseEncodedLua, "use encoded Lua ");
			
			GUI.color = Color.yellow;
			if (GUILayout.Button ("Create Priority StreamingAssets", GUILayout.Width (300))) {
				CreateStreamingAssets ();
			}
			if (GUILayout.Button ("Move Other to StreamingAssets", GUILayout.Width (300))) {
				MoveOtherToStreamingAssets ();
			}
			GUI.color = Color.white;
		}
		NGUIEditorTools.EndContents ();
		
		if (isShowAlert) {
			
		}
		
		EditorGUILayout.EndScrollView ();
	}
	
	bool isShowAlert = false;
	
	void CreateFolders ()
	{
		Directory.CreateDirectory (Application.dataPath + "/" + data.name);
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/Resources");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/Editor");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/upgradeResMedium");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/other");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/upgradeRes4Publish");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/upgradeRes4Ver");
		Directory.CreateDirectory (Application.dataPath + "/" + data.name + "/xRes");
		EditorUtility.DisplayDialog ("success", "Create Folders cuccess!", "Okey");
	}
	
	void modifyProjectName() {
		if(string.IsNullOrEmpty(newProjName)) {
			EditorUtility.DisplayDialog ("Alert", "The new project name is empty!", "Okey");
			return;
		}
		doModifyProjectName(Application.dataPath + "/" + data.name + "/upgradeResMedium/priority", data.name , newProjName);
		if(PathCfg.self != null) {
			PathCfg.self.basePath = newProjName;
			PathCfg.self.resetPath(newProjName);
		}
		
		modifyLuaPath (data.name, newProjName);
		
		if(Directory.Exists(Application.dataPath + "/" + data.name)) {
			Directory.Move(Application.dataPath + "/" + data.name, Application.dataPath + "/" + newProjName);
		}
		data.name = newProjName;
		data.cfgFolderStr = data.cfgFolderStr.Replace(data.name+"/", newProjName+"/");
		saveData();
	}
	
	public static void modifyLuaPath (string oldProjName, string newProjName) {
		CLBaseLua[] bcs = FindObjectsOfType (typeof(CLBaseLua)) as CLBaseLua[];
		for(int i=0; bcs != null && i < bcs.Length; i++) {
			Debug.LogError("=====" + bcs[i].luaPath);
			bcs[i].luaPath = bcs[i].luaPath.Replace(oldProjName+"/", newProjName+"/");
			EditorUtility.SetDirty(bcs[i]);
		}
	}
	
	public static void doModifyProjectName(string path, string oldProjName, string newProjName) {
		if(!Directory.Exists(path)) return;
		string[] fileEntries = Directory.GetFiles (path);
		string extension = "";
		string filePath = "";
		CLBaseLua baseLua = null;
		UnityEngine.Object obj = null;
		foreach (string fileName in fileEntries) {
			extension = Path.GetExtension (fileName);
			if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			obj = CLEditorTools.getObjectByPath(fileName.Replace(Application.dataPath+"/", ""));
			if(obj != null && obj is GameObject) {
				CLBaseLua[] baseLuaList = ((GameObject)obj).GetComponents<CLBaseLua>();
				for(int i =0; baseLuaList != null && i < baseLuaList.Length; i++) {
					baseLua = baseLuaList[i];
					if(baseLua != null && baseLua.luaPath != null) {
						Debug.Log(baseLua.name +"====" +  baseLua.luaPath);
						baseLua.luaPath = baseLua.luaPath.Replace(oldProjName+"/", newProjName+"/");
						EditorUtility.SetDirty(baseLua);
					}
				}
			}
		}
		
		string[] dirEntries = Directory.GetDirectories (path);
		foreach (string dir in dirEntries) {
			doModifyProjectName (dir, oldProjName, newProjName);
		}
	}
	
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
				data = ProjectData.parse ((Hashtable)obj);
			} else {
				data = new ProjectData ();
			}
		} else {
			data = new ProjectData ();
		}
	}
	
	void createScene ()
	{
		GameObject go = new GameObject ("Main");
		go.AddComponent<CLMain> ();
		go = new GameObject ("cfg");
		go.AddComponent<SCfg> ();
		go.AddComponent<PathCfg> ();
		go.AddComponent<CLVerManager> ();
		go.AddComponent<SAssetsManager> ();
	}
	
	void saveData ()
	{
		PathCfg.self.resetPath (data.name);
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeObject (ms, data.ToMap ());
		FileEx.WriteAllBytes (configFile, ms.ToArray ());
	}
	
	public class ProjectData
	{
		public string name = "";
		public string cfgFolderStr = "";
		UnityEngine.Object _cfgFolder;
		
		public UnityEngine.Object cfgFolder {
			get {
				if (_cfgFolder == null && !string.IsNullOrEmpty (cfgFolderStr)) {
					_cfgFolder = AssetDatabase.LoadAssetAtPath (cfgFolderStr, 
					                                            typeof(UnityEngine.Object));
				}
				return _cfgFolder;
			}
			set {
				_cfgFolder = value;
				if (_cfgFolder != null) {
					cfgFolderStr = AssetDatabase.GetAssetPath (_cfgFolder.GetInstanceID ());
				} else {
					cfgFolderStr = "";
				}
			}
		}
		
		public Hashtable ToMap ()
		{
			Hashtable r = new Hashtable ();
			r ["name"] = name;
			r ["cfgFolderStr"] = cfgFolderStr;
			return r;
		}
		
		public static ProjectData parse (Hashtable map)
		{
			if (map == null) {
				return null;
			}
			ProjectData r = new ProjectData ();
			r.name = MapEx.getString (map, "name");
			r.cfgFolderStr = MapEx.getString (map, "cfgFolderStr");
			return r;
		}
	}
	
	void CreateStreamingAssets ()
	{
		string publishVerPath = Application.dataPath + "/" + ver4Publish;
		if (!File.Exists (publishVerPath)) {
			GUI.color = Color.red;
			EditorUtility.DisplayDialog ("失败!!!!!!!!", "请先设置Publish[PubshlishSetting]!\n失败!失败!失败!失败!失败!失败!", "失败");
			GUI.color = Color.white;
			return;
		}
		Hashtable publishCfg = fileToMap (publishVerPath);
		string streamingAssetsPackge = Application.streamingAssetsPath + "/priority.r";
		string priorityPath = Application.streamingAssetsPath + "/" + data.name + "/upgradeRes/priority/";
		if (Directory.Exists (priorityPath)) {
			Directory.Delete (priorityPath, true);
		}
		copyPriorityFiles (publishCfg);
		
		//		string path="";// = AssetDatabase.GetAssetPath (Selection.activeObject);//Selection表示你鼠标选择激活的对象
		//		path = Application.dataPath + "/" + data.name + "/.upgradeRes/priority/";
		Hashtable outMap = new Hashtable ();
		//		doCreateStreamingAssets (path, ref outMap);
		//		
		//		if (!SCfg.self.isUseEncodedLua) {
		//			path = Application.dataPath + "/" + data.name + "/upgradeResMedium/priority/lua/";
		//			doCreateStreamingAssets (path, ref outMap);
		//		}
		doCreateStreamingAssets (publishCfg, ref outMap);
		
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeMap (ms, outMap);
		File.WriteAllBytes (streamingAssetsPackge, ms.ToArray ());
		EditorUtility.DisplayDialog ("success", "Create Priority StreamingAssets cuccess!", "Okey");
	}
	
	void copyPriorityFiles (Hashtable resMap)
	{
		
		string extension = "";
		string key = "";
		byte[] buffer = null;
		string filePath = "";
		foreach (DictionaryEntry cell in resMap) {
			filePath = Application.dataPath + "/" + cell.Key;
			if (filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/panel") ||
			    filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/cell") ||
			    filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/other")) {
				key = filter (filePath); 
				key = key.Replace ("/upgradeRes4Publish/", "/upgradeRes/");
				key = key.Replace ("/upgradeResMedium/", "/upgradeRes/");
				if (!SCfg.self.isUseEncodedLua 
				    && Path.GetExtension (filePath) == ".lua") {
					filePath = filePath.Replace ("/upgradeRes4Publish/", "/upgradeResMedium/");
				}
				string toPath = Application.streamingAssetsPath + "/" + key;
				Directory.CreateDirectory (Path.GetDirectoryName (toPath));
				File.Copy (filePath, toPath, true);
			}
		}
	}
	
	void doCreateStreamingAssets (Hashtable resMap, ref Hashtable map)
	{
		string extension = "";
		string key = "";
		byte[] buffer = null;
		string filePath = "";
		foreach (DictionaryEntry cell in resMap) {
			filePath = Application.dataPath + "/" + cell.Key;
			if (!filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/")) {
				continue;
			}
			
			if (filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/panel") ||
			    filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/cell") ||
			    filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/priority/ui/other")) {
				continue;
			}
			key = filter (filePath); 
			key = key.Replace ("/upgradeRes4Publish/", "/upgradeRes/");
			key = key.Replace ("/upgradeResMedium/", "/upgradeRes/");
			if (!SCfg.self.isUseEncodedLua 
			    && Path.GetExtension (filePath) == ".lua") {
				filePath = filePath.Replace ("/upgradeRes4Publish/", "/upgradeResMedium/");
			}
			Debug.Log ("filePath==" + filePath);
			buffer = File.ReadAllBytes (filePath);
			map [key] = buffer;
		}
		
	}
	
	void doCreateStreamingAssets (string path, ref Hashtable map)
	{
		string[] fileEntries = Directory.GetFiles (path);//因为Application.dataPath得到的是型如 "工程名称/Assets"
		string extension = "";
		string key = "";
		byte[] buffer = null;
		string filePath = "";
		foreach (string fileName in fileEntries) {
			filePath = fileName;
			extension = Path.GetExtension (fileName);
			if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			key = filter (fileName);
			key = key.Replace ("/upgradeRes4Publish/", "/upgradeRes/");
			key = key.Replace ("/upgradeResMedium/", "/upgradeRes/");
			if (!SCfg.self.isUseEncodedLua 
			    && Path.GetExtension (fileName) == ".lua") {
				filePath = fileName.Replace ("/upgradeRes4Publish/", "/upgradeResMedium/");
			}
			Debug.Log ("filePath==" + filePath);
			buffer = File.ReadAllBytes (filePath);
			map [key] = buffer;
		}
		
		string[] dirEntries = Directory.GetDirectories (path);
		foreach (string dir in dirEntries) {
			
			//跳过不同平台的资源
			#if UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
			if(Path.GetFileName(dir).Equals("IOS")) {
				continue;
			}
			#elif UNITY_IOS
			if(Path.GetFileName(dir).Equals("Android")) {
				Debug.Log(Path.GetFileName(dir));
				continue;
			}
			#endif
			doCreateStreamingAssets (dir, ref map);
		}
	}
	
	//过滤路径
	public string filter (string oldStr)
	{
		string basePath = Application.dataPath + "/";
		basePath = basePath.Replace ("/Assets/", "/");
		
		string[] replaces = {basePath + "StreamingAssets/",
			basePath + "Resources/",
			basePath + "Assets/"};
		string str = oldStr;
		string rep = "";
		for (int i =0; i < replaces.Length; i++) {
			rep = replaces [i];
			str = str.Replace (rep, "");
		}
		return str;
	}
	
	void MoveOtherToStreamingAssets ()
	{
		string publishVerPath = Application.dataPath + "/" + ver4Publish;
		if (!File.Exists (publishVerPath)) {
			GUI.color = Color.red;
			EditorUtility.DisplayDialog ("失败!!!!!!!!", "请先设置Publish[PubshlishSetting]!\n失败!失败!失败!失败!失败!失败!", "失败");
			GUI.color = Color.white;
			return;
		}
		Hashtable publishCfg = fileToMap (publishVerPath);
		
		string asPath = "Assets/StreamingAssets/";
		string basePath = "Assets/" + data.name + "/upgradeRes4Publish/";
		string pPath = asPath + data.name + "/upgradeRes/other/";
		if (Directory.Exists (pPath)) {
			Directory.Delete (pPath, true);
		}
		Directory.CreateDirectory (pPath);
		
		//		cpyDir (basePath + "other/", pPath);
		
		string filePath = "";
		string toPath = "";
		foreach (DictionaryEntry cell in publishCfg) {
			filePath = Application.dataPath + "/" + cell.Key;
			if (!filePath.Contains (Application.dataPath + "/" + data.name + "/upgradeRes4Publish/other/")) {
				continue;
			}
			toPath = Application.dataPath + "/StreamingAssets/" + cell.Key.ToString ().Replace ("/upgradeRes4Publish/", "/upgradeRes/");
			
			Directory.CreateDirectory (Path.GetDirectoryName (toPath));
			File.Copy (filePath, toPath);
		}
		
		EditorUtility.DisplayDialog ("success", "Move Others to StreamingAssets cuccess!", "Okey");
	}
	
	void cpyDir (string path, string toPath)
	{
		
		string[] fileEntries = Directory.GetFiles (path);
		string f = "";
		string extension = "";
		Directory.CreateDirectory (toPath);
		for (int i =0; i < fileEntries.Length; i++) {
			f = fileEntries [i];
			extension = Path.GetExtension (f);
			if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			Debug.Log (f + "          " + toPath + Path.GetFileName (f));
			File.Copy (f, toPath + Path.GetFileName (f));
		}
		
		string[] dirEntries = Directory.GetDirectories (path);
		foreach (string dir in dirEntries) {
			//跳过不同平台的资源
			#if UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
			if(Path.GetFileName(dir).Equals("IOS")) {
				continue;
			}
			#elif UNITY_IOS
			if(Path.GetFileName(dir).Equals("Android")) {
				continue;
			}
			#endif
			cpyDir (dir, toPath + Path.GetFileName (dir) + "/");
		}
	}
	
	void refreshCfgFiles ()
	{
		cfgFiles.Clear ();
		if (string.IsNullOrEmpty (data.cfgFolderStr)) {
			return;
		}
		
		string[] files = Directory.GetFiles (data.cfgFolderStr);
		string extension = "";
		foreach (string f in files) {
			extension = Path.GetExtension (f);
			if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			cfgFiles.Add (f);
		}
	}
	
	string createCfgBioDataFromJson (string className, string jsonPath)
	{
		Debug.Log(jsonPath);
		ArrayList list = JSON.DecodeList(File.ReadAllText(Application.dataPath + "/" + jsonPath)) ;
		if (list == null)
			return "";
		string outVerFile = getCfgBioDataPath (className);
		Directory.CreateDirectory (Path.GetDirectoryName (outVerFile));
		ArrayList _list = null;
		for(int i = 1; i < list.Count; i++) {
			_list = (ArrayList)(list[i]);
			for(int j = 0; j < _list.Count; j++) {
				if(_list[j] is System.Double) {
					_list[j] = NumEx.int2Bio(NumEx.stringToInt (_list[j].ToString()));
				}
			}
			list[i] = _list;
		}
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeObject (ms, list);
		File.WriteAllBytes (outVerFile, ms.ToArray ());
		return outVerFile;
	}
	string createCfgBioData (string className)
	{
		ArrayList list = null;
		//		if(className == "DBCFNpcData") {
		//			DBCFNpcData rld  = new DBCFNpcData();
		//			list = rld.getData();
		//		} else {
		Type tp = Type.GetType (className);
		object obj = Activator.CreateInstance (tp);
		DBCfgAbsData cfgData = (DBCfgAbsData)obj;
		list = cfgData.getData ();
		//		}
		int count = list.Count;
		DBCfgAbs cfg = null;
		ArrayList _list = new ArrayList ();
		for (int i = 0; i < count; i++) {
			cfg = (DBCfgAbs)(list [i]);
			Hashtable h = cfg.ToMap ();
			_list.Add (cfg.ToMap ());
		}
		string outVerFile = getCfgBioDataPath (className);
		Directory.CreateDirectory (Path.GetDirectoryName (outVerFile));
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeObject (ms, _list);
		File.WriteAllBytes (outVerFile, ms.ToArray ());
		return outVerFile;
	}
	
	string getCfgBioDataPath (string className)
	{
		string outVerFile = "Assets/" + data.name + "/upgradeRes4Publish/priority/cfg/" + className + ".cfg";
		return outVerFile;
	}
	
	/// <summary>
	/// 取得最后一次更新后的版本信息
	/// </summary>
	/// <returns>The last upgrade ver.</returns>
	public static Hashtable getLastUpgradeVer ()
	{
		string path = Application.dataPath + "/" + ver4Upgrade;
		return fileToMap (path);
	}
	
	public static Hashtable getLastUpgradeMd5Ver ()
	{
		string path = Application.dataPath + "/" + ver4UpgradeMd5;
		return fileToMap (path);
	}
	
	public static Hashtable fileToMap (string path)
	{
		Hashtable r = new Hashtable ();
		if (!File.Exists (path)) {
			return r;
		}
		string[] content = File.ReadAllLines (path);
		int count = content.Length;
		string str = "";
		for (int i =0; i < count; i++) {
			str = content [i];
			if (str.StartsWith ("#"))
				continue;
			string[] strs = str.Split (',');
			if (strs.Length > 1) {
				r [strs [0]] = strs [1];
			}
		}
		return r;
	}
	
	string refreshAllAssetbundles (bool isOnlyGetResult = false)
	{
		AssetDatabase.Refresh ();
		// get current ver
		Hashtable tmpOtherVer = CreateVerCfg.create2Map ("Assets/" + data.name + "/upgradeResMedium/other");
		Hashtable tmpPriorityVer = CreateVerCfg.create2Map ("Assets/" + data.name + "/upgradeResMedium/priority");
		Hashtable tmpCfgdataVer = null;
		if (!String.IsNullOrEmpty (data.cfgFolderStr)) {
			tmpCfgdataVer = CreateVerCfg.create2Map (data.cfgFolderStr);
		}
		tmpCfgdataVer = tmpCfgdataVer == null ? new Hashtable () : tmpCfgdataVer;
		
		string lastVerPath = "";
		// get last time ver
		lastVerPath = Application.dataPath + "/" + ver4DevelopeMd5;
		
		Hashtable lastVerMap = null;
		if (File.Exists (lastVerPath)) {
			lastVerMap = Utl.fileToMap (lastVerPath);
		}
		lastVerMap = lastVerMap == null ? new Hashtable () : lastVerMap;
		//		string deviceIdentity = MapEx.getString (lastVerMap, "deviceUniqueIdentifier");
		Hashtable lastOtherVer = null;
		Hashtable lastPriorityVer = null;
		Hashtable lastCfgdataVer = null;
		//		if (deviceIdentity.Equals (SystemInfo.deviceUniqueIdentifier)) {
		lastOtherVer = MapEx.getMap (lastVerMap, "other");
		lastPriorityVer = MapEx.getMap (lastVerMap, "priority");
		lastCfgdataVer = MapEx.getMap (lastVerMap, "cfgData");
		//		} else {
		//			lastOtherVer = new Hashtable ();
		//			lastPriorityVer = new Hashtable ();
		//			lastCfgdataVer = new Hashtable ();
		//		}
		//		lastVerMap ["deviceUniqueIdentifier"] = SystemInfo.deviceUniqueIdentifier;
		
		// refresh other assetbundle
		PStr resultPstr = PStr.b ();
		string result = "";
		string path = "";
		string md5str = "";
		CLTextureMgr textureMgr = null;
		CLModelMgr modelMgr = null;
		foreach (DictionaryEntry cell in tmpOtherVer) {
			path = cell.Key.ToString ();
			md5str = cell.Value.ToString ();
			if (lastOtherVer == null || lastOtherVer [path] == null || lastOtherVer [path].ToString () != md5str) {
				//do refresh asset
				Debug.Log ("Assets/" + path);
				//				result = result + path + "\n";
				resultPstr.a (path).a ("\n");
				if (!isOnlyGetResult) {
					//					GameObject obj = (GameObject)(AssetDatabase.LoadAssetAtPath("Assets/" + path, typeof(GameObject)));
					UnityEngine.Object obj = CLEditorTools.getObjectByPath("Assets/" + path);
					if(obj != null && obj is GameObject) {
						textureMgr = ((GameObject)obj).GetComponent<CLTextureMgr>();
						modelMgr = ((GameObject)obj).GetComponent<CLModelMgr>();
					} else {
						modelMgr = null;
						textureMgr = null;
					}

					if( textureMgr != null ) {
						textureMgr.cleanMat();
					}
					if(modelMgr != null) {
						modelMgr.cleanModel();
					}
					CreatUnity3dType.createAssets4Upgrade ("Assets/" + path);
					if( textureMgr != null ) {
						textureMgr.resetMat();
					}
					if(modelMgr != null) {
						modelMgr.resetModel();
					}
				}
			}
		}
		lastVerMap ["other"] = tmpOtherVer;
		
		// refresh priority assetsbutndle
		foreach (DictionaryEntry cell in tmpPriorityVer) {
			path = cell.Key.ToString ();
			md5str = cell.Value.ToString ();
			if(path.Contains(".project") || path.Contains(".buildpath")) {
				continue;
			}
			if (path.Contains ("/priority/atlas/") ||
			    path.Contains ("/priority/font/")) {
				//1. atlas
				if (lastPriorityVer == null || lastPriorityVer [path] == null || lastPriorityVer [path].ToString () != md5str) {
					//do refresh asset
					Debug.Log ("Assets/" + path);
					//					result = result + path + "\n";
					resultPstr.a (path).a ("\n");
					if (!isOnlyGetResult) {
						CreatUnity3dType.createAssets4Upgrade ("Assets/" + path, false);
					}
				}
			} else if (path.Contains ("/priority/lua/")) {
				// encode lua
				if (lastPriorityVer == null || lastPriorityVer [path] == null || lastPriorityVer [path].ToString () != md5str) {
					//					result = result + path + "\n";
					resultPstr.a (path).a ("\n");
					if (!isOnlyGetResult) {
						// if (SystemInfo.operatingSystem.Contains ("Mac")) {
							CLLuaEncode.luajitEncode ("Assets/" + path);
                        // }
					}
				}
			} else if (path.Contains ("/priority/ui/cell/") ||
			           path.Contains ("/priority/ui/other/")) {
				// refresh ui cell
				if (lastPriorityVer == null || lastPriorityVer [path] == null || lastPriorityVer [path].ToString () != md5str) {
					GameObject t = (GameObject)(AssetDatabase.LoadAssetAtPath ("Assets/" + path, typeof(GameObject)));
					CLCellLua uicell = t.GetComponent<CLCellLua> ();
					if (uicell != null) {
						//						result = result + path + "\n";
						resultPstr.a (path).a ("\n");
						
						if (!isOnlyGetResult) {
							CLCellLuaInspector.doSaveAsset (uicell);
						}
					} else {
						Debug.LogError("The object can not get the [CLCellLu]!");
					}
				}
			} else if (path.Contains ("/priority/ui/panel/")) {
				// refresh panel
				if (lastPriorityVer == null || lastPriorityVer [path] == null || lastPriorityVer [path].ToString () != md5str) {
					GameObject t = (GameObject)(AssetDatabase.LoadAssetAtPath ("Assets/" + path, typeof(GameObject)));
					CLPanelLua panel = t.GetComponent<CLPanelLua> ();
					if (panel != null) {
						//						result = result + path + "\n";
						resultPstr.a (path).a ("\n");
						if (!isOnlyGetResult) {
							//							Debug.Log("pathe===" + path);
							CLPanelLuaInspector.doSaveAsset (panel);
						}
					} else {
						Debug.LogError("The object can not get the [CLPanelLua]!");
					}
				}
			} else {
				if (lastPriorityVer == null || lastPriorityVer [path] == null || lastPriorityVer [path].ToString () != md5str) {
					//					result = result + path + "\n";
					resultPstr.a (path).a ("\n");
					if (!isOnlyGetResult) {
						string cpyPath = path.Replace ("/upgradeResMedium", "/upgradeRes4Publish");
						cpyPath = Application.dataPath + "/" + cpyPath;
						Directory.CreateDirectory (Path.GetDirectoryName (cpyPath));
						File.Copy (Application.dataPath + "/" + path, cpyPath, true);
					}
				}
			}
		}
		lastVerMap ["priority"] = tmpPriorityVer;
		
		// cfg data refresh
		lastVerMap ["cfgData"] = tmpCfgdataVer;
		foreach (DictionaryEntry cell in tmpCfgdataVer) {
			path = cell.Key.ToString ();
			md5str = cell.Value.ToString ();
			if (lastCfgdataVer == null || lastCfgdataVer [path] == null || lastCfgdataVer [path].ToString () != md5str) {
				string className = Path.GetFileNameWithoutExtension (path);
				//				Debug.Log("className==" + className);
				//				result = result + createCfgBioData(className) + "\n";
				if (isOnlyGetResult) {
					resultPstr.a (getCfgBioDataPath (className)).a ("\n");
				} else {
					resultPstr.a (createCfgBioDataFromJson (className, path)).a ("\n");
				}
			}
		}
		
		result = resultPstr.e ();
		Debug.Log ("result.len==" + result.Length);
		if (!isOnlyGetResult) {
			Debug.Log ("result==" + result);
			GUIMsgBox.show ("Refresh success", result == "" ? "nothing need refresh!" : result, null, null);
			
			Directory.CreateDirectory (Path.GetDirectoryName (lastVerPath));
			MemoryStream ms = new MemoryStream ();
			B2OutputStream.writeObject (ms, lastVerMap);
			FileEx.WriteAllBytes (ver4DevelopeMd5, ms.ToArray ());
			
			return "";
		} else {
			return result;
		}
	}
	
	void publishSetting ()
	{
		string path = Application.dataPath + "/" + data.name + "/upgradeRes4Publish";
		GUIResList.show4PublishSeting (path, (Callback)onGetFiles4PublishSetting, null);
	}
	
	void onGetFiles4PublishSetting (params object[] args)
	{
		ArrayList files = (ArrayList)(args [0]);
		int count = files.Count;
		ResInfor ri = null;
		string path = Application.dataPath + "/" + ver4Publish;
		string upgradeVerPath = Application.dataPath + "/" + ver4Upgrade;
		string upgradeVerPathMd5 = Application.dataPath + "/" + ver4UpgradeMd5;
		string content = "";
		string content2 = "";
		Hashtable content3 = new Hashtable ();
		Hashtable content4 = new Hashtable ();
		string md5VerStr = "";
		PStr ps = PStr.b (content);
		PStr ps2 = PStr.b (content2);
		PStr ps3 = PStr.b (md5VerStr);
		
		bool needCreateMd5 = false;
		if (!File.Exists (upgradeVerPath)) {
			needCreateMd5 = true;
		}
		for (int i = 0; i < count; i++) {
			ri = (ResInfor)(files [i]);
			ps.a (ri.relativePath).a (",").a (ri.ver).a ("\n");
			if (needCreateMd5) {
				ps2.a (ri.publishPath).a (",").a (ri.ver).a ("\n");
				ps3.a (ri.relativePath).a (",").a (Utl.MD5Encrypt (File.ReadAllBytes (ri.path))).a ("\n");
			}
			if (ri.path.Contains ("/priority/")) {
				content3 [ri.publishPath] = ri.ver;
			} else {
				content4 [ri.publishPath] = ri.ver;
			}
		}
		//
		File.WriteAllText (path, ps.e ());
		//
		if (!File.Exists (upgradeVerPath)) {
			File.WriteAllText (upgradeVerPath, ps2.e ());
			// create md5version
			File.WriteAllText (upgradeVerPathMd5, ps3.e ());
		}
		
		// create version file
		string mVerverPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.fverVer).end ();
		string mVerPrioriPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.versPath).a ("/").a (CLVerManager.verPriority).end ();
		string mVerOtherPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.versPath).a ("/").a (CLVerManager.verOthers).end ();
		
		Hashtable verVerMap = new Hashtable ();// Utl.fileToMap(Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Publish/" + mVerverPath);
		verVerMap [mVerPrioriPath] = 0;
		verVerMap [mVerOtherPath] = 0;
		
		string tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerverPath;
		if (!File.Exists (tmpPath)) {
			Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
			CreateVerCfg.saveMap (verVerMap, tmpPath);
		} else {
			Hashtable m = Utl.fileToMap (tmpPath);
			verVerMap [mVerPrioriPath] = MapEx.getInt (m, mVerPrioriPath);
			verVerMap [mVerOtherPath] = MapEx.getInt (m, mVerOtherPath);
		}
		
		tmpPath = Application.dataPath + "/StreamingAssets/" + mVerverPath;
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verVerMap, tmpPath);
		
		tmpPath = Application.dataPath + "/StreamingAssets/" + mVerPrioriPath;
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (content3, tmpPath);
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerPrioriPath;
		if (!File.Exists (tmpPath)) {
			Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
			CreateVerCfg.saveMap (content3, tmpPath);
		}
		tmpPath = Application.dataPath + "/StreamingAssets/" + mVerOtherPath;
		CreateVerCfg.saveMap (content4, tmpPath);
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerOtherPath;
		if (!File.Exists (tmpPath)) {
			Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
			CreateVerCfg.saveMap (content4, tmpPath);
		}
		
		EditorUtility.DisplayDialog ("success", "Publish Version File Created!", "Okay");
	}
	
	void upgrade4Publish ()
	{
		string path = Application.dataPath + "/" + data.name + "/upgradeRes4Publish";
		GUIResList.show4Upgrade (path, (Callback)onGetFiles4Upgrade, null);
	}
	
	void onGetFiles4Upgrade (params object[] args)
	{
		ArrayList list = (ArrayList)(args [0]);
		if (list.Count == 0)
			return;
		
		string mVerverPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.fverVer).end ();
		string mVerPrioriPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.versPath).a ("/").a (CLVerManager.verPriority).end ();
		string mVerOtherPath = PStr.begin ().a (PathCfg.self.basePath).a ("/").a (CLVerManager.resVer).a ("/").a (PathCfg.self.platform).a ("/").a (CLVerManager.versPath).a ("/").a (CLVerManager.verOthers).end ();
		
		string tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerPrioriPath;
		Hashtable verPrioriMap = Utl.fileToMap (tmpPath);
		
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerOtherPath;
		Hashtable verOtherMap = Utl.fileToMap (tmpPath);
		
		Hashtable verLastUpgradeMap = fileToMap (Application.dataPath + "/" + ver4Upgrade);
		
		bool isNeedUpgradeOther = false;
		bool isNeedUpgradePriori = false;
		int count = list.Count;
		ResInfor ri = null;
		//		string toPath = Application.dataPath +"/" + data.name +  "/upgradeRes4Publish/" + data.name + "/upgradeRes/";
		string toPathBase = (Application.dataPath + "/").Replace ("/Assets/", "/Assets4Upgrade/" + DateEx.format (DateEx.fmt_yyyy_MM_dd_HH_mm_ss) + "/");
		string toPath = toPathBase;
		if (Directory.Exists (toPath)) {
			Directory.Delete (toPath, true);
		}
		int verVal = 0;
		for (int i=0; i < count; i++) {
			ri = (ResInfor)(list [i]);
			//
			//			toPath = Application.dataPath +"/" + data.name +  "/upgradeRes4Publish/" + ri.publishPath;
			verVal = NumEx.stringToInt (MapEx.getString (verLastUpgradeMap, ri.publishPath)) + 1;
			verLastUpgradeMap [ri.publishPath] = verVal;
			
			//要更新的文件后面加一个版本号，这样使得后面做更新时可以使用cdn
			toPath = toPathBase + ri.publishPath;
			if (verVal > 0) {
				toPath = toPath + "." + verVal;
			}
			Directory.CreateDirectory (Path.GetDirectoryName (toPath));
			if (toPath.Contains ("/priority/lua/") && !SCfg.self.isUseEncodedLua) {
				File.Copy (ri.path.Replace ("/upgradeRes4Publish/", "/upgradeResMedium/"), toPath);
			} else {
				File.Copy (ri.path, toPath);
			}
			
			if (ri.relativePath.Contains ("/priority/")) {
				isNeedUpgradePriori = true;
				int ver = NumEx.stringToInt (MapEx.getString (verPrioriMap, ri.publishPath));
				verPrioriMap [ri.publishPath] = ver + 1;
			} else {
				isNeedUpgradeOther = true;
				int ver = NumEx.stringToInt (MapEx.getString (verOtherMap, ri.publishPath));
				verOtherMap [ri.publishPath] = ver + 1;
			}
		}
		
		//===========================		
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerverPath;
		Hashtable verVerMap = Utl.fileToMap (tmpPath);
		if (isNeedUpgradePriori) {
			verVerMap [mVerPrioriPath] = NumEx.stringToInt (MapEx.getString (verVerMap, mVerPrioriPath)) + 1;
		} else {
			verVerMap [mVerPrioriPath] = NumEx.stringToInt (MapEx.getString (verVerMap, mVerPrioriPath));
		}
		if (isNeedUpgradeOther) {
			verVerMap [mVerOtherPath] = NumEx.stringToInt (MapEx.getString (verVerMap, mVerOtherPath)) + 1;
		} else {
			verVerMap [mVerOtherPath] = NumEx.stringToInt (MapEx.getString (verVerMap, mVerOtherPath));
		}
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verVerMap, tmpPath);
		tmpPath = toPathBase + mVerverPath;
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verVerMap, tmpPath);
		//===========================	
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerPrioriPath;		
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verPrioriMap, tmpPath);
		tmpPath = toPathBase + mVerPrioriPath + "." + verVerMap [mVerPrioriPath]; //加上版本号，就可以用cdn了
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verPrioriMap, tmpPath);
		
		tmpPath = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Ver/" + mVerOtherPath;		
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verOtherMap, tmpPath);
		tmpPath = toPathBase + mVerOtherPath + "." + verVerMap [mVerOtherPath]; //加上版本号，就可以用cdn了
		Directory.CreateDirectory (Path.GetDirectoryName (tmpPath));
		CreateVerCfg.saveMap (verOtherMap, tmpPath);
		
		//-------------------------------------------------
		string str = "";
		foreach (DictionaryEntry cell in verLastUpgradeMap) {
			str = str + cell.Key.ToString () + "," + cell.Value.ToString () + "\n";
		}
		File.WriteAllText (Application.dataPath + "/" + ver4Upgrade, str);
		
		Hashtable tmpResVer = CreateVerCfg.create2Map ("Assets/" + CoolapeProject.data.name + "/upgradeRes4Publish");
		str = "";
		foreach (DictionaryEntry cell in tmpResVer) {
			str = str + cell.Key.ToString ().Replace ("/upgradeRes", "/upgradeRes4Publish") + "," + cell.Value.ToString () + "\n";
		}
		File.WriteAllText (Application.dataPath + "/" + ver4UpgradeMd5, str);
		
		EditorUtility.DisplayDialog ("success", "Upgrade Version File Created!", "Okay");
	}
}
