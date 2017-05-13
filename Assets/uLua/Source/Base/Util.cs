using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Util {

	#region add by chenbin
	private static List<string> luaPaths = new List<string>();
	
	/// <summary>
	/// 取得Lua路径
	/// </summary>
	public static string LuaPath(string name) {
		string path = PathCfg.luaBasePath + PathCfg.self.luaPathRoot;
		#if UNITY_EDITOR
		if (!SCfg.self.isNotEditorMode)
		{
			path = path.Replace("/upgradeRes/", "/upgradeResMedium/");
		}
		#endif
		string lowerName = name.ToLower();
		if (lowerName.EndsWith(".lua")) {
			int index = name.LastIndexOf('.');
			name = name.Substring(0, index);
		}
		name = name.Replace('.', '/');
		if (luaPaths.Count == 0) {
			AddLuaPath(path + "uLua/Lua/");
		}
		path = SearchLuaPath(name + ".lua");
		return path;
		//return path + "/uLua/lua/" + name + ".lua";
	}
	
	/// <summary>
	/// 获取Lua路径
	/// </summary>
	/// <param name="fileName"></param>
	/// <returns></returns>
	public static string SearchLuaPath(string fileName) {
		string filePath = fileName;
		int count = luaPaths.Count;
		for (int i = 0; i < count; i++) {
			filePath = luaPaths[i] + fileName;
			if (File.Exists(filePath)) {
				return filePath;
			}
		}
		return filePath;
	}
	
	/// <summary>
	/// 添加的Lua路径
	/// </summary>
	/// <param name="path"></param>
	public static void AddLuaPath(string path) {
		if (!luaPaths.Contains(path)) {
			if (!path.EndsWith("/")) {
				path += "/";
			}
			luaPaths.Add(path);
		}
	}
	
	/// <summary>
	/// 删除Lua路径
	/// </summary>
	/// <param name="path"></param>
	public static void RemoveLuaPath(string path) {
		luaPaths.Remove(path);
	}
	#endregion
	
	public static void Log(string str) {
		Debug.Log(str);
	}
	
	public static void LogWarning(string str) {
		Debug.LogWarning(str);
	}
	
	public static void LogError(string str) {
		Debug.LogError(str); 
	}
	
	/// <summary>
	/// 清理内存
	/// </summary>
    public static void ClearMemory() {
        GC.Collect(); 
        Resources.UnloadUnusedAssets();
        LuaScriptMgr mgr = LuaScriptMgr.Instance;
        if (mgr != null && mgr.lua != null) mgr.LuaGC();
    }

    /// <summary>
    /// 防止初学者不按步骤来操作
    /// </summary>
    /// <returns></returns>
    static int CheckRuntimeFile() {
		if (Application.isPlaying || !Application.isEditor) return 0;
        string sourceDir = AppConst.uLuaPath + "/Source/LuaWrap/";
        if (!Directory.Exists(sourceDir)) {
            return -2;
        } else {
            string[] files = Directory.GetFiles(sourceDir);
            if (files.Length == 0) return -2;
        }
        return 0;
    }

    /// <summary>
    /// 检查运行环境
    /// </summary>
    public static bool CheckEnvironment() {
#if UNITY_EDITOR
        int resultId = Util.CheckRuntimeFile();
        if (resultId == -1) {
            Debug.LogError("没有找到框架所需要的资源，单击Game菜单下Build xxx Resource生成！！");
            EditorApplication.isPlaying = false;
            return false;
        } else if (resultId == -2) {
            Debug.LogError("没有找到Wrap脚本缓存，单击Lua菜单下Gen Lua Wrap Files生成脚本！！");
            EditorApplication.isPlaying = false;
            return false;
        }
#endif
        return true;
    }

	#region add by chenbin
	public static Type getTypeByName(string typeName) {
		Type type = Type.GetType(typeName);
		if(type == null) {
			Debug.LogError(typeName);
		}
		return type;
	}
	#endregion

	public static void AddButtonClick(UIButton button, EventDelegate.Callback onClick ) {
		EventDelegate.Add( button.onClick, onClick);
	}

	public static void SetButtonClick(UIButton button, EventDelegate.Callback onClick ) {
		button.onClick.Clear();
		EventDelegate.Add( button.onClick, onClick);
	}

	public static void RemoveButtonClick(UIButton button) {
		button.onClick.Clear();
	}

	public static void SetButtonState(UIButton button, int state) {
		button.SetState((UIButtonColor.State)state, true);
	}

	public static void SetButtonSpriteNormal(UIButton button, string spriteName) {
		button.normalSprite = spriteName;
	}

	public static void SetButtonSpriteHover(UIButton button, string spriteName) {
		button.hoverSprite = spriteName;
	}

	public static void SetButtonDisabled(UIButton button, string spriteName) {
		button.disabledSprite = spriteName;
	}

	public static void SetButtonPressed(UIButton button, string spriteName) {
		button.pressedSprite = spriteName;
	}

	public static void SetButtonColorNormal(UIButton button, Color clr) {
		button.defaultColor = clr;
	}
	// ------------
	public static void SetTweenFinished(UITweener tweener, EventDelegate.Callback onFinish ) {
		tweener.onFinished.Clear();
		EventDelegate.Add( tweener.onFinished, onFinish);
	}

	public static void RemoveTweenFinished(UITweener tweener) {
		tweener.onFinished.Clear();
	}

	public static int GetInstanceId(UnityEngine.Object obj) {
		if (obj == null) return 0;
		return obj.GetInstanceID();
	}

	public static void UnBindHud(GameObject hud) {
		UIFollowTarget ft = hud.GetComponent<UIFollowTarget>();
		ft.enabled = false;
		ft.setTarget (null, Vector3.zero);
	}

	public static void BindHud(GameObject hud,Transform target, Vector3 offset) {

		hud.transform.localPosition = Vector3.zero;
		hud.transform.localScale = Vector3.one;
		
		UIFollowTarget ft = hud.GetComponent<UIFollowTarget>();
		// ft.disableIfInvisible = false;
		ft.setTarget (target, offset);
		ft.setCamera (SCfg.self.mainCamera, SCfg.self.uiCamera);
		ft.enabled = true;
		ft.LateUpdate();
	}
}
 