using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class NAlertTxtWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("add", add),
			new LuaMethod("New", _CreateNAlertTxt),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("hudBackgroundSpriteName", get_hudBackgroundSpriteName, set_hudBackgroundSpriteName),
			new LuaField("hudBackgroundColor", get_hudBackgroundColor, set_hudBackgroundColor),
			new LuaField("pool", get_pool, set_pool),
		};

		LuaScriptMgr.RegisterLib(L, "NAlertTxt", typeof(NAlertTxt), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNAlertTxt(IntPtr L)
	{
		LuaDLL.luaL_error(L, "NAlertTxt class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(NAlertTxt);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, NAlertTxt.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hudBackgroundSpriteName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NAlertTxt obj = (NAlertTxt)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hudBackgroundSpriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hudBackgroundSpriteName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hudBackgroundSpriteName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hudBackgroundColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NAlertTxt obj = (NAlertTxt)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hudBackgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hudBackgroundColor on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hudBackgroundColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pool(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, NAlertTxt.pool);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		NAlertTxt.self = (NAlertTxt)LuaScriptMgr.GetUnityObject(L, 3, typeof(NAlertTxt));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hudBackgroundSpriteName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NAlertTxt obj = (NAlertTxt)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hudBackgroundSpriteName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hudBackgroundSpriteName on a nil value");
			}
		}

		obj.hudBackgroundSpriteName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_hudBackgroundColor(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		NAlertTxt obj = (NAlertTxt)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hudBackgroundColor");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hudBackgroundColor on a nil value");
			}
		}

		obj.hudBackgroundColor = LuaScriptMgr.GetColor(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pool(IntPtr L)
	{
		NAlertTxt.pool = (SpriteHudPool)LuaScriptMgr.GetNetObject(L, 3, typeof(SpriteHudPool));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int add(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			NAlertTxt.add(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			NAlertTxt.add(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 5)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			Color arg1 = LuaScriptMgr.GetColor(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg4 = LuaScriptMgr.GetBoolean(L, 5);
			NAlertTxt.add(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NAlertTxt.add");
		}

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

