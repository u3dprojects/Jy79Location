using System;
using LuaInterface;

public class System_IO_FileWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("AppendAllText", AppendAllText),
			new LuaMethod("AppendText", AppendText),
			new LuaMethod("Copy", Copy),
			new LuaMethod("CreateText", CreateText),
			new LuaMethod("Delete", Delete),
			new LuaMethod("Exists", Exists),
			new LuaMethod("GetAttributes", GetAttributes),
			new LuaMethod("GetCreationTime", GetCreationTime),
			new LuaMethod("GetCreationTimeUtc", GetCreationTimeUtc),
			new LuaMethod("GetLastAccessTime", GetLastAccessTime),
			new LuaMethod("GetLastAccessTimeUtc", GetLastAccessTimeUtc),
			new LuaMethod("GetLastWriteTime", GetLastWriteTime),
			new LuaMethod("GetLastWriteTimeUtc", GetLastWriteTimeUtc),
			new LuaMethod("Move", Move),
			new LuaMethod("Open", Open),
			new LuaMethod("OpenRead", OpenRead),
			new LuaMethod("OpenText", OpenText),
			new LuaMethod("OpenWrite", OpenWrite),
			new LuaMethod("Replace", Replace),
			new LuaMethod("SetAttributes", SetAttributes),
			new LuaMethod("SetCreationTime", SetCreationTime),
			new LuaMethod("SetCreationTimeUtc", SetCreationTimeUtc),
			new LuaMethod("SetLastAccessTime", SetLastAccessTime),
			new LuaMethod("SetLastAccessTimeUtc", SetLastAccessTimeUtc),
			new LuaMethod("SetLastWriteTime", SetLastWriteTime),
			new LuaMethod("SetLastWriteTimeUtc", SetLastWriteTimeUtc),
			new LuaMethod("ReadAllBytes", ReadAllBytes),
			new LuaMethod("ReadAllLines", ReadAllLines),
			new LuaMethod("ReadAllText", ReadAllText),
			new LuaMethod("WriteAllBytes", WriteAllBytes),
			new LuaMethod("WriteAllLines", WriteAllLines),
			new LuaMethod("WriteAllText", WriteAllText),
			new LuaMethod("Encrypt", Encrypt),
			new LuaMethod("Decrypt", Decrypt),
			new LuaMethod("New", _CreateSystem_IO_File),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaScriptMgr.RegisterLib(L, "System.IO.File", regs);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSystem_IO_File(IntPtr L)
	{
		LuaDLL.luaL_error(L, "System.IO.File class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(System.IO.File);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendAllText(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			System.IO.File.AppendAllText(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			System.Text.Encoding arg2 = (System.Text.Encoding)LuaScriptMgr.GetNetObject(L, 3, typeof(System.Text.Encoding));
			System.IO.File.AppendAllText(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.AppendAllText");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.StreamWriter o = System.IO.File.AppendText(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Copy(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			System.IO.File.Copy(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			bool arg2 = LuaScriptMgr.GetBoolean(L, 3);
			System.IO.File.Copy(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.Copy");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.StreamWriter o = System.IO.File.CreateText(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Delete(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.File.Delete(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Exists(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = System.IO.File.Exists(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAttributes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.FileAttributes o = System.IO.File.GetAttributes(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCreationTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetCreationTime(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetCreationTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetCreationTimeUtc(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLastAccessTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetLastAccessTime(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLastAccessTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetLastAccessTimeUtc(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLastWriteTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetLastWriteTime(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetLastWriteTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime o = System.IO.File.GetLastWriteTimeUtc(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Move(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		System.IO.File.Move(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Open(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			System.IO.FileMode arg1 = (System.IO.FileMode)LuaScriptMgr.GetNetObject(L, 2, typeof(System.IO.FileMode));
			System.IO.FileStream o = System.IO.File.Open(arg0,arg1);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			System.IO.FileMode arg1 = (System.IO.FileMode)LuaScriptMgr.GetNetObject(L, 2, typeof(System.IO.FileMode));
			System.IO.FileAccess arg2 = (System.IO.FileAccess)LuaScriptMgr.GetNetObject(L, 3, typeof(System.IO.FileAccess));
			System.IO.FileStream o = System.IO.File.Open(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			System.IO.FileMode arg1 = (System.IO.FileMode)LuaScriptMgr.GetNetObject(L, 2, typeof(System.IO.FileMode));
			System.IO.FileAccess arg2 = (System.IO.FileAccess)LuaScriptMgr.GetNetObject(L, 3, typeof(System.IO.FileAccess));
			System.IO.FileShare arg3 = (System.IO.FileShare)LuaScriptMgr.GetNetObject(L, 4, typeof(System.IO.FileShare));
			System.IO.FileStream o = System.IO.File.Open(arg0,arg1,arg2,arg3);
			LuaScriptMgr.PushObject(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.Open");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenRead(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.FileStream o = System.IO.File.OpenRead(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.StreamReader o = System.IO.File.OpenText(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OpenWrite(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.FileStream o = System.IO.File.OpenWrite(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Replace(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			string arg2 = LuaScriptMgr.GetLuaString(L, 3);
			System.IO.File.Replace(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 4)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			string arg2 = LuaScriptMgr.GetLuaString(L, 3);
			bool arg3 = LuaScriptMgr.GetBoolean(L, 4);
			System.IO.File.Replace(arg0,arg1,arg2,arg3);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.Replace");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetAttributes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.FileAttributes arg1 = (System.IO.FileAttributes)LuaScriptMgr.GetNetObject(L, 2, typeof(System.IO.FileAttributes));
		System.IO.File.SetAttributes(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCreationTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetCreationTime(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCreationTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetCreationTimeUtc(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLastAccessTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetLastAccessTime(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLastAccessTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetLastAccessTimeUtc(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLastWriteTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetLastWriteTime(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLastWriteTimeUtc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		DateTime arg1 = (DateTime)LuaScriptMgr.GetNetObject(L, 2, typeof(DateTime));
		System.IO.File.SetLastWriteTimeUtc(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadAllBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] o = System.IO.File.ReadAllBytes(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadAllLines(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] o = System.IO.File.ReadAllLines(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			System.Text.Encoding arg1 = (System.Text.Encoding)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.Encoding));
			string[] o = System.IO.File.ReadAllLines(arg0,arg1);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.ReadAllLines");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadAllText(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string o = System.IO.File.ReadAllText(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			System.Text.Encoding arg1 = (System.Text.Encoding)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.Encoding));
			string o = System.IO.File.ReadAllText(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.ReadAllText");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteAllBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		System.IO.File.WriteAllBytes(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteAllLines(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			System.IO.File.WriteAllLines(arg0,objs1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] objs1 = LuaScriptMgr.GetArrayString(L, 2);
			System.Text.Encoding arg2 = (System.Text.Encoding)LuaScriptMgr.GetNetObject(L, 3, typeof(System.Text.Encoding));
			System.IO.File.WriteAllLines(arg0,objs1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.WriteAllLines");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteAllText(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			System.IO.File.WriteAllText(arg0,arg1);
			return 0;
		}
		else if (count == 3)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			System.Text.Encoding arg2 = (System.Text.Encoding)LuaScriptMgr.GetNetObject(L, 3, typeof(System.Text.Encoding));
			System.IO.File.WriteAllText(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: System.IO.File.WriteAllText");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Encrypt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.File.Encrypt(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Decrypt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		System.IO.File.Decrypt(arg0);
		return 0;
	}
}

