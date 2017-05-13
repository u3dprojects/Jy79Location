using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLCellLuaWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("setLua", setLua),
			new LuaMethod("initLuaFunc", initLuaFunc),
			new LuaMethod("init", init),
			new LuaMethod("refresh", refresh),
			new LuaMethod("OnClick", OnClick),
			new LuaMethod("onClick4Lua", onClick4Lua),
			new LuaMethod("onDoubleClick4Lua", onDoubleClick4Lua),
			new LuaMethod("onHover4Lua", onHover4Lua),
			new LuaMethod("onPress4Lua", onPress4Lua),
			new LuaMethod("onDrag4Lua", onDrag4Lua),
			new LuaMethod("onDrop4Lua", onDrop4Lua),
			new LuaMethod("onKey4Lua", onKey4Lua),
			new LuaMethod("New", _CreateCLCellLua),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isNeedResetAtlase", get_isNeedResetAtlase, set_isNeedResetAtlase),
		};

		LuaScriptMgr.RegisterLib(L, "CLCellLua", typeof(CLCellLua), regs, fields, typeof(CLCellBase));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLCellLua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLCellLua class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLCellLua);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNeedResetAtlase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLCellLua obj = (CLCellLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedResetAtlase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedResetAtlase on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNeedResetAtlase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNeedResetAtlase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLCellLua obj = (CLCellLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedResetAtlase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedResetAtlase on a nil value");
			}
		}

		obj.isNeedResetAtlase = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initLuaFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		obj.initLuaFunc();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.init(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int refresh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.refresh(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		obj.OnClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onClick4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.onClick4Lua(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDoubleClick4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.onDoubleClick4Lua(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onHover4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		obj.onHover4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onPress4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		obj.onPress4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDrag4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		Vector2 arg2 = LuaScriptMgr.GetVector2(L, 4);
		obj.onDrag4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDrop4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 4, typeof(GameObject));
		obj.onDrop4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onKey4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLCellLua obj = (CLCellLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLCellLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		KeyCode arg2 = (KeyCode)LuaScriptMgr.GetNetObject(L, 4, typeof(KeyCode));
		obj.onKey4Lua(arg0,arg1,arg2);
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

