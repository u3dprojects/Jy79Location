using UnityEngine;
using System.Collections;
using Toolkit;
using System.IO;
using LuaInterface;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CLUIInit : MonoBehaviour
{
	public UIFont emptFont;
	public UIAtlas emptAtlas;
	public Transform uiPublicRoot;
	public static CLUIInit self;
	public static Dictionary<string, UIFont> fontMap = new Dictionary<string, UIFont> ();
	public static Dictionary<string, UIAtlas> atlasMap = new Dictionary<string, UIAtlas> ();

	public CLUIInit ()
	{
		self = this;
	}

	public void clean ()
	{
		foreach(var item in fontMap) {
			if(item.Key != "fontDyn") {
				#if UNITY_EDITOR
				DestroyImmediate(item.Value);
				#else
				DestroyObject(item.Value);
				#endif
			}
		}
		fontMap.Clear ();
		foreach(var item in atlasMap) {
			if(item.Key != "EmptyAltas") {
				#if UNITY_EDITOR
				DestroyImmediate(item.Value);
				#else
				DestroyObject(item.Value);
				#endif
			}
		}
		atlasMap.Clear ();
		emptAtlas.replacement = null;
	}

	public bool init ()
	{
		clean ();
#if !UNITY_EDITOR
		//取得最新的语言
		Callback cb = onGetLocalize;
		StartCoroutine (FileEx.readNewAllBytes (
            PStr.begin (PathCfg.self.localizationPath, Localization.language, ".txt").end (), 
			cb));
#endif
		
//		CLPanelManager.self. initLuaBuilder ();
		return initAtlas ();
	}
	//设置语言
	void onGetLocalize (params object[] para)
	{
		if (para != null && para.Length > 0) {
			byte[] buff = (byte[])(para [0]);
			Localization.Load (Localization.language, buff);
		}
	}
	
	/// <summary>
	/// Inits the atlas.初始化ui所用的atlas
	/// </summary>
	/// <returns>
	/// The atlas.
	/// </returns>
	public  bool initAtlas ()
	{
		UIAtlas atlas = getAtlasByName ("atlasAllReal");
		if (atlas != null) {
			emptAtlas.replacement = atlas;
			atlasMap ["EmptyAltas"] = emptAtlas;
			fontMap ["fontDyn"] = emptFont;
			return true;
		}
		return false;
	}

	public UIFont getFontByName (string fontName)
	{
		if (fontMap.ContainsKey (fontName)) {
			return fontMap [fontName];
		}
			
#if UNITY_EDITOR
		string tmpPath = "";
		if(SCfg.self.isEditMode && !Application.isPlaying) {
			tmpPath = PStr.begin ()
				.a ("Assets/").a (PathCfg.self.basePath).a ("/").a ("upgradeResMedium").
					a ("/priority/font/").a(fontName).a (".prefab").end ();
			UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath (tmpPath, typeof(UnityEngine.Object));
			if(obj != null) {
				return ((GameObject)obj).GetComponent<UIFont>();
			}
			return null;
		} else {
			return _getFontByName(fontName);
		}
#else
		return _getFontByName (fontName);
#endif
	}
	
	UIFont _getFontByName (string fontName)
	{
		try {
			string tmpPath = PStr.begin ().a (PathCfg.persistentDataPath)
				.a ("/").a (PathCfg.self.basePath).a ("/").a ("upgradeRes").
					a ("/priority/font/").a (PathCfg.self.platform).a ("/").a (fontName).a (".unity3d").end ();
			#if UNITY_EDITOR
			if(!SCfg.self.isNotEditorMode) {
				tmpPath = tmpPath.Replace("/upgradeRes/", "/upgradeRes4Publish/");
			}
			#endif
			AssetBundle atlasBundel = AssetBundle.LoadFromFile (tmpPath);
			if (atlasBundel != null) {
				GameObject go = atlasBundel.mainAsset as GameObject;
				atlasBundel.Unload (false);
				atlasBundel = null;
				if (go != null) {
					UIFont font = go.GetComponent<UIFont> ();
					fontMap [fontName] = font;
					return font;
				}
			}
			return null;
		} catch (System.Exception e) {
			Debug.LogError (e);
			return null;
		}
	}
	
	public UIAtlas getAtlasByName (string atlasName)
	{
		if (atlasMap.ContainsKey (atlasName)) {
			return atlasMap [atlasName];
		}
		
		#if UNITY_EDITOR
		string tmpPath = "";
		if(SCfg.self.isEditMode && !Application.isPlaying) {
			tmpPath = PStr.begin ()
				.a ("Assets/").a (PathCfg.self.basePath).a ("/").a ("upgradeResMedium").
					a ("/priority/atlas/").a(atlasName).a (".prefab").end ();
			UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath (tmpPath, typeof(UnityEngine.Object));
			if(obj != null) {
				return ((GameObject)obj).GetComponent<UIAtlas>();
			}
			return null;
		} else {
			return _getAtlasByName(atlasName);
		}
		#else
		return _getAtlasByName (atlasName);
		#endif
	}
	UIAtlas _getAtlasByName (string atlasName)
	{
		try {
			string tmpPath = PStr.begin ().a (PathCfg.persistentDataPath)
				.a ("/").a (PathCfg.self.basePath).a ("/").a ("upgradeRes").
					a ("/priority/atlas/").a (PathCfg.self.platform).a ("/").a (atlasName).a (".unity3d").end ();
			#if UNITY_EDITOR
			if(!SCfg.self.isNotEditorMode) {
				tmpPath = tmpPath.Replace("/upgradeRes/", "/upgradeRes4Publish/");
			}
			#endif
			AssetBundle atlasBundel = AssetBundle.LoadFromFile (tmpPath);
			if (atlasBundel != null) {
				GameObject go = atlasBundel.mainAsset as GameObject;
				atlasBundel.Unload (false);
				atlasBundel = null;
				if (go != null) {
					UIAtlas atlas = go.GetComponent<UIAtlas> ();
					atlasMap [atlasName] = atlas;
					return atlas;
				}
			}
			return null;
		} catch (System.Exception e) {
			Debug.LogError (e);
			return null;
		}
	}
}
