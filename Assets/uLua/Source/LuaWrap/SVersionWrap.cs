using System;
using LuaInterface;

public class SVersionWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateSVersion),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("version", get_version, set_version),
			new LuaField("versionCode", get_versionCode, set_versionCode),
		};

		LuaScriptMgr.RegisterLib(L, "SVersion", typeof(SVersion), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSVersion(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SVersion class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SVersion);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_version(IntPtr L)
	{
		LuaScriptMgr.Push(L, SVersion.version);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_versionCode(IntPtr L)
	{
		LuaScriptMgr.Push(L, SVersion.versionCode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_version(IntPtr L)
	{
		SVersion.version = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_versionCode(IntPtr L)
	{
		SVersion.versionCode = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}
}

