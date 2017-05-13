using System;
using LuaInterface;

public class CLAssetTypeWrap
{
	static LuaMethod[] enums = new LuaMethod[]
	{
		new LuaMethod("text", Gettext),
		new LuaMethod("bytes", Getbytes),
		new LuaMethod("texture", Gettexture),
		new LuaMethod("assetBundle", GetassetBundle),
		new LuaMethod("IntToEnum", IntToEnum),
	};

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "CLAssetType", typeof(CLAssetType), enums);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Gettext(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLAssetType.text);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Getbytes(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLAssetType.bytes);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Gettexture(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLAssetType.texture);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetassetBundle(IntPtr L)
	{
		LuaScriptMgr.Push(L, CLAssetType.assetBundle);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		CLAssetType o = (CLAssetType)arg0;
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

