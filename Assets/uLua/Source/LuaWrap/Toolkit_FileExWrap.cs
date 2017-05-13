using System;
using System.Collections;
using UnityEngine;
using LuaInterface;

public class Toolkit_FileExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("TexturePath", TexturePath),
			new LuaMethod("ScriptPath", ScriptPath),
			new LuaMethod("DataPath", DataPath),
			new LuaMethod("BasePath", BasePath),
			new LuaMethod("BundlePath", BundlePath),
			new LuaMethod("StreamingAssets", StreamingAssets),
			new LuaMethod("OutPackagePbPath", OutPackagePbPath),
			new LuaMethod("InPackagePbPath", InPackagePbPath),
			new LuaMethod("AssetPath", AssetPath),
			new LuaMethod("FileExists", FileExists),
			new LuaMethod("WriteAllBytes", WriteAllBytes),
			new LuaMethod("ReadAllBytes", ReadAllBytes),
			new LuaMethod("WriteAllText", WriteAllText),
			new LuaMethod("AppendAllText", AppendAllText),
			new LuaMethod("ReadToEnd", ReadToEnd),
			new LuaMethod("Delete", Delete),
			new LuaMethod("DirectoryExists", DirectoryExists),
			new LuaMethod("CreateDirectory", CreateDirectory),
			new LuaMethod("GetFiles", GetFiles),
			new LuaMethod("SaveTexture2D", SaveTexture2D),
			new LuaMethod("LoadTexture2D", LoadTexture2D),
			new LuaMethod("readNewAllText", readNewAllText),
			new LuaMethod("readNewAllBytes", readNewAllBytes),
			new LuaMethod("getTextFromCache", getTextFromCache),
			new LuaMethod("getBytesFromCache", getBytesFromCache),
			new LuaMethod("cleanCache", cleanCache),
			new LuaMethod("New", _CreateToolkit_FileEx),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("FileTextMap", get_FileTextMap, set_FileTextMap),
			new LuaField("FileBytesMap", get_FileBytesMap, set_FileBytesMap),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.FileEx", typeof(Toolkit.FileEx), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_FileEx(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.FileEx obj = new Toolkit.FileEx();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.FileEx.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.FileEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FileTextMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Toolkit.FileEx.FileTextMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FileBytesMap(IntPtr L)
	{
		LuaScriptMgr.PushObject(L, Toolkit.FileEx.FileBytesMap);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FileTextMap(IntPtr L)
	{
		Toolkit.FileEx.FileTextMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_FileBytesMap(IntPtr L)
	{
		Toolkit.FileEx.FileBytesMap = (Hashtable)LuaScriptMgr.GetNetObject(L, 3, typeof(Hashtable));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int TexturePath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.TexturePath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ScriptPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.ScriptPath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DataPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.DataPath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BasePath(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			string o = Toolkit.FileEx.BasePath();
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string o = Toolkit.FileEx.BasePath(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.FileEx.BasePath");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BundlePath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.BundlePath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StreamingAssets(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.StreamingAssets();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OutPackagePbPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.OutPackagePbPath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InPackagePbPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.InPackagePbPath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AssetPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.FileEx.AssetPath();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FileExists(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.FileEx.FileExists(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteAllBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		Toolkit.FileEx.WriteAllBytes(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadAllBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] o = Toolkit.FileEx.ReadAllBytes(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteAllText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Toolkit.FileEx.WriteAllText(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppendAllText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Toolkit.FileEx.AppendAllText(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadToEnd(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Toolkit.FileEx.ReadToEnd(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Delete(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Toolkit.FileEx.Delete(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DirectoryExists(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.FileEx.DirectoryExists(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreateDirectory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.FileEx.CreateDirectory(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFiles(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			string[] o = Toolkit.FileEx.GetFiles();
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string[] o = Toolkit.FileEx.GetFiles(arg0);
			LuaScriptMgr.PushArray(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.FileEx.GetFiles");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SaveTexture2D(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] objs1 = LuaScriptMgr.GetArrayNumber<byte>(L, 2);
		Toolkit.FileEx.SaveTexture2D(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadTexture2D(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		string arg2 = LuaScriptMgr.GetLuaString(L, 3);
		Texture2D o = Toolkit.FileEx.LoadTexture2D(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readNewAllText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		IEnumerator o = Toolkit.FileEx.readNewAllText(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int readNewAllBytes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		IEnumerator o = Toolkit.FileEx.readNewAllBytes(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getTextFromCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Toolkit.FileEx.getTextFromCache(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getBytesFromCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] o = Toolkit.FileEx.getBytesFromCache(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cleanCache(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Toolkit.FileEx.cleanCache();
		return 0;
	}
}

