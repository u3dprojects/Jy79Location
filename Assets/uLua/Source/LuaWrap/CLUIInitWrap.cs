using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLUIInitWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("clean", clean),
			new LuaMethod("init", init),
			new LuaMethod("initAtlas", initAtlas),
			new LuaMethod("getFontByName", getFontByName),
			new LuaMethod("getAtlasByName", getAtlasByName),
			new LuaMethod("New", _CreateCLUIInit),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("emptFont", get_emptFont, set_emptFont),
			new LuaField("emptAtlas", get_emptAtlas, set_emptAtlas),
			new LuaField("uiPublicRoot", get_uiPublicRoot, set_uiPublicRoot),
			new LuaField("self", get_self, set_self),
			new LuaField("fontMap", get_fontMap, set_fontMap),
			new LuaField("atlasMap", get_atlasMap, set_atlasMap),
		};

		LuaScriptMgr.RegisterLib(L, "CLUIInit", typeof(CLUIInit), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLUIInit(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLUIInit class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLUIInit);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_emptFont(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emptFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emptFont on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.emptFont);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_emptAtlas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emptAtlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emptAtlas on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.emptAtlas);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiPublicRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiPublicRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiPublicRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiPublicRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLUIInit.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fontMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLUIInit.fontMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_atlasMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLUIInit.atlasMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_emptFont(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emptFont");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emptFont on a nil value");
			}
		}

		obj.emptFont = (UIFont)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIFont));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_emptAtlas(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name emptAtlas");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index emptAtlas on a nil value");
			}
		}

		obj.emptAtlas = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIAtlas));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiPublicRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIInit obj = (CLUIInit)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiPublicRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiPublicRoot on a nil value");
			}
		}

		obj.uiPublicRoot = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLUIInit.self = (CLUIInit)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLUIInit));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fontMap(IntPtr L)
	{
		CLUIInit.fontMap = (Dictionary<string,UIFont>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<string,UIFont>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_atlasMap(IntPtr L)
	{
		CLUIInit.atlasMap = (Dictionary<string,UIAtlas>)LuaScriptMgr.GetNetObject(L, 3, typeof(Dictionary<string,UIAtlas>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUIInit obj = (CLUIInit)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIInit");
		obj.clean();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUIInit obj = (CLUIInit)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIInit");
		bool o = obj.init();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initAtlas(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUIInit obj = (CLUIInit)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIInit");
		bool o = obj.initAtlas();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getFontByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLUIInit obj = (CLUIInit)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIInit");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		UIFont o = obj.getFontByName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAtlasByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLUIInit obj = (CLUIInit)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIInit");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		UIAtlas o = obj.getAtlasByName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
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

