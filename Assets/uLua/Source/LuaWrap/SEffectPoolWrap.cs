using System;
using System.Collections;
using LuaInterface;

public class SEffectPoolWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("clean", clean),
			new LuaMethod("initPool", initPool),
			new LuaMethod("havePrefab", havePrefab),
			new LuaMethod("setPrefab", setPrefab),
			new LuaMethod("getEffectPool", getEffectPool),
			new LuaMethod("borrowEffect", borrowEffect),
			new LuaMethod("borrowEffectAsyn", borrowEffectAsyn),
			new LuaMethod("onFinishSetPrefab", onFinishSetPrefab),
			new LuaMethod("returnEffect", returnEffect),
			new LuaMethod("New", _CreateSEffectPool),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("OnSetPrefabCallbacks", get_OnSetPrefabCallbacks, set_OnSetPrefabCallbacks),
			new LuaField("isFinishInitPool", get_isFinishInitPool, set_isFinishInitPool),
			new LuaField("effectPubPool", get_effectPubPool, set_effectPubPool),
			new LuaField("prefabMap", get_prefabMap, set_prefabMap),
		};

		LuaScriptMgr.RegisterLib(L, "SEffectPool", typeof(SEffectPool), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSEffectPool(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SEffectPool class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SEffectPool);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_OnSetPrefabCallbacks(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, SEffectPool.OnSetPrefabCallbacks);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFinishInitPool(IntPtr L)
	{
		LuaScriptMgr.Push(L, SEffectPool.isFinishInitPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectPubPool(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, SEffectPool.effectPubPool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_prefabMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, SEffectPool.prefabMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_OnSetPrefabCallbacks(IntPtr L)
	{
		SEffectPool.OnSetPrefabCallbacks = (CLDelegate)LuaScriptMgr.GetNetObject(L, 3, typeof(CLDelegate));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isFinishInitPool(IntPtr L)
	{
		SEffectPool.isFinishInitPool = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectPubPool(IntPtr L)
	{
		SEffectPool.effectPubPool = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_prefabMap(IntPtr L)
	{
		SEffectPool.prefabMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		SEffectPool.clean();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initPool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		SEffectPool.initPool();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int havePrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = SEffectPool.havePrefab(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setPrefab(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			SEffectPool.setPrefab(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			SEffectPool.setPrefab(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SEffectPool.setPrefab");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getEffectPool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		EffectPubPool o = SEffectPool.getEffectPool(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int borrowEffect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		SEffect o = SEffectPool.borrowEffect(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int borrowEffectAsyn(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			SEffectPool.borrowEffectAsyn(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			SEffectPool.borrowEffectAsyn(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SEffectPool.borrowEffectAsyn");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object[] objs0 = LuaScriptMgr.GetArrayObject<object>(L, 1);
		SEffectPool.onFinishSetPrefab(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int returnEffect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		SEffect arg1 = (SEffect)LuaScriptMgr.GetUnityObject(L, 2, typeof(SEffect));
		SEffectPool.returnEffect(arg0,arg1);
		return 0;
	}
}

