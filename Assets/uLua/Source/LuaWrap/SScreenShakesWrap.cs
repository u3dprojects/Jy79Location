using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SScreenShakesWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("play", play),
			new LuaMethod("stop", stop),
			new LuaMethod("_play", _play),
			new LuaMethod("doShakes", doShakes),
			new LuaMethod("doFinishCallback", doFinishCallback),
			new LuaMethod("onFinish", onFinish),
			new LuaMethod("New", _CreateSScreenShakes),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("twPos", get_twPos, set_twPos),
			new LuaField("offset", get_offset, set_offset),
		};

		LuaScriptMgr.RegisterLib(L, "SScreenShakes", typeof(SScreenShakes), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSScreenShakes(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SScreenShakes class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SScreenShakes);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, SScreenShakes.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_twPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SScreenShakes obj = (SScreenShakes)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twPos on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.twPos);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_offset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SScreenShakes obj = (SScreenShakes)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name offset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index offset on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.offset);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		SScreenShakes.self = (SScreenShakes)LuaScriptMgr.GetUnityObject(L, 3, typeof(SScreenShakes));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_twPos(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SScreenShakes obj = (SScreenShakes)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twPos");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twPos on a nil value");
			}
		}

		obj.twPos = (TweenPosition)LuaScriptMgr.GetUnityObject(L, 3, typeof(TweenPosition));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_offset(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SScreenShakes obj = (SScreenShakes)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name offset");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index offset on a nil value");
			}
		}

		obj.offset = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			SScreenShakes.play(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			SScreenShakes.play(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			SScreenShakes.play(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SScreenShakes.play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		SScreenShakes.stop();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _play(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		SScreenShakes obj = (SScreenShakes)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SScreenShakes");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
		obj._play(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doShakes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		SScreenShakes obj = (SScreenShakes)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SScreenShakes");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
		IEnumerator o = obj.doShakes(arg0,arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doFinishCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SScreenShakes obj = (SScreenShakes)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SScreenShakes");
		obj.doFinishCallback();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinish(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SScreenShakes obj = (SScreenShakes)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SScreenShakes");
		obj.onFinish();
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

