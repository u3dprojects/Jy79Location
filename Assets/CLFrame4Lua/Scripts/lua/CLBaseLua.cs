using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using System.Collections.Generic;

//把mobobehaviour的处理都转到lua层
public class CLBaseLua : MonoBehaviour
{
	public bool isPause = false;
	public string luaPath;
	public static LuaScriptMgr mainLua = new LuaScriptMgr ();
	public LuaScriptMgr lua;
	
	public virtual void setLua ()
	{
		doSetLua (false);
	}

	LuaTable _luaTable;
	public LuaTable luaTable;
//	{
//		get {
//			if(_luaTable == null) {
//				setLua();
//			}
//			return _luaTable;
//		}
//		set {
//			_luaTable = value;
//		}
//	}
	
	public object[] doSetLua (bool Independent)
	{
		object[] ret = null;
		try {
			luaFuncMap.Clear ();
			if (Independent) {
				lua = new LuaScriptMgr ();
				lua.Start ();
			} else {
				lua = mainLua;
			}
			if (!string.IsNullOrEmpty (luaPath)) {
				ret = Utl.doLua (lua, PathCfg.persistentDataPath + "/" + luaPath);
				if (ret != null && ret.Length > 0) {
					luaTable = (LuaTable)(ret [0]);
				}
			}
		} catch (System.Exception e) {
			Debug.LogError (e);
		}
		return ret;
	}

	Transform _tr; //缓存transform
	public Transform transform {
		get {
			if(_tr == null) {
				_tr = gameObject.transform;
			}
			return _tr;
		}
	}

	public void onNotifyLua(GameObject go, string funcName, object paras) {
		LuaFunction lfunc = null;
		if(!string.IsNullOrEmpty(funcName)) {
			lfunc = getLuaFunction (funcName);
		} else {
			lfunc = getLuaFunction ("onNotifyLua");
		}
		if(lfunc != null) {
			lfunc.Call(go, paras);
		}
	}

	public Dictionary<string, LuaFunction> luaFuncMap = new Dictionary<string, LuaFunction> ();
	
	public virtual LuaFunction getLuaFunction (string funcName)
	{
		if (string.IsNullOrEmpty (funcName))
			return null;
		LuaFunction ret = null;
		if (luaFuncMap.ContainsKey (funcName)) {
			ret = luaFuncMap [funcName]; 
		}
		if (ret == null && luaTable != null) {
			ret = (LuaFunction)(luaTable [funcName]);
			if (ret != null) {
				luaFuncMap [funcName] = ret;
			}
		}
		return ret;
	}
	
	public object getLuaVar (string name)
	{
		if (luaTable == null)
			return null;
		return  luaTable [name];
	}

	/// <summary>
	/// Invoke4s the lua.回调lua函数， 等待时间
	/// </summary>
	/// <param name='callbakFunc'>
	/// Callbak func.
	/// </param>
	/// <param name='sec'>
	/// Sec.
	/// </param>
	Hashtable coroutineMap = Hashtable.Synchronized (new Hashtable ());
	Hashtable coroutineIndex = Hashtable.Synchronized (new Hashtable ());
	
	public Coroutine invoke4Lua (string callbakFunc, float sec)
	{
		return invoke4Lua (callbakFunc, "", sec);
	}
	
	public Coroutine invoke4Lua (string callbakFunc, object orgs, float sec)
	{
		return invoke4Lua (callbakFunc, orgs, sec, false);
	}
	/// <summary>
	/// Invoke4s the lua.
	/// </summary>
	/// <param name="callbakFunc">Callbak func.lua函数</param>
	/// <param name="orgs">Orgs.参数</param>
	/// <param name="sec">Sec.等待时间</param>
	public Coroutine invoke4Lua (string callbakFunc, object orgs, float sec,  bool onlyOneCoroutine)
	{
		try {
			Coroutine ct = null;
			if(onlyOneCoroutine) {
				cleanCoroutines(callbakFunc);
			}
			int index = getCoroutineIndex(callbakFunc);
			ct = StartCoroutine ( doInvoke4Lua (callbakFunc, sec, orgs, index));
			setCoroutine(callbakFunc, ct, index);
			return ct;
		} catch (System.Exception e) {
			Debug.LogError (callbakFunc + ":" + e);
			return null;
		}
	}

