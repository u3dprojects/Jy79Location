using UnityEngine;
using System.Collections;
using Toolkit;

//路径配置
using System.Collections.Generic;
using System.IO;


public class PathCfg : MonoBehaviour
{
	public static PathCfg self;

	public PathCfg()
	{
		self = this;
	}
	
	static string _luaBasePath = "";

	public static string luaBasePath {
		get {
			if (string.IsNullOrEmpty(_luaBasePath)) {
#if UNITY_EDITOR
				if(SCfg.self.isNotEditorMode) {
					_luaBasePath = PStr.begin ().a (persistentDataPath).a ("/").end ();
				} else{
					_luaBasePath = PStr.begin ().a (Application.dataPath).a ("/").end ();
				}
#else 
				_luaBasePath = PStr.begin().a(persistentDataPath).a("/").end();
#endif
			}
			return _luaBasePath;
		}
	}
	
    static string _persistentDataPath = "";
	public static string persistentDataPath {
		get {
#if UNITY_EDITOR
			if(SCfg.self.isNotEditorMode) {
                if(_persistentDataPath == null || _persistentDataPath == "") {
                    _persistentDataPath = Application.persistentDataPath;
                }
                return _persistentDataPath;
			} else {
				return Application.dataPath;
			}
#else
            if(_persistentDataPath == null || _persistentDataPath == "") {
                _persistentDataPath = Application.persistentDataPath;
                #if UNITY_ANDROID
                if(_persistentDataPath == null || _persistentDataPath == "") {
					AndroidJavaClass jc = new AndroidJavaClass("com.x3gu.tools.Tools4FilePath");
                    _persistentDataPath = jc.CallStatic<string>("getPath");
                }
                #endif
            }
            return _persistentDataPath;
#endif
		}
	}
	
	public string platform {
		get {
#if UNITY_IOS
			return "IOS";
#else
			return "Android";
#endif
		}
	}
	//
//	[HideInInspector]
	public string basePath = "xxx";
	//实际的atlase路径
//	public string realAtlasePathAndroid = "xxx/upgradeRes/priority/atlas/Android/atlasAllReal.unity3d";
//	public string realAtlasePathIOS = "xxx/upgradeRes/priority/atlas/IOS/atlasAllReal.unity3d";
	//实际的font路径
	public string realFontPath = "xxx/upgradeRes/priority/font/FontDynReal.unity3d";
	//页面数据存放路径
	public string panelDataPath = "xxx/upgradeRes/priority/ui/panel/";
	public string cellDataPath = "xxx/upgradeRes/priority/ui/cell/";
    public  string _cellDataPath {
        get {
            #if UNITY_EDITOR
            if(SCfg.self.isNotEditorMode) {
                return cellDataPath;
            }
            return  cellDataPath.Replace("/upgradeRes/", "/upgradeRes4Publish/");
            #else
            return cellDataPath;
            #endif
        }
    }
	//lua页面生成器路径
//	public string panelLuaBuilder = "xxx/upgradeRes/priority/lua/builder/CLGameObjBuilder.lua";
	//多语言文件路径
	public string localizationPath = "xxx/upgradeRes/priority/localization/";
	public string luaPathRoot = "xxx/upgradeRes/priority/lua";
	string[] _luaPackgePath = null;
	
	public string[] luaPackgePath {
		get {
			if (_luaPackgePath == null) {
				List<string> list = new List<string>();
#if UNITY_EDITOR
				string tmpRootPath = luaPathRoot;
				if(!SCfg.self.isNotEditorMode) {
					tmpRootPath = luaPathRoot.Replace("/upgradeRes", "/upgradeResMedium");
				}
				resetLuaPackgePath(tmpRootPath, list);
#else
				resetLuaPackgePath(luaPathRoot, list);
#endif
				_luaPackgePath = list.ToArray();
			}
			return _luaPackgePath;
		}
	}

    public static string upgradeRes {
        get{
#if UNITY_EDITOR
            if(SCfg.self.isNotEditorMode) {
                return "upgradeRes";
            }
            return "upgradeRes4Publish";
#else
            return "upgradeRes";
#endif
        }
    }
	
	public void resetLuaPackgePath(string path, List<string> list)
	{
		string d2 = "";
//		list.Add(path+"/?.lua");
		list.Add(path);
		string[] dirs = Directory.GetDirectories(luaBasePath + path);
		foreach (string d in dirs) {
			d2 = d.Replace(luaBasePath, "");
			resetLuaPackgePath(d2, list);
		}
	}

//#if UNITY_EDITOR
	public void resetPath(string basePath)
	{
		this.basePath = basePath;
		//实际的atlase路径
//		realAtlasePathAndroid = basePath + "/upgradeRes/priority/atlas/Android/atlasAllReal.unity3d";
//		realAtlasePathIOS = basePath + "/upgradeRes/priority/atlas/IOS/atlasAllReal.unity3d";
		//实际的font路径
		realFontPath = basePath + "/upgradeRes/priority/font/FontDynReal.unity3d";
		//页面数据存放路径
		panelDataPath = basePath + "/upgradeRes/priority/ui/panel/";
		cellDataPath = basePath + "/upgradeRes/priority/ui/cell/";
		//lua页面生成器路径
		//		instance.panelLuaBuilder = instance.basePath + "/upgradeRes/priority/lua/builder/CLGameObjBuilder.lua";
		//多语言文件路径
		localizationPath = basePath + "/upgradeRes/priority/localization/";
		
		luaPathRoot =  basePath + "/upgradeRes/priority/lua/";
	}
//#endif
}
