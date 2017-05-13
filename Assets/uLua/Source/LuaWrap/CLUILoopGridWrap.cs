using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLUILoopGridWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("init", init),
			new LuaMethod("resetClip", resetClip),
			new LuaMethod("setList", setList),
			new LuaMethod("New", _CreateCLUILoopGrid),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isPlayTween", get_isPlayTween, set_isPlayTween),
			new LuaField("twType", get_twType, set_twType),
			new LuaField("tweenSpeed", get_tweenSpeed, set_tweenSpeed),
			new LuaField("twDuration", get_twDuration, set_twDuration),
			new LuaField("twMethod", get_twMethod, set_twMethod),
			new LuaField("scrollView", get_scrollView, null),
		};

		LuaScriptMgr.RegisterLib(L, "CLUILoopGrid", typeof(CLUILoopGrid), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLUILoopGrid(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLUILoopGrid class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLUILoopGrid);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPlayTween(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlayTween");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlayTween on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isPlayTween);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_twType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.twType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tweenSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_twDuration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twDuration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twDuration on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.twDuration);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_twMethod(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twMethod");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twMethod on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.twMethod);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scrollView(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollView");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollView on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scrollView);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPlayTween(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPlayTween");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPlayTween on a nil value");
			}
		}

		obj.isPlayTween = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_twType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twType on a nil value");
			}
		}

		obj.twType = (TweenType)LuaScriptMgr.GetNetObject(L, 3, typeof(TweenType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenSpeed on a nil value");
			}
		}

		obj.tweenSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_twDuration(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twDuration");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twDuration on a nil value");
			}
		}

		obj.twDuration = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_twMethod(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name twMethod");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index twMethod on a nil value");
			}
		}

		obj.twMethod = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 3, typeof(UITweener.Method));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
		obj.init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetClip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
		obj.resetClip();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			obj.setList(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			obj.setList(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 5)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			obj.setList(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
			obj.setList(arg0,arg1,arg2,arg3,arg4);
			return 0;
		}
		else if (count == 7)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 7);
			obj.setList(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else if (count == 8)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 7);
			UITweener.Method arg6 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 8, typeof(UITweener.Method));
			obj.setList(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			return 0;
		}
		else if (count == 9)
		{
			CLUILoopGrid obj = (CLUILoopGrid)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUILoopGrid");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
			float arg5 = (float)LuaScriptMgr.GetNumber(L, 7);
			UITweener.Method arg6 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 8, typeof(UITweener.Method));
			TweenType arg7 = (TweenType)LuaScriptMgr.GetNetObject(L, 9, typeof(TweenType));
			obj.setList(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUILoopGrid.setList");
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

