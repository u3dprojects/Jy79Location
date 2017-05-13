using UnityEngine;
using System.Collections;
using Toolkit;
using LuaInterface;
using System.Collections.Generic;

//怪物的对象池
public class CLRolePool
{
	public static CLDelegate OnSetPrefabCallbacks = new CLDelegate();
	public static Hashtable poolMap = new Hashtable();
    public static Hashtable prefabMap = new Hashtable();

	public static void clean() {
		poolMap.Clear();
		prefabMap.Clear();
	}

    #region 设置预设
    //设置预设===========
    public static bool havePrefab(string name)
    {
        return prefabMap.Contains(name);
    }

    public static bool isNeedDownload(string roleName) {
        if(SCfg.self.isEditMode) {
            return false;
        }
        #if UNITY_EDITOR
        string path = PStr.begin(PathCfg.self.basePath,
                                 "/"+PathCfg.upgradeRes + "/other/roles/", 
                                 PathCfg.self.platform, "/", roleName, ".unity3d").end();
        #else
        string path = PStr.begin(PathCfg.self.basePath,
                                 "/upgradeRes/other/roles/", 
                                 PathCfg.self.platform, "/", roleName, ".unity3d").end();
        #endif
        return CLVerManager.self.checkNeedDownload(path);
    }
	
	public static void setPrefab(string name, object finishCallback)
	{
		setPrefab(name, finishCallback, null);
	}
    public static void setPrefab(string name, object finishCallback, object args)
    {
        if (name == null)
            return;
        if (havePrefab(name))
        {
            if (finishCallback != null)
            {
                if (typeof(LuaFunction) == finishCallback.GetType())
                {
                    ((LuaFunction)finishCallback).Call(prefabMap [name], args);
                } else if (typeof(Callback) == finishCallback.GetType())
                {
                    ((Callback)finishCallback)(prefabMap [name], args);   
                }
            }
        } else
        {
#if UNITY_EDITOR
            string path = PStr.begin(PathCfg.self.basePath,
	             "/"+PathCfg.upgradeRes + "/other/roles/", 
	            PathCfg.self.platform, "/", name, ".unity3d").end();
#else
            string path = PStr.begin(PathCfg.self.basePath,
                                     "/upgradeRes/other/roles/", 
                                     PathCfg.self.platform, "/", name, ".unity3d").end();
#endif
            Callback cb = onGetAssetsBundle;
            CLVerManager.self.getNewestRes(path, 
                    CLAssetType.assetBundle, 
                   cb, finishCallback, name, args);
        }
    }
	
    static void onGetAssetsBundle(params object[] paras)
    {
        string name = "";
        try
        {
            if (paras != null)
            {
//          string path = (paras [0]).ToString ();
                AssetBundle asset = (paras [1]) as AssetBundle;
                object[] org = (object[])(paras [2]);
                object cb = org [0];
                name = (org [1]).ToString();
                object args = org[2];
				GameObject go = asset.mainAsset as GameObject;
                go.name = name;
				SUnit unit = go.GetComponent<SUnit>();
				prefabMap [unit.name] = unit;
//				CLTextureMgr tm = go.GetComponent<CLTextureMgr>();
//				if(tm != null) {
//					tm.Start();
//				}
                asset.Unload(false);

                SAssetsManager.self.addAsset(unit.name, asset, realseAsset);
                if (cb != null)
                {
                    if (typeof(LuaFunction) == cb.GetType())
                    {
                        ((LuaFunction)cb).Call(unit, args);
                    } else if (typeof(Callback) == cb.GetType())
                    {
                        ((Callback)cb)(unit, args);   
                    }
                }
            } else
            {
                Debug.LogError("Get monster assetsbundle failed!");
            }
        } catch (System.Exception e)
        {
            Debug.LogError("name==" + name + "," + e);
        }
    }
    //释放资源
    static void realseAsset(params object[] paras)
    {
        try
        {
            string name = paras [0].ToString();
            object obj = poolMap [name];
            _MonsterPool pool = null;
            if (obj != null)
            {
                pool = obj as _MonsterPool;
            }
            while (pool.queue.Count > 0)
            {
                GameObject.DestroyImmediate(pool.queue.Dequeue().gameObject, true);
            }
            pool.queue.Clear();

			SUnit unit = (SUnit)(prefabMap[name]);
            prefabMap.Remove(name);
//			SAssetsManager.unloadAsset(unit.gameObject);
            GameObject.DestroyImmediate(unit.gameObject, true);
            unit = null;
        } catch (System.Exception e)
        {
            Debug.LogError(e);
        }
    }
    
//  public static void setPrefab (SUnit unit)
//  {
//      if (unit == null)
//          return;
//      prefabMap [unit.name] = unit;
//  }
    #endregion
    
	public static SUnit borrowUnit(string name)
    {
        object obj = poolMap [name];
        _MonsterPool pool = null;
		SUnit ret = null;
        if (obj == null)
        {
            pool = new _MonsterPool();
            poolMap [name] = pool;
        } else
        {
            pool = obj as _MonsterPool;
        }
        ret = pool.borrowObject(name);
        poolMap [name] = pool;
        SAssetsManager.self.useAsset(name);
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
	public static void borrowUnitAsyn (string name, object onGetCallbak)
	{
		borrowUnitAsyn (name, onGetCallbak, null);
	}
	public static void borrowUnitAsyn (string name, object onGetCallbak, object orgs)
	{
		if (havePrefab (name)) {
			SUnit unit = borrowUnit (name);
			if (onGetCallbak != null) {
				if (onGetCallbak.GetType () == typeof(Callback)) {
					((Callback)onGetCallbak) (name, unit, orgs);
				} else if (onGetCallbak.GetType () == typeof(LuaFunction)) {
					((LuaFunction)onGetCallbak).Call (name, unit, orgs);
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
			SUnit unit = paras [0] as SUnit; 
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
						unit = borrowUnit (name);
						if (cb.GetType () == typeof(Callback)) {
							((Callback)cb) (name, unit, orgs);
						} else if (cb.GetType () == typeof(LuaFunction)) {
							((LuaFunction)cb).Call (name, unit, orgs);
						}
					}
				}
			}
			list.Clear ();
			OnSetPrefabCallbacks.removeDelegates (name);
		}
	}
	public static void returnUnit(SUnit unit)
    {
        if (unit == null)
            return;
        
        object obj = poolMap [unit.name];
        _MonsterPool pool = null;
        if (obj == null)
        {
            pool = new _MonsterPool();
            poolMap [unit.name] = pool;
        } else
        {
            pool = obj as _MonsterPool;
        }
        unit.clean();
        pool.returnObject(unit);
		unit.transform.parent = null;
        SAssetsManager.self.unUseAsset(unit.name);
        poolMap [unit.name] = pool;
    }
}

public class _MonsterPool : AbstractObjectPool<SUnit>
{
	public override SUnit createObject(string key = null)
    {
		SUnit unit = (SUnit)(CLRolePool.prefabMap [key]);
        if (unit != null)
        {
			SUnit ret = GameObject.Instantiate(unit) as SUnit;
            ret.name = key;
            return ret;
        }
        return null;
    }

	public override SUnit resetObject(SUnit t)
    {
        return t;
    }
}
