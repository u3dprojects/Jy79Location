using System;
using LuaInterface;

public class Toolkit_PStrWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("b", b),
			new LuaMethod("begin", begin),
			new LuaMethod("a", a),
			new LuaMethod("fmt", fmt),
			new LuaMethod("a_kv", a_kv),
			new LuaMethod("an", an),
			new LuaMethod("Length", Length),
			new LuaMethod("e", e),
			new LuaMethod("end", end),
			new LuaMethod("str", str),
			new LuaMethod("New", _CreateToolkit_PStr),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("sb", get_sb, set_sb),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.PStr", typeof(Toolkit.PStr), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_PStr(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Toolkit.PStr class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Toolkit.PStr);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Toolkit.PStr obj = (Toolkit.PStr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sb on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.sb);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sb(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Toolkit.PStr obj = (Toolkit.PStr)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sb");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sb on a nil value");
			}
		}

		obj.sb = (System.Text.StringBuilder)LuaScriptMgr.GetNetObject(L, 3, typeof(System.Text.StringBuilder));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int b(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.PStr o = Toolkit.PStr.b();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Toolkit.PStr o = Toolkit.PStr.b(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 1, count))
		{
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
			Toolkit.PStr o = Toolkit.PStr.b(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.b");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int begin(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.PStr o = Toolkit.PStr.begin();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			Toolkit.PStr o = Toolkit.PStr.begin(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 1, count))
		{
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
			Toolkit.PStr o = Toolkit.PStr.begin(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.begin");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int a(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(double)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			double arg0 = (double)LuaDLL.lua_tonumber(L, 2);
			Toolkit.PStr o = obj.a(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(byte[])))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
			Toolkit.PStr o = obj.a(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(string)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Toolkit.PStr o = obj.a(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(char[])))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			Toolkit.PStr o = obj.a(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(object)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			Toolkit.PStr o = obj.a(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(string), typeof(Toolkit.NewMap)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Toolkit.NewMap arg1 = (Toolkit.NewMap)LuaScriptMgr.GetLuaObject(L, 3);
			Toolkit.PStr o = obj.a(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(char), typeof(int)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			char arg0 = (char)LuaDLL.lua_tonumber(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			Toolkit.PStr o = obj.a(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(string), typeof(int), typeof(int)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			Toolkit.PStr o = obj.a(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(char[]), typeof(int), typeof(int)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			char[] objs0 = LuaScriptMgr.GetArrayNumber<char>(L, 2);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 3);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 4);
			Toolkit.PStr o = obj.a(objs0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(string)) && LuaScriptMgr.CheckParamsType(L, typeof(object), 3, count - 2))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
			Toolkit.PStr o = obj.a(arg0,objs1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Toolkit.PStr o = obj.a(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.a");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fmt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		Toolkit.PStr o = obj.fmt(arg0,objs1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int a_kv(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		Toolkit.PStr o = obj.a_kv(arg0,objs1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int an(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Toolkit.PStr), typeof(string)))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetString(L, 2);
			Toolkit.PStr o = obj.an(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (LuaScriptMgr.CheckParamsType(L, typeof(object), 2, count - 1))
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
			Toolkit.PStr o = obj.an(objs0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.an");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Length(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
		int o = obj.Length();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int e(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string o = obj.e();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.e(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.e");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int end(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string o = obj.end();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.end(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.PStr.end");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int str(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Toolkit.PStr obj = (Toolkit.PStr)LuaScriptMgr.GetNetObjectSelf(L, 1, "Toolkit.PStr");
		string o = obj.str();
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

