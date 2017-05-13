using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;

/// <summary>
/// S effect pool.特效池
/// </summary>
public static class SEffectPool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate();
	public static bool isFinishInitPool = false;
	public static Hashtable effectPubPool = new Hashtable ();
	public static Hashtable prefabMap = new Hashtable ();

	public static void clean() {
		isFinishInitPool = false;
		effectPubPool.Clear();
		prefabMap.Clear();
	}
	
	public static void initPool ()
	{
		if (isFinishInitPool)
			return;
		isFinishInitPool = true;
		//TODO:
	}
	
	#region 设置预设
	//设置预设===========
	public static bool havePrefab (string name)
	{
		return prefabMap.Contains (name);
	}
	
	public static void setPrefab (string name, object finishCallback)
	{
		setPrefab (name, finishCallback,  null);
	}
	public static void setPrefab (string name, object finishCallback,  object args)
	{
		if (name == null)
			return;
		if (havePrefab(name)) {
			if (finishCallback != null) {
				if (typeof(LuaFunction) == finishCallback.GetType ()) {
                    ((LuaFunction)finishCallback).Call (prefabMap[name], args);
				} else if (typeof(Callback) == finishCallback.GetType ()) {
                    ((Callback)finishCallback) (prefabMap[name], args);	
				}
			}
		} else {
#if UNITY_EDITOR
			string path = PStr.begin(PathCfg.self.basePath,
				"/" + PathCfg.upgradeRes + "/other/effect/", 
				PathCfg.self.platform, "/", name, ".unity3d").end();
#else
            string path = PStr.begin(PathCfg.self.basePath,
                 "/upgradeRes/other/effect/", 
                 PathCfg.self.platform, "/", name, ".unity3d").end();
#endif
			Callback cb = onGetAssetsBundle;
			CLVerManager.self.getNewestRes(path, 
				CLAssetType.assetBundle, 
               cb, finishCallback, name, args);
		}
	}

	static void onGetAssetsBundle (params object[] paras)
	{
		string name ="";
		string path = "";
		try {
			if (paras != null) {
				path = (paras [0]).ToString ();
				AssetBundle asset = (paras [1]) as AssetBundle;
				object[] org = (object[])(paras [2]);
				object cb = org [0];
				name = (org [1]).ToString ();
                object args =  org [2];
//				GameObject go = asset.Load (name) as GameObject;
				GameObject go = asset.mainAsset as GameObject;
                go.name = name;
				SEffect unit = go.GetComponent<SEffect> ();
				prefabMap [unit.name] = unit;
//				CLTextureMgr tm = go.GetComponent<CLTextureMgr>();
//				if(tm != null) {
//					tm.Start();
//				}
                asset.Unload(false);
				SAssetsManager.self.addAsset (unit.name, asset, realseAsset);
			
				if (cb != null) {
					if (typeof(LuaFunction) == cb.GetType ()) {
                        ((LuaFunction)cb).Call (unit, args);
					} else if (typeof(Callback) == cb.GetType ()) {
                        ((Callback)cb) (unit, args);	
					}
				}
			} else {
				Debug.LogError ("Get effect assetsbundle failed!");
			}
		} catch(System.Exception e) {
			Debug.LogError("path==" + path + "," +e +name );
		}
	}
	
	//释放资源
	static void realseAsset (params object[] paras)
	{
		string name = "";
		try {
			name = paras [0].ToString ();
			object obj = effectPubPool [name];
			EffectPubPool pool = null;
			if (obj != null) {
				pool = obj as EffectPubPool;
			}
			if (pool == null)
				return;
			SEffect effect = null;
			while (pool.queue.Count > 0) {
				effect = pool.queue.Dequeue ();
				if(effect != null) {
                    GameObject.DestroyImmediate (effect.gameObject, true);
				}
                effect = null;
			}
			pool.queue.Clear ();

            SEffect unit = (SEffect)(prefabMap[name]);
            prefabMap.Remove (name);
//			SAssetsManager.unloadAsset(unit.gameObject);
            GameObject.DestroyImmediate(unit.gameObject, true);
            unit = null;
		} catch (System.Exception e) {
			Debug.LogError ("name==" + name +":" +e);
		}
	}
	
//	public static void setPrefab (SEffect unit)
//	{
//		if (unit == null)
//			return;
//		prefabMap [unit.name] = unit;
//	}
	#endregion
	
	public static EffectPubPool getEffectPool (string name)
	{
		object obj = effectPubPool [name];
		EffectPubPool pool = null;
		if (obj == null) {
			pool = new EffectPubPool ();
			effectPubPool [name] = pool;
		} else {
			pool = (EffectPubPool)obj;
		}
		return pool;
	}
	
	public static SEffect borrowEffect (string name)
	{
		SEffect r = null;
		object obj = effectPubPool [name];
		EffectPubPool pool = null;
		if (obj == null) {
			pool = new EffectPubPool ();
			effectPubPool [name] = pool;
		} else {
			pool = (EffectPubPool)obj;
		}
		r = pool.borrowObject (name);

		effectPubPool [name] = pool;
		SAssetsManager.self.useAsset (name);
		return r;
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
	public static void borrowEffectAsyn (string name, object onGetCallbak)
	{
		borrowEffectAsyn (name, onGetCallbak, null);
	}
	public static void borrowEffectAsyn (string name, object onGetCallbak, object orgs)
	{
		if (havePrefab (name)) {
			SEffect effect = borrowEffect (name);
			if (onGetCallbak != null) {
				if (onGetCallbak.GetType () == typeof(Callback)) {
					((Callback)onGetCallbak) (name, effect, orgs);
				} else if (onGetCallbak.GetType () == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call (name, effect, orgs);
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
			SEffect effect = paras [0] as SEffect; 
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
						effect = borrowEffect (name);
						if (cb.GetType () == typeof(Callback)) {
							((Callback)cb) (name, effect, orgs);
						} else if (cb.GetType () == typeof(LuaFunction)) {
							((LuaFunction)cb).Call (name, effect, orgs);
						}
					}
				}
			}
			list.Clear ();
			OnSetPrefabCallbacks.removeDelegates (name);
		}
	}

	public static void returnEffect (string name, SEffect effect)
	{
		object obj = effectPubPool [name];
		EffectPubPool pool = null;
		if (obj == null) {
			pool = new EffectPubPool ();
			effectPubPool [name] = pool;
		} else {
			pool = (EffectPubPool)obj;
		}
		pool.returnObject (effect);
		effectPubPool [name] = pool;
		effect.transform.parent = null;
		SAssetsManager.self.unUseAsset (name);
	}
	
}

public class EffectPubPool : AbstractObjectPool<SEffect>
{
	public override SEffect createObject (string key)
	{
		SEffect unit = (SEffect)(SEffectPool.prefabMap [key]);
		if (unit != null) {
			SEffect ret = GameObject.Instantiate (unit) as SEffect;
			ret.name = key;
			return ret;
		}
		return null;
	}
	
	public override SEffect resetObject (SEffect t)
	{
		return t;
	}
}


