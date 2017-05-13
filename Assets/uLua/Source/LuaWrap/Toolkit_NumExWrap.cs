using System;
using System.Collections;
using LuaInterface;

public class Toolkit_NumExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("_rnd", _rnd),
			new LuaMethod("stringToBool", stringToBool),
			new LuaMethod("stringToInt", stringToInt),
			new LuaMethod("stringToLong", stringToLong),
			new LuaMethod("stringToDouble", stringToDouble),
			new LuaMethod("NextInt", NextInt),
			new LuaMethod("NextBool", NextBool),
			new LuaMethod("Next", Next),
			new LuaMethod("distance", distance),
			new LuaMethod("percent", percent),
			new LuaMethod("Min", Min),
			new LuaMethod("Max", Max),
			new LuaMethod("nStr", nStr),
			new LuaMethod("nStrForLen", nStrForLen),
			new LuaMethod("readByte", readByte),
			new LuaMethod("readBool", readBool),
			new LuaMethod("readChar", readChar),
			new LuaMethod("readShort", readShort),
			new LuaMethod("readInt", readInt),
			new LuaMethod("readLong", readLong),
			new LuaMethod("Int64BitsToDouble", Int64BitsToDouble),
			new LuaMethod("DoubleToInt64Bits", DoubleToInt64Bits),
			new LuaMethod("kb", kb),
			new LuaMethod("mb", mb),
			new LuaMethod("gb", gb),
			new LuaMethod("tb", tb),
			new LuaMethod("pb", pb),
			new LuaMethod("toInt", toInt),
			new LuaMethod("bio2Int", bio2Int),
			new LuaMethod("int2Bio", int2Bio),
			new LuaMethod("bio2Long", bio2Long),
			new LuaMethod("Long2Bio", Long2Bio),
			new LuaMethod("bio2Double", bio2Double),
			new LuaMethod("Double2Bio", Double2Bio),
			new LuaMethod("getB2Int", getB2Int),
			new LuaMethod("New", _CreateToolkit_NumEx),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("BYTE_MIN_VALUE", get_BYTE_MIN_VALUE, null),
			new LuaField("BYTE_MAX_VALUE", get_BYTE_MAX_VALUE, null),
			new LuaField("SHORT_MIN_VALUE", get_SHORT_MIN_VALUE, null),
			new LuaField("SHORT_MAX_VALUE", get_SHORT_MAX_VALUE, null),
			new LuaField("INT_MIN_VALUE", get_INT_MIN_VALUE, null),
			new LuaField("INT_MAX_VALUE", get_INT_MAX_VALUE, null),
			new LuaField("LONG_MIN_VALUE", get_LONG_MIN_VALUE, null),
			new LuaField("LONG_MAX_VALUE", get_LONG_MAX_VALUE, null),
			new LuaField("KB", get_KB, null),
			new LuaField("MB", get_MB, null),
			new LuaField("GB", get_GB, null),
			new LuaField("TB", get_TB, null),
			new LuaField("PB", get_PB, null),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.NumEx", typeof(Toolkit.NumEx), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_NumEx(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.NumEx obj = new Toolkit.NumEx();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.NumEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BYTE_MIN_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.BYTE_MIN_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BYTE_MAX_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.BYTE_MAX_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SHORT_MIN_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.SHORT_MIN_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SHORT_MAX_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.SHORT_MAX_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_INT_MIN_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.INT_MIN_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_INT_MAX_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.INT_MAX_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LONG_MIN_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.LONG_MIN_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LONG_MAX_VALUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.LONG_MAX_VALUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_KB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.KB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.MB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.GB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.TB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PB(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.NumEx.PB);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _rnd(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Random o = Toolkit.NumEx._rnd();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stringToBool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.NumEx.stringToBool(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stringToInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = Toolkit.NumEx.stringToInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stringToLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		long o = Toolkit.NumEx.stringToLong(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int stringToDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		double o = Toolkit.NumEx.stringToDouble(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NextInt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int o = Toolkit.NumEx.NextInt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = Toolkit.NumEx.NextInt(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.NextInt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NextBool(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			bool o = Toolkit.NumEx.NextBool();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1)
		{
			double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
			bool o = Toolkit.NumEx.NextBool(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			bool o = Toolkit.NumEx.NextBool(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.NextBool");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Next(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string[])))
		{
			string[] objs0 = LuaScriptMgr.GetArrayString(L, 1);
			string o = Toolkit.NumEx.Next(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int[])))
		{
			int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 1);
			int o = Toolkit.NumEx.Next(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			object o = Toolkit.NumEx.Next(arg0);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.Next");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int distance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		int o = Toolkit.NumEx.distance(arg0,arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int percent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
		double arg1 = (double)LuaScriptMgr.GetNumber(L, 2);
		int o = Toolkit.NumEx.percent(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Min(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(double[])))
		{
			double[] objs0 = LuaScriptMgr.GetArrayNumber<double>(L, 1);
			double o = Toolkit.NumEx.Min(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			int o = Toolkit.NumEx.Min(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int[])))
		{
			int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 1);
			int o = Toolkit.NumEx.Min(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.Min");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Max(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(double[])))
		{
			double[] objs0 = LuaScriptMgr.GetArrayNumber<double>(L, 1);
			double o = Toolkit.NumEx.Max(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ArrayList)))
		{
			ArrayList arg0 = (ArrayList)LuaScriptMgr.GetLuaObject(L, 1);
			int o = Toolkit.NumEx.Max(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int[])))
		{
			int[] objs0 = LuaScriptMgr.GetArrayNumber<int>(L, 1);
			int o = Toolkit.NumEx.Max(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.Max");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nStr(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string o = Toolkit.NumEx.nStr(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(long), typeof(long)))
		{
			long arg0 = (long)LuaDLL.lua_tonumber(L, 1);
			long arg1 = (long)LuaDLL.lua_tonumber(L, 2);
			string o = Toolkit.NumEx.nStr(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.nStr");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nStrForLen(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(int)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string o = Toolkit.NumEx.nStrForLen(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(int), typeof(int)))
		{
			int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
			int arg1 = (int)LuaDLL.lua_tonumber(L, 2);
			string o = Toolkit.NumEx.nStrForLen(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.NumEx.nStrForLen");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		int o = Toolkit.NumEx.readByte(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readBool(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		bool o = Toolkit.NumEx.readBool(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readChar(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		char o = Toolkit.NumEx.readChar(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readShort(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		short o = Toolkit.NumEx.readShort(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		int o = Toolkit.NumEx.readInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		System.IO.Stream arg0 = (System.IO.Stream)LuaScriptMgr.GetNetObject(L, 1, typeof(System.IO.Stream));
		long o = Toolkit.NumEx.readLong(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Int64BitsToDouble(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		double o = Toolkit.NumEx.Int64BitsToDouble(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoubleToInt64Bits(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
		long o = Toolkit.NumEx.DoubleToInt64Bits(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int kb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int o = Toolkit.NumEx.kb(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int mb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int o = Toolkit.NumEx.mb(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int gb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int o = Toolkit.NumEx.gb(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int tb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int o = Toolkit.NumEx.tb(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int pb(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int o = Toolkit.NumEx.pb(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		int o = Toolkit.NumEx.toInt(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int bio2Int(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		int o = Toolkit.NumEx.bio2Int(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int int2Bio(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		byte[] o = Toolkit.NumEx.int2Bio(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int bio2Long(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		long o = Toolkit.NumEx.bio2Long(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Long2Bio(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		byte[] o = Toolkit.NumEx.Long2Bio(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int bio2Double(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		double o = Toolkit.NumEx.bio2Double(objs0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Double2Bio(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		double arg0 = (double)LuaScriptMgr.GetNumber(L, 1);
		byte[] o = Toolkit.NumEx.Double2Bio(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getB2Int(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		byte[] o = Toolkit.NumEx.getB2Int(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}
}

