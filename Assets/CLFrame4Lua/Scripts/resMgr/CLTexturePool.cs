using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;

public class CLTexturePool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate();
	public static Hashtable prefabMap = new Hashtable();
	//设置预设===========
	public static bool havePrefab(string path)
	{
		return prefabMap.Contains(path);
	}
	
	public static void clean()
	{
		prefabMap.Clear();
	}
	
	public static void setPrefab(string path, object finishCallback)
	{
		setPrefab(path, finishCallback, null);
	}

	public static void setPrefab(string path, object finishCallback, object args)
	{
		if (path == null) {
			return;
		}
		if (havePrefab(path)) {
			if (finishCallback != null) {
				if (typeof(LuaFunction) == finishCallback.GetType()) {
					((LuaFunction)finishCallback).Call(prefabMap [path], args);
				} else if (typeof(Callback) == finishCallback.GetType()) {
					((Callback)finishCallback)(prefabMap [path], args);   
				}
			}
		} else {
			Callback cb = onGetPrefab;
			CLVerManager.self.getNewestRes(path, 
			                               CLAssetType.assetBundle, 
			                               cb, finishCallback, args);
		}
	}
	
	static void onGetPrefab(params object[] paras)
	{
		if (paras != null && paras.Length > 2) {
			string path = paras [0].ToString();
			AssetBundle asset = (AssetBundle)(paras [1]);
			object[] orgs = (object[])(paras [2]);
			object cb = orgs [0];
			object list = orgs [1];
			
			if (asset == null) {
				if (cb != null) {
					if (typeof(LuaFunction) == cb.GetType()) {
						((LuaFunction)cb).Call(null);
					} else if (typeof(Callback) == cb.GetType()) {
						((Callback)cb)(null);  
					}
				}
				return;
			}
			Texture ac = asset.mainAsset as Texture;
			prefabMap [path] = ac;
			asset.Unload(false);
			SAssetsManager.self.addAsset(path, asset, realseAsset);
			if (cb != null) {
				if (typeof(LuaFunction) == cb.GetType()) {
					((LuaFunction)cb).Call(ac, list);
				} else if (typeof(Callback) == cb.GetType()) {
					((Callback)cb)(ac, list);
				}
			}
		} else {
			Debug.LogError("Set monster prefab failed!!");
		}
	}

	//释放资源
	static void realseAsset(params object[] paras)
	{
		try {
			string path = paras [0].ToString();
			Texture ac = (Texture)(prefabMap [path]);
			if (ac != null) {
				UnityEngine.Resources.UnloadAsset(ac);
				GameObject.DestroyImmediate(ac, true);
				ac = null;
				prefabMap.Remove(path);
			}
		} catch (System.Exception e) {
			Debug.LogError(e);
		}
	}
	
	public static Texture borrowTexture(string path)
	{
		SAssetsManager.self.useAsset(path);
		return (Texture)(prefabMap [path]);
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
	public static void borrowTextureAsyn (string path, object onGetCallbak)
	{
		borrowTextureAsyn (path, onGetCallbak, null);
	}
	public static void borrowTextureAsyn(string path, object onGetCallbak, object orgs)
	{
		if(havePrefab(path))  {
			Texture tex = borrowTexture(path);
			if(onGetCallbak != null) {
				if(onGetCallbak.GetType() == typeof(Callback)) {
					((Callback)onGetCallbak)(path, tex, orgs);
				} else if(onGetCallbak.GetType() == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call(path, tex, orgs);
				}
			}
		} else {
			OnSetPrefabCallbacks.add(path, onGetCallbak, orgs);
			setPrefab(path, (Callback)onFinishSetPrefab, path);
		}
	}

	public static void onFinishSetPrefab(object[] paras) {
		if(paras != null && paras.Length > 1) {
			Texture tex = paras[0] as Texture;
			string path = paras[1].ToString();
			ArrayList list = OnSetPrefabCallbacks.getDelegates(path);
			int count = list.Count;
			ArrayList cell = null;
			object cb = null;
			object orgs = null;
			for(int i=0; i< count; i++) {
				cell = list[i] as ArrayList;
				if(cell != null && cell.Count > 1) {
					cb = cell[0];
					orgs = cell[1];
					if(cb != null) {
						tex = borrowTexture(path);
						if(cb.GetType() == typeof(Callback)) {
							((Callback)cb)(path, tex, orgs);
						} else if(cb.GetType() == typeof(LuaFunction)) {
							((LuaFunction)cb).Call(path, tex, orgs);
						}
					}
				}
			}
			list.Clear();
			OnSetPrefabCallbacks.removeDelegates(path);
		}
	}

	
	public static void returnTexture(string path)
	{
		SAssetsManager.self.unUseAsset(path);
	}
}


