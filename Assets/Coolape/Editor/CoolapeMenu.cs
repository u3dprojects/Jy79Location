using UnityEngine;
using UnityEditor;
using System.Collections;
using Toolkit;

/// <summary>
/// Coolape menu.
/// 酷猿菜单
/// 2013-11-16
/// create by chenbin
/// </summary>
using System.IO;


static public class CoolapeMenu
{
	
	[MenuItem("Coolape/ProjectManager", false, 1)]
	static public void LuaProject ()
	{
		EditorWindow.GetWindow<CoolapeProject> (false, "CoolapeProject", true);
	}
    
    [MenuItem("Coolape/Publish Tool", false, 2)]
    static public void OpenBuilder ()
    {
        EditorWindow.GetWindow<CoolapePublisher> (false, "CoolapePublisher", true);
    }
	
	[MenuItem("Coolape/LightMapping/Bake", false, 5)]
	static public void LightMappingBake ()
	{
		CLLightmaping.bake ();
	}
	
	[MenuItem("Coolape/uiPanelsSaveToU3d", false, 6)]
	static public void uipanels2U3d ()
	{
		UnityEngine.Object[] objs = Selection.objects;
		int count = objs.Length;
		UnityEngine.Object obj = null;
		CLPanelLua panel = null;
		for (int i=0; i < count; i++) {
			obj = objs [i];
			panel = ((GameObject)obj).GetComponent<CLPanelLua> ();
			if (panel != null) {
				Debug.LogError (obj.name);
				CLPanelLuaInspector.doSaveAsset (panel);
			}
		}
	}

    [MenuItem("Coolape/Clean Cache", false, 10)]
    static public void cleanCache ()
    {
        Debug.Log (Application.persistentDataPath);
        FileUtil.DeleteFileOrDirectory (Application.persistentDataPath);
        PlayerPrefs.DeleteAll ();
    }

//    [MenuItem("Coolape/CreateLua2BIO", false, 5)]
//    static public void CreateLua2BIO ()
//    {
//        CreateBIO.CreateLua2BIO ();
//    }
    
	[MenuItem("Coolape/LuaEncode/Encode selected Lua", false, 1)]
    static public void LuaEncodeSelected ()
    {
        CLLuaEncode.luajitEncode ();
    }

	[MenuItem("Coolape/LuaEncode/Encode selected Dir", false, 1)]
    static public void LuaEncodeAll ()
    {
        CLLuaEncode.luajitEncodeAll ();
    }
    
	[MenuItem("Coolape/GenerateSecondaryUVSet", false, 5)]
    static public void GenerateSecondaryUVSet ()
    {
        MeshFilter mf = null;
        foreach (UnityEngine.Object o in Selection.objects) {
            if (o is GameObject) {
                mf = ((GameObject)o).GetComponent<MeshFilter> ();
                if (mf != null && mf.mesh != null) {
                    Unwrapping.GenerateSecondaryUVSet (mf.mesh);
                    EditorUtility.SetDirty (o);
                }
            }
        }
    }
    
	[MenuItem("Coolape/DataProc/PrintBioFile", false, 5)]
    static public void showBioFileContent ()
    {
        UnityEngine.Object obj = Selection.objects [0];
        string path = AssetDatabase.GetAssetPath (obj);//Selection表示你鼠标选择激活的对象
		object _obj = Utl.fileToObj (path);
		if(_obj is Hashtable) {
			Debug.Log (Utl.MapToString ((Hashtable)_obj));
		}else if(		_obj.GetType() == typeof(NewList)  ||
			         	_obj.GetType() == typeof(ArrayList)) {
			Debug.Log (Utl.ArrayListToString2 ((ArrayList)_obj));
		} else {
			Debug.Log (_obj.ToString());
		}
    }
    
	[MenuItem("Coolape/DataProc/Bio2Json", false, 5)]
    static public void Bio2Json ()
    {
        UnityEngine.Object[] objs = Selection.objects;
        int count = objs.Length;
        UnityEngine.Object obj = null;
        CLPanelLua panel = null;
        for (int i=0; i < count; i++) {
            obj = objs [i];
            string path = AssetDatabase.GetAssetPath (obj);//Selection表示你鼠标选择激活的对象
            object map = Utl.fileToObj (path);
            string jsonStr = JSON.JsonEncode(map);
            Debug.Log (jsonStr);

            File.WriteAllText(path+".json", jsonStr);
        }
    }

	[MenuItem("Coolape/DataProc/Json2Bio", false, 5)]
    static public void Json2Bio ()
    {
        UnityEngine.Object[] objs = Selection.objects;
        int count = objs.Length;
        UnityEngine.Object obj = null;
        CLPanelLua panel = null;
        for (int i=0; i < count; i++) {
            obj = objs [i];
            string path = AssetDatabase.GetAssetPath (obj);//Selection表示你鼠标选择激活的对象
            string jsonStr = File.ReadAllText(path);
            object map = JSON.JsonDecode(jsonStr);
            
            MemoryStream ms = new MemoryStream ();
            B2OutputStream.writeObject (ms, map);
            Directory.CreateDirectory(Path.GetDirectoryName(path));
            File.WriteAllBytes (path+".bio", ms.ToArray ());
        }
    }

    //生成版本配置文件
//  [MenuItem("Coolape/CreateVerCfg")]
//  static public void CreateVerCfgCall ()
//  {
//      CreateVerCfg.create();
//  }
    
}
