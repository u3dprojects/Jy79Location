using System;
using UnityEngine;
using System.Collections;
using LuaInterface;

public class UtlWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("uuid", uuid),
			new LuaMethod("GetMacAddress", GetMacAddress),
			new LuaMethod("vector2ToMap", vector2ToMap),
			new LuaMethod("vector3ToMap", vector3ToMap),
			new LuaMethod("vector4ToMap", vector4ToMap),
			new LuaMethod("mapToVector2", mapToVector2),
			new LuaMethod("mapToVector3", mapToVector3),
			new LuaMethod("filterPath", filterPath),
			new LuaMethod("colorToMap", colorToMap),
			new LuaMethod("mapToColor", mapToColor),
			new LuaMethod("fileToMap", fileToMap),
			new LuaMethod("fileToObj", fileToObj),
			new LuaMethod("fileToMapAsyn4Lua", fileToMapAsyn4Lua),
			new LuaMethod("fileToMapAsyn", fileToMapAsyn),
			new LuaMethod("getAudioClip", getAudioClip),
			new LuaMethod("getAnimation", getAnimation),
			new LuaMethod("getAnimationCurve", getAnimationCurve),
			new LuaMethod("getMainAsset", getMainAsset),
			new LuaMethod("getMainAssetTexture", getMainAssetTexture),
			new LuaMethod("loadAssetsBunlde", loadAssetsBunlde),
			new LuaMethod("loadAssetsBunldeOnly", loadAssetsBunldeOnly),
			new LuaMethod("getAssetFromPath", getAssetFromPath),
			new LuaMethod("rotateTowardsForecast", rotateTowardsForecast),
			new LuaMethod("RotateTowards", RotateTowards),
			new LuaMethod("getAngle", getAngle),
			new LuaMethod("setBodyMatEdit", setBodyMatEdit),
			new LuaMethod("distance", distance),
			new LuaMethod("distance4Loc", distance4Loc),
			new LuaMethod("MapToString", MapToString),
			new LuaMethod("ArrayListToString2", ArrayListToString2),
			new LuaMethod("ArrayListToString", ArrayListToString),
			new LuaMethod("drawGrid", drawGrid),
			new LuaMethod("drawLine", drawLine),
			new LuaMethod("cloneRes", cloneRes),
			new LuaMethod("loadRes", loadRes),
			new LuaMethod("loadGobj", loadGobj),
			new LuaMethod("doLua", doLua),
			new LuaMethod("addVector2", addVector2),
			new LuaMethod("addVector3", addVector3),
			new LuaMethod("cutVector2", cutVector2),
			new LuaMethod("cutVector3", cutVector3),
			new LuaMethod("sign", sign),
			new LuaMethod("getChild", getChild),
			new LuaMethod("saveData", saveData),
			new LuaMethod("getDataByte", getDataByte),
			new LuaMethod("getDataByteByMap", getDataByteByMap),
			new LuaMethod("getData", getData),
			new LuaMethod("getDataByBts", getDataByBts),
			new LuaMethod("chgToSKCard", chgToSKCard),
			new LuaMethod("getMapFnamesInFolder", getMapFnamesInFolder),
			new LuaMethod("getOrderInFolder", getOrderInFolder),
			new LuaMethod("MD5Encrypt", MD5Encrypt),
			new LuaMethod("netIsActived", netIsActived),
			new LuaMethod("getNetState", getNetState),
			new LuaMethod("urlAddTimes", urlAddTimes),
			new LuaMethod("getSingInCodeAndroid", getSingInCodeAndroid),
			new LuaMethod("getLayer", getLayer),
			new LuaMethod("getRaycastHitInfor", getRaycastHitInfor),
			new LuaMethod("doCallback", doCallback),
			new LuaMethod("New", _CreateUtl),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("kXAxis", get_kXAxis, set_kXAxis),
			new LuaField("kZAxis", get_kZAxis, set_kZAxis),
			new LuaField("uid", get_uid, null),
			new LuaField("isApplePlatform", get_isApplePlatform, null),
		};

		LuaScriptMgr.RegisterLib(L, "Utl", typeof(Utl), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUtl(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Utl class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Utl);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kXAxis(IntPtr L)
	{
		LuaScriptMgr.Push(L, Utl.kXAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kZAxis(IntPtr L)
	{
		LuaScriptMgr.Push(L, Utl.kZAxis);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid(IntPtr L)
	{
		LuaScriptMgr.Push(L, Utl.uid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isApplePlatform(IntPtr L)
	{
		LuaScriptMgr.Push(L, Utl.isApplePlatform);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_kXAxis(IntPtr L)
	{
		Utl.kXAxis = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_kZAxis(IntPtr L)
	{
		Utl.kZAxis = LuaScriptMgr.GetVector3(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int uuid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Utl.uuid();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetMacAddress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Utl.GetMacAddress();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int vector2ToMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
		Hashtable o = Utl.vector2ToMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int vector3ToMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
		Hashtable o = Utl.vector3ToMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int vector4ToMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector4 arg0 = LuaScriptMgr.GetVector4(L, 1);
		Hashtable o = Utl.vector4ToMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int mapToVector2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Vector2 o = Utl.mapToVector2(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int mapToVector3(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Vector3 o = Utl.mapToVector3(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int filterPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Utl.filterPath(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int colorToMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Color arg0 = LuaScriptMgr.GetColor(L, 1);
		Hashtable o = Utl.colorToMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int mapToColor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		Color o = Utl.mapToColor(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fileToMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Hashtable o = Utl.fileToMap(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fileToObj(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object o = Utl.fileToObj(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fileToMapAsyn4Lua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		object arg3 = LuaScriptMgr.GetVarObject(L, 4);
		Utl.fileToMapAsyn4Lua(arg0,arg1,arg2,arg3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int fileToMapAsyn(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		object[] objs2 = LuaScriptMgr.GetParamsObject(L, 3, count - 2);
		Utl.fileToMapAsyn(arg0,arg1,objs2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAudioClip(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		AudioClip o = Utl.getAudioClip(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAnimation(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Animation o = Utl.getAnimation(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAnimationCurve(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ArrayList arg0 = (ArrayList)LuaScriptMgr.GetNetObject(L, 1, typeof(ArrayList));
		WrapMode arg1 = (WrapMode)LuaScriptMgr.GetNetObject(L, 2, typeof(WrapMode));
		WrapMode arg2 = (WrapMode)LuaScriptMgr.GetNetObject(L, 3, typeof(WrapMode));
		AnimationCurve o = Utl.getAnimationCurve(arg0,arg1,arg2);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getMainAsset(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AssetBundle arg0 = (AssetBundle)LuaScriptMgr.GetUnityObject(L, 1, typeof(AssetBundle));
		GameObject o = Utl.getMainAsset(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getMainAssetTexture(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		AssetBundle arg0 = (AssetBundle)LuaScriptMgr.GetUnityObject(L, 1, typeof(AssetBundle));
		Texture o = Utl.getMainAssetTexture(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int loadAssetsBunlde(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		object arg3 = LuaScriptMgr.GetVarObject(L, 4);
		IEnumerator o = Utl.loadAssetsBunlde(objs0,arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int loadAssetsBunldeOnly(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		object arg3 = LuaScriptMgr.GetVarObject(L, 4);
		IEnumerator o = Utl.loadAssetsBunldeOnly(objs0,arg1,arg2,arg3);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAssetFromPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		object arg2 = LuaScriptMgr.GetVarObject(L, 3);
		Utl.getAssetFromPath(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int rotateTowardsForecast(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform arg1 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Utl.rotateTowardsForecast(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RotateTowards(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2)
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Utl.RotateTowards(arg0,arg1);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Transform), typeof(LuaTable), typeof(float)))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetLuaObject(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			float arg2 = (float)LuaDLL.lua_tonumber(L, 3);
			Utl.RotateTowards(arg0,arg1,arg2);
			return 0;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, 1, typeof(Transform), typeof(LuaTable), typeof(LuaTable)))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetLuaObject(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Vector3 arg2 = LuaScriptMgr.GetVector3(L, 3);
			Utl.RotateTowards(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.RotateTowards");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getAngle(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 o = Utl.getAngle(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable)))
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Vector3 o = Utl.getAngle(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Transform), typeof(LuaTable)))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetLuaObject(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			Vector3 o = Utl.getAngle(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.getAngle");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int setBodyMatEdit(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
			Utl.setBodyMatEdit(arg0);
			return 0;
		}
		else if (count == 2)
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
			Shader arg1 = (Shader)LuaScriptMgr.GetUnityObject(L, 2, typeof(Shader));
			Utl.setBodyMatEdit(arg0,arg1);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.setBodyMatEdit");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int distance(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable)))
		{
			Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
			Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
			float o = Utl.distance(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(LuaTable), typeof(LuaTable)))
		{
			Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
			Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
			float o = Utl.distance(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, 1, typeof(Transform), typeof(Transform)))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetLuaObject(L, 1);
			Transform arg1 = (Transform)LuaScriptMgr.GetLuaObject(L, 2);
			float o = Utl.distance(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.distance");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int distance4Loc(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		Transform arg1 = (Transform)LuaScriptMgr.GetUnityObject(L, 2, typeof(Transform));
		float o = Utl.distance4Loc(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MapToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
			string o = Utl.MapToString(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 3)
		{
			Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
			System.Text.StringBuilder arg1 = (System.Text.StringBuilder)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.StringBuilder));
			int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
			Utl.MapToString(arg0,arg1,arg2);
			return 0;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.MapToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ArrayListToString2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		ArrayList arg0 = (ArrayList)LuaScriptMgr.GetNetObject(L, 1, typeof(ArrayList));
		string o = Utl.ArrayListToString2(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ArrayListToString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		ArrayList arg0 = (ArrayList)LuaScriptMgr.GetNetObject(L, 1, typeof(ArrayList));
		System.Text.StringBuilder arg1 = (System.Text.StringBuilder)LuaScriptMgr.GetNetObject(L, 2, typeof(System.Text.StringBuilder));
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		Utl.ArrayListToString(arg0,arg1,arg2);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int drawGrid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 7);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		int arg2 = (int)LuaScriptMgr.GetNumber(L, 3);
		float arg3 = (float)LuaScriptMgr.GetNumber(L, 4);
		Color arg4 = LuaScriptMgr.GetColor(L, 5);
		Transform arg5 = (Transform)LuaScriptMgr.GetUnityObject(L, 6, typeof(Transform));
		float arg6 = (float)LuaScriptMgr.GetNumber(L, 7);
		ArrayList o = Utl.drawGrid(arg0,arg1,arg2,arg3,arg4,arg5,arg6);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int drawLine(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		Color arg2 = LuaScriptMgr.GetColor(L, 3);
		LineRenderer o = Utl.drawLine(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cloneRes(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(GameObject)))
		{
			GameObject arg0 = (GameObject)LuaScriptMgr.GetLuaObject(L, 1);
			GameObject o = Utl.cloneRes(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			GameObject o = Utl.cloneRes(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.cloneRes");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int loadRes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object o = Utl.loadRes(arg0);
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int loadGobj(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = Utl.loadGobj(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doLua(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		LuaScriptMgr arg0 = (LuaScriptMgr)LuaScriptMgr.GetNetObject(L, 1, typeof(LuaScriptMgr));
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		object[] o = Utl.doLua(arg0,arg1);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addVector2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		Vector2 o = Utl.addVector2(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int addVector3(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		Vector3 o = Utl.addVector3(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cutVector2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = LuaScriptMgr.GetVector2(L, 1);
		Vector2 arg1 = LuaScriptMgr.GetVector2(L, 2);
		Vector2 o = Utl.cutVector2(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int cutVector3(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector3 arg0 = LuaScriptMgr.GetVector3(L, 1);
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		Vector3 o = Utl.cutVector3(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int sign(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		string o = Utl.sign(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getChild(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		Transform arg0 = (Transform)LuaScriptMgr.GetUnityObject(L, 1, typeof(Transform));
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		Transform o = Utl.getChild(arg0,objs1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int saveData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Hashtable arg1 = (Hashtable)LuaScriptMgr.GetNetObject(L, 2, typeof(Hashtable));
		Utl.saveData(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getDataByte(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		byte[] o = Utl.getDataByte(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getDataByteByMap(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = (Hashtable)LuaScriptMgr.GetNetObject(L, 1, typeof(Hashtable));
		byte[] o = Utl.getDataByteByMap(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Hashtable o = Utl.getData(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getDataByBts(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
		Hashtable o = Utl.getDataByBts(objs0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int chgToSKCard(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Utl.chgToSKCard(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getMapFnamesInFolder(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		Hashtable o = Utl.getMapFnamesInFolder(arg0,arg1);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getOrderInFolder(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		int o = Utl.getOrderInFolder(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MD5Encrypt(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(byte[])))
		{
			byte[] objs0 = LuaScriptMgr.GetArrayNumber<byte>(L, 1);
			string o = Utl.MD5Encrypt(objs0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, 1, typeof(string)))
		{
			string arg0 = LuaScriptMgr.GetString(L, 1);
			string o = Utl.MD5Encrypt(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Utl.MD5Encrypt");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int netIsActived(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		bool o = Utl.netIsActived();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getNetState(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Utl.getNetState();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int urlAddTimes(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Utl.urlAddTimes(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getSingInCodeAndroid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		int o = Utl.getSingInCodeAndroid();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLayer(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		LayerMask o = Utl.getLayer(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getRaycastHitInfor(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Camera arg0 = (Camera)LuaScriptMgr.GetUnityObject(L, 1, typeof(Camera));
		Vector3 arg1 = LuaScriptMgr.GetVector3(L, 2);
		LayerMask arg2 = (LayerMask)LuaScriptMgr.GetNetObject(L, 3, typeof(LayerMask));
		RaycastHit o = Utl.getRaycastHitInfor(arg0,arg1,arg2);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int doCallback(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		Utl.doCallback(arg0,arg1);
		return 0;
	}
}

