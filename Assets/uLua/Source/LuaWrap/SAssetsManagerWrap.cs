using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SAssetsManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("addAsset", addAsset),
			new LuaMethod("useAsset", useAsset),
			new LuaMethod("unUseAsset", unUseAsset),
			new LuaMethod("getAsset", getAsset),
			new LuaMethod("_releaseAsset", _releaseAsset),
			new LuaMethod("releaseAsset", releaseAsset),
			new LuaMethod("New", _CreateSAssetsManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("isForceRelease", get_isForceRelease, set_isForceRelease),
			new LuaField("realseTime", get_realseTime, set_realseTime),
			new LuaField("assetsMap", get_assetsMap, set_assetsMap),
		};

		LuaScriptMgr.RegisterLib(L, "SAssetsManager", typeof(SAssetsManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSAssetsManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SAssetsManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SAssetsManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, SAssetsManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isForceRelease(IntPtr L)
	{
		LuaScriptMgr.Push(L, SAssetsManager.isForceRelease);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realseTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, SAssetsManager.realseTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_assetsMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SAssetsManager obj = (SAssetsManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name assetsMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index assetsMap on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.assetsMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		SAssetsManager.self = (SAssetsManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(SAssetsManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isForceRelease(IntPtr L)
	{
		SAssetsManager.isForceRelease = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realseTime(IntPtr L)
	{
		SAssetsManager.realseTime = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_assetsMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SAssetsManager obj = (SAssetsManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name assetsMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index assetsMap on a nil value");
			}
		}

		obj.assetsMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AssetBundle arg1 = (AssetBundle)LuaScriptMgr.GetUnityObject(L, 3, typeof(AssetBundle));
		Callback arg2 = null;
		LuaTypes funcType4 = LuaDLL.lua_type(L, 4);

		if (funcType4 != LuaTypes.LUA_TFUNCTION)
		{
			 arg2 = (Callback)LuaScriptMgr.GetNetObject(L, 4, typeof(Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 4);
			arg2 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushArray(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.addAsset(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int useAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.useAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int unUseAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.unUseAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj.getAsset(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _releaseAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		obj._releaseAsset();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int releaseAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		SAssetsManager obj = (SAssetsManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SAssetsManager");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.releaseAsset(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Object arg0 = LuaScriptMgr.GetLuaObject(L, 1) as Object;
		Object arg1 = LuaScriptMgr.GetLuaObject(L, 2) as Object;
		bool o = arg0 == arg1;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

