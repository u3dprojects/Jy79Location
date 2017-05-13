﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLCellBaseWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("init", init),
			new LuaMethod("New", _CreateCLCellBase),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "CLCellBase", typeof(CLCellBase), regs, fields, typeof(CLBehaviour4Lua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLCellBase(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLCellBase class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLCellBase);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLCellBase obj = (CLCellBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellBase");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.init(arg0,arg1);
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

