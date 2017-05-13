using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SBSliderBarWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("init", init),
			new LuaMethod("instance", instance),
			new LuaMethod("addHudtxt", addHudtxt),
			new LuaMethod("hide", hide),
			new LuaMethod("New", _CreateSBSliderBar),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("followTarget", get_followTarget, set_followTarget),
			new LuaField("hudText", get_hudText, null),
		};

		LuaScriptMgr.RegisterLib(L, "SBSliderBar", typeof(SBSliderBar), regs, fields, typeof(CLCellLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSBSliderBar(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SBSliderBar class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SBSliderBar);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_followTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SBSliderBar obj = (SBSliderBar)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name followTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index followTarget on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.followTarget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hudText(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SBSliderBar obj = (SBSliderBar)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name hudText");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index hudText on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.hudText);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_followTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SBSliderBar obj = (SBSliderBar)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name followTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index followTarget on a nil value");
			}
		}

		obj.followTarget = (UIFollowTarget)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIFollowTarget));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			SBSliderBar.init();
			return 0;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			SBSliderBar.init(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SBSliderBar.init");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int instance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		SBSliderBar o = SBSliderBar.instance(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addHudtxt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4)
		{
			SBSliderBar obj = (SBSliderBar)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SBSliderBar");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			UILabel o = obj.addHudtxt(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 5)
		{
			SBSliderBar obj = (SBSliderBar)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SBSliderBar");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			Color arg1 = LuaScriptMgr.GetColor(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			UILabel o = obj.addHudtxt(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SBSliderBar.addHudtxt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SBSliderBar obj = (SBSliderBar)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SBSliderBar");
		obj.hide();
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

