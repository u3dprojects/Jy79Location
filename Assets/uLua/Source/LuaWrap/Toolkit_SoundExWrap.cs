using System;
using UnityEngine;
using LuaInterface;

public class Toolkit_SoundExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("PlaySoundWithCallback", PlaySoundWithCallback),
			new LuaMethod("playSound", playSound),
			new LuaMethod("onFinishSetAudio", onFinishSetAudio),
			new LuaMethod("playSoundSingleton", playSoundSingleton),
			new LuaMethod("onFinishSetAudio4Singleton", onFinishSetAudio4Singleton),
			new LuaMethod("playSound2", playSound2),
			new LuaMethod("onGetMainMusic", onGetMainMusic),
			new LuaMethod("doPlayMainMusic", doPlayMainMusic),
			new LuaMethod("playMainMusic", playMainMusic),
			new LuaMethod("New", _CreateToolkit_SoundEx),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("mainClip", get_mainClip, set_mainClip),
			new LuaField("soundEffSwitch", get_soundEffSwitch, set_soundEffSwitch),
			new LuaField("musicSwitch", get_musicSwitch, set_musicSwitch),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.SoundEx", typeof(Toolkit.SoundEx), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_SoundEx(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.SoundEx obj = new Toolkit.SoundEx();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.SoundEx.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.SoundEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_mainClip(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.SoundEx.mainClip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_soundEffSwitch(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.SoundEx.soundEffSwitch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_musicSwitch(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.SoundEx.musicSwitch);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_mainClip(IntPtr L)
	{
		Toolkit.SoundEx.mainClip = (AudioClip)LuaScriptMgr.GetUnityObject(L, 3, typeof(AudioClip));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_soundEffSwitch(IntPtr L)
	{
		Toolkit.SoundEx.soundEffSwitch = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_musicSwitch(IntPtr L)
	{
		Toolkit.SoundEx.musicSwitch = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int PlaySoundWithCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		MonoBehaviour arg0 = (MonoBehaviour)LuaScriptMgr.GetUnityObject(L, 1, typeof(MonoBehaviour));
		AudioClip arg1 = (AudioClip)LuaScriptMgr.GetUnityObject(L, 2, typeof(AudioClip));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		object arg3 = LuaScriptMgr.GetVarObject(L, 4);
		Toolkit.SoundEx.PlaySoundWithCallback(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playSound(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(AudioClip), typeof(float), typeof(int)))
		{
			AudioClip arg0 = (AudioClip)LuaScriptMgr.GetLuaObject(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			Toolkit.SoundEx.playSound(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(string), typeof(float), typeof(int)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			float arg1 = (float)LuaDLL.lua_tonumber(L, 2);
			int arg2 = (int)LuaDLL.lua_tonumber(L, 3);
			Toolkit.SoundEx.playSound(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.SoundEx.playSound");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetAudio(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		Toolkit.SoundEx.onFinishSetAudio(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playSoundSingleton(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Toolkit.SoundEx.playSoundSingleton(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onFinishSetAudio4Singleton(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		Toolkit.SoundEx.onFinishSetAudio4Singleton(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playSound2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Toolkit.SoundEx.playSound2(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int onGetMainMusic(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		Toolkit.SoundEx.onGetMainMusic(objs0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doPlayMainMusic(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AudioClip arg0 = (AudioClip)LuaScriptMgr.GetUnityObject(L, 1, typeof(AudioClip));
		Toolkit.SoundEx.doPlayMainMusic(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int playMainMusic(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Toolkit.SoundEx.playMainMusic();
		return 0;
	}
}

