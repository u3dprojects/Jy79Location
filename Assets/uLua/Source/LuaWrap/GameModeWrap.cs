using System;
using LuaInterface;

public class GameModeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("normal", Getnormal),
		new LuaMethod("battle", Getbattle),
		new LuaMethod("map", Getmap),
		new LuaMethod("explore", Getexplore),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "GameMode", typeof(GameMode), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Getnormal(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameMode.normal);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Getbattle(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameMode.battle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Getmap(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameMode.map);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Getexplore(IntPtr L)
	{
		LuaScriptMgr.Push(L, GameMode.explore);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		GameMode o = (GameMode)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

