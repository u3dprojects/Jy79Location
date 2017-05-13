using System;
using System.Collections;
using LuaInterface;

public class Toolkit_JSONWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("DecodeMap", DecodeMap),
			new LuaMethod("DecodeList", DecodeList),
			new LuaMethod("JsonDecode", JsonDecode),
			new LuaMethod("JsonEncode", JsonEncode),
			new LuaMethod("New", _CreateToolkit_JSON),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("TOKEN_NONE", get_TOKEN_NONE, null),
			new LuaField("TOKEN_CURLY_OPEN", get_TOKEN_CURLY_OPEN, null),
			new LuaField("TOKEN_CURLY_CLOSE", get_TOKEN_CURLY_CLOSE, null),
			new LuaField("TOKEN_SQUARED_OPEN", get_TOKEN_SQUARED_OPEN, null),
			new LuaField("TOKEN_SQUARED_CLOSE", get_TOKEN_SQUARED_CLOSE, null),
			new LuaField("TOKEN_COLON", get_TOKEN_COLON, null),
			new LuaField("TOKEN_COMMA", get_TOKEN_COMMA, null),
			new LuaField("TOKEN_STRING", get_TOKEN_STRING, null),
			new LuaField("TOKEN_NUMBER", get_TOKEN_NUMBER, null),
			new LuaField("TOKEN_TRUE", get_TOKEN_TRUE, null),
			new LuaField("TOKEN_FALSE", get_TOKEN_FALSE, null),
			new LuaField("TOKEN_NULL", get_TOKEN_NULL, null),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.JSON", typeof(Toolkit.JSON), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_JSON(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.JSON obj = new Toolkit.JSON();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.JSON.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.JSON);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_NONE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_NONE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_CURLY_OPEN(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_CURLY_OPEN);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_CURLY_CLOSE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_CURLY_CLOSE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_SQUARED_OPEN(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_SQUARED_OPEN);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_SQUARED_CLOSE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_SQUARED_CLOSE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_COLON(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_COLON);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_COMMA(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_COMMA);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_STRING(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_STRING);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_NUMBER(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_NUMBER);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_TRUE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_TRUE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_FALSE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_FALSE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TOKEN_NULL(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.JSON.TOKEN_NULL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecodeMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Hashtable o = Toolkit.JSON.DecodeMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecodeList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		ArrayList o = Toolkit.JSON.DecodeList(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int JsonDecode(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object o = Toolkit.JSON.JsonDecode(arg0);
			LuaScriptMgr.PushVarObject(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			bool arg1 = (bool)LuaScriptMgr.GetNetObject(L, 2, typeof(bool));
			object o = Toolkit.JSON.JsonDecode(arg0,ref arg1);
			LuaScriptMgr.PushVarObject(L, o);
			LuaScriptMgr.Push(L, arg1);
			return 2;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.JSON.JsonDecode");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int JsonEncode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		string o = Toolkit.JSON.JsonEncode(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

