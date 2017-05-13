using System;
using System.Collections;
using LuaInterface;

public class Toolkit_NewListWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("create", create),
			new LuaMethod("add", add),
			new LuaMethod("Contains", Contains),
			new LuaMethod("getObject", getObject),
			new LuaMethod("getBool", getBool),
			new LuaMethod("getByte", getByte),
			new LuaMethod("getInt", getInt),
			new LuaMethod("getLong", getLong),
			new LuaMethod("getDouble", getDouble),
			new LuaMethod("getString", getString),
			new LuaMethod("getList", getList),
			new LuaMethod("getNewList", getNewList),
			new LuaMethod("getMap", getMap),
			new LuaMethod("getNewMap", getNewMap),
			new LuaMethod("pageCount", pageCount),
			new LuaMethod("getPage", getPage),
			new LuaMethod("New", _CreateToolkit_NewList),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.NewList", typeof(Toolkit.NewList), regs, fields, typeof(ArrayList));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_NewList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.NewList obj = new Toolkit.NewList();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NewList.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.NewList);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.NewList o = Toolkit.NewList.create();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			Toolkit.NewList o = Toolkit.NewList.create(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 1, count))
		{
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
			Toolkit.NewList o = Toolkit.NewList.create(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NewList.create");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int add(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.NewList), typeof(object)))
		{
			Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			Toolkit.NewList o = obj.add(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Toolkit.NewList o = obj.add(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NewList.add");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getObject(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.NewList), typeof(int)))
		{
			Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
			int arg0 = (int)LuaDLL.lua_tonumber(L, 2);
			object o = obj.getObject(arg0);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList), typeof(int)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			object o = Toolkit.NewList.getObject(arg0,arg1);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NewList.getObject");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		bool o = obj.getBool(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		byte o = obj.getByte(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.getInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		double o = obj.getLong(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		double o = obj.getDouble(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		string o = obj.getString(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		ArrayList o = obj.getList(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNewList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Toolkit.NewList o = obj.getNewList(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Hashtable o = obj.getMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNewMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		Toolkit.NewMap o = obj.getNewMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int pageCount(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = obj.pageCount(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getPage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Toolkit.NewList obj = (Toolkit.NewList)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.NewList");
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		ArrayList o = obj.getPage(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

