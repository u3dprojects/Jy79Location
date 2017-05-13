using UnityEngine;

using System;
using System.IO;
using System.Text;
using System.Collections;
using LuaInterface;

namespace Toolkit
{

	/*
    On a desktop computer (Mac OS or Windows) the location of the files can be obtained with the following code:-
      path = Application.dataPath + "/StreamingAssets";
    On iOS, you should use:-
      path = Application.dataPath + "/Raw";
    ...while on Android, you should use:-
      path = "jar:file://" + Application.dataPath + "!/assets/";
    */
	public class FileEx
	{
		//
		static string texturePath;
	
		public static string TexturePath ()
		{
			if (texturePath != null && texturePath.Length > 3)
				return texturePath;
		
			texturePath = BasePath () + "_texture/";
			if (!DirectoryExists (texturePath))
				CreateDirectory (texturePath);
		
			return texturePath;
		}
		//
		static string scriptPath;
	
		public static string ScriptPath ()
		{
			if (scriptPath != null && scriptPath.Length > 3)
				return scriptPath;
		
			scriptPath = BasePath () + "_script/";
			if (!DirectoryExists (scriptPath))
				CreateDirectory (scriptPath);
		
			return scriptPath;
		}
		//
		static string dataPath;
	
		public static string DataPath ()
		{
			if (dataPath != null && dataPath.Length > 3)
				return dataPath;
		
			dataPath = BasePath () + "_data/";
			if (!DirectoryExists (dataPath))
				CreateDirectory (dataPath);
		
			return dataPath;
		}
		//
	
		public static string BasePath ()
		{
			string r2 = "";
#if UNITY_EDITOR
		r2 = Application.dataPath + "/";
#elif UNITY_IPHONE			
	string PathBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
	r2 = PathBase.Substring(0, PathBase.LastIndexOf('/')) + "/Documents/";
#elif UNITY_ANDROID
	r2 = Application.persistentDataPath + "/";
#else
			r2 = Application.dataPath + "/";
#endif
		
			if (! DirectoryExists (r2))
				CreateDirectory (r2);
		
			return r2;
		}
	
		public static string BundlePath ()
		{
			string r2 = "";
#if UNITY_EDITOR
		r2 = Application.dataPath + "/";
		//r2 =  Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/";
#elif UNITY_IPHONE			
		r2 = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/";
#elif UNITY_ANDROID
		r2 = Application.persistentDataPath + "/";
#else
			r2 = Application.dataPath + "/";
#endif
			return r2;
		}
	
		public static string StreamingAssets ()
		{
			string filepath = "";
#if UNITY_EDITOR
		filepath = Application.dataPath +"/StreamingAssets/";
#elif UNITY_IPHONE
      	filepath = Application.dataPath +"/Raw/";
#elif UNITY_ANDROID 
//      	filepath = "jar:file://" + Application.dataPath + "!/assets/";
//		filepath = Application.dataPath + "/assets/";
		filepath = Application.streamingAssetsPath + "/";
#endif
			return filepath;
		}
		
		//
		static string pbPath;
	
		public static string OutPackagePbPath ()
		{
			if (pbPath != null && pbPath.Length > 3)
				return pbPath;
		
			pbPath = BasePath () + "pbs/";
			
#if UNITY_EDITOR
			pbPath = BasePath () + "StreamingAssets/pbs/";
#endif
			if (!DirectoryExists (pbPath))
				CreateDirectory (pbPath);
		
			return pbPath;
		}

		public static string InPackagePbPath ()
		{
			string filepath = "";
			#if UNITY_EDITOR
			filepath = "file://" + Application.streamingAssetsPath +"/pbs/";
			#elif UNITY_IPHONE
			//filepath = Application.dataPath +"/Raw/pbs/";
			filepath = "file://" +  Application.streamingAssetsPath +"/pbs/";
			#elif UNITY_ANDROID 
			//      	filepath = "jar:file://" + Application.dataPath + "!/assets/";
			//		filepath = Application.dataPath + "/assets/";
			filepath = Application.streamingAssetsPath + "/pbs/";
			#endif
			return filepath;
		}

		public static string AssetPath ()
		{
			return Application.dataPath + "/";
		}
	
		public static string BasePath (string fn)
		{
			return BasePath () + fn;
		}
	
