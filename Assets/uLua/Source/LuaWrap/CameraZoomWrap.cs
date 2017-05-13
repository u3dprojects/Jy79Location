using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CameraZoomWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("zoom", zoom),
			new LuaMethod("zoomFromTo", zoomFromTo),
			new LuaMethod("New", _CreateCameraZoom),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("speed", get_speed, set_speed),
			new LuaField("camera", get_camera, set_camera),
			new LuaField("subCamera", get_subCamera, set_subCamera),
		};

		LuaScriptMgr.RegisterLib(L, "CameraZoom", typeof(CameraZoom), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCameraZoom(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CameraZoom class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CameraZoom);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CameraZoom.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.speed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_camera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name camera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index camera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.camera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_subCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subCamera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.subCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CameraZoom.self = (CameraZoom)LuaScriptMgr.GetUnityObject(L, 3, typeof(CameraZoom));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_speed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name speed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index speed on a nil value");
			}
		}

		obj.speed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_camera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name camera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index camera on a nil value");
			}
		}

		obj.camera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_subCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CameraZoom obj = (CameraZoom)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name subCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index subCamera on a nil value");
			}
		}

		obj.subCamera = (Camera)LuaScriptMgr.GetUnityObject(L, 3, typeof(Camera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int zoom(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		CameraZoom obj = (CameraZoom)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CameraZoom");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		object arg2 = LuaScriptMgr.GetVarObject(L, 4);
		obj.zoom(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int zoomFromTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 6);
		CameraZoom obj = (CameraZoom)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CameraZoom");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 4);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 5);
		object arg4 = LuaScriptMgr.GetVarObject(L, 6);
		obj.zoomFromTo(arg0,arg1,arg2,arg3,arg4);
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

