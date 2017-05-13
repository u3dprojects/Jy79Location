using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class WWWExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("checkWWWTimeout", checkWWWTimeout),
			new LuaMethod("doCheckWWWTimeout", doCheckWWWTimeout),
			new LuaMethod("uncheckWWWTimeout", uncheckWWWTimeout),
			new LuaMethod("doCallback", doCallback),
			new LuaMethod("newWWW", newWWW),
			new LuaMethod("doNewWWW", doNewWWW),
			new LuaMethod("getWwwByUrl", getWwwByUrl),
			new LuaMethod("New", _CreateWWWEx),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("wwwMapUrl", get_wwwMapUrl, set_wwwMapUrl),
			new LuaField("wwwMap4Check", get_wwwMap4Check, set_wwwMap4Check),
			new LuaField("wwwMap4Get", get_wwwMap4Get, set_wwwMap4Get),
		};

		LuaScriptMgr.RegisterLib(L, "WWWEx", typeof(WWWEx), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateWWWEx(IntPtr L)
	{
		LuaDLL.luaL_error(L, "WWWEx class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(WWWEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wwwMapUrl(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, WWWEx.wwwMapUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wwwMap4Check(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, WWWEx.wwwMap4Check);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wwwMap4Get(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, WWWEx.wwwMap4Get);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wwwMapUrl(IntPtr L)
	{
		WWWEx.wwwMapUrl = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wwwMap4Check(IntPtr L)
	{
		WWWEx.wwwMap4Check = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wwwMap4Get(IntPtr L)
	{
		WWWEx.wwwMap4Get = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int checkWWWTimeout(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		WWW arg1 = (WWW)LuaScriptMgr.GetNetObject(L, 2, typeof(WWW));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		object arg4 = LuaScriptMgr.GetVarObject(L, 5);
		object arg5 = LuaScriptMgr.GetVarObject(L, 6);
		WWWEx.checkWWWTimeout(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doCheckWWWTimeout(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 8);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		WWW arg1 = (WWW)LuaScriptMgr.GetNetObject(L, 2, typeof(WWW));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		object arg4 = LuaScriptMgr.GetVarObject(L, 5);
		float arg5 = (float)LuaScriptMgr.GetNumber(L, 6);
		float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
		object arg7 = LuaScriptMgr.GetVarObject(L, 8);
		IEnumerator o = WWWEx.doCheckWWWTimeout(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int uncheckWWWTimeout(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		WWW arg1 = (WWW)LuaScriptMgr.GetNetObject(L, 2, typeof(WWW));
		WWWEx.uncheckWWWTimeout(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		WWWEx.doCallback(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int newWWW(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 9);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		CLAssetType arg2 = (CLAssetType)LuaScriptMgr.GetNetObject(L, 3, typeof(CLAssetType));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		object arg5 = LuaScriptMgr.GetVarObject(L, 6);
		object arg6 = LuaScriptMgr.GetVarObject(L, 7);
		object arg7 = LuaScriptMgr.GetVarObject(L, 8);
		object arg8 = LuaScriptMgr.GetVarObject(L, 9);
		WWWEx.newWWW(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doNewWWW(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 9);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		CLAssetType arg2 = (CLAssetType)LuaScriptMgr.GetNetObject(L, 3, typeof(CLAssetType));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		object arg5 = LuaScriptMgr.GetVarObject(L, 6);
		object arg6 = LuaScriptMgr.GetVarObject(L, 7);
		object arg7 = LuaScriptMgr.GetVarObject(L, 8);
		object arg8 = LuaScriptMgr.GetVarObject(L, 9);
		IEnumerator o = WWWEx.doNewWWW(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getWwwByUrl(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		WWW o = WWWEx.getWwwByUrl(arg0);
		LuaScriptMgr.PushObject(L, o);
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

