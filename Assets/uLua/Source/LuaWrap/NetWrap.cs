using System;
using System.Collections;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class NetWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("setLua", setLua),
			new LuaMethod("dispatchGate4Lua", dispatchGate4Lua),
			new LuaMethod("dispatchGame4Lua", dispatchGame4Lua),
			new LuaMethod("dispatchHttp4Lua", dispatchHttp4Lua),
			new LuaMethod("connectGate", connectGate),
			new LuaMethod("connectGame", connectGame),
			new LuaMethod("sendGate", sendGate),
			new LuaMethod("send", send),
			new LuaMethod("sendHttpJson", sendHttpJson),
			new LuaMethod("doSendHttpJson", doSendHttpJson),
			new LuaMethod("getParas", getParas),
			new LuaMethod("sendHttp", sendHttp),
			new LuaMethod("sendHttp2", sendHttp2),
			new LuaMethod("doSendHttp", doSendHttp),
			new LuaMethod("chgMapKey", chgMapKey),
			new LuaMethod("heart", heart),
			new LuaMethod("doHeart", doHeart),
			new LuaMethod("cancelHeart", cancelHeart),
			new LuaMethod("New", _CreateNet),
			new LuaMethod("GetClassType", GetClassType),
			new LuaMethod("__eq", Lua_Eq),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("self", get_self, set_self),
			new LuaField("isReallyUseNet", get_isReallyUseNet, set_isReallyUseNet),
			new LuaField("选择网络", get_选择网络, set_选择网络),
			new LuaField("defHost", get_defHost, set_defHost),
			new LuaField("gatePort", get_gatePort, set_gatePort),
			new LuaField("httpPort", get_httpPort, set_httpPort),
			new LuaField("httpFunc", get_httpFunc, set_httpFunc),
			new LuaField("host", get_host, set_host),
			new LuaField("port", get_port, set_port),
			new LuaField("gateTcp", get_gateTcp, set_gateTcp),
			new LuaField("gameTcp", get_gameTcp, set_gameTcp),
			new LuaField("netGateDataQueue", get_netGateDataQueue, set_netGateDataQueue),
			new LuaField("netGameDataQueue", get_netGameDataQueue, set_netGameDataQueue),
			new LuaField("netHttpDataQueue", get_netHttpDataQueue, set_netHttpDataQueue),
			new LuaField("gateHost", get_gateHost, set_gateHost),
			new LuaField("baseUrl", get_baseUrl, null),
		};

		LuaScriptMgr.RegisterLib(L, "Net", typeof(Net), regs, fields, typeof(CLBaseLua));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNet(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Net class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Net);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_self(IntPtr L)
	{
		LuaScriptMgr.Push(L, Net.self);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isReallyUseNet(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isReallyUseNet");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isReallyUseNet on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.isReallyUseNet);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_选择网络(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name 选择网络");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index 选择网络 on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.选择网络);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_defHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defHost on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.defHost);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gatePort(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gatePort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gatePort on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.gatePort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_httpPort(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name httpPort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index httpPort on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.httpPort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_httpFunc(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name httpFunc");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index httpFunc on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.httpFunc);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_host(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name host");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index host on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.host);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_port(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name port");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index port on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.port);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gateTcp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gateTcp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gateTcp on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.gateTcp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameTcp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gameTcp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gameTcp on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.gameTcp);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_netGateDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netGateDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netGateDataQueue on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.netGateDataQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_netGameDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netGameDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netGameDataQueue on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.netGameDataQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_netHttpDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netHttpDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netHttpDataQueue on a nil value");
			}
		}

		LuaScriptMgr.PushObject(L, obj.netHttpDataQueue);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gateHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gateHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gateHost on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.gateHost);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_baseUrl(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name baseUrl");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index baseUrl on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.baseUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_self(IntPtr L)
	{
		Net.self = (Net)LuaScriptMgr.GetUnityObject(L, 3, typeof(Net));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isReallyUseNet(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name isReallyUseNet");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index isReallyUseNet on a nil value");
			}
		}

		obj.isReallyUseNet = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_选择网络(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name 选择网络");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index 选择网络 on a nil value");
			}
		}

		obj.选择网络 = (Net.NetWorkType)LuaScriptMgr.GetNetObject(L, 3, typeof(Net.NetWorkType));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_defHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name defHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index defHost on a nil value");
			}
		}

		obj.defHost = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gatePort(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gatePort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gatePort on a nil value");
			}
		}

		obj.gatePort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_httpPort(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name httpPort");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index httpPort on a nil value");
			}
		}

		obj.httpPort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_httpFunc(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name httpFunc");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index httpFunc on a nil value");
			}
		}

		obj.httpFunc = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_host(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name host");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index host on a nil value");
			}
		}

		obj.host = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_port(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name port");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index port on a nil value");
			}
		}

		obj.port = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gateTcp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gateTcp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gateTcp on a nil value");
			}
		}

		obj.gateTcp = (Tcp)LuaScriptMgr.GetNetObject(L, 3, typeof(Tcp));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gameTcp(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gameTcp");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gameTcp on a nil value");
			}
		}

		obj.gameTcp = (Tcp)LuaScriptMgr.GetNetObject(L, 3, typeof(Tcp));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_netGateDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netGateDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netGateDataQueue on a nil value");
			}
		}

		obj.netGateDataQueue = (Queue)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_netGameDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netGameDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netGameDataQueue on a nil value");
			}
		}

		obj.netGameDataQueue = (Queue)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_netHttpDataQueue(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name netHttpDataQueue");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index netHttpDataQueue on a nil value");
			}
		}

		obj.netHttpDataQueue = (Queue)LuaScriptMgr.GetNetObject(L, 3, typeof(Queue));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_gateHost(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Net obj = (Net)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name gateHost");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index gateHost on a nil value");
			}
		}

		obj.gateHost = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		obj.setLua();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int dispatchGate4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.dispatchGate4Lua(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int dispatchGame4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.dispatchGame4Lua(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int dispatchHttp4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.dispatchHttp4Lua(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int connectGate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		obj.connectGate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int connectGame(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.connectGame(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sendGate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		obj.sendGate(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int send(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		obj.send(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sendHttpJson(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		obj.sendHttpJson(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doSendHttpJson(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		IEnumerator o = obj.doSendHttpJson(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getParas(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		string o = obj.getParas(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sendHttp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		obj.sendHttp(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sendHttp2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		obj.sendHttp2(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doSendHttp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		IEnumerator o = obj.doSendHttp(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int chgMapKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		obj.chgMapKey(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int heart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		obj.heart();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doHeart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		obj.doHeart();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cancelHeart(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Net obj = (Net)LuaScriptMgr.GetUnityObjectSelf(L, 1, "Net");
		obj.cancelHeart();
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

