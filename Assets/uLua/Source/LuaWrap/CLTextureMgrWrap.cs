using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLTextureMgrWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Start", Start),
			new LuaMethod("init", init),
			new LuaMethod("OnDestroy", OnDestroy),
			new LuaMethod("cleanMat", cleanMat),
			new LuaMethod("resetMat", resetMat),
			new LuaMethod("resetMat2", resetMat2),
			new LuaMethod("New", _CreateCLTextureMgr),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("data", get_data, set_data),
		};

		LuaScriptMgr.RegisterLib(L, "CLTextureMgr", typeof(CLTextureMgr), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLTextureMgr(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLTextureMgr class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLTextureMgr);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLTextureMgr obj = (CLTextureMgr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index data on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.data);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_data(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLTextureMgr obj = (CLTextureMgr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name data");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index data on a nil value");
			}
		}

		obj.data = (List<CLTexture>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<CLTexture>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.init(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		obj.OnDestroy();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cleanMat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		obj.cleanMat();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetMat(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		obj.resetMat();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetMat2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLTextureMgr obj = (CLTextureMgr)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLTextureMgr");
		obj.resetMat2();
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

