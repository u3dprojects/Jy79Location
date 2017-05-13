using System;
using System.Collections;
using UnityEngine;
using LuaInterface;

public class CLUIOtherObjPoolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("clean", clean),
			new LuaMethod("initPool", initPool),
			new LuaMethod("havePrefab", havePrefab),
			new LuaMethod("setPrefab", setPrefab),
			new LuaMethod("getObjPool", getObjPool),
			new LuaMethod("borrowObj", borrowObj),
			new LuaMethod("borrowObjAsyn", borrowObjAsyn),
			new LuaMethod("onFinishSetPrefab", onFinishSetPrefab),
			new LuaMethod("returnObj", returnObj),
			new LuaMethod("New", _CreateCLUIOtherObjPool),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("OnSetPrefabCallbacks", get_OnSetPrefabCallbacks, set_OnSetPrefabCallbacks),
			new LuaField("isFinishInitPool", get_isFinishInitPool, set_isFinishInitPool),
			new LuaField("objPubPool", get_objPubPool, set_objPubPool),
			new LuaField("prefabMap", get_prefabMap, set_prefabMap),
		};

		LuaScriptMgr.RegisterLib(L, "CLUIOtherObjPool", typeof(CLUIOtherObjPool), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLUIOtherObjPool(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLUIOtherObjPool class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLUIOtherObjPool);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnSetPrefabCallbacks(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLUIOtherObjPool.OnSetPrefabCallbacks);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFinishInitPool(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLUIOtherObjPool.isFinishInitPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_objPubPool(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLUIOtherObjPool.objPubPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prefabMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLUIOtherObjPool.prefabMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnSetPrefabCallbacks(IntPtr L)
	{
		CLUIOtherObjPool.OnSetPrefabCallbacks = (CLDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(CLDelegate));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isFinishInitPool(IntPtr L)
	{
		CLUIOtherObjPool.isFinishInitPool = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_objPubPool(IntPtr L)
	{
		CLUIOtherObjPool.objPubPool = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prefabMap(IntPtr L)
	{
		CLUIOtherObjPool.prefabMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CLUIOtherObjPool.clean();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initPool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CLUIOtherObjPool.initPool();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int havePrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = CLUIOtherObjPool.havePrefab(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		CLUIOtherObjPool.setPrefab(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getObjPool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		UIOtherObjPubPool o = CLUIOtherObjPool.getObjPool(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int borrowObj(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = CLUIOtherObjPool.borrowObj(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int borrowObjAsyn(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			CLUIOtherObjPool.borrowObjAsyn(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			CLUIOtherObjPool.borrowObjAsyn(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIOtherObjPool.borrowObjAsyn");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object[] objs0 = LuaScriptMgr.GetArrayObject<object>(L, 1);
		CLUIOtherObjPool.onFinishSetPrefab(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int returnObj(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		CLUIOtherObjPool.returnObj(arg0,arg1);
		return 0;
	}
}

