using System;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLPanelBaseWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("SortByName", SortByName),
			new LuaMethod("Start", Start),
			new LuaMethod("sortTweeners", sortTweeners),
			new LuaMethod("showWithEffect", showWithEffect),
			new LuaMethod("hideWithEffect", hideWithEffect),
			new LuaMethod("Update", Update),
			new LuaMethod("onNetwork", onNetwork),
			new LuaMethod("procNetwork", procNetwork),
			new LuaMethod("init", init),
			new LuaMethod("getSubPanelsDepth", getSubPanelsDepth),
			new LuaMethod("setSubPanelsDepth", setSubPanelsDepth),
			new LuaMethod("setData", setData),
			new LuaMethod("show", show),
			new LuaMethod("refresh", refresh),
			new LuaMethod("hideSelfOnKeyBack", hideSelfOnKeyBack),
			new LuaMethod("hide", hide),
			new LuaMethod("OnDestroy", OnDestroy),
			new LuaMethod("New", _CreateCLPanelBase),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("isNeedBackplate", get_isNeedBackplate, set_isNeedBackplate),
			new LuaField("destroyWhenHide", get_destroyWhenHide, set_destroyWhenHide),
			new LuaField("isNeedResetAtlase", get_isNeedResetAtlase, set_isNeedResetAtlase),
			new LuaField("isNeedMask4Init", get_isNeedMask4Init, set_isNeedMask4Init),
			new LuaField("isHideWithEffect", get_isHideWithEffect, set_isHideWithEffect),
			new LuaField("isRefeshContentWhenEffectFinish", get_isRefeshContentWhenEffectFinish, set_isRefeshContentWhenEffectFinish),
			new LuaField("EffectRoot", get_EffectRoot, set_EffectRoot),
			new LuaField("effectType", get_effectType, set_effectType),
			new LuaField("EffectList", get_EffectList, set_EffectList),
			new LuaField("networkQueue", get_networkQueue, set_networkQueue),
			new LuaField("isFinishInit", get_isFinishInit, set_isFinishInit),
			new LuaField("isActive", get_isActive, set_isActive),
			new LuaField("panel", get_panel, null),
			new LuaField("depth", get_depth, set_depth),
		};

		LuaScriptMgr.RegisterLib(L, "CLPanelBase", typeof(CLPanelBase), regs, fields, typeof(CLBaseLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLPanelBase(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLPanelBase class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLPanelBase);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNeedBackplate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedBackplate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedBackplate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNeedBackplate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_destroyWhenHide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name destroyWhenHide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index destroyWhenHide on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.destroyWhenHide);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNeedResetAtlase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedResetAtlase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedResetAtlase on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNeedResetAtlase);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNeedMask4Init(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedMask4Init");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedMask4Init on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNeedMask4Init);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isHideWithEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isHideWithEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isHideWithEffect on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isHideWithEffect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRefeshContentWhenEffectFinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRefeshContentWhenEffectFinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRefeshContentWhenEffectFinish on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isRefeshContentWhenEffectFinish);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EffectRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name EffectRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index EffectRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.EffectRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectType on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.effectType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_EffectList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name EffectList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index EffectList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.EffectList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_networkQueue(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, CLPanelBase.networkQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFinishInit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isFinishInit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isFinishInit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isFinishInit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isActive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isActive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isActive on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isActive);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panel(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name panel");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index panel on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.panel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNeedBackplate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedBackplate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedBackplate on a nil value");
			}
		}

		obj.isNeedBackplate = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_destroyWhenHide(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name destroyWhenHide");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index destroyWhenHide on a nil value");
			}
		}

		obj.destroyWhenHide = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNeedResetAtlase(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedResetAtlase");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedResetAtlase on a nil value");
			}
		}

		obj.isNeedResetAtlase = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNeedMask4Init(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNeedMask4Init");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNeedMask4Init on a nil value");
			}
		}

		obj.isNeedMask4Init = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isHideWithEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isHideWithEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isHideWithEffect on a nil value");
			}
		}

		obj.isHideWithEffect = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRefeshContentWhenEffectFinish(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRefeshContentWhenEffectFinish");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRefeshContentWhenEffectFinish on a nil value");
			}
		}

		obj.isRefeshContentWhenEffectFinish = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_EffectRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name EffectRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index EffectRoot on a nil value");
			}
		}

		obj.EffectRoot = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectType(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name effectType");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index effectType on a nil value");
			}
		}

		obj.effectType = (CLPanelBase.EffectType)LuaScriptMgr.GetNetObject(L, 3, typeof(CLPanelBase.EffectType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_EffectList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name EffectList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index EffectList on a nil value");
			}
		}

		obj.EffectList = (List<UITweener>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<UITweener>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_networkQueue(IntPtr L)
	{
		CLPanelBase.networkQueue = (Queue<CLPanelBase.OnNetWorkData>)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue<CLPanelBase.OnNetWorkData>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isFinishInit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isFinishInit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isFinishInit on a nil value");
			}
		}

		obj.isFinishInit = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isActive(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isActive");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isActive on a nil value");
			}
		}

		obj.isActive = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_depth(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelBase obj = (CLPanelBase)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name depth");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index depth on a nil value");
			}
		}

		obj.depth = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SortByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITweener arg0 = (UITweener)LuaScriptMgr.GetUnityObject(L, 1, typeof(UITweener));
		UITweener arg1 = (UITweener)LuaScriptMgr.GetUnityObject(L, 2, typeof(UITweener));
		int o = CLPanelBase.SortByName(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sortTweeners(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		UITweener[] objs0 = LuaScriptMgr.GetArrayObject<UITweener>(L, 2);
		obj.sortTweeners(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int showWithEffect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.showWithEffect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hideWithEffect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.hideWithEffect(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onNetwork(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.onNetwork(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int procNetwork(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 5);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		object arg3 = LuaScriptMgr.GetVarObject(L, 5);
		obj.procNetwork(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getSubPanelsDepth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.getSubPanelsDepth();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setSubPanelsDepth(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.setSubPanelsDepth();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.setData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int show(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
			obj.show();
			return 0;
		}
		else if (count == 2)
		{
			CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
			object arg0 = LuaScriptMgr.GetVarObject(L, 2);
			obj.show(arg0);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: CLPanelBase.show");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int refresh(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.refresh();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hideSelfOnKeyBack(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		bool o = obj.hideSelfOnKeyBack();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.hide();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLPanelBase obj = (CLPanelBase)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelBase");
		obj.OnDestroy();
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

