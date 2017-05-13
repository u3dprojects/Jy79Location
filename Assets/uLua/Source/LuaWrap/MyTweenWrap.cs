using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class MyTweenWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("flyout", flyout),
			new LuaMethod("onFinishTween", onFinishTween),
			new LuaMethod("stop", stop),
			new LuaMethod("FixedUpdate", FixedUpdate),
			new LuaMethod("moveForward", moveForward),
			new LuaMethod("stopMoveForward", stopMoveForward),
			new LuaMethod("New", _CreateMyTween),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("speed", get_speed, set_speed),
			new LuaField("turningSpeed", get_turningSpeed, set_turningSpeed),
			new LuaField("high", get_high, set_high),
			new LuaField("obstrucLayer", get_obstrucLayer, set_obstrucLayer),
			new LuaField("obsDistance", get_obsDistance, set_obsDistance),
			new LuaField("shadow", get_shadow, set_shadow),
			new LuaField("shadowHeight", get_shadowHeight, set_shadowHeight),
			new LuaField("curveSpeed", get_curveSpeed, set_curveSpeed),
			new LuaField("curveHigh", get_curveHigh, set_curveHigh),
			new LuaField("isMoveNow", get_isMoveNow, set_isMoveNow),
			new LuaField("transform", get_transform, null),
		};

		LuaScriptMgr.RegisterLib(L, "MyTween", typeof(MyTween), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateMyTween(IntPtr L)
	{
		LuaDLL.luaL_error(L, "MyTween class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(MyTween);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.speed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_turningSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name turningSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index turningSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.turningSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_high(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name high");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index high on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.high);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_obstrucLayer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obstrucLayer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obstrucLayer on a nil value");
			}
		}

		LuaScriptMgr.PushValue(L, obj.obstrucLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_obsDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obsDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obsDistance on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.obsDistance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shadow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shadow on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.shadow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shadowHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shadowHeight on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.shadowHeight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_curveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name curveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index curveSpeed on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.curveSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_curveHigh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name curveHigh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index curveHigh on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.curveHigh);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMoveNow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isMoveNow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isMoveNow on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isMoveNow);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name transform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index transform on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.transform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		obj.speed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_turningSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name turningSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index turningSpeed on a nil value");
			}
		}

		obj.turningSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_high(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name high");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index high on a nil value");
			}
		}

		obj.high = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_obstrucLayer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obstrucLayer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obstrucLayer on a nil value");
			}
		}

		obj.obstrucLayer = (LayerMask)LuaScriptMgr.GetNetObject(L, 3, typeof(LayerMask));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_obsDistance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name obsDistance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index obsDistance on a nil value");
			}
		}

		obj.obsDistance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shadow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shadow on a nil value");
			}
		}

		obj.shadow = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowHeight(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name shadowHeight");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index shadowHeight on a nil value");
			}
		}

		obj.shadowHeight = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_curveSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name curveSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index curveSpeed on a nil value");
			}
		}

		obj.curveSpeed = (AnimationCurve)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationCurve));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_curveHigh(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name curveHigh");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index curveHigh on a nil value");
			}
		}

		obj.curveHigh = (AnimationCurve)LuaScriptMgr.GetNetObject(L, 3, typeof(AnimationCurve));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isMoveNow(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		MyTween obj = (MyTween)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isMoveNow");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isMoveNow on a nil value");
			}
		}

		obj.isMoveNow = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int flyout(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 7)
		{
			MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			object arg4 = LuaScriptMgr.GetVarObject(L, 6);
			bool arg5 = LuaScriptMgr.GetBoolean(L, 7);
			obj.flyout(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else if (count == 8)
		{
			MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			object arg4 = LuaScriptMgr.GetVarObject(L, 6);
			object arg5 = LuaScriptMgr.GetVarObject(L, 7);
			bool arg6 = LuaScriptMgr.GetBoolean(L, 8);
			obj.flyout(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			return 0;
		}
		else if (count == 9)
		{
			MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
			float arg4 = (float)LuaScriptMgr.GetNumber(L, 6);
			object arg5 = LuaScriptMgr.GetVarObject(L, 7);
			object arg6 = LuaScriptMgr.GetVarObject(L, 8);
			bool arg7 = LuaScriptMgr.GetBoolean(L, 9);
			obj.flyout(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: MyTween.flyout");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
		obj.onFinishTween();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stop(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
		obj.stop();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FixedUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
		obj.FixedUpdate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int moveForward(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.moveForward(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stopMoveForward(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		MyTween obj = (MyTween)LuaScriptMgr.GetUnityObjectSelf(L, 1, "MyTween");
		obj.stopMoveForward();
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

