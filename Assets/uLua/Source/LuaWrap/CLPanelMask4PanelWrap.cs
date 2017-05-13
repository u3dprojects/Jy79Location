using System;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLPanelMask4PanelWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("_show", _show),
			new LuaMethod("_hide", _hide),
			new LuaMethod("onTweenFinish", onTweenFinish),
			new LuaMethod("show", show),
			new LuaMethod("hide", hide),
			new LuaMethod("New", _CreateCLPanelMask4Panel),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("tweenAlpha", get_tweenAlpha, set_tweenAlpha),
			new LuaField("sprite", get_sprite, set_sprite),
			new LuaField("label", get_label, set_label),
			new LuaField("self", get_self, set_self),
			new LuaField("defautSpriteNameList", get_defautSpriteNameList, set_defautSpriteNameList),
		};

		LuaScriptMgr.RegisterLib(L, "CLPanelMask4Panel", typeof(CLPanelMask4Panel), regs, fields, typeof(CLPanelLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLPanelMask4Panel(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLPanelMask4Panel class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLPanelMask4Panel);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenAlpha(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenAlpha on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.tweenAlpha);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sprite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sprite on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.sprite);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_label(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.label);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLPanelMask4Panel.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defautSpriteNameList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defautSpriteNameList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defautSpriteNameList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.defautSpriteNameList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenAlpha(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name tweenAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index tweenAlpha on a nil value");
			}
		}

		obj.tweenAlpha = (TweenAlpha)LuaScriptMgr.GetUnityObject(L, 3, typeof(TweenAlpha));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sprite(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name sprite");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index sprite on a nil value");
			}
		}

		obj.sprite = (UISprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(UISprite));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_label(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name label");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index label on a nil value");
			}
		}

		obj.label = (UILabel)LuaScriptMgr.GetUnityObject(L, 3, typeof(UILabel));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLPanelMask4Panel.self = (CLPanelMask4Panel)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLPanelMask4Panel));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defautSpriteNameList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defautSpriteNameList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defautSpriteNameList on a nil value");
			}
		}

		obj.defautSpriteNameList = (List<string>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<string>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelMask4Panel");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		List<string> arg1 = (List<string>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<string>));
		obj._show(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelMask4Panel");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj._hide(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onTweenFinish(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLPanelMask4Panel obj = (CLPanelMask4Panel)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLPanelMask4Panel");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.onTweenFinish(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int show(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		List<string> arg1 = (List<string>)LuaScriptMgr.GetNetObject(L, 2, typeof(List<string>));
		CLPanelMask4Panel.show(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int hide(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		CLPanelMask4Panel.hide(arg0);
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

