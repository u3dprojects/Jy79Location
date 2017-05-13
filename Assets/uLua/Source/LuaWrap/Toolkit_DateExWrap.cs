using System;
using LuaInterface;

public class Toolkit_DateExWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("format", format),
			new LuaMethod("nowString", nowString),
			new LuaMethod("formatByMs", formatByMs),
			new LuaMethod("javaDate", javaDate),
			new LuaMethod("toJavaNTimeLong", toJavaNTimeLong),
			new LuaMethod("toJavaDate", toJavaDate),
			new LuaMethod("newDateLong", newDateLong),
			new LuaMethod("getTimeArray", getTimeArray),
			new LuaMethod("toHHMMSS", toHHMMSS),
			new LuaMethod("toStrEn", toStrEn),
			new LuaMethod("toStrCn", toStrCn),
			new LuaMethod("ToTimeStr2", ToTimeStr2),
			new LuaMethod("ToTimeStr3", ToTimeStr3),
			new LuaMethod("ToTimeCost", ToTimeCost),
			new LuaMethod("ToTimeStr", ToTimeStr),
			new LuaMethod("getLongJavaByHMS", getLongJavaByHMS),
			new LuaMethod("nowStrYyyyMMdd", nowStrYyyyMMdd),
			new LuaMethod("nxtStrYyyyMMdd", nxtStrYyyyMMdd),
			new LuaMethod("isSameDateStr", isSameDateStr),
			new LuaMethod("nowStrYyyyMMddHHmm", nowStrYyyyMMddHHmm),
			new LuaMethod("nxtStrYyyyMMddHHmm", nxtStrYyyyMMddHHmm),
			new LuaMethod("isBeforeNow4yyMMddHHmm", isBeforeNow4yyMMddHHmm),
			new LuaMethod("getLongJavaByYMDHMS", getLongJavaByYMDHMS),
			new LuaMethod("New", _CreateToolkit_DateEx),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("fmt_yyyy_MM_dd_HH_mm_ss", get_fmt_yyyy_MM_dd_HH_mm_ss, null),
			new LuaField("fmt_MM_dd_HH_mm", get_fmt_MM_dd_HH_mm, null),
			new LuaField("fmt_yyyy_MM_dd", get_fmt_yyyy_MM_dd, null),
			new LuaField("fmt_yyyyMMdd", get_fmt_yyyyMMdd, null),
			new LuaField("fmt_yyyyMMddHHmm", get_fmt_yyyyMMddHHmm, null),
			new LuaField("fmt_HH_mm_ss", get_fmt_HH_mm_ss, null),
			new LuaField("TIME_MILLISECOND", get_TIME_MILLISECOND, null),
			new LuaField("TIME_SECOND", get_TIME_SECOND, null),
			new LuaField("TIME_MINUTE", get_TIME_MINUTE, null),
			new LuaField("TIME_HOUR", get_TIME_HOUR, null),
			new LuaField("TIME_DAY", get_TIME_DAY, null),
			new LuaField("TIME_WEEK", get_TIME_WEEK, null),
			new LuaField("TIME_YEAR", get_TIME_YEAR, null),
			new LuaField("diffTimeWithServer", get_diffTimeWithServer, set_diffTimeWithServer),
			new LuaField("now", get_now, null),
			new LuaField("nowMS", get_nowMS, null),
			new LuaField("nowServerTime", get_nowServerTime, null),
		};

		LuaScriptMgr.RegisterLib(L, "Toolkit.DateEx", typeof(Toolkit.DateEx), regs, fields, typeof(object));
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateToolkit_DateEx(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Toolkit.DateEx obj = new Toolkit.DateEx();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.DateEx.New");
		}

		return 0;
	}

	static Type classType = typeof(Toolkit.DateEx);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_yyyy_MM_dd_HH_mm_ss(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_yyyy_MM_dd_HH_mm_ss);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_MM_dd_HH_mm(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_MM_dd_HH_mm);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_yyyy_MM_dd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_yyyy_MM_dd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_yyyyMMdd(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_yyyyMMdd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_yyyyMMddHHmm(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_yyyyMMddHHmm);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_fmt_HH_mm_ss(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.fmt_HH_mm_ss);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_MILLISECOND(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_MILLISECOND);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_SECOND(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_SECOND);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_MINUTE(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_MINUTE);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_HOUR(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_HOUR);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_DAY(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_DAY);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_WEEK(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_WEEK);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TIME_YEAR(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.TIME_YEAR);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_diffTimeWithServer(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.diffTimeWithServer);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_now(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.now);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nowMS(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.nowMS);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_nowServerTime(IntPtr L)
	{
		LuaScriptMgr.Push(L, Toolkit.DateEx.nowServerTime);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_diffTimeWithServer(IntPtr L)
	{
		Toolkit.DateEx.diffTimeWithServer = (long)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int format(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			string arg0 = LuaScriptMgr.GetLuaString(L, 1);
			string o = Toolkit.DateEx.format(arg0);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else if (count == 2)
		{
			DateTime arg0 = (DateTime)LuaScriptMgr.GetNetObject(L, 1, typeof(DateTime));
			string arg1 = LuaScriptMgr.GetLuaString(L, 2);
			string o = Toolkit.DateEx.format(arg0,arg1);
			LuaScriptMgr.Push(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Toolkit.DateEx.format");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nowString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.DateEx.nowString();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int formatByMs(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		string o = Toolkit.DateEx.formatByMs(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int javaDate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		DateTime o = Toolkit.DateEx.javaDate(arg0);
		LuaScriptMgr.PushValue(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toJavaNTimeLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		long o = Toolkit.DateEx.toJavaNTimeLong();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toJavaDate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		DateTime arg0 = (DateTime)LuaScriptMgr.GetNetObject(L, 1, typeof(DateTime));
		long o = Toolkit.DateEx.toJavaDate(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int newDateLong(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		bool arg1 = LuaScriptMgr.GetBoolean(L, 2);
		long o = Toolkit.DateEx.newDateLong(arg0,arg1);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getTimeArray(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		int[] o = Toolkit.DateEx.getTimeArray(arg0);
		LuaScriptMgr.PushArray(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toHHMMSS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.toHHMMSS(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toStrEn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.toStrEn(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int toStrCn(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.toStrCn(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToTimeStr2(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.ToTimeStr2(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToTimeStr3(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.ToTimeStr3(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToTimeCost(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.ToTimeCost(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToTimeStr(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		long arg0 = (long)LuaScriptMgr.GetNumber(L, 1);
		string o = Toolkit.DateEx.ToTimeStr(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLongJavaByHMS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		long o = Toolkit.DateEx.getLongJavaByHMS(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nowStrYyyyMMdd(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.DateEx.nowStrYyyyMMdd();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nxtStrYyyyMMdd(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.DateEx.nxtStrYyyyMMdd();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isSameDateStr(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.DateEx.isSameDateStr(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nowStrYyyyMMddHHmm(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.DateEx.nowStrYyyyMMddHHmm();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int nxtStrYyyyMMddHHmm(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Toolkit.DateEx.nxtStrYyyyMMddHHmm();
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int isBeforeNow4yyMMddHHmm(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Toolkit.DateEx.isBeforeNow4yyMMddHHmm(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int getLongJavaByYMDHMS(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		long o = Toolkit.DateEx.getLongJavaByYMDHMS(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}

