using UnityEngine;
using System.Collections;

/// <summary>
/// CLDB cfg.配制数据存储（不能把数据放在lua则，因为在不同的lua环境中，取数据会重新加载）
/// </summary>
using Toolkit;
using LuaInterface;


public static class CLDBCfg
{
	private static Hashtable mdb = new Hashtable ();	// 原始配置数据
	public static Hashtable db = new Hashtable ();	// 经过处理后的配置数据

	public static void clean ()
	{
		mdb.Clear ();
		db.Clear ();
	}

	public static  ArrayList getDatas (string cfgPath)
	{
		if (string.IsNullOrEmpty (cfgPath)) {
			return new ArrayList ();
		}
		ArrayList list = (ArrayList)(mdb [cfgPath]);
		if (list == null) {
			list =  new ArrayList();
			ArrayList _list = (ArrayList)(Utl.fileToObj (cfgPath));
			if(_list == null || _list.Count < 2) {
				mdb [cfgPath] = list;
				return list;
			}
			int count = _list.Count;
			int n = 0;
			ArrayList keys = (ArrayList)(_list[0]);
			ArrayList cellList = null;
			Hashtable cell = null;
			for(int i=1; i < count; i++) {
				cellList = (ArrayList)(_list[i]);
				n = cellList.Count;
				cell = new Hashtable();
				CLMain.self.lua.lua.NewTable();
				for(int j=0; j < n; j++) {
					cell[keys[j]] = cellList[j]; 
				}
				list.Add(cell);
			}
			mdb [cfgPath] = list;
		}
		Debug.LogError(list.Count);
		return list;
	}
	
	public  static Hashtable select (string cfgPath, string key, object val)
	{
		return select (cfgPath, key, val, null, null, null, null);
	}

	public  static Hashtable select (string cfgPath, string key, object val, string key2, object val2)
	{
		return select (cfgPath, key, val, key2, val2, null, null);
	}

	public  static Hashtable select (string cfgPath, string key, object val, string key2, object val2, string key3, object val3)
	{
		ArrayList list = getDatas (cfgPath);
		int count = list.Count;
		Hashtable cell = null;
		for (int i = 0; i < count - 1; i++) {
			cell = (Hashtable)(list [i]);
			if (string.Compare (cell [key].ToString (), val.ToString ()) == 0
				&& (string.IsNullOrEmpty (key2) || (string.Compare (cell [key2].ToString (), val2.ToString ()) == 0))
				&& (string.IsNullOrEmpty (key3) || (string.Compare (cell [key3].ToString (), val3.ToString ()) == 0))
			   ) {
				return cell;
			}
		}
		return new Hashtable ();
	}

	public static bool isLoaded (string cfgPath)
	{
		if (db [cfgPath] != null) {
			return true;
		}
		return false;
	}

	public static Hashtable pariseWithGID (string cfgPath)
	{
		if (db [cfgPath] != null) {
			return (Hashtable)(db [cfgPath]);
		}
		ArrayList datas = getDatas (cfgPath);
		Hashtable dbMap = new Hashtable ();
		int count = datas.Count;
		Hashtable item = null;
		int gid = 0;
		for (int i=0; i  < count; i++) {
			item = (Hashtable)(datas [i]);
			gid = NumEx.bio2Int ((byte[])(item ["GID"]));
			dbMap [gid.ToString ()] = datas [i];
		}
		return dbMap;
	}
	
	public static Hashtable pariseWithID (string cfgPath)
	{
		if (db [cfgPath] != null) {
			return (Hashtable)(db [cfgPath]);
		}
		ArrayList datas = getDatas (cfgPath);
		Hashtable dbMap = new Hashtable ();
		int count = datas.Count;
		Hashtable item = null;
		int gid = 0;
		for (int i=0; i  < count; i++) {
			item = (Hashtable)(datas [i]);
			gid = NumEx.bio2Int ((byte[])(item ["ID"]));
			dbMap [gid.ToString ()] = item;
		}
		return dbMap;
	}

	public static object getCfgData (string func, params object[] paras)
	{
		object obj = null;
		ArrayList list = null;
		if (paras == null || paras.Length == 0) {
			obj = null;
		} else if (paras.Length == 1) {
			obj = paras [0];
		} else {
			list = new ArrayList ();
			for (int i=0; i < paras.Length; i++) {
				list.Add (paras [i]);
			}
			obj = list;
		}

		object[] ret = CLMain.self.lua.CallLuaFunction("CLLDBCfg", func, obj);

		if (list != null) {
			list.Clear ();
			list = null;
		}
		obj = null;
		if (ret != null && ret.Length > 0) {
			return ret [0];
		}
		return null;
	}

}
