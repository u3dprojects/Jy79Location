using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLBaseLuaWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("setLua", setLua),
			new LuaMethod("doSetLua", doSetLua),
			new LuaMethod("onNotifyLua", onNotifyLua),
			new LuaMethod("getLuaFunction", getLuaFunction),
			new LuaMethod("getLuaVar", getLuaVar),
			new LuaMethod("invoke4Lua", invoke4Lua),
			new LuaMethod("getCoroutineIndex", getCoroutineIndex),
			new LuaMethod("setCoroutineIndex", setCoroutineIndex),
			new LuaMethod("getCoroutines", getCoroutines),
			new LuaMethod("setCoroutine", setCoroutine),
			new LuaMethod("cleanCoroutines", cleanCoroutines),
			new LuaMethod("rmCoroutine", rmCoroutine),
			new LuaMethod("cancelInvoke4Lua", cancelInvoke4Lua),
			new LuaMethod("pause", pause),
			new LuaMethod("regain", regain),
			new LuaMethod("OnDestroy", OnDestroy),
			new LuaMethod("destoryLua", destoryLua),
			new LuaMethod("fixedInvoke4Lua", fixedInvoke4Lua),
			new LuaMethod("fixedInvoke", fixedInvoke),
			new LuaMethod("cancelFixedInvoke4Lua", cancelFixedInvoke4Lua),
			new LuaMethod("FixedUpdate", FixedUpdate),
			new LuaMethod("New", _CreateCLBaseLua),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isPause", get_isPause, set_isPause),
			new LuaField("luaPath", get_luaPath, set_luaPath),
			new LuaField("mainLua", get_mainLua, set_mainLua),
			new LuaField("lua", get_lua, set_lua),
			new LuaField("luaTable", get_luaTable, set_luaTable),
			new LuaField("luaFuncMap", get_luaFuncMap, set_luaFuncMap),
			new LuaField("fixedInvokeMap", get_fixedInvokeMap, set_fixedInvokeMap),
			new LuaField("frameCounter", get_frameCounter, set_frameCounter),
			new LuaField("transform", get_transform, null),
			new LuaField("canFixedInvoke", get_canFixedInvoke, set_canFixedInvoke),
		};

		LuaScriptMgr.RegisterLib(L, "CLBaseLua", typeof(CLBaseLua), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLBaseLua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLBaseLua class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLBaseLua);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPause on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isPause);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.luaPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainLua(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLBaseLua.mainLua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lua on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.lua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaTable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaTable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaTable on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.luaTable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaFuncMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaFuncMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaFuncMap on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.luaFuncMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fixedInvokeMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fixedInvokeMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fixedInvokeMap on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.fixedInvokeMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameCounter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frameCounter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frameCounter on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.frameCounter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_transform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

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
	static int get_canFixedInvoke(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canFixedInvoke");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canFixedInvoke on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canFixedInvoke);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isPause on a nil value");
			}
		}

		obj.isPause = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaPath on a nil value");
			}
		}

		obj.luaPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainLua(IntPtr L)
	{
		CLBaseLua.mainLua = (LuaScriptMgr)LuaScriptMgr.GetNetObject(L, 3, typeof(LuaScriptMgr));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name lua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index lua on a nil value");
			}
		}

		obj.lua = (LuaScriptMgr)LuaScriptMgr.GetNetObject(L, 3, typeof(LuaScriptMgr));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaTable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaTable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaTable on a nil value");
			}
		}

		obj.luaTable = LuaScriptMgr.GetLuaTable(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaFuncMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaFuncMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaFuncMap on a nil value");
			}
		}

		obj.luaFuncMap = (Dictionary<string,LuaInterface.LuaFunction>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<string,LuaInterface.LuaFunction>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fixedInvokeMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fixedInvokeMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fixedInvokeMap on a nil value");
			}
		}

		obj.fixedInvokeMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frameCounter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name frameCounter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index frameCounter on a nil value");
			}
		}

		obj.frameCounter = (long)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canFixedInvoke(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBaseLua obj = (CLBaseLua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canFixedInvoke");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canFixedInvoke on a nil value");
			}
		}

		obj.canFixedInvoke = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doSetLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		object[] o = obj.doSetLua(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onNotifyLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		obj.onNotifyLua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLuaFunction(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		LuaInterface.LuaFunction o = obj.getLuaFunction(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLuaVar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object o = obj.getLuaVar(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int invoke4Lua(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			Coroutine o = obj.invoke4Lua(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			Coroutine o = obj.invoke4Lua(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 5);
			Coroutine o = obj.invoke4Lua(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLBaseLua.invoke4Lua");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getCoroutineIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int o = obj.getCoroutineIndex(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setCoroutineIndex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.setCoroutineIndex(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Hashtable o = obj.getCoroutines(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setCoroutine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Coroutine arg1 = (Coroutine)LuaScriptMgr.GetNetObject(L, 3, typeof(Coroutine));
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		obj.setCoroutine(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cleanCoroutines(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.cleanCoroutines(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int rmCoroutine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.rmCoroutine(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cancelInvoke4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.cancelInvoke4Lua(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int pause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.pause();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int regain(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.regain();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.OnDestroy();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int destoryLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.destoryLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fixedInvoke4Lua(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
			obj.fixedInvoke4Lua(arg0,arg1);
			return 0;
		}
		else if (count == 4)
		{
			CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			object arg1 = LuaScriptMgr.GetVarObject(L, 3);
			float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
			obj.fixedInvoke4Lua(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLBaseLua.fixedInvoke4Lua");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fixedInvoke(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		obj.fixedInvoke(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cancelFixedInvoke4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.cancelFixedInvoke4Lua(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FixedUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBaseLua obj = (CLBaseLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBaseLua");
		obj.FixedUpdate();
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

