using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;

public class CLMaterialPool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate();
	public static Hashtable prefabMap = new Hashtable ();
	//设置预设===========
	public static bool havePrefab (string name)
	{
		return prefabMap.Contains (name);
	}
	
	public static void clean() {
		prefabMap.Clear();
	}
	
	public static void setPrefab (string name, object finishCallback)
	{
		setPrefab (name, finishCallback,  null);
	}
	public static void setPrefab (string name, object finishCallback, object args)
	{
		if (name == null)
			return;
		if (havePrefab(name)) {
			if (finishCallback != null) {
				if (typeof(LuaFunction) == finishCallback.GetType()) {
					((LuaFunction)finishCallback).Call(prefabMap [name], args);
				} else if (typeof(Callback) == finishCallback.GetType()) {
					((Callback)finishCallback)(prefabMap [name], args);   
				}
			}
		} else {
			#if UNITY_EDITOR
			string path = PStr.begin(PathCfg.self.basePath,
			                         "/"+PathCfg.upgradeRes+"/other/Materials/", 
			                         PathCfg.self.platform, "/", name, ".unity3d").end();
			#else
			string path = PStr.begin(PathCfg.self.basePath,
			                         "/upgradeRes/other/Materials/", 
			                         PathCfg.self.platform, "/", name, ".unity3d").end();
			#endif
			Callback cb = onGetPrefab;
			CLVerManager.self.getNewestRes(path, 
			                               CLAssetType.assetBundle, 
			                               cb, finishCallback, name, args);
		}
	}
	
	static void onGetPrefab (params object[] paras)
	{
		if (paras != null && paras.Length > 2) {
			//          string path = paras [0].ToString ();
			AssetBundle  asset = (AssetBundle)(paras [1]);
			object[] orgs = (object[])(paras [2]);
			object cb = orgs [0];
			string name = orgs [1].ToString ();
			object list = orgs[2];
			
			if(asset == null) {
				if (cb != null) {
					if (typeof(LuaFunction) == cb.GetType ()) {
						((LuaFunction)cb).Call (null, list);
					} else if (typeof(Callback) == cb.GetType ()) {
						((Callback)cb) (null, list);  
					}
				}
				return;
			}
			Material ac = asset.mainAsset as Material;
			ac.name = name;
			prefabMap [name] = ac;
			asset.Unload(false);
			SAssetsManager.self.addAsset (name, asset, realseAsset);
			if (cb != null) {
				if (typeof(LuaFunction) == cb.GetType ()) {
					((LuaFunction)cb).Call (ac, list);
				} else if (typeof(Callback) == cb.GetType ()) {
					((Callback)cb) (ac, list);
				}
			}
		} else {
			Debug.LogError ("Set monster prefab failed!!");
		}
	}

	//释放资源
	static void realseAsset (params object[] paras)
	{
		try {
			string name = paras [0].ToString ();
			Material ac = (Material)(prefabMap[name]);
			if(ac  != null) {
				UnityEngine.Resources.UnloadAsset(ac);
				GameObject.DestroyImmediate(ac, true);
				ac = null;
				prefabMap.Remove (name);
			}
		} catch (System.Exception e) {
			Debug.LogError (e);
		}
	}
	
	public static Material borrowMat (string name)
	{
		SAssetsManager.self.useAsset(name);
		return (Material)(prefabMap [name]) ;
	}
	
	/// <summary>
	/// Borrows the texture asyn.
	/// 异步取得texture
	/// </summary>
	/// <returns>The texture asyn.</returns>
	/// <param name="path">Path.</param>
	/// <param name="onGetTexture">On get texture.</param>
	/// 回调函数
	/// <param name="org">Org.</param>
	/// 透传参数
	public static void borrowMatAsyn (string name, object onGetCallbak)
	{
		borrowMatAsyn (name, onGetCallbak, null);
	}
	public static void borrowMatAsyn (string name, object onGetCallbak, object orgs)
	{
		if (havePrefab (name)) {
			Material mat = borrowMat (name);
			if (onGetCallbak != null) {
				if (onGetCallbak.GetType () == typeof(Callback)) {
					((Callback)onGetCallbak) (name, mat, orgs);
				} else if (onGetCallbak.GetType () == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call (name, mat, orgs);
				}
			}
		} else {
			OnSetPrefabCallbacks.add (name, onGetCallbak, orgs);
			setPrefab (name, (Callback)onFinishSetPrefab, name);
		}
	}
	
	public static void onFinishSetPrefab (object[] paras)
	{
		if (paras != null && paras.Length > 1) {
			Material mat = paras [0] as Material; 
			string name = paras [1].ToString ();
			ArrayList list = OnSetPrefabCallbacks.getDelegates (name);
			int count = list.Count;
			ArrayList cell = null;
			object cb = null;
			object orgs = null;
			for (int i=0; i< count; i++) {
				cell = list [i] as ArrayList;
				if (cell != null && cell.Count > 1) {
					cb = cell [0];
					orgs = cell [1];
					if (cb != null) {
						mat = borrowMat (name);
						if (cb.GetType () == typeof(Callback)) {
							((Callback)cb) (name, mat, orgs);
						} else if (cb.GetType () == typeof(LuaFunction)) {
							((LuaFunction)cb).Call (name, mat, orgs);
						}
					}
				}
			}
			list.Clear ();
			OnSetPrefabCallbacks.removeDelegates (name);
		}
	}
	
	public static void returnMat(string name) {
		SAssetsManager.self.unUseAsset(name);
	}
}
