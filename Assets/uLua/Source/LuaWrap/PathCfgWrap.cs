using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class PathCfgWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("resetLuaPackgePath", resetLuaPackgePath),
			new LuaMethod("resetPath", resetPath),
			new LuaMethod("New", _CreatePathCfg),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("basePath", get_basePath, set_basePath),
			new LuaField("realFontPath", get_realFontPath, set_realFontPath),
			new LuaField("panelDataPath", get_panelDataPath, set_panelDataPath),
			new LuaField("cellDataPath", get_cellDataPath, set_cellDataPath),
			new LuaField("localizationPath", get_localizationPath, set_localizationPath),
			new LuaField("luaPathRoot", get_luaPathRoot, set_luaPathRoot),
			new LuaField("luaBasePath", get_luaBasePath, null),
			new LuaField("persistentDataPath", get_persistentDataPath, null),
			new LuaField("platform", get_platform, null),
			new LuaField("_cellDataPath", get__cellDataPath, null),
			new LuaField("luaPackgePath", get_luaPackgePath, null),
			new LuaField("upgradeRes", get_upgradeRes, null),
		};

		LuaScriptMgr.RegisterLib(L, "PathCfg", typeof(PathCfg), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePathCfg(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PathCfg class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(PathCfg);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathCfg.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_basePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name basePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index basePath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.basePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realFontPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name realFontPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index realFontPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.realFontPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelDataPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panelDataPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panelDataPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.panelDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_cellDataPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellDataPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellDataPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.cellDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localizationPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localizationPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localizationPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.localizationPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaPathRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaPathRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaPathRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.luaPathRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaBasePath(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathCfg.luaBasePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_persistentDataPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathCfg.persistentDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_platform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name platform");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index platform on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.platform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__cellDataPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _cellDataPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _cellDataPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._cellDataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaPackgePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaPackgePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaPackgePath on a nil value");
			}
		}

		LuaScriptMgr.PushArray(L, obj.luaPackgePath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_upgradeRes(IntPtr L)
	{
		LuaScriptMgr.Push(L, PathCfg.upgradeRes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		PathCfg.self = (PathCfg)LuaScriptMgr.GetUnityObject(L, 3, typeof(PathCfg));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_basePath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name basePath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index basePath on a nil value");
			}
		}

		obj.basePath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realFontPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name realFontPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index realFontPath on a nil value");
			}
		}

		obj.realFontPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panelDataPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panelDataPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panelDataPath on a nil value");
			}
		}

		obj.panelDataPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_cellDataPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name cellDataPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index cellDataPath on a nil value");
			}
		}

		obj.cellDataPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localizationPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localizationPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localizationPath on a nil value");
			}
		}

		obj.localizationPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaPathRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		PathCfg obj = (PathCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name luaPathRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index luaPathRoot on a nil value");
			}
		}

		obj.luaPathRoot = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetLuaPackgePath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		PathCfg obj = (PathCfg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PathCfg");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		List<string> arg1 = (List<string>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<string>));
		obj.resetLuaPackgePath(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PathCfg obj = (PathCfg)LuaScriptMgr.GetUnityObjectSelf(L, 1, "PathCfg");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.resetPath(arg0);
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

