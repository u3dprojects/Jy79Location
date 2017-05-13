using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLPBackplateWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("show", show),
			new LuaMethod("proc", proc),
			new LuaMethod("New", _CreateCLPBackplate),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
		};

		LuaScriptMgr.RegisterLib(L, "CLPBackplate", typeof(CLPBackplate), regs, fields, typeof(CLPanelLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLPBackplate(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLPBackplate class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLPBackplate);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPBackplate.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLPBackplate.self = (CLPBackplate)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPBackplate));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPBackplate obj = (CLPBackplate)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPBackplate");
		obj.show();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int proc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPBackplate obj = (CLPBackplate)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPBackplate");
		CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 2, typeof(CLPanelBase));
		obj.proc(arg0);
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