	public int getCoroutineIndex(string callbakFunc) {
		int ret = 0;
		if (coroutineIndex.Contains (callbakFunc)) {
			ret = Toolkit.MapEx.getInt(coroutineIndex, callbakFunc);
		}
		coroutineIndex[callbakFunc] = ret + 1;
		return ret;
	}
	
	public void setCoroutineIndex(string callbakFunc, int val) {
		coroutineIndex[callbakFunc] = val;
	}

	public Hashtable getCoroutines(string callbakFunc) {
		if (coroutineMap [callbakFunc] == null) {
			coroutineMap [callbakFunc] = new Hashtable();
		}
		return (Hashtable)(coroutineMap [callbakFunc]);
	}
	public void setCoroutine(string callbakFunc, Coroutine ct, int index) {
		Hashtable map = getCoroutines (callbakFunc);
		map[index] = ct;
		coroutineMap [callbakFunc] = map;
	}

	public void cleanCoroutines(string callbakFunc) {
		Hashtable list = getCoroutines (callbakFunc);
		foreach(DictionaryEntry cell in list) {
			StopCoroutine((Coroutine)(cell.Value));
		}
		list.Clear();
		setCoroutineIndex (callbakFunc, 0);
		coroutineMap.Remove (callbakFunc);
	}

	
	public void rmCoroutine(string callbakFunc, int index) {
		Hashtable list = getCoroutines (callbakFunc);
		list.Remove (index);
		coroutineMap[callbakFunc] = list;
	}

	public void cancelInvoke4Lua (string callbakFunc)
	{
		if (string.IsNullOrEmpty (callbakFunc)) {
			#if UNITY_4_6 || UNITY_5
			Hashtable list = null;

			foreach(DictionaryEntry item in coroutineMap) {
				list = getCoroutines(item.Key.ToString());
				foreach(DictionaryEntry cell in list) {
					StopCoroutine((Coroutine)(cell.Value));
				}
				list.Clear();
			}
			#endif
			StopCoroutine ("doInvoke4Lua");
			coroutineMap.Clear ();
			coroutineIndex.Clear();
		} else {
			cleanCoroutines(callbakFunc);
		}
	}
	
	Queue invokeFuncs = new Queue ();
	
	IEnumerator doInvoke4Lua (string callbakFunc, float sec, object orgs, int index)
	{
		yield return new WaitForSeconds (sec);
		try {
//			if (coroutineMap [callbakFunc] != null) {
//				coroutineMap.Remove (callbakFunc);
			rmCoroutine(callbakFunc, index);

			LuaFunction f = getLuaFunction (callbakFunc);
			if (f != null) {
				if (!isPause) {
					f.Call (orgs);

				} else {
					ArrayList list = new ArrayList();
					list.Add(f);
					list.Add(orgs);
					list.Add(index);
					invokeFuncs.Enqueue (list);
				}
			}
//			}
		} catch (System.Exception e) {
			string msg = "call err:doInvoke4Lua" + ",callbakFunc=[" + callbakFunc + "]";
			NAlertTxt.add (msg, Color.red, -1);
			Debug.LogError (msg);
			Debug.LogError (e);
		}
	}
	
	public virtual void pause ()
	{
		isPause = true;
	}
	
	public virtual void regain ()
	{
		isPause = false;
		LuaFunction f = null;
		ArrayList invokeList = null;
		try {
			while (invokeFuncs.Count > 0) {
				invokeList = (ArrayList)(invokeFuncs.Dequeue ());
				f = (LuaFunction)(invokeList[0]);
				if (f != null) {
					f.Call (invokeList[1]);
				}
				invokeList.Clear();
				invokeList = null;
			}
		} catch (System.Exception e) {
			Debug.LogError (f != null ? f.name : "" + "==" + e);
		}
	}
	
