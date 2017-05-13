using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;
using Toolkit;

//生成版本配置文件
public static class CreateVerCfg
{
	static string basePath = "";
	static ArrayList replaces = new ArrayList ();

	static public  void create ()
	{	
		string outVerFile = "";
		string path = AssetDatabase.GetAssetPath (Selection.activeObject);//Selection表示你鼠标选择激活的对象
//		Debug.Log ("Selected Folder: " + path);
		if (string.IsNullOrEmpty (path) || !Directory.Exists (path)) {
			Debug.LogWarning ("请选择目录!");
			return;
		}
//		Debug.Log (path);
//		Debug.Log (Path.GetFullPath (path));
		outVerFile = (Path.GetDirectoryName (Path.GetFullPath (path)) + "/" + Path.GetFileName (path) + ".ver");
//		Debug.Log (outVerFile);
		basePath = Application.dataPath + "/";
		basePath = basePath.Replace ("/Assets/", "/");
		replaces.Add (basePath + "Assets/StreamingAssets/");
		replaces.Add (basePath + "Assets/Resources/");
		replaces.Add (basePath + "Assets/");
		
		path = basePath + path;
		Hashtable outMap = new Hashtable ();
		doCreate (path, ref outMap);
		
//		foreach(DictionaryEntry cell in outMap) {
//			Debug.Log(cell.Key + "         " +  cell.Value);
//		}
		
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeMap (ms, outMap);
		File.WriteAllBytes (outVerFile, ms.ToArray ());
		
	}
	
	static public  Hashtable create2Map (string path)
	{	
		basePath = Application.dataPath + "/";
		basePath = basePath.Replace ("/Assets/", "/");
		replaces.Add (basePath + "Assets/StreamingAssets/");
		replaces.Add (basePath + "Assets/Resources/");
		replaces.Add (basePath + "Assets/");
		
		path = basePath + path;
		Hashtable outMap = new Hashtable ();
		doCreate (path, ref outMap);
		return outMap;
	}
	static public  void create (string path, string outPath)
	{	
		Hashtable outMap = create2Map(path);
		saveMap(outMap, outPath);
	}

	static public void saveMap(Hashtable map, string outPath) {
		MemoryStream ms = new MemoryStream ();
		B2OutputStream.writeMap (ms, map);
		Directory.CreateDirectory(Path.GetDirectoryName(outPath));
		File.WriteAllBytes (outPath, ms.ToArray ());
	}

	static void doCreate (string path, ref Hashtable outMap)
	{
		string[] fileEntries = Directory.GetFiles (path);
		string extension = "";
		string filePath = "";
		string md5Str = "";
		foreach (string fileName in fileEntries) {
			extension = Path.GetExtension (fileName);
            if (extension.ToLower () == ".meta" || extension.ToLower () == ".ds_store") {
				continue;
			}
			filePath = filter (fileName);
//			Debug.Log (filePath);
			md5Str = Utl.MD5Encrypt (File.ReadAllBytes (fileName));
//			Debug.Log (filePath + ".."+"md5==" + md5Str);
			filePath = filePath.Replace("\\", "/");
            filePath = filePath.Replace("/upgradeRes4Publish/", "/upgradeRes/");
			outMap [filePath] = md5Str;
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
			doCreate (dir, ref outMap);
		}
	}
	
	static string filter (string path)
	{
		string str = "";
		for (int i =0; i < replaces.Count; i++) {
			str = replaces [i].ToString ();
			path = path.Replace (str, "");
		}
		return path;
	}
}
