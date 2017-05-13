using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLMainWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Start", Start),
			new LuaMethod("gameInit", gameInit),
			new LuaMethod("reStart", reStart),
			new LuaMethod("doRestart", doRestart),
			new LuaMethod("OnApplicationQuit", OnApplicationQuit),
			new LuaMethod("setLua", setLua),
			new LuaMethod("initGetLuaFunc", initGetLuaFunc),
			new LuaMethod("Update", Update),
			new LuaMethod("onOffline", onOffline),
			new LuaMethod("doOffline", doOffline),
			new LuaMethod("slowDown", slowDown),
			new LuaMethod("normalSpeed", normalSpeed),
			new LuaMethod("setTimeScale", setTimeScale),
			new LuaMethod("New", _CreateCLMain),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("startPanel", get_startPanel, set_startPanel),
		};

		LuaScriptMgr.RegisterLib(L, "CLMain", typeof(CLMain), regs, fields, typeof(CLBehaviour4Lua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLMain(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLMain class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLMain);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLMain.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_startPanel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLMain obj = (CLMain)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startPanel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.startPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLMain.self = (CLMain)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLMain));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_startPanel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLMain obj = (CLMain)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name startPanel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index startPanel on a nil value");
			}
		}

		obj.startPanel = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int gameInit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		IEnumerator o = obj.gameInit();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int reStart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.reStart();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doRestart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.doRestart();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnApplicationQuit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.OnApplicationQuit();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initGetLuaFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.initGetLuaFunc();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onOffline(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.onOffline();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doOffline(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.doOffline();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int slowDown(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.slowDown(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int normalSpeed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		obj.normalSpeed();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setTimeScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLMain obj = (CLMain)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLMain");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.setTimeScale(arg0);
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

