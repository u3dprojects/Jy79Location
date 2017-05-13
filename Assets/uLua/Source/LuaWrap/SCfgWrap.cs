using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class SCfgWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("New", _CreateSCfg),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("UUID", get_UUID, set_UUID),
			new LuaField("singinMd5Code", get_singinMd5Code, set_singinMd5Code),
			new LuaField("isNotEditorMode", get_isNotEditorMode, set_isNotEditorMode),
			new LuaField("isNetMode", get_isNetMode, set_isNetMode),
			new LuaField("isUseEncodedLua", get_isUseEncodedLua, set_isUseEncodedLua),
			new LuaField("isGuidMode", get_isGuidMode, set_isGuidMode),
			new LuaField("isFullEffect", get_isFullEffect, set_isFullEffect),
			new LuaField("useBio4Battle", get_useBio4Battle, set_useBio4Battle),
			new LuaField("fps", get_fps, set_fps),
			new LuaField("mainCamera", get_mainCamera, set_mainCamera),
			new LuaField("camera4Top", get_camera4Top, set_camera4Top),
			new LuaField("uiCamera", get_uiCamera, set_uiCamera),
			new LuaField("mainAudio", get_mainAudio, set_mainAudio),
			new LuaField("singletonAudio", get_singletonAudio, set_singletonAudio),
			new LuaField("mLookatTarget", get_mLookatTarget, set_mLookatTarget),
			new LuaField("mHUDRoot", get_mHUDRoot, set_mHUDRoot),
			new LuaField("mHUDRoot4Scene", get_mHUDRoot4Scene, set_mHUDRoot4Scene),
			new LuaField("mode", get_mode, set_mode),
			new LuaField("dragDropRoot", get_dragDropRoot, set_dragDropRoot),
			new LuaField("Channel", get_Channel, set_Channel),
			new LuaField("PakageName", get_PakageName, set_PakageName),
			new LuaField("isEditMode", get_isEditMode, null),
		};

		LuaScriptMgr.RegisterLib(L, "SCfg", typeof(SCfg), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSCfg(IntPtr L)
	{
		LuaDLL.luaL_error(L, "SCfg class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(SCfg);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, SCfg.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UUID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name UUID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index UUID on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.UUID);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_singinMd5Code(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name singinMd5Code");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index singinMd5Code on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.singinMd5Code);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNotEditorMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNotEditorMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNotEditorMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNotEditorMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isNetMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNetMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNetMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isNetMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isUseEncodedLua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isUseEncodedLua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isUseEncodedLua on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isUseEncodedLua);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isGuidMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isGuidMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isGuidMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isGuidMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFullEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isFullEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isFullEffect on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isFullEffect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useBio4Battle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useBio4Battle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useBio4Battle on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.useBio4Battle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fps(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fps");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fps on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.fps);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainCamera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_camera4Top(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name camera4Top");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index camera4Top on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.camera4Top);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uiCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiCamera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.uiCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainAudio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainAudio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainAudio on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mainAudio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_singletonAudio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name singletonAudio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index singletonAudio on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.singletonAudio);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mLookatTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mLookatTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mLookatTarget on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mLookatTarget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mHUDRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mHUDRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mHUDRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mHUDRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mHUDRoot4Scene(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mHUDRoot4Scene");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mHUDRoot4Scene on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mHUDRoot4Scene);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.mode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dragDropRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragDropRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragDropRoot on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dragDropRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Channel(IntPtr L)
	{
		LuaScriptMgr.Push(L, SCfg.Channel);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_PakageName(IntPtr L)
	{
		LuaScriptMgr.Push(L, SCfg.PakageName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isEditMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isEditMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isEditMode on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isEditMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		SCfg.self = (SCfg)LuaScriptMgr.GetUnityObject(L, 3, typeof(SCfg));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UUID(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name UUID");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index UUID on a nil value");
			}
		}

		obj.UUID = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_singinMd5Code(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name singinMd5Code");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index singinMd5Code on a nil value");
			}
		}

		obj.singinMd5Code = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNotEditorMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNotEditorMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNotEditorMode on a nil value");
			}
		}

		obj.isNotEditorMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isNetMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isNetMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isNetMode on a nil value");
			}
		}

		obj.isNetMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isUseEncodedLua(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isUseEncodedLua");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isUseEncodedLua on a nil value");
			}
		}

		obj.isUseEncodedLua = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isGuidMode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isGuidMode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isGuidMode on a nil value");
			}
		}

		obj.isGuidMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isFullEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isFullEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isFullEffect on a nil value");
			}
		}

		obj.isFullEffect = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useBio4Battle(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name useBio4Battle");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index useBio4Battle on a nil value");
			}
		}

		obj.useBio4Battle = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_fps(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name fps");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index fps on a nil value");
			}
		}

		obj.fps = (CLFPS)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLFPS));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainCamera on a nil value");
			}
		}

		obj.mainCamera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_camera4Top(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name camera4Top");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index camera4Top on a nil value");
			}
		}

		obj.camera4Top = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uiCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name uiCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index uiCamera on a nil value");
			}
		}

		obj.uiCamera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainAudio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mainAudio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mainAudio on a nil value");
			}
		}

		obj.mainAudio = (AudioSource)LuaScriptMgr.GetUnityObject(L, 3, typeof(AudioSource));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_singletonAudio(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name singletonAudio");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index singletonAudio on a nil value");
			}
		}

		obj.singletonAudio = (AudioSource)LuaScriptMgr.GetUnityObject(L, 3, typeof(AudioSource));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mLookatTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mLookatTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mLookatTarget on a nil value");
			}
		}

		obj.mLookatTarget = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mHUDRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mHUDRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mHUDRoot on a nil value");
			}
		}

		obj.mHUDRoot = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mHUDRoot4Scene(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mHUDRoot4Scene");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mHUDRoot4Scene on a nil value");
			}
		}

		obj.mHUDRoot4Scene = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mode(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name mode");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index mode on a nil value");
			}
		}

		obj.mode = (GameMode)LuaScriptMgr.GetNetObject(L, 3, typeof(GameMode));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dragDropRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		SCfg obj = (SCfg)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragDropRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragDropRoot on a nil value");
			}
		}

		obj.dragDropRoot = (GameObject)LuaScriptMgr.GetUnityObject(L, 3, typeof(GameObject));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Channel(IntPtr L)
	{
		SCfg.Channel = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_PakageName(IntPtr L)
	{
		SCfg.PakageName = LuaScriptMgr.GetString(L, 3);
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

