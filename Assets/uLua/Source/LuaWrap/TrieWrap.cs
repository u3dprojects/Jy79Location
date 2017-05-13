using System;
using LuaInterface;

public class TrieWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("getInstanse", getInstanse),
			new LuaMethod("init", init),
			new LuaMethod("Add", Add),
			new LuaMethod("isExistChar", isExistChar),
			new LuaMethod("isExistCharArrays", isExistCharArrays),
			new LuaMethod("filter", filter),
			new LuaMethod("isUnlawful", isUnlawful),
			new LuaMethod("New", _CreateTrie),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Trie", typeof(Trie), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateTrie(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Trie class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Trie);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getInstanse(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Trie o = Trie.getInstanse();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.init(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.Add(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isExistChar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		char arg0 = (char)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.isExistChar(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isExistCharArrays(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 4);
		bool o = obj.isExistCharArrays(objs0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int filter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string o = obj.filter(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isUnlawful(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Trie obj = (Trie)LuaScriptMgr.GetNetObjectSelf(L, 1, "Trie");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		bool o = obj.isUnlawful(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

