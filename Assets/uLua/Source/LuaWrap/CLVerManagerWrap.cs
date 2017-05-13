using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLVerManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("initStreamingAssetsPackge", initStreamingAssetsPackge),
			new LuaMethod("toMap", toMap),
			new LuaMethod("getNewestRes4Lua", getNewestRes4Lua),
			new LuaMethod("getNewestRes", getNewestRes),
			new LuaMethod("setWWWListner", setWWWListner),
			new LuaMethod("addWWW", addWWW),
			new LuaMethod("rmWWW", rmWWW),
			new LuaMethod("doGetContent", doGetContent),
			new LuaMethod("onGetNewstResTimeOut", onGetNewstResTimeOut),
			new LuaMethod("getAtalsTexture4Edit", getAtalsTexture4Edit),
			new LuaMethod("checkNeedDownload", checkNeedDownload),
			new LuaMethod("isVerNewest", isVerNewest),
			new LuaMethod("New", _CreateCLVerManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("fverVer", get_fverVer, null),
			new LuaField("verPriority", get_verPriority, null),
			new LuaField("verOthers", get_verOthers, null),
			new LuaField("baseUrl", get_baseUrl, set_baseUrl),
			new LuaField("platform", get_platform, set_platform),
			new LuaField("self", get_self, set_self),
			new LuaField("resVer", get_resVer, set_resVer),
			new LuaField("versPath", get_versPath, set_versPath),
			new LuaField("localPriorityVer", get_localPriorityVer, set_localPriorityVer),
			new LuaField("otherResVerOld", get_otherResVerOld, set_otherResVerOld),
			new LuaField("otherResVerNew", get_otherResVerNew, set_otherResVerNew),
			new LuaField("haveUpgrade", get_haveUpgrade, set_haveUpgrade),
			new LuaField("is2GNetUpgrade", get_is2GNetUpgrade, set_is2GNetUpgrade),
			new LuaField("is3GNetUpgrade", get_is3GNetUpgrade, set_is3GNetUpgrade),
			new LuaField("is4GNetUpgrade", get_is4GNetUpgrade, set_is4GNetUpgrade),
			new LuaField("mVerverPath", get_mVerverPath, set_mVerverPath),
			new LuaField("mVerPrioriPath", get_mVerPrioriPath, set_mVerPrioriPath),
			new LuaField("mVerOtherPath", get_mVerOtherPath, set_mVerOtherPath),
			new LuaField("wwwMap", get_wwwMap, set_wwwMap),
			new LuaField("clientVersion", get_clientVersion, set_clientVersion),
		};

		LuaScriptMgr.RegisterLib(L, "CLVerManager", typeof(CLVerManager), regs, fields, typeof(CLBaseLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLVerManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLVerManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLVerManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fverVer(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.fverVer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_verPriority(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.verPriority);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_verOthers(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.verOthers);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_baseUrl(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name baseUrl");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index baseUrl on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.baseUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_platform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

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
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resVer(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.resVer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_versPath(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLVerManager.versPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localPriorityVer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localPriorityVer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localPriorityVer on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.localPriorityVer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_otherResVerOld(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name otherResVerOld");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index otherResVerOld on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.otherResVerOld);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_otherResVerNew(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name otherResVerNew");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index otherResVerNew on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.otherResVerNew);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_haveUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name haveUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index haveUpgrade on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.haveUpgrade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_is2GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is2GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is2GNetUpgrade on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.is2GNetUpgrade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_is3GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is3GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is3GNetUpgrade on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.is3GNetUpgrade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_is4GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is4GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is4GNetUpgrade on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.is4GNetUpgrade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mVerverPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerverPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerverPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mVerverPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mVerPrioriPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerPrioriPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerPrioriPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mVerPrioriPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mVerOtherPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerOtherPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerOtherPath on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mVerOtherPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wwwMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLVerManager.wwwMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_clientVersion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clientVersion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clientVersion on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.clientVersion);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_baseUrl(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name baseUrl");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index baseUrl on a nil value");
			}
		}

		obj.baseUrl = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_platform(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

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

		obj.platform = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLVerManager.self = (CLVerManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLVerManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resVer(IntPtr L)
	{
		CLVerManager.resVer = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_versPath(IntPtr L)
	{
		CLVerManager.versPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localPriorityVer(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name localPriorityVer");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index localPriorityVer on a nil value");
			}
		}

		obj.localPriorityVer = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_otherResVerOld(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name otherResVerOld");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index otherResVerOld on a nil value");
			}
		}

		obj.otherResVerOld = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_otherResVerNew(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name otherResVerNew");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index otherResVerNew on a nil value");
			}
		}

		obj.otherResVerNew = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_haveUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name haveUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index haveUpgrade on a nil value");
			}
		}

		obj.haveUpgrade = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_is2GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is2GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is2GNetUpgrade on a nil value");
			}
		}

		obj.is2GNetUpgrade = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_is3GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is3GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is3GNetUpgrade on a nil value");
			}
		}

		obj.is3GNetUpgrade = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_is4GNetUpgrade(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name is4GNetUpgrade");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index is4GNetUpgrade on a nil value");
			}
		}

		obj.is4GNetUpgrade = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mVerverPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerverPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerverPath on a nil value");
			}
		}

		obj.mVerverPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mVerPrioriPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerPrioriPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerPrioriPath on a nil value");
			}
		}

		obj.mVerPrioriPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mVerOtherPath(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mVerOtherPath");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mVerOtherPath on a nil value");
			}
		}

		obj.mVerOtherPath = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wwwMap(IntPtr L)
	{
		CLVerManager.wwwMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_clientVersion(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLVerManager obj = (CLVerManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name clientVersion");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index clientVersion on a nil value");
			}
		}

		obj.clientVersion = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initStreamingAssetsPackge(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		Callback arg0 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg0 = (Callback)LuaScriptMgr.GetNetObject(L, 2, typeof(Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg0 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.PushArray(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		obj.initStreamingAssetsPackge(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		Hashtable o = obj.toMap(objs0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNewestRes4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		CLAssetType arg1 = (CLAssetType)LuaScriptMgr.GetNetObject(L, 3, typeof(CLAssetType));
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.getNewestRes4Lua(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNewestRes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		CLAssetType arg1 = (CLAssetType)LuaScriptMgr.GetNetObject(L, 3, typeof(CLAssetType));
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		object[] objs3 = LuaScriptMgr.GetParamsObject(L, 5, count - 4);
		obj.getNewestRes(arg0,arg1,arg2,objs3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setWWWListner(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.setWWWListner(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addWWW(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		WWW arg0 = (WWW)LuaScriptMgr.GetNetObject(L, 2, typeof(WWW));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		obj.addWWW(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int rmWWW(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.rmWWW(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doGetContent(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		CLAssetType arg3 = (CLAssetType)LuaScriptMgr.GetNetObject(L, 5, typeof(CLAssetType));
		object arg4 = LuaScriptMgr.GetVarObject(L, 6);
		object[] objs5 = LuaScriptMgr.GetParamsObject(L, 7, count - 6);
		IEnumerator o = obj.doGetContent(arg0,arg1,arg2,arg3,arg4,objs5);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onGetNewstResTimeOut(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		obj.onGetNewstResTimeOut(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAtalsTexture4Edit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Texture o = obj.getAtalsTexture4Edit(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int checkNeedDownload(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.checkNeedDownload(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isVerNewest(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLVerManager obj = (CLVerManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLVerManager");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool o = obj.isVerNewest(arg0,arg1);
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

