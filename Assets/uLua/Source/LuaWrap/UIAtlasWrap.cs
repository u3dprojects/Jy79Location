using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIAtlasWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("init", init),
			new LuaMethod("returnSpriteByname", returnSpriteByname),
			new LuaMethod("releaseAllTexturesImm", releaseAllTexturesImm),
			new LuaMethod("doReleaseTexture", doReleaseTexture),
			new LuaMethod("borrowSpriteByname", borrowSpriteByname),
			new LuaMethod("GetSprite", GetSprite),
			new LuaMethod("GetRandomSprite", GetRandomSprite),
			new LuaMethod("MarkSpriteListAsChanged", MarkSpriteListAsChanged),
			new LuaMethod("SortAlphabetically", SortAlphabetically),
			new LuaMethod("GetListOfSprites", GetListOfSprites),
			new LuaMethod("CheckIfRelated", CheckIfRelated),
			new LuaMethod("MarkAsChanged", MarkAsChanged),
			new LuaMethod("New", _CreateUIAtlas),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("releaseSpriteTime", get_releaseSpriteTime, set_releaseSpriteTime),
			new LuaField("isBorrowSpriteMode", get_isBorrowSpriteMode, set_isBorrowSpriteMode),
			new LuaField("spriteMap", get_spriteMap, set_spriteMap),
			new LuaField("spriteMaterial", get_spriteMaterial, set_spriteMaterial),
			new LuaField("premultipliedAlpha", get_premultipliedAlpha, null),
			new LuaField("spriteList", get_spriteList, set_spriteList),
			new LuaField("texture", get_texture, null),
			new LuaField("pixelSize", get_pixelSize, set_pixelSize),
			new LuaField("replacement", get_replacement, set_replacement),
		};

		LuaScriptMgr.RegisterLib(L, "UIAtlas", typeof(UIAtlas), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUIAtlas(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIAtlas class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(UIAtlas);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_releaseSpriteTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, UIAtlas.releaseSpriteTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isBorrowSpriteMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isBorrowSpriteMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isBorrowSpriteMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isBorrowSpriteMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMap on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.spriteMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteMaterial(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.spriteMaterial);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_premultipliedAlpha(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name premultipliedAlpha");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index premultipliedAlpha on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.premultipliedAlpha);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_spriteList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.spriteList);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_texture(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name texture");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index texture on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.texture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_pixelSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.pixelSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_replacement(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name replacement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.replacement);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_releaseSpriteTime(IntPtr L)
	{
		UIAtlas.releaseSpriteTime = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isBorrowSpriteMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isBorrowSpriteMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isBorrowSpriteMode on a nil value");
			}
		}

		obj.isBorrowSpriteMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteMap(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMap");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMap on a nil value");
			}
		}

		obj.spriteMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteMaterial(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteMaterial");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteMaterial on a nil value");
			}
		}

		obj.spriteMaterial = (Material)LuaScriptMgr.GetUnityObject(L, 3, typeof(Material));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_spriteList(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name spriteList");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index spriteList on a nil value");
			}
		}

		obj.spriteList = (List<UISpriteData>)LuaScriptMgr.GetNetObject(L, 3, typeof(List<UISpriteData>));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name pixelSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index pixelSize on a nil value");
			}
		}

		obj.pixelSize = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_replacement(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		UIAtlas obj = (UIAtlas)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name replacement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index replacement on a nil value");
			}
		}

		obj.replacement = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 3, typeof(UIAtlas));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int init(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		obj.init();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int returnSpriteByname(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.returnSpriteByname(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int releaseAllTexturesImm(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		obj.releaseAllTexturesImm();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doReleaseTexture(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			obj.doReleaseTexture(arg0);
			return 0;
		}
		else if (count == 3)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg1 = LuaScriptMgr.GetBoolean(L, 3);
			obj.doReleaseTexture(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIAtlas.doReleaseTexture");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int borrowSpriteByname(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			UISprite arg1 = (UISprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(UISprite));
			UISpriteData o = obj.borrowSpriteByname(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			UISprite arg1 = (UISprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(UISprite));
			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			UISpriteData o = obj.borrowSpriteByname(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 5)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			UISprite arg1 = (UISprite)LuaScriptMgr.GetUnityObject(L, 3, typeof(UISprite));
			object arg2 = LuaScriptMgr.GetVarObject(L, 4);
			object arg3 = LuaScriptMgr.GetVarObject(L, 5);
			UISpriteData o = obj.borrowSpriteByname(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIAtlas.borrowSpriteByname");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		UISpriteData o = obj.GetSprite(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetRandomSprite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		string o = obj.GetRandomSprite(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkSpriteListAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		obj.MarkSpriteListAsChanged();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SortAlphabetically(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		obj.SortAlphabetically();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetListOfSprites(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			BetterList<string> o = obj.GetListOfSprites();
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 2)
		{
			UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			BetterList<string> o = obj.GetListOfSprites(arg0);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIAtlas.GetListOfSprites");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckIfRelated(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIAtlas arg0 = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIAtlas));
		UIAtlas arg1 = (UIAtlas)LuaScriptMgr.GetUnityObject(L, 2, typeof(UIAtlas));
		bool o = UIAtlas.CheckIfRelated(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MarkAsChanged(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIAtlas obj = (UIAtlas)LuaScriptMgr.GetUnityObjectSelf(L, 1, "UIAtlas");
		obj.MarkAsChanged();
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

