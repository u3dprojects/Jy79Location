using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLBehaviour4LuaWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("setLua", setLua),
			new LuaMethod("initGetLuaFunc", initGetLuaFunc),
			new LuaMethod("clean", clean),
			new LuaMethod("Start", Start),
			new LuaMethod("Awake", Awake),
			new LuaMethod("Update", Update),
			new LuaMethod("LateUpdate", LateUpdate),
			new LuaMethod("FixedUpdate", FixedUpdate),
			new LuaMethod("OnTriggerEnter", OnTriggerEnter),
			new LuaMethod("OnTriggerExit", OnTriggerExit),
			new LuaMethod("OnTriggerStay", OnTriggerStay),
			new LuaMethod("OnCollisionEnter", OnCollisionEnter),
			new LuaMethod("OnCollisionExit", OnCollisionExit),
			new LuaMethod("OnApplicationPause", OnApplicationPause),
			new LuaMethod("OnApplicationFocus", OnApplicationFocus),
			new LuaMethod("OnBecameInvisible", OnBecameInvisible),
			new LuaMethod("OnBecameVisible", OnBecameVisible),
			new LuaMethod("OnControllerColliderHit", OnControllerColliderHit),
			new LuaMethod("OnDestroy", OnDestroy),
			new LuaMethod("OnDisable", OnDisable),
			new LuaMethod("OnEnable", OnEnable),
			new LuaMethod("OnWillRenderObject", OnWillRenderObject),
			new LuaMethod("OnPreRender", OnPreRender),
			new LuaMethod("OnPostRender", OnPostRender),
			new LuaMethod("OnClick", OnClick),
			new LuaMethod("OnPress", OnPress),
			new LuaMethod("OnDrag", OnDrag),
			new LuaMethod("uiEventDelegate", uiEventDelegate),
			new LuaMethod("New", _CreateCLBehaviour4Lua),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("flclean", get_flclean, set_flclean),
			new LuaField("flStart", get_flStart, set_flStart),
			new LuaField("flUpdate", get_flUpdate, set_flUpdate),
			new LuaField("flLateUpdate", get_flLateUpdate, set_flLateUpdate),
			new LuaField("flFixedUpdate", get_flFixedUpdate, set_flFixedUpdate),
			new LuaField("flAwake", get_flAwake, set_flAwake),
			new LuaField("flOnTriggerEnter", get_flOnTriggerEnter, set_flOnTriggerEnter),
			new LuaField("flOnTriggerExit", get_flOnTriggerExit, set_flOnTriggerExit),
			new LuaField("flOnTriggerStay", get_flOnTriggerStay, set_flOnTriggerStay),
			new LuaField("flOnCollisionEnter", get_flOnCollisionEnter, set_flOnCollisionEnter),
			new LuaField("flOnCollisionExit", get_flOnCollisionExit, set_flOnCollisionExit),
			new LuaField("flOnApplicationPause", get_flOnApplicationPause, set_flOnApplicationPause),
			new LuaField("flOnApplicationFocus", get_flOnApplicationFocus, set_flOnApplicationFocus),
			new LuaField("flOnBecameInvisible", get_flOnBecameInvisible, set_flOnBecameInvisible),
			new LuaField("flOnBecameVisible", get_flOnBecameVisible, set_flOnBecameVisible),
			new LuaField("flOnControllerColliderHit", get_flOnControllerColliderHit, set_flOnControllerColliderHit),
			new LuaField("flOnDestroy", get_flOnDestroy, set_flOnDestroy),
			new LuaField("flOnDisable", get_flOnDisable, set_flOnDisable),
			new LuaField("flOnEnable", get_flOnEnable, set_flOnEnable),
			new LuaField("flOnWillRenderObject", get_flOnWillRenderObject, set_flOnWillRenderObject),
			new LuaField("flOnPreRender", get_flOnPreRender, set_flOnPreRender),
			new LuaField("flOnPostRender", get_flOnPostRender, set_flOnPostRender),
			new LuaField("flOnClick", get_flOnClick, set_flOnClick),
			new LuaField("flOnPress", get_flOnPress, set_flOnPress),
			new LuaField("flOnDrag", get_flOnDrag, set_flOnDrag),
			new LuaField("flUIEventDelegate", get_flUIEventDelegate, set_flUIEventDelegate),
		};

		LuaScriptMgr.RegisterLib(L, "CLBehaviour4Lua", typeof(CLBehaviour4Lua), regs, fields, typeof(CLBaseLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLBehaviour4Lua(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLBehaviour4Lua class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLBehaviour4Lua);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flclean(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flclean");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flclean on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flclean);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flStart on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flUpdate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flUpdate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flLateUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flLateUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flLateUpdate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flLateUpdate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flFixedUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flFixedUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flFixedUpdate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flFixedUpdate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flAwake on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flAwake);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnTriggerEnter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerEnter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerEnter on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnTriggerEnter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnTriggerExit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerExit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerExit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnTriggerExit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnTriggerStay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerStay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerStay on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnTriggerStay);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnCollisionEnter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnCollisionEnter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnCollisionEnter on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnCollisionEnter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnCollisionExit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnCollisionExit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnCollisionExit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnCollisionExit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnApplicationPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnApplicationPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnApplicationPause on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnApplicationPause);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnApplicationFocus(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnApplicationFocus");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnApplicationFocus on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnApplicationFocus);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnBecameInvisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnBecameInvisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnBecameInvisible on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnBecameInvisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnBecameVisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnBecameVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnBecameVisible on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnBecameVisible);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnControllerColliderHit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnControllerColliderHit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnControllerColliderHit on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnControllerColliderHit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnDestroy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDestroy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDestroy on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnDestroy);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnDisable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDisable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDisable on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnDisable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnEnable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnEnable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnEnable on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnEnable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnWillRenderObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnWillRenderObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnWillRenderObject on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnWillRenderObject);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnPreRender(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPreRender");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPreRender on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnPreRender);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnPostRender(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPostRender");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPostRender on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnPostRender);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnClick on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPress on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnPress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flOnDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDrag on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flOnDrag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_flUIEventDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flUIEventDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flUIEventDelegate on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.flUIEventDelegate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flclean(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flclean");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flclean on a nil value");
			}
		}

		obj.flclean = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flStart on a nil value");
			}
		}

		obj.flStart = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flUpdate on a nil value");
			}
		}

		obj.flUpdate = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flLateUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flLateUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flLateUpdate on a nil value");
			}
		}

		obj.flLateUpdate = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flFixedUpdate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flFixedUpdate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flFixedUpdate on a nil value");
			}
		}

		obj.flFixedUpdate = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flAwake(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flAwake");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flAwake on a nil value");
			}
		}

		obj.flAwake = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnTriggerEnter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerEnter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerEnter on a nil value");
			}
		}

		obj.flOnTriggerEnter = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnTriggerExit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerExit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerExit on a nil value");
			}
		}

		obj.flOnTriggerExit = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnTriggerStay(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnTriggerStay");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnTriggerStay on a nil value");
			}
		}

		obj.flOnTriggerStay = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnCollisionEnter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnCollisionEnter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnCollisionEnter on a nil value");
			}
		}

		obj.flOnCollisionEnter = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnCollisionExit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnCollisionExit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnCollisionExit on a nil value");
			}
		}

		obj.flOnCollisionExit = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnApplicationPause(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnApplicationPause");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnApplicationPause on a nil value");
			}
		}

		obj.flOnApplicationPause = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnApplicationFocus(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnApplicationFocus");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnApplicationFocus on a nil value");
			}
		}

		obj.flOnApplicationFocus = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnBecameInvisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnBecameInvisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnBecameInvisible on a nil value");
			}
		}

		obj.flOnBecameInvisible = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnBecameVisible(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnBecameVisible");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnBecameVisible on a nil value");
			}
		}

		obj.flOnBecameVisible = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnControllerColliderHit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnControllerColliderHit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnControllerColliderHit on a nil value");
			}
		}

		obj.flOnControllerColliderHit = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnDestroy(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDestroy");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDestroy on a nil value");
			}
		}

		obj.flOnDestroy = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnDisable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDisable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDisable on a nil value");
			}
		}

		obj.flOnDisable = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnEnable(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnEnable");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnEnable on a nil value");
			}
		}

		obj.flOnEnable = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnWillRenderObject(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnWillRenderObject");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnWillRenderObject on a nil value");
			}
		}

		obj.flOnWillRenderObject = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnPreRender(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPreRender");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPreRender on a nil value");
			}
		}

		obj.flOnPreRender = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnPostRender(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPostRender");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPostRender on a nil value");
			}
		}

		obj.flOnPostRender = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnClick on a nil value");
			}
		}

		obj.flOnClick = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnPress on a nil value");
			}
		}

		obj.flOnPress = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flOnDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flOnDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flOnDrag on a nil value");
			}
		}

		obj.flOnDrag = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_flUIEventDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name flUIEventDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index flUIEventDelegate on a nil value");
			}
		}

		obj.flUIEventDelegate = LuaScriptMgr.GetLuaFunction(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int initGetLuaFunc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.initGetLuaFunc();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int clean(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.clean();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.Start();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Awake(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.Awake();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Update(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.Update();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LateUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.LateUpdate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FixedUpdate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.FixedUpdate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnTriggerEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Collider arg0 = (Collider)LuaScriptMgr.GetUnityObject(L, 2, typeof(Collider));
		obj.OnTriggerEnter(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnTriggerExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Collider arg0 = (Collider)LuaScriptMgr.GetUnityObject(L, 2, typeof(Collider));
		obj.OnTriggerExit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnTriggerStay(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Collider arg0 = (Collider)LuaScriptMgr.GetUnityObject(L, 2, typeof(Collider));
		obj.OnTriggerStay(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnCollisionEnter(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Collision arg0 = (Collision)LuaScriptMgr.GetNetObject(L, 2, typeof(Collision));
		obj.OnCollisionEnter(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnCollisionExit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Collision arg0 = (Collision)LuaScriptMgr.GetNetObject(L, 2, typeof(Collision));
		obj.OnCollisionExit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnApplicationPause(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.OnApplicationPause(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnApplicationFocus(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.OnApplicationFocus(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBecameInvisible(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnBecameInvisible();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnBecameVisible(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnBecameVisible();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnControllerColliderHit(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		ControllerColliderHit arg0 = (ControllerColliderHit)LuaScriptMgr.GetNetObject(L, 2, typeof(ControllerColliderHit));
		obj.OnControllerColliderHit(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDestroy(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnDestroy();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDisable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnDisable();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnEnable(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnEnable();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnWillRenderObject(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnWillRenderObject();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPreRender(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnPreRender();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPostRender(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnPostRender();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		obj.OnClick();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnPress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		bool arg0 = LuaScriptMgr.GetBoolean(L, 2);
		obj.OnPress(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDrag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
		obj.OnDrag(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int uiEventDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLBehaviour4Lua obj = (CLBehaviour4Lua)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLBehaviour4Lua");
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 2, typeof(GameObject));
		obj.uiEventDelegate(arg0);
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

