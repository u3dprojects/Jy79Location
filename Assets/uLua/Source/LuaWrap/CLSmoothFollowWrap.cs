using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLSmoothFollowWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LateUpdate", LateUpdate),
			new LuaMethod("New", _CreateCLSmoothFollow),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("target", get_target, set_target),
			new LuaField("distance", get_distance, set_distance),
			new LuaField("height", get_height, set_height),
			new LuaField("heightDamping", get_heightDamping, set_heightDamping),
			new LuaField("rotationDamping", get_rotationDamping, set_rotationDamping),
			new LuaField("isCanRotate", get_isCanRotate, set_isCanRotate),
			new LuaField("isRole", get_isRole, set_isRole),
		};

		LuaScriptMgr.RegisterLib(L, "CLSmoothFollow", typeof(CLSmoothFollow), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLSmoothFollow(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLSmoothFollow class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLSmoothFollow);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.target);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_distance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distance on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.distance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.height);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_heightDamping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heightDamping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heightDamping on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.heightDamping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationDamping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDamping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDamping on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rotationDamping);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isCanRotate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCanRotate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCanRotate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isCanRotate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isRole(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRole");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRole on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isRole);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name target");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index target on a nil value");
			}
		}

		obj.target = (Transform)LuaScriptMgr.GetUnityObject(L, 3, typeof(Transform));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_distance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name distance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index distance on a nil value");
			}
		}

		obj.distance = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_height(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name height");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index height on a nil value");
			}
		}

		obj.height = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_heightDamping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name heightDamping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index heightDamping on a nil value");
			}
		}

		obj.heightDamping = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationDamping(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationDamping");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationDamping on a nil value");
			}
		}

		obj.rotationDamping = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isCanRotate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isCanRotate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isCanRotate on a nil value");
			}
		}

		obj.isCanRotate = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isRole(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isRole");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isRole on a nil value");
			}
		}

		obj.isRole = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LateUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLSmoothFollow obj = (CLSmoothFollow)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLSmoothFollow");
		obj.LateUpdate();
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

