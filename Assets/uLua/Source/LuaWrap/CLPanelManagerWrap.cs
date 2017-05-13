using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLPanelManagerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("showPanel", showPanel),
			new LuaMethod("hidePanel", hidePanel),
			new LuaMethod("showTopPanel", showTopPanel),
			new LuaMethod("doShowTopPanel", doShowTopPanel),
			new LuaMethod("hideTopPanel", hideTopPanel),
			new LuaMethod("hideAllPanel", hideAllPanel),
			new LuaMethod("Update", Update),
			new LuaMethod("Start", Start),
			new LuaMethod("clean", clean),
			new LuaMethod("reset", reset),
			new LuaMethod("resetPanelLua", resetPanelLua),
			new LuaMethod("destoryAllPanel", destoryAllPanel),
			new LuaMethod("getPanelAsy", getPanelAsy),
			new LuaMethod("onGetPanelAssetBundle", onGetPanelAssetBundle),
			new LuaMethod("finishGetPanel", finishGetPanel),
			new LuaMethod("resetAtlasAndFont", resetAtlasAndFont),
			new LuaMethod("getPanel", getPanel),
			new LuaMethod("destroyPanel", destroyPanel),
			new LuaMethod("New", _CreateCLPanelManager),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Const_RenderQueue", get_Const_RenderQueue, null),
			new LuaField("self", get_self, set_self),
			new LuaField("_uiPanelRoot", get__uiPanelRoot, set__uiPanelRoot),
			new LuaField("showingPanels", get_showingPanels, set_showingPanels),
			new LuaField("seaShowPanel", get_seaShowPanel, set_seaShowPanel),
			new LuaField("isShowPanel", get_isShowPanel, set_isShowPanel),
			new LuaField("isHidePanel", get_isHidePanel, set_isHidePanel),
			new LuaField("seaHidePanel", get_seaHidePanel, set_seaHidePanel),
			new LuaField("panelRetainLayer", get_panelRetainLayer, set_panelRetainLayer),
			new LuaField("isShowTopPanel", get_isShowTopPanel, set_isShowTopPanel),
			new LuaField("topPanel", get_topPanel, set_topPanel),
			new LuaField("oldPanel", get_oldPanel, set_oldPanel),
			new LuaField("oldoldPanel", get_oldoldPanel, set_oldoldPanel),
			new LuaField("isShowPrePanel", get_isShowPrePanel, set_isShowPrePanel),
			new LuaField("mainPanelName", get_mainPanelName, set_mainPanelName),
			new LuaField("panelBuff", get_panelBuff, set_panelBuff),
			new LuaField("panelAssetBundle", get_panelAssetBundle, set_panelAssetBundle),
			new LuaField("isFinishStart", get_isFinishStart, set_isFinishStart),
			new LuaField("uiPanelRoot", get_uiPanelRoot, null),
		};

		LuaScriptMgr.RegisterLib(L, "CLPanelManager", typeof(CLPanelManager), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLPanelManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLPanelManager class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLPanelManager);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Const_RenderQueue(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.Const_RenderQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__uiPanelRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelManager obj = (CLPanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _uiPanelRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _uiPanelRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._uiPanelRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_showingPanels(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.showingPanels);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_seaShowPanel(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.seaShowPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isShowPanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.isShowPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isHidePanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.isHidePanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_seaHidePanel(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.seaHidePanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelRetainLayer(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.panelRetainLayer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isShowTopPanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.isShowTopPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_topPanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.topPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_oldPanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.oldPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_oldoldPanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.oldoldPanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isShowPrePanel(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.isShowPrePanel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainPanelName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelManager obj = (CLPanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainPanelName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainPanelName on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainPanelName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelBuff(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.panelBuff);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelAssetBundle(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelManager.panelAssetBundle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFinishStart(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelManager.isFinishStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiPanelRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelManager obj = (CLPanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiPanelRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiPanelRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiPanelRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLPanelManager.self = (CLPanelManager)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPanelManager));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set__uiPanelRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelManager obj = (CLPanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _uiPanelRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _uiPanelRoot on a nil value");
			}
		}

		obj._uiPanelRoot = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_showingPanels(IntPtr L)
	{
		CLPanelManager.showingPanels = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_seaShowPanel(IntPtr L)
	{
		CLPanelManager.seaShowPanel = (Queue<CLPanelBase>)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue<CLPanelBase>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isShowPanel(IntPtr L)
	{
		CLPanelManager.isShowPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isHidePanel(IntPtr L)
	{
		CLPanelManager.isHidePanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_seaHidePanel(IntPtr L)
	{
		CLPanelManager.seaHidePanel = (Queue<CLPanelBase>)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue<CLPanelBase>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panelRetainLayer(IntPtr L)
	{
		CLPanelManager.panelRetainLayer = (Stack<CLPanelBase>)LuaScriptMgr.GetNetObject(L, 3, typeof(Stack<CLPanelBase>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isShowTopPanel(IntPtr L)
	{
		CLPanelManager.isShowTopPanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_topPanel(IntPtr L)
	{
		CLPanelManager.topPanel = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPanelBase));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_oldPanel(IntPtr L)
	{
		CLPanelManager.oldPanel = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPanelBase));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_oldoldPanel(IntPtr L)
	{
		CLPanelManager.oldoldPanel = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPanelBase));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isShowPrePanel(IntPtr L)
	{
		CLPanelManager.isShowPrePanel = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainPanelName(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelManager obj = (CLPanelManager)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainPanelName");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainPanelName on a nil value");
			}
		}

		obj.mainPanelName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panelBuff(IntPtr L)
	{
		CLPanelManager.panelBuff = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_panelAssetBundle(IntPtr L)
	{
		CLPanelManager.panelAssetBundle = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isFinishStart(IntPtr L)
	{
		CLPanelManager.isFinishStart = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int showPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
		CLPanelManager.showPanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hidePanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
		CLPanelManager.hidePanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int showTopPanel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
			CLPanelManager.showTopPanel(arg0);
			return 0;
		}
		else if (count == 3)
		{
			CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			CLPanelManager.showTopPanel(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLPanelManager.showTopPanel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doShowTopPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
		bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
		CLPanelManager.doShowTopPanel(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hideTopPanel(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			CLPanelManager.hideTopPanel();
			return 0;
		}
		else if (count == 2)
		{
			bool arg0 = LuaScriptMgr.GetBoolean(L, 1);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
			CLPanelManager.hideTopPanel(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLPanelManager.hideTopPanel");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hideAllPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CLPanelManager.hideAllPanel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelManager obj = (CLPanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelManager");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelManager obj = (CLPanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelManager");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelManager obj = (CLPanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelManager");
		obj.clean();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int reset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelManager obj = (CLPanelManager)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelManager");
		obj.reset();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetPanelLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CLPanelManager.resetPanelLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int destoryAllPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		CLPanelManager.destoryAllPanel();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getPanelAsy(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			CLPanelManager.getPanelAsy(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			object arg1 = LuaScriptMgr.GetVarObject(L, 2);
			object arg2 = LuaScriptMgr.GetVarObject(L, 3);
			CLPanelManager.getPanelAsy(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLPanelManager.getPanelAsy");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onGetPanelAssetBundle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		CLPanelManager.onGetPanelAssetBundle(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int finishGetPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		AssetBundle arg1 = (AssetBundle)LuaScriptMgr.GetUnityObject(L, 2, typeof(AssetBundle));
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		object arg3 = LuaScriptMgr.GetVarObject(L, 4);
		CLPanelManager.finishGetPanel(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int resetAtlasAndFont(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		CLPanelManager.resetAtlasAndFont(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		CLPanelBase o = CLPanelManager.getPanel(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int destroyPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase arg0 = (CLPanelBase)LuaScriptMgr.GetUnityObject(L, 1, typeof(CLPanelBase));
		CLPanelManager.destroyPanel(arg0);
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