	public virtual void OnDestroy ()
	{
		destoryLua();
	}

	public void destoryLua() {
		foreach (var cell in luaFuncMap) {
			if (cell.Value != null) {
				cell.Value.Release ();
			}
		}
		luaFuncMap.Clear ();
		if (luaTable != null) {
			luaTable.Dispose ();
			luaTable = null;
		}
	}
	//================================================
	// Fixed invoke 4 lua
	//================================================
	bool _doFixedUpdate = false;

	public bool canFixedInvoke {
		get {
			return _doFixedUpdate;
		}
		set {
			_doFixedUpdate = value;
			if (value) {
				if (fixedInvokeMap == null) {
					fixedInvokeMap = Hashtable.Synchronized (_fixedInvokeMap);
				}
			}
			if (!_doFixedUpdate) {
				frameCounter = 0;
			}
		}
	}
	//	public Dictionary<long, List<LuaFunction>> fixedInvokeMap = new Dictionary<long, List<LuaFunction>> ();
	Hashtable _fixedInvokeMap = new Hashtable ();
	public Hashtable fixedInvokeMap = null;
	
	public void fixedInvoke4Lua (string luaFunc,  float waitSec)
	{
		fixedInvoke4Lua (luaFunc,  null, waitSec);
	}
	public void fixedInvoke4Lua (string luaFunc, object paras, float waitSec)
	{
		LuaFunction func = getLuaFunction (luaFunc);
		if (func == null)
			return;
		fixedInvoke (func, paras, waitSec);
	}

	public void fixedInvoke(object callback, object paras, float waitSec) {
		if (fixedInvokeMap == null) {
			fixedInvokeMap = Hashtable.Synchronized (_fixedInvokeMap);
		}
		int waiteFrame = Mathf.CeilToInt (waitSec / Time.fixedDeltaTime);
		waiteFrame = waiteFrame <= 0 ? 1 : waiteFrame; //至少有帧
		long key = frameCounter + waiteFrame; 
		object[] content = new object[2];
		//		print (waiteFrame + "===" + key +"====" + luaFunc);
		List<object[]> funcList = (List<object[]>)(fixedInvokeMap [key]);
		if (funcList == null) {
			funcList = new List<object[]> ();
		}
		content [0] = callback;
		content [1] = paras;
		funcList.Add (content);
		fixedInvokeMap [key] = funcList;
	}

	public void cancelFixedInvoke4Lua (string funcName)
	{
		if (fixedInvokeMap == null)
			return;
		if (string.IsNullOrEmpty (funcName)) {
			fixedInvokeMap.Clear ();
			return;
		}
		LuaFunction func = getLuaFunction (funcName);
		if (func == null)
			return;
		List<object[]> list = null;
		int count = 0;
		object[] content = null;
		foreach (DictionaryEntry item in fixedInvokeMap) {
			list = (List<object[]>)(item.Value);
			count = list.Count;
			for(int i = count-1; i >=0; i--) {
				content = list[i];
				if(content[0] == func) {
					list.RemoveAt(i);
				}
			}
		}
	}
	
	void doFixedInvoke (long key)
	{
		object[] content = null;
		List<object[]> funcList = (List<object[]>)(fixedInvokeMap [key]);
		object callback = null;
		if (funcList != null) {
			for (int i = 0; i < funcList.Count; i++) {
				content = funcList[i];
				callback = content[0];
				if(callback is LuaFunction) {
					((LuaFunction)callback).Call (content[1]);
				} else if(callback is Callback){
					((Callback)callback)(content[1]);
				}
			}
			funcList.Clear ();
			funcList = null;
			fixedInvokeMap.Remove (key);
		}
	}

	//================================================
	// FixedUpdate
	//================================================
	public long frameCounter = 0;		//帧统计
	public virtual void FixedUpdate ()
	{
		if (canFixedInvoke) {
			frameCounter++;
			doFixedInvoke (frameCounter);
		}
	}
}
