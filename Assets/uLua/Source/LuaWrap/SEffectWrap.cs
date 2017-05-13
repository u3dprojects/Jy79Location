using System;
using UnityEngine;
using System.Collections;
using LuaInterface;
using Object = UnityEngine.Object;

public class SEffectWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("playDelay", playDelay),
			new LuaMethod("play", play),
			new LuaMethod("onFinishSetPrefab", onFinishSetPrefab),
			new LuaMethod("onFinishSetPrefab2", onFinishSetPrefab2),
			new LuaMethod("show", show),
			new LuaMethod("onFinish", onFinish),
			new LuaMethod("Start", Start),
			new LuaMethod("pause", pause),
			new LuaMethod("regain", regain),
			new LuaMethod("playSC", playSC),
			new LuaMethod("New", _CreateSEffect),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("effectName", get_effectName, set_effectName),
			new LuaField("willFinishCallback", get_willFinishCallback, set_willFinishCallback),
			new LuaField("willFinishCallbackPara", get_willFinishCallbackPara, set_willFinishCallbackPara),
			new LuaField("finishCallback", get_finishCallback, set_finishCallback),
			new LuaField("finishCallbackPara", get_finishCallbackPara, set_finishCallbackPara),
			new LuaField("returnAuto", get_returnAuto, set_returnAuto),
			new LuaField("willFinishTime", get_willFinishTime, set_willFinishTime),
			new LuaField("animationProc", get_animationProc, null),
			new LuaField("transform", get_transform, null),
			new LuaField("particleSys", get_particleSys, null),
			new LuaField("animators", get_animators, null),
			new LuaField("animations", get_animations, null),
		};

		LuaScriptMgr.RegisterLib(L, "SEffect", typeof(SEffect), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSEffect(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SEffect class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SEffect);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.effectName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_willFinishCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishCallback on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.willFinishCallback);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_willFinishCallbackPara(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishCallbackPara");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishCallbackPara on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.willFinishCallbackPara);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_finishCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCallback on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.finishCallback);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_finishCallbackPara(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCallbackPara");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCallbackPara on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.finishCallbackPara);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_returnAuto(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name returnAuto");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index returnAuto on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.returnAuto);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_willFinishTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishTime on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.willFinishTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animationProc(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animationProc");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animationProc on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.animationProc);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

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
	static int get_particleSys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name particleSys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index particleSys on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.particleSys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animators(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animators");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animators on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.animators);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_animations(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name animations");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index animations on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.animations);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectName on a nil value");
			}
		}

		obj.effectName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_willFinishCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishCallback on a nil value");
			}
		}

		obj.willFinishCallback = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_willFinishCallbackPara(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishCallbackPara");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishCallbackPara on a nil value");
			}
		}

		obj.willFinishCallbackPara = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_finishCallback(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCallback");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCallback on a nil value");
			}
		}

		obj.finishCallback = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_finishCallbackPara(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name finishCallbackPara");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index finishCallbackPara on a nil value");
			}
		}

		obj.finishCallbackPara = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_returnAuto(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name returnAuto");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index returnAuto on a nil value");
			}
		}

		obj.returnAuto = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_willFinishTime(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SEffect obj = (SEffect)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name willFinishTime");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index willFinishTime on a nil value");
			}
		}

		obj.willFinishTime = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playDelay(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 10 && LuaScriptMgr.CheckTypes(L, 1, typeof(SEffect), typeof(LuaTable), typeof(Transform), typeof(float), typeof(object), typeof(object), typeof(object), typeof(object), typeof(float), typeof(bool)))
		{
			SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
			Transform arg1 = (Transform)LuaScriptMgr.GetLuaObject(L, 3);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			object arg4 = LuaScriptMgr.GetVarObject(L, 6);
			object arg5 = LuaScriptMgr.GetVarObject(L, 7);
			object arg6 = LuaScriptMgr.GetVarObject(L, 8);
			float arg7 = (float)LuaDLL.lua_tonumber(L, 9);
			bool arg8 = LuaDLL.lua_toboolean(L, 10);
			IEnumerator o = obj.playDelay(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 10 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(LuaTable), typeof(Transform), typeof(float), typeof(object), typeof(object), typeof(object), typeof(object), typeof(float), typeof(bool)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Transform arg2 = (Transform)LuaScriptMgr.GetLuaObject(L, 3);
			float arg3 = (float)LuaDLL.lua_tonumber(L, 4);
			object arg4 = LuaScriptMgr.GetVarObject(L, 5);
			object arg5 = LuaScriptMgr.GetVarObject(L, 6);
			object arg6 = LuaScriptMgr.GetVarObject(L, 7);
			object arg7 = LuaScriptMgr.GetVarObject(L, 8);
			float arg8 = (float)LuaDLL.lua_tonumber(L, 9);
			bool arg9 = LuaDLL.lua_toboolean(L, 10);
			SEffect o = SEffect.playDelay(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8,arg9);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SEffect.playDelay");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int play(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			SEffect o = SEffect.play(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Transform arg2 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
			SEffect o = SEffect.play(arg0,arg1,arg2);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			SEffect o = SEffect.play(arg0,arg1,arg2,arg3);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 9)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Transform arg2 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
			float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
			object arg4 = LuaScriptMgr.GetVarObject(L, 5);
			object arg5 = LuaScriptMgr.GetVarObject(L, 6);
			object arg6 = LuaScriptMgr.GetVarObject(L, 7);
			object arg7 = LuaScriptMgr.GetVarObject(L, 8);
			bool arg8 = LuaScriptMgr.GetBoolean(L, 9);
			SEffect o = SEffect.play(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: SEffect.play");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetPrefab(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		SEffect.onFinishSetPrefab(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetPrefab2(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		SEffect.onFinishSetPrefab2(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 9);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
		Transform arg1 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		object arg4 = LuaScriptMgr.GetVarObject(L, 6);
		object arg5 = LuaScriptMgr.GetVarObject(L, 7);
		object arg6 = LuaScriptMgr.GetVarObject(L, 8);
		bool arg7 = LuaScriptMgr.GetBoolean(L, 9);
		obj.show(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinish(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		obj.onFinish(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		obj.pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int regain(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		obj.regain();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playSC(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 10);
		SEffect obj = (SEffect)LuaScriptMgr.GetUnityObjectSelf(L, 1, "SEffect");
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
		Transform arg1 = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		object arg4 = LuaScriptMgr.GetVarObject(L, 6);
		object arg5 = LuaScriptMgr.GetVarObject(L, 7);
		object arg6 = LuaScriptMgr.GetVarObject(L, 8);
		float arg7 = (float)LuaScriptMgr.GetNumber(L, 9);
		bool arg8 = LuaScriptMgr.GetBoolean(L, 10);
		obj.playSC(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
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

