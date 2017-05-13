using System;
using System.Collections;
using LuaInterface;

public class Toolkit_MapExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("builder", builder),
			new LuaMethod("Add", Add),
			new LuaMethod("Count", Count),
			new LuaMethod("Clear", Clear),
			new LuaMethod("Set", Set),
			new LuaMethod("ToMap", ToMap),
			new LuaMethod("Keys", Keys),
			new LuaMethod("KeysList", KeysList),
			new LuaMethod("Values", Values),
			new LuaMethod("ValuesList", ValuesList),
			new LuaMethod("ContainsKey", ContainsKey),
			new LuaMethod("ContainsValue", ContainsValue),
			new LuaMethod("get", get),
			new LuaMethod("getBool", getBool),
			new LuaMethod("getByte", getByte),
			new LuaMethod("getInt", getInt),
			new LuaMethod("getLong", getLong),
			new LuaMethod("getDouble", getDouble),
			new LuaMethod("getString", getString),
			new LuaMethod("getList", getList),
			new LuaMethod("getMap", getMap),
			new LuaMethod("getObject", getObject),
			new LuaMethod("getBytes", getBytes),
			new LuaMethod("getBytes2Int", getBytes2Int),
			new LuaMethod("setInt2Bytes", setInt2Bytes),
			new LuaMethod("getByIntKey", getByIntKey),
			new LuaMethod("newMap", newMap),
			new LuaMethod("createKvs", createKvs),
			new LuaMethod("putKvs", putKvs),
			new LuaMethod("isNull", isNull),
			new LuaMethod("isNullOrEmpty", isNullOrEmpty),
			new LuaMethod("clearMap", clearMap),
			new LuaMethod("clearNullMap", clearNullMap),
			new LuaMethod("keys2List", keys2List),
			new LuaMethod("vals2List", vals2List),
			new LuaMethod("cloneMap", cloneMap),
			new LuaMethod("New", _CreateToolkit_MapEx),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("map", get_map, set_map),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.MapEx", typeof(Toolkit.MapEx), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_MapEx(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.MapEx obj = new Toolkit.MapEx();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1)
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
			Toolkit.MapEx obj = new Toolkit.MapEx(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.MapEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_map(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name map");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index map on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.map);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_map(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name map");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index map on a nil value");
			}
		}

		obj.map = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int builder(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Toolkit.MapEx o = Toolkit.MapEx.builder();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		Toolkit.MapEx o = obj.Add(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Count(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		int o = obj.Count();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		Toolkit.MapEx o = obj.Clear();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Set(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		Toolkit.MapEx o = obj.Set(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToMap(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			Hashtable o = Toolkit.MapEx.ToMap(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			Hashtable o = obj.ToMap();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.ToMap");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Keys(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		ICollection o = obj.Keys();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int KeysList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		ArrayList o = obj.KeysList();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Values(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		ICollection o = obj.Values();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ValuesList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		ArrayList o = obj.ValuesList();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsKey(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsValue(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object o = obj.get(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBool(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = obj.getBool(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			bool o = Toolkit.MapEx.getBool(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getBool");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getByte(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable), typeof(object)))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			byte o = Toolkit.MapEx.getByte(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			byte o = obj.getByte(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getByte");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			int o = obj.getInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			int o = Toolkit.MapEx.getInt(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLong(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable), typeof(object)))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			long o = Toolkit.MapEx.getLong(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			long o = obj.getLong(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getLong");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getDouble(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable), typeof(object)))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			double o = Toolkit.MapEx.getDouble(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			double o = obj.getDouble(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getDouble");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			string o = obj.getString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(object), typeof(object)))
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			string o = Toolkit.MapEx.getString(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable), typeof(object)))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			ArrayList o = Toolkit.MapEx.getList(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			ArrayList o = obj.getList(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getList");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getMap(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable), typeof(object)))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			Hashtable o = Toolkit.MapEx.getMap(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.MapEx), typeof(object)))
		{
			Toolkit.MapEx obj = (Toolkit.MapEx)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.MapEx");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			Hashtable o = obj.getMap(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.getMap");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		object o = Toolkit.MapEx.getObject(arg0,arg1);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		byte[] o = Toolkit.MapEx.getBytes(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBytes2Int(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		int o = Toolkit.MapEx.getBytes2Int(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setInt2Bytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		Toolkit.MapEx.setInt2Bytes(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getByIntKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		object o = Toolkit.MapEx.getByIntKey(arg0,arg1);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int newMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Hashtable o = Toolkit.MapEx.newMap();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int createKvs(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		Hashtable o = Toolkit.MapEx.createKvs(objs0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int putKvs(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.NewMap)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			Toolkit.NewMap arg0 = (Toolkit.NewMap)LuaScriptMgr.GetLuaObject(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Toolkit.NewMap o = Toolkit.MapEx.putKvs(arg0,objs1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Hashtable)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetLuaObject(L, 1);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Hashtable o = Toolkit.MapEx.putKvs(arg0,objs1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.MapEx.putKvs");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isNull(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		bool o = Toolkit.MapEx.isNull(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isNullOrEmpty(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		bool o = Toolkit.MapEx.isNullOrEmpty(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clearMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Toolkit.MapEx.clearMap(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clearNullMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Toolkit.MapEx.clearNullMap(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int keys2List(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		ArrayList o = Toolkit.MapEx.keys2List(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int vals2List(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		ArrayList o = Toolkit.MapEx.vals2List(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cloneMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		Hashtable o = Toolkit.MapEx.cloneMap(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}

