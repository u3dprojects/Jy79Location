using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;
	
/// <summary>
/// CL other object pool.的其它物件对象池
/// </summary>
public static class CLThingsPool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate ();
	public static bool isFinishInitPool = false;
	public static Hashtable objPubPool = new Hashtable ();
	public static Hashtable prefabMap = new Hashtable ();
		
	public static void clean ()
	{
		isFinishInitPool = false;
		objPubPool.Clear ();
		prefabMap.Clear ();
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
		
	public static void setPrefab (string name, object finishCallback, object args)
	{
		if (name == null)
			return;
		if (havePrefab (name)) {
			if (finishCallback != null) {
				if (typeof(LuaFunction) == finishCallback.GetType ()) {
					((LuaFunction)finishCallback).Call (prefabMap [name], args);
				} else if (typeof(Callback) == finishCallback.GetType ()) {
					((Callback)finishCallback) (prefabMap [name], args);	
				}
			}
		} else {
			string path = wrapPath(name);
			Callback cb = onGetAssetsBundle;
			CLVerManager.self.getNewestRes (path, 
				                               CLAssetType.assetBundle, 
				                               cb, finishCallback, name, args);
		}
	}

	public static string wrapPath(string thingName) {
		string[] strs = thingName.Split ('/');
		string path = PStr.begin (PathCfg.self.basePath,
		                          "/", PathCfg.upgradeRes, "/other/things/").end ();
		int len = strs.Length;
		for(int i =0; i < len-1; i++) {
			path = PStr.begin(path).a (strs[i]).a ("/").end();
		}
		path = PStr.begin(path).a(PathCfg.self.platform).a ("/").a (strs[len -1]).a (".unity3d").end ();
		return path;
	}

	static void onGetAssetsBundle (params object[] paras)
	{
		string name = "";
		string path = "";
		try {
			if (paras != null) {
				path = (paras [0]).ToString ();
				AssetBundle asset = (paras [1]) as AssetBundle;
				object[] org = (object[])(paras [2]);
				object cb = org [0];
				name = (org [1]).ToString ();
				object args = org [2];
				//				GameObject go = asset.Load (name) as GameObject;
				GameObject go = asset.mainAsset as GameObject;
				go.name = name;
				prefabMap [name] = go;
				asset.Unload (false);
				SAssetsManager.self.addAsset (name, asset, realseAsset);
					
				if (cb != null) {
					if (typeof(LuaFunction) == cb.GetType ()) {
						((LuaFunction)cb).Call (go, args);
					} else if (typeof(Callback) == cb.GetType ()) {
						((Callback)cb) (go, args);	
					}
				}
			} else {
				Debug.LogError ("Get effect assetsbundle failed!");
			}
		} catch (System.Exception e) {
			Debug.LogError ("path==" + path + "," + e + name);
		}
	}
		
	//释放资源
	static void realseAsset (params object[] paras)
	{
		string name = "";
		try {
			name = paras [0].ToString ();
			object obj = objPubPool [name];
			OtherObjPubPool pool = null;
			if (obj != null) {
				pool = obj as OtherObjPubPool;
			}
			if (pool == null)
				return;
			GameObject go = null;
			while (pool.queue.Count > 0) {
				go = pool.queue.Dequeue ();
				if (go != null) {
					GameObject.DestroyImmediate (go, true);
				}
				go = null;
			}
			pool.queue.Clear ();
				
			GameObject unit = (GameObject)(prefabMap [name]);
			prefabMap.Remove (name);
			//			SAssetsManager.unloadAsset(unit.gameObject);
			GameObject.DestroyImmediate (unit, true);
			unit = null;
		} catch (System.Exception e) {
			Debug.LogError ("name==" + name + ":" + e);
		}
	}
		
#endregion
		
	public static OtherObjPubPool getObjPool (string name)
	{
		object obj = objPubPool [name];
		OtherObjPubPool pool = null;
		if (obj == null) {
			pool = new OtherObjPubPool ();
			objPubPool [name] = pool;
		} else {
			pool = (OtherObjPubPool)obj;
		}
		return pool;
	}
		
	public static GameObject borrowObj (string name)
	{
		GameObject r = null;
		OtherObjPubPool pool = getObjPool(name);
		r = pool.borrowObject (name);
		r.name = name;
		objPubPool [name] = pool;
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
	public static void borrowObjAsyn (string name, object onGetCallbak)
	{
		borrowObjAsyn (name, onGetCallbak, null);
	}

	public static void borrowObjAsyn (string name, object onGetCallbak, object orgs)
	{
		if (havePrefab (name)) {
			GameObject go = borrowObj (name);
			if (onGetCallbak != null) {
				if (onGetCallbak.GetType () == typeof(Callback)) {
					((Callback)onGetCallbak) (name, go, orgs);
				} else if (onGetCallbak.GetType () == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call (name, go, orgs);
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
			GameObject go = paras [0] as GameObject; 
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
						go = borrowObj (name);
						if (cb.GetType () == typeof(Callback)) {
							((Callback)cb) (name, go, orgs);
						} else if (cb.GetType () == typeof(LuaFunction)) {
							((LuaFunction)cb).Call (name, go, orgs);
						}
					}
				}
			}
			list.Clear ();
			OnSetPrefabCallbacks.removeDelegates (name);
		}
	}
		
	public static void returnObj (string name, GameObject go)
	{
		OtherObjPubPool pool = getObjPool(name);
		pool.returnObject (go);
		go.transform.parent = null;
		objPubPool [name] = pool;
		SAssetsManager.self.unUseAsset (name);
	}
		
}
	
public class OtherObjPubPool : AbstractObjectPool<GameObject>
{
	public override GameObject createObject (string key)
	{
		GameObject unit = (GameObject)(CLThingsPool.prefabMap [key]);
		if (unit != null) {
			GameObject ret = GameObject.Instantiate (unit) as GameObject;
			ret.name = key;
			return ret;
		}
		return null;
	}
		
	public override GameObject resetObject (GameObject t)
	{
		return t;
	}
}
	
