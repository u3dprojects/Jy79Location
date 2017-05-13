using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;
using System.Collections.Generic;

/// <summary>
/// Bullet pool.子弹对象池
/// </summary>
public class CLBulletPool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate ();
	public static Hashtable poolMap = new Hashtable ();
	public static Hashtable prefabMap = new Hashtable ();


	public static void clean ()
	{
		poolMap.Clear ();
		prefabMap.Clear ();
	}

    #region 设置预设
	//设置预设===========
	public static bool havePrefab (string name)
	{
		return prefabMap.Contains (name);
	}
	
	public static void setPrefab (string name, object finishCallback)
	{
		setPrefab (name, finishCallback, null);
	}
	public static void setPrefab (string name, object finishCallback, object orgs)
	{
		if (name == null)
			return;
		if (havePrefab (name)) {
			if (finishCallback != null) {
				if (typeof(LuaFunction) == finishCallback.GetType ()) {
					((LuaFunction)finishCallback).Call (prefabMap [name], orgs);
				} else if (typeof(Callback) == finishCallback.GetType ()) {
					((Callback)finishCallback) (prefabMap [name], orgs);   
				}
			}
		} else {
#if UNITY_EDITOR
            string path = PStr.begin(PathCfg.self.basePath,
                                     "/"+PathCfg.upgradeRes+"/other/bullet/", 
                                     PathCfg.self.platform, "/", name, ".unity3d").end();
#else
			string path = PStr.begin (PathCfg.self.basePath,
                                     "/upgradeRes/other/bullet/", 
                                     PathCfg.self.platform, "/", name, ".unity3d").end ();
#endif
			Callback cb = onGetAssetsBundle;
			CLVerManager.self.getNewestRes (path, 
                    CLAssetType.assetBundle, 
                    cb, finishCallback, name, orgs);
		}
	}
    
	static void onGetAssetsBundle (params object[] paras)
	{
		if (paras != null) {
//          string path = (paras [0]).ToString ();
			AssetBundle asset = (paras [1]) as AssetBundle;
			object[] org = (object[])(paras [2]);
			object cb = org [0];
			string name = (org [1]).ToString ();
			object args = org [2];
			GameObject go = asset.mainAsset as GameObject;
			CLBullet bullet = null;
			if (go != null) {
				bullet = go.GetComponent<CLBullet> ();
				prefabMap [bullet.name] = bullet;
//				CLTextureMgr tm = go.GetComponent<CLTextureMgr>();
//				if(tm != null) {
//					tm.Start();
//				}
			} else {
				Debug.LogError ("Get bullet assetsbundle failed!");
			}
			asset.Unload (false);
			SAssetsManager.self.addAsset (bullet.name, asset, realseAsset);
			if (cb != null) {
				if (typeof(LuaFunction) == cb.GetType ()) {
					((LuaFunction)cb).Call (bullet, args);
				} else if (typeof(Callback) == cb.GetType ()) {
					((Callback)cb) (bullet, args); 
				}
			}
		} else {
			Debug.LogError ("Get bullet assetsbundle failed!");
		}
	}
	//释放资源
	public static void realseAsset (params object[] paras)
	{
		try {
			string name = paras [0].ToString ();
			object obj = poolMap [name];
			_BulletPool pool = null;
			if (obj != null) {
				pool = obj as _BulletPool;
			}

			while (pool.queue.Count > 0) {
				GameObject.DestroyImmediate (pool.queue.Dequeue ().gameObject, true);
			}
			pool.queue.Clear ();
            
			CLBullet bullet = (CLBullet)(prefabMap [name]);
			prefabMap.Remove (name);
//			SAssetsManager.unloadAsset(bullet.gameObject);

			if (bullet != null) {
				GameObject.DestroyImmediate (bullet.gameObject, true);
				bullet = null;
			}
		} catch (System.Exception e) {
			Debug.LogError (e);
		}
	}
    
    #endregion
    
	public static CLBullet borrowBullet (string name)
	{
		object obj = poolMap [name];
		_BulletPool pool = null;
		CLBullet ret = null;
		if (obj == null) {
			pool = new _BulletPool ();
			poolMap [name] = pool;
		} else {
			pool = obj as _BulletPool;
		}
		ret = pool.borrowObject (name);
		poolMap [name] = pool;
		SAssetsManager.self.useAsset (name);
		return ret;
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
	public static void borrowBulletAsyn (string name, object onGetCallbak)
	{
		borrowBulletAsyn (name, onGetCallbak, null);
	}
	public static void borrowBulletAsyn (string name, object onGetCallbak, object orgs)
	{
		if (havePrefab (name)) {
			CLBullet bullet = borrowBullet (name);
			if (onGetCallbak != null) {
				if (onGetCallbak.GetType () == typeof(Callback)) {
					((Callback)onGetCallbak) (name, bullet, orgs);
				} else if (onGetCallbak.GetType () == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call (name, bullet, orgs);
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
			CLBullet bullet = paras [0] as CLBullet;
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
						bullet = borrowBullet (name);
						if (cb.GetType () == typeof(Callback)) {
							((Callback)cb) (name, bullet, orgs);
						} else if (cb.GetType () == typeof(LuaFunction)) {
							((LuaFunction)cb).Call (name, bullet, orgs);
						}
					}
				}
			}
			list.Clear ();
			OnSetPrefabCallbacks.removeDelegates (name);
		}
	}
    
	public static void returnBullet (CLBullet unit)
	{
		if (unit == null)
			return;
        
		object obj = poolMap [unit.name];
		_BulletPool pool = null;
		if (obj == null) {
			pool = new _BulletPool ();
			poolMap [unit.name] = pool;
		} else {
			pool = obj as _BulletPool;
		}
		pool.returnObject (unit);
		unit.transform.parent = null;
        
		SAssetsManager.self.unUseAsset (unit.name);
		poolMap [unit.name] = pool;
	}
}

public class _BulletPool : AbstractObjectPool<CLBullet>
{
	public override CLBullet createObject (string key = null)
	{
		CLBullet unit = (CLBullet)(CLBulletPool.prefabMap [key]);
		if (unit != null) {
			CLBullet ret = GameObject.Instantiate (unit) as CLBullet;
			ret.name = key;
			return ret;
		}
		return null;
	}

	public override CLBullet resetObject (CLBullet t)
	{
		return t;
	}
}
