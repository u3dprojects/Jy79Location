using System;
using System.Collections;
using LuaInterface;

public class QueueWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("CopyTo", CopyTo),
			new LuaMethod("GetEnumerator", GetEnumerator),
			new LuaMethod("Clone", Clone),
			new LuaMethod("Clear", Clear),
			new LuaMethod("Contains", Contains),
			new LuaMethod("Dequeue", Dequeue),
			new LuaMethod("Enqueue", Enqueue),
			new LuaMethod("Peek", Peek),
			new LuaMethod("Synchronized", Synchronized),
			new LuaMethod("ToArray", ToArray),
			new LuaMethod("TrimToSize", TrimToSize),
			new LuaMethod("New", _CreateQueue),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("Count", get_Count, null),
			new LuaField("IsSynchronized", get_IsSynchronized, null),
			new LuaField("SyncRoot", get_SyncRoot, null),
		};

		LuaScriptMgr.RegisterLib(L, "System.Collections.Queue", typeof(Queue), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateQueue(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Queue obj = new Queue();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(ICollection)))
		{
			ICollection arg0 = (ICollection)LuaScriptMgr.GetNetObject(L, 1, typeof(ICollection));
			Queue obj = new Queue(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(int)))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Queue obj = new Queue(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2)
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Queue obj = new Queue(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Queue.New");
		}

		return 0;
	}

	static Type classType = typeof(Queue);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Queue obj = (Queue)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Count on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.Count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSynchronized(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Queue obj = (Queue)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsSynchronized");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsSynchronized on a nil value");
			}
		}

		LuaScriptMgr.Push(L, obj.IsSynchronized);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SyncRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);
		Queue obj = (Queue)o;

		if (obj == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name SyncRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index SyncRoot on a nil value");
			}
		}

		LuaScriptMgr.PushVarObject(L, obj.SyncRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		Array arg0 = (Array)LuaScriptMgr.GetNetObject(L, 2, typeof(Array));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.CopyTo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		IEnumerator o = obj.GetEnumerator();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object o = obj.Clone();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		obj.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dequeue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object o = obj.Dequeue();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Enqueue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.Enqueue(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Peek(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object o = obj.Peek();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Synchronized(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue arg0 = (Queue)LuaScriptMgr.GetNetObject(L, 1, typeof(Queue));
		Queue o = Queue.Synchronized(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		object[] o = obj.ToArray();
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TrimToSize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Queue obj = (Queue)LuaScriptMgr.GetNetObjectSelf(L, 1, "Queue");
		obj.TrimToSize();
		return 0;
	}
}

