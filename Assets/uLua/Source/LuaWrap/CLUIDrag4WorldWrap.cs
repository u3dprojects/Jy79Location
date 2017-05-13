using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class CLUIDrag4WorldWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("setCanClickPanel", setCanClickPanel),
			new LuaMethod("removeCanClickPanel", removeCanClickPanel),
			new LuaMethod("OnDrag", OnDrag),
			new LuaMethod("getAngle", getAngle),
			new LuaMethod("procScaler", procScaler),
			new LuaMethod("CancelMovement", CancelMovement),
			new LuaMethod("CancelSpring", CancelSpring),
			new LuaMethod("New", _CreateCLUIDrag4World),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("onDragMoveDelegate", get_onDragMoveDelegate, set_onDragMoveDelegate),
			new LuaField("onEndDragMoveDelegate", get_onEndDragMoveDelegate, set_onEndDragMoveDelegate),
			new LuaField("main3DCamera", get_main3DCamera, set_main3DCamera),
			new LuaField("target", get_target, set_target),
			new LuaField("scaleTarget", get_scaleTarget, set_scaleTarget),
			new LuaField("canMove", get_canMove, set_canMove),
			new LuaField("canRotation", get_canRotation, set_canRotation),
			new LuaField("canRotationOneTouch", get_canRotationOneTouch, set_canRotationOneTouch),
			new LuaField("canScale", get_canScale, set_canScale),
			new LuaField("canDoInertance", get_canDoInertance, set_canDoInertance),
			new LuaField("scrollMomentum", get_scrollMomentum, set_scrollMomentum),
			new LuaField("dragEffect", get_dragEffect, set_dragEffect),
			new LuaField("momentumAmount", get_momentumAmount, set_momentumAmount),
			new LuaField("groundMask", get_groundMask, set_groundMask),
			new LuaField("viewCenter", get_viewCenter, set_viewCenter),
			new LuaField("viewRadius", get_viewRadius, set_viewRadius),
			new LuaField("rotationMini", get_rotationMini, set_rotationMini),
			new LuaField("rotationMax", get_rotationMax, set_rotationMax),
			new LuaField("scaleMini", get_scaleMini, set_scaleMini),
			new LuaField("scaleMax", get_scaleMax, set_scaleMax),
			new LuaField("scaleHeightMini", get_scaleHeightMini, set_scaleHeightMini),
			new LuaField("scaleHeightMax", get_scaleHeightMax, set_scaleHeightMax),
			new LuaField("rotateSpeed", get_rotateSpeed, set_rotateSpeed),
			new LuaField("scaleSpeed", get_scaleSpeed, set_scaleSpeed),
			new LuaField("dragMovement", get_dragMovement, set_dragMovement),
			new LuaField("_scaleValue", get__scaleValue, null),
		};

		LuaScriptMgr.RegisterLib(L, "CLUIDrag4World", typeof(CLUIDrag4World), regs, fields, typeof(MonoBehaviour));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateCLUIDrag4World(IntPtr L)
	{
		LuaDLL.luaL_error(L, "CLUIDrag4World class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(CLUIDrag4World);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLUIDrag4World.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragMoveDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragMoveDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragMoveDelegate on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.onDragMoveDelegate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onEndDragMoveDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onEndDragMoveDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onEndDragMoveDelegate on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.onEndDragMoveDelegate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_main3DCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name main3DCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index main3DCamera on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.main3DCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

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
	static int get_scaleTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleTarget on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleTarget);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canMove on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canMove);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canRotation on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canRotation);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canRotationOneTouch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canRotationOneTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canRotationOneTouch on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canRotationOneTouch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canScale on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canScale);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_canDoInertance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canDoInertance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canDoInertance on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.canDoInertance);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scrollMomentum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollMomentum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollMomentum on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scrollMomentum);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dragEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragEffect on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dragEffect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_momentumAmount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name momentumAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index momentumAmount on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.momentumAmount);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_groundMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name groundMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index groundMask on a nil value");
			}
		}

		LuaScriptMgr.PushValue(L, obj.groundMask);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_viewCenter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name viewCenter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index viewCenter on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.viewCenter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_viewRadius(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name viewRadius");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index viewRadius on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.viewRadius);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationMini on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rotationMini);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotationMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationMax on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rotationMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleMini on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleMini);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleMax on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleHeightMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleHeightMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleHeightMini on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleHeightMini);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleHeightMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleHeightMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleHeightMax on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleHeightMax);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_rotateSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotateSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotateSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.rotateSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_scaleSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleSpeed on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.scaleSpeed);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_dragMovement(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragMovement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragMovement on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.dragMovement);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get__scaleValue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name _scaleValue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index _scaleValue on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj._scaleValue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		CLUIDrag4World.self = (CLUIDrag4World)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLUIDrag4World));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragMoveDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragMoveDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragMoveDelegate on a nil value");
			}
		}

		obj.onDragMoveDelegate = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onEndDragMoveDelegate(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onEndDragMoveDelegate");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onEndDragMoveDelegate on a nil value");
			}
		}

		obj.onEndDragMoveDelegate = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_main3DCamera(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name main3DCamera");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index main3DCamera on a nil value");
			}
		}

		obj.main3DCamera = (MyMainCamera)LuaScriptMgr.GetUnityObject(L, 3, typeof(MyMainCamera));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_target(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

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
	static int set_scaleTarget(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleTarget");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleTarget on a nil value");
			}
		}

		obj.scaleTarget = (CLSmoothFollow)LuaScriptMgr.GetUnityObject(L, 3, typeof(CLSmoothFollow));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canMove(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canMove");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canMove on a nil value");
			}
		}

		obj.canMove = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canRotation(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canRotation");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canRotation on a nil value");
			}
		}

		obj.canRotation = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canRotationOneTouch(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canRotationOneTouch");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canRotationOneTouch on a nil value");
			}
		}

		obj.canRotationOneTouch = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canScale(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canScale");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canScale on a nil value");
			}
		}

		obj.canScale = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_canDoInertance(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name canDoInertance");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index canDoInertance on a nil value");
			}
		}

		obj.canDoInertance = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scrollMomentum(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scrollMomentum");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scrollMomentum on a nil value");
			}
		}

		obj.scrollMomentum = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dragEffect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragEffect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragEffect on a nil value");
			}
		}

		obj.dragEffect = (CLUIDrag4World.DragEffect)LuaScriptMgr.GetNetObject(L, 3, typeof(CLUIDrag4World.DragEffect));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_momentumAmount(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name momentumAmount");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index momentumAmount on a nil value");
			}
		}

		obj.momentumAmount = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_groundMask(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name groundMask");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index groundMask on a nil value");
			}
		}

		obj.groundMask = (LayerMask)LuaScriptMgr.GetNetObject(L, 3, typeof(LayerMask));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_viewCenter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name viewCenter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index viewCenter on a nil value");
			}
		}

		obj.viewCenter = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_viewRadius(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name viewRadius");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index viewRadius on a nil value");
			}
		}

		obj.viewRadius = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationMini on a nil value");
			}
		}

		obj.rotationMini = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotationMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotationMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotationMax on a nil value");
			}
		}

		obj.rotationMax = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleMini on a nil value");
			}
		}

		obj.scaleMini = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleMax on a nil value");
			}
		}

		obj.scaleMax = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleHeightMini(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleHeightMini");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleHeightMini on a nil value");
			}
		}

		obj.scaleHeightMini = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleHeightMax(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleHeightMax");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleHeightMax on a nil value");
			}
		}

		obj.scaleHeightMax = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_rotateSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name rotateSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index rotateSpeed on a nil value");
			}
		}

		obj.rotateSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_scaleSpeed(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name scaleSpeed");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index scaleSpeed on a nil value");
			}
		}

		obj.scaleSpeed = (float)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_dragMovement(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name dragMovement");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index dragMovement on a nil value");
			}
		}

		obj.dragMovement = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setCanClickPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		CLUIDrag4World.setCanClickPanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int removeCanClickPanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		CLUIDrag4World.removeCanClickPanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDrag(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLUIDrag4World obj = (CLUIDrag4World)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIDrag4World");
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 2);
		obj.OnDrag(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAngle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLUIDrag4World obj = (CLUIDrag4World)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIDrag4World");
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 2);
		float o = obj.getAngle(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int procScaler(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		CLUIDrag4World obj = (CLUIDrag4World)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIDrag4World");
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		obj.procScaler(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelMovement(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIDrag4World");
		obj.CancelMovement();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CancelSpring(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		CLUIDrag4World obj = (CLUIDrag4World)LuaScriptMgr.GetUnityObjectSelf(L, 1, "CLUIDrag4World");
		obj.CancelSpring();
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

