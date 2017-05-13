using System;
using UnityEngine;
using System.Collections;
using LuaInterface;

public class CLUIUtlWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("appendList4Lua", appendList4Lua),
			new LuaMethod("appendList", appendList),
			new LuaMethod("resetList", resetList),
			new LuaMethod("resetList4Lua", resetList4Lua),
			new LuaMethod("resetCellTween", resetCellTween),
			new LuaMethod("resetCellTweenPosition", resetCellTweenPosition),
			new LuaMethod("resetCellTweenScale", resetCellTweenScale),
			new LuaMethod("resetCellTweenAlpha", resetCellTweenAlpha),
			new LuaMethod("resetChatList", resetChatList),
			new LuaMethod("setTabSelected", setTabSelected),
			new LuaMethod("showConfirm", showConfirm),
			new LuaMethod("setSpriteFit", setSpriteFit),
			new LuaMethod("onGetSprite", onGetSprite),
			new LuaMethod("onGetSprite2", onGetSprite2),
			new LuaMethod("setAllSpriteGray", setAllSpriteGray),
			new LuaMethod("setSpriteGray", setSpriteGray),
			new LuaMethod("New", _CreateCLUIUtl),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "CLUIUtl", typeof(CLUIUtl), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLUIUtl(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CLUIUtl obj = new CLUIUtl();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.New");
		}

		return 0;
	}

	static Type classType = typeof(CLUIUtl);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int appendList4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		UIGrid arg0 = (UIGrid)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIGrid));
		GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		ArrayList arg2 = (ArrayList)LuaScriptMgr.GetNetObject(L, 3, typeof(ArrayList));
		int arg3 = (int)LuaScriptMgr.GetNumber(L, 4);
		object arg4 = LuaScriptMgr.GetVarObject(L, 5);
		CLUIUtl.appendList4Lua(arg0,arg1,arg2,arg3,arg4);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int appendList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 6)
		{
			UIGrid arg0 = (UIGrid)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIGrid));
			GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			ArrayList arg2 = (ArrayList)LuaScriptMgr.GetNetObject(L, 3, typeof(ArrayList));
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			object arg5 = LuaScriptMgr.GetVarObject(L, 6);
			CLUIUtl.appendList(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else if (count == 8)
		{
			UIGrid arg0 = (UIGrid)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIGrid));
			GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			ArrayList arg2 = (ArrayList)LuaScriptMgr.GetNetObject(L, 3, typeof(ArrayList));
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
			int arg4 = (int)LuaScriptMgr.GetNumber(L, 5);
			GameObject arg5 = (GameObject)LuaScriptMgr.GetUnityObject(L, 6, typeof(GameObject));
			object arg6 = LuaScriptMgr.GetVarObject(L, 7);
			float arg7 = (float)LuaScriptMgr.GetNumber(L, 8);
			CLUIUtl.appendList(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.appendList");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetList(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITable), typeof(GameObject), typeof(object), typeof(Type), typeof(object), typeof(bool), typeof(float)))
		{
			UITable arg0 = (UITable)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
			object arg4 = LuaScriptMgr.GetVarObject(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			float arg6 = (float)LuaDLL.lua_tonumber(L, 7);
			CLUIUtl.resetList(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			return 0;
		}
		else if (count == 7 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIGrid), typeof(GameObject), typeof(object), typeof(Type), typeof(object), typeof(bool), typeof(float)))
		{
			UIGrid arg0 = (UIGrid)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
			object arg4 = LuaScriptMgr.GetVarObject(L, 5);
			bool arg5 = LuaDLL.lua_toboolean(L, 6);
			float arg6 = (float)LuaDLL.lua_tonumber(L, 7);
			CLUIUtl.resetList(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
			return 0;
		}
		else if (count == 9)
		{
			object arg0 = LuaScriptMgr.GetVarObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
			GameObject arg4 = (GameObject)LuaScriptMgr.GetUnityObject(L, 5, typeof(GameObject));
			bool arg5 = LuaScriptMgr.GetBoolean(L, 6);
			object arg6 = LuaScriptMgr.GetVarObject(L, 7);
			bool arg7 = LuaScriptMgr.GetBoolean(L, 8);
			float arg8 = (float)LuaScriptMgr.GetNumber(L, 9);
			CLUIUtl.resetList(arg0,arg1,arg2,arg3,arg4,arg5,arg6,arg7,arg8);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.resetList");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetList4Lua(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITable), typeof(GameObject), typeof(object), typeof(object)))
		{
			UITable arg0 = (UITable)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			CLUIUtl.resetList4Lua(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 4 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIGrid), typeof(GameObject), typeof(object), typeof(object)))
		{
			UIGrid arg0 = (UIGrid)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			CLUIUtl.resetList4Lua(arg0,arg1,arg2,arg3);
			return 0;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(UITable), typeof(GameObject), typeof(object), typeof(object), typeof(bool), typeof(float)))
		{
			UITable arg0 = (UITable)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			bool arg4 = LuaDLL.lua_toboolean(L, 5);
			float arg5 = (float)LuaDLL.lua_tonumber(L, 6);
			CLUIUtl.resetList4Lua(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else if (count == 6 && LuaScriptMgr.CheckTypes(L, 1, typeof(UIGrid), typeof(GameObject), typeof(object), typeof(object), typeof(bool), typeof(float)))
		{
			UIGrid arg0 = (UIGrid)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject arg1 = (GameObject)LuaScriptMgr.GetLuaObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			bool arg4 = LuaDLL.lua_toboolean(L, 5);
			float arg5 = (float)LuaDLL.lua_tonumber(L, 6);
			CLUIUtl.resetList4Lua(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.resetList4Lua");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetCellTween(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 7);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		UITweener.Method arg5 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 6, typeof(UITweener.Method));
		TweenType arg6 = (TweenType)LuaScriptMgr.GetNetObject(L, 7, typeof(TweenType));
		CLUIUtl.resetCellTween(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetCellTweenPosition(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		UITweener.Method arg5 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 6, typeof(UITweener.Method));
		CLUIUtl.resetCellTweenPosition(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetCellTweenScale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		UITweener.Method arg5 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 6, typeof(UITweener.Method));
		CLUIUtl.resetCellTweenScale(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetCellTweenAlpha(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		UITweener.Method arg5 = (UITweener.Method)LuaScriptMgr.GetNetObject(L, 6, typeof(UITweener.Method));
		CLUIUtl.resetCellTweenAlpha(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetChatList(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		GameObject arg1 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		ArrayList arg2 = (ArrayList)LuaScriptMgr.GetNetObject(L, 3, typeof(ArrayList));
		Type arg3 = LuaScriptMgr.GetTypeObject(L, 4);
		float arg4 = (float)LuaScriptMgr.GetNumber(L, 5);
		object arg5 = LuaScriptMgr.GetVarObject(L, 6);
		CLUIUtl.resetChatList(arg0,arg1,arg2,arg3,arg4,arg5);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setTabSelected(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		CLUIUtl.setTabSelected(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int showConfirm(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			CLUIUtl.showConfirm(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			CLUIUtl.showConfirm(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 6)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			string arg2 = LuaScriptMgr.GetLuaString(L, 3);
			object arg3 = LuaScriptMgr.GetVarObject(L, 4);
			string arg4 = LuaScriptMgr.GetLuaString(L, 5);
			object arg5 = LuaScriptMgr.GetVarObject(L, 6);
			CLUIUtl.showConfirm(arg0,arg1,arg2,arg3,arg4,arg5);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.showConfirm");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setSpriteFit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			UISprite arg0 = (UISprite)LuaScriptMgr.GetUnityObject(L, 1, typeof(UISprite));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			CLUIUtl.setSpriteFit(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			UISprite arg0 = (UISprite)LuaScriptMgr.GetUnityObject(L, 1, typeof(UISprite));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			CLUIUtl.setSpriteFit(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLUIUtl.setSpriteFit");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onGetSprite(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		CLUIUtl.onGetSprite(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onGetSprite2(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		CLUIUtl.onGetSprite2(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setAllSpriteGray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		CLUIUtl.setAllSpriteGray(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setSpriteGray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UISprite arg0 = (UISprite)LuaScriptMgr.GetUnityObject(L, 1, typeof(UISprite));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		CLUIUtl.setSpriteGray(arg0,arg1);
		return 0;
	}
}

