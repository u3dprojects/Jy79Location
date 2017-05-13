using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UtilWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("LuaPath", LuaPath),
			new LuaMethod("SearchLuaPath", SearchLuaPath),
			new LuaMethod("AddLuaPath", AddLuaPath),
			new LuaMethod("RemoveLuaPath", RemoveLuaPath),
			new LuaMethod("Log", Log),
			new LuaMethod("LogWarning", LogWarning),
			new LuaMethod("LogError", LogError),
			new LuaMethod("ClearMemory", ClearMemory),
			new LuaMethod("CheckEnvironment", CheckEnvironment),
			new LuaMethod("getTypeByName", getTypeByName),
			new LuaMethod("AddButtonClick", AddButtonClick),
			new LuaMethod("SetButtonClick", SetButtonClick),
			new LuaMethod("RemoveButtonClick", RemoveButtonClick),
			new LuaMethod("SetButtonState", SetButtonState),
			new LuaMethod("SetButtonSpriteNormal", SetButtonSpriteNormal),
			new LuaMethod("SetButtonSpriteHover", SetButtonSpriteHover),
			new LuaMethod("SetButtonDisabled", SetButtonDisabled),
			new LuaMethod("SetButtonPressed", SetButtonPressed),
			new LuaMethod("SetButtonColorNormal", SetButtonColorNormal),
			new LuaMethod("SetTweenFinished", SetTweenFinished),
			new LuaMethod("RemoveTweenFinished", RemoveTweenFinished),
			new LuaMethod("GetInstanceId", GetInstanceId),
			new LuaMethod("UnBindHud", UnBindHud),
			new LuaMethod("BindHud", BindHud),
			new LuaMethod("New", _CreateUtil),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
		};

		LuaScriptMgr.RegisterLib(L, "Util", typeof(Util), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUtil(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Util obj = new Util();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Util.New");
		}

		return 0;
	}

	static Type classType = typeof(Util);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.LuaPath(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SearchLuaPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.SearchLuaPath(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddLuaPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.AddLuaPath(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveLuaPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.RemoveLuaPath(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.Log(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.LogWarning(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.LogError(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Util.ClearMemory();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CheckEnvironment(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		bool o = Util.CheckEnvironment();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getTypeByName(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type o = Util.getTypeByName(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddButtonClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		EventDelegate.Callback arg1 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (EventDelegate.Callback)LuaScriptMgr.GetNetObject(L, 2, typeof(EventDelegate.Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg1 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		Util.AddButtonClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		EventDelegate.Callback arg1 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (EventDelegate.Callback)LuaScriptMgr.GetNetObject(L, 2, typeof(EventDelegate.Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg1 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		Util.SetButtonClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveButtonClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		Util.RemoveButtonClick(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		Util.SetButtonState(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonSpriteNormal(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.SetButtonSpriteNormal(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonSpriteHover(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.SetButtonSpriteHover(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonDisabled(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.SetButtonDisabled(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonPressed(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.SetButtonPressed(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetButtonColorNormal(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UIButton arg0 = (UIButton)LuaScriptMgr.GetUnityObject(L, 1, typeof(UIButton));
		Color arg1 = LuaScriptMgr.GetColor(L, 2);
		Util.SetButtonColorNormal(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetTweenFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		UITweener arg0 = (UITweener)LuaScriptMgr.GetUnityObject(L, 1, typeof(UITweener));
		EventDelegate.Callback arg1 = null;
		LuaTypes funcType2 = LuaDLL.lua_type(L, 2);

		if (funcType2 != LuaTypes.LUA_TFUNCTION)
		{
			 arg1 = (EventDelegate.Callback)LuaScriptMgr.GetNetObject(L, 2, typeof(EventDelegate.Callback));
		}
		else
		{
			LuaFunction func = LuaScriptMgr.GetLuaFunction(L, 2);
			arg1 = (param0) =>
			{
				int top = func.BeginPCall();
				LuaScriptMgr.Push(L, param0);
				func.PCall(top, 1);
				func.EndPCall(top);
			};
		}

		Util.SetTweenFinished(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveTweenFinished(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		UITweener arg0 = (UITweener)LuaScriptMgr.GetUnityObject(L, 1, typeof(UITweener));
		Util.RemoveTweenFinished(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInstanceId(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Object arg0 = (Object)LuaScriptMgr.GetUnityObject(L, 1, typeof(Object));
		int o = Util.GetInstanceId(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnBindHud(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		Util.UnBindHud(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BindHud(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetUnityObject(L, 1, typeof(GameObject));
		Transform arg1 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		Vector3 arg2 = LuaScriptMgr.GetVector3(L, 3);
		Util.BindHud(arg0,arg1,arg2);
		return 0;
	}
}

