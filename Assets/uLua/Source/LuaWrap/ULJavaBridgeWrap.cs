using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ULJavaBridgeWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Init", Init),
			new LuaMethod("SendToJava", SendToJava),
			new LuaMethod("OnResult", OnResult),
			new LuaMethod("New", _CreateULJavaBridge),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("NAME_JAVA_BRIDGE_CLASS", get_NAME_JAVA_BRIDGE_CLASS, null),
			new LuaField("NAME_Gobj", get_NAME_Gobj, null),
			new LuaField("NAME_ON_RESULT_FUNC", get_NAME_ON_RESULT_FUNC, null),
			new LuaField("NAME_JAVA_METHOD_INITALL", get_NAME_JAVA_METHOD_INITALL, null),
			new LuaField("NAME_JAVA_METHOD_NOTIFY", get_NAME_JAVA_METHOD_NOTIFY, null),
		};

		LuaScriptMgr.RegisterLib(L, "ULJavaBridge", typeof(ULJavaBridge), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateULJavaBridge(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ULJavaBridge class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(ULJavaBridge);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NAME_JAVA_BRIDGE_CLASS(IntPtr L)
	{
		LuaScriptMgr.Push(L, ULJavaBridge.NAME_JAVA_BRIDGE_CLASS);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NAME_Gobj(IntPtr L)
	{
		LuaScriptMgr.Push(L, ULJavaBridge.NAME_Gobj);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NAME_ON_RESULT_FUNC(IntPtr L)
	{
		LuaScriptMgr.Push(L, ULJavaBridge.NAME_ON_RESULT_FUNC);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NAME_JAVA_METHOD_INITALL(IntPtr L)
	{
		LuaScriptMgr.Push(L, ULJavaBridge.NAME_JAVA_METHOD_INITALL);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NAME_JAVA_METHOD_NOTIFY(IntPtr L)
	{
		LuaScriptMgr.Push(L, ULJavaBridge.NAME_JAVA_METHOD_NOTIFY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LuaFunction arg1 = LuaScriptMgr.GetLuaFunction(L, 2);
		ULJavaBridge.Init(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendToJava(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		ULJavaBridge.SendToJava(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnResult(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ULJavaBridge obj = (ULJavaBridge)LuaScriptMgr.GetUnityObjectSelf(L, 1, "ULJavaBridge");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.OnResult(arg0);
		return 0;
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