		public static bool FileExists (string fn)
		{
			try {
				string path = BasePath (fn);
				return File.Exists (path);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
			return false;
		}
	
		public static void WriteAllBytes (string fn, byte[] bytes)
		{
			try {
				string path = BasePath (fn);
				File.WriteAllBytes (path, bytes);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		}
	
		public static byte[] ReadAllBytes (string fn)
		{
			try {
				string path = BasePath (fn);
				return File.ReadAllBytes (path);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		
			return null;
		}
	
		public static void WriteAllText (string fn, string str)
		{
			try {
				string path = BasePath (fn);
				File.WriteAllText (path, str);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		}

		public static void AppendAllText (string fn, string str)
		{
			try {
				string path = BasePath (fn);
				File.AppendAllText (path, str);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		}

		public static string ReadToEnd (string fn)
		{
			try {
				string path = BasePath (fn);
				return File.ReadAllText (path);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		
			return "";
		}
	
		public static void Delete (string fn)
		{
			try {
				string path = BasePath (fn);
				File.Delete (path);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		}
	
		public static bool DirectoryExists (string path)
		{
			return Directory.Exists (path);
		}
	
		public static bool CreateDirectory (string path)
		{
			if (DirectoryExists (path))
				return true;
			
			DirectoryInfo di = Directory.CreateDirectory (path);
			return di.Exists;
		}
	
		public static string[] GetFiles (string fn)
		{
			try {
				string path = BasePath (fn);
				return Directory.GetFiles (path);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
		
			return new string[0];
		}
	
		public static string[] GetFiles ()
		{
			return GetFiles ("");
		}
	
		public static void SaveTexture2D (string fn, byte[] data)
		{
			try { 
				if (fn == null || fn.Length <= 0 || data == null || data.Length <= 0)
					return;
				string path = TexturePath () + fn;
				Debug.Log (path);
				File.WriteAllBytes (path, data);
			} catch (Exception e) {
				Debug.Log (e.Message);
			}		
		}
	
		public static Texture2D LoadTexture2D (int w, int h, string fn)
		{
			try { 
				string path = TexturePath () + fn;
				if (!File.Exists (path))
					return null;
		
				byte[] bytes = File.ReadAllBytes (path);
				if (bytes == null || bytes.Length <= 10)
					return null;
				Texture2D r2 = new Texture2D (w, h);
				bool succ = r2.LoadImage (bytes);
				if (!succ)
					return null;
				return r2;
			} catch (Exception e) {
				Debug.Log (e.Message);
			}
			return null;
		}
		
		public static IEnumerator readNewAllText (string fName, object OnGet)
		{
			string buff = "";
			string fPath = PathCfg.persistentDataPath + "/" + fName;
			if (File.Exists (fPath)) {
				yield return null;
				buff = File.ReadAllText (fPath);
			} else {
				fPath = Application.streamingAssetsPath + "/" + fName;
				if (Application.platform == RuntimePlatform.Android) {
					WWW www = new WWW (Utl.urlAddTimes(fPath));
					yield return www;
					buff = www.text;
                    www.Dispose();
                    www = null;
				} else {
					yield return null;
					if (File.Exists (fPath)) {
						buff = File.ReadAllText (fPath);
					}
				}
			}
#if UNITY_EDITOR
			if(buff == null) {
				Debug.LogError("Get null content == " + fPath);
			}
#endif
			if(OnGet != null) {
				if(typeof(LuaFunction) == OnGet.GetType()) {
					((LuaFunction)OnGet).Call (buff);
				} else if(typeof(Callback) == OnGet.GetType()){
					((Callback)OnGet) (buff);
				}
			}
		}
		
		public static IEnumerator readNewAllBytes (string fName, object OnGet)
		{
			byte[] buff = null;
            string fPath = PathCfg.persistentDataPath + "/" + fName;
			if (File.Exists (fPath)) {
				yield return null;
				buff = File.ReadAllBytes (fPath);
			} else {
				fPath = Application.streamingAssetsPath + "/" + fName;
				if (Application.platform == RuntimePlatform.Android) {
					WWW www = new WWW (Utl.urlAddTimes(fPath));
					yield return www;
					if (string.IsNullOrEmpty (www.error)) {
						buff = www.bytes;
                        www.Dispose();
                        www = null;
					}
				} else {
					yield return null;
					if (File.Exists (fPath)) {
						buff = File.ReadAllBytes (fPath);
					}
				}
			}
#if UNITY_EDITOR
			if(buff == null) {
				Debug.LogError("Get null content == " + fPath);
			}
#endif
			if(OnGet != null) {
				if(typeof(LuaFunction) == OnGet.GetType()) {
					((LuaFunction)OnGet).Call (buff);
				} else if(typeof(Callback) == OnGet.GetType()){
					((Callback)OnGet) (buff);
				}
			}
		}
        
        public static Hashtable FileTextMap = new Hashtable();
        public static Hashtable FileBytesMap = new Hashtable();
        
        public static string getTextFromCache(string path) {
            if(string.IsNullOrEmpty(path)) return null;
            string ret = MapEx.getString(FileTextMap, path);
            if(string.IsNullOrEmpty(ret)) {
                ret = File.ReadAllText(path);
                FileTextMap[path] = ret;
            }
            return ret;
        }
        
        public static byte[] getBytesFromCache(string path) {
            if(string.IsNullOrEmpty(path)) return null;
            byte[] ret = MapEx.getBytes(FileBytesMap, path);
            if(ret == null) {
                ret = File.ReadAllBytes(path);
                FileBytesMap[path] = ret;
            }
            return ret;
        }
        
        public static void cleanCache() {
            FileTextMap.Clear();
            FileBytesMap.Clear();
        }
	}
}