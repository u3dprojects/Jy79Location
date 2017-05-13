using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLPanelLuaWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("reLoadLua", reLoadLua),
			new LuaMethod("setLua", setLua),
			new LuaMethod("hideSelfOnKeyBack", hideSelfOnKeyBack),
			new LuaMethod("hide", hide),
			new LuaMethod("init", init),
			new LuaMethod("setData", setData),
			new LuaMethod("procNetwork", procNetwork),
			new LuaMethod("show", show),
			new LuaMethod("onfinishShowMask", onfinishShowMask),
			new LuaMethod("_show", _show),
			new LuaMethod("refresh", refresh),
			new LuaMethod("uiEventDelegate", uiEventDelegate),
			new LuaMethod("onClick4Lua", onClick4Lua),
			new LuaMethod("onDoubleClick4Lua", onDoubleClick4Lua),
			new LuaMethod("onHover4Lua", onHover4Lua),
			new LuaMethod("onPress4Lua", onPress4Lua),
			new LuaMethod("onDrag4Lua", onDrag4Lua),
			new LuaMethod("onDrop4Lua", onDrop4Lua),
			new LuaMethod("onKey4Lua", onKey4Lua),
			new LuaMethod("New", _CreateCLPanelLua),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "CLPanelLua", typeof(CLPanelLua), regs, fields, typeof(CLPanelBase));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLPanelLua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLPanelLua class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLPanelLua);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int reLoadLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj.reLoadLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hideSelfOnKeyBack(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		bool o = obj.hideSelfOnKeyBack();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj.hide();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj.init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.setData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int procNetwork(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.procNetwork(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int show(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
			obj.show();
			return 0;
		}
		else if (count == 2)
		{
			CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.show(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLPanelLua.show");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onfinishShowMask(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		obj.onfinishShowMask(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj._show();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int refresh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		obj.refresh();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int uiEventDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.uiEventDelegate(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onClick4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.onClick4Lua(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDoubleClick4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		obj.onDoubleClick4Lua(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onHover4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		obj.onHover4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onPress4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 4);
		obj.onPress4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDrag4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		Vector2 arg2 = LuaScriptMgr.GetVector2(L, 4);
		obj.onDrag4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onDrop4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		GameObject arg2 = (GameObject)LuaScriptMgr.GetUnityObject(L, 4, typeof(GameObject));
		obj.onDrop4Lua(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onKey4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelLua obj = (CLPanelLua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelLua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		string arg1 = LuaScriptMgr.GetLuaString(L, 3);
		KeyCode arg2 = (KeyCode)LuaScriptMgr.GetNetObject(L, 4, typeof(KeyCode));
		obj.onKey4Lua(arg0,arg1,arg2);
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

