using System.Collections;
using System;
using System.Text;
using UnityEngine;

namespace Toolkit
{
    public class DateEx
    {
        public const string fmt_yyyy_MM_dd_HH_mm_ss = "yyyy-MM-dd HH:mm:ss";
        public const string fmt_MM_dd_HH_mm = "MM-dd HH:mm";
        public const string fmt_yyyy_MM_dd = "yyyy-MM-dd";
        public const string fmt_yyyyMMdd = "yyyyMMdd";
        public const string fmt_yyyyMMddHHmm = "yyyyMMddHHmm";
        public const string fmt_HH_mm_ss = "HH:mm:ss";
        public const long TIME_MILLISECOND = 1;
        public const long TIME_SECOND = 1000 * TIME_MILLISECOND;
        public const long TIME_MINUTE = 60 * TIME_SECOND;
        public const long TIME_HOUR = 60 * TIME_MINUTE;
        public const long TIME_DAY = 24 * TIME_HOUR;
        public const long TIME_WEEK = 7 * TIME_DAY;
        public const long TIME_YEAR = 365 * TIME_DAY;

        public static long now
        {
            get
            {
                return DateTime.Now.ToFileTime();
            }
        }

        public static long nowMS
        {
            get
            {
                return DateTime.Now.ToFileTime() / 10000;
            }
        }

        public static string format(string fmt)
        {
            return format(DateTime.Now, fmt);
        }

        public static string nowString()
        {
            return format(fmt_yyyy_MM_dd_HH_mm_ss);
        }

        public static string format(DateTime d, string fmt)
        {
            return d.ToString(fmt);
        }

        public static string formatByMs(long ms, string fmt = fmt_yyyy_MM_dd_HH_mm_ss)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            long us = (ms + d1.Ticks / 10000) * 10000;
            DateTime d = new DateTime(us);
            return d.ToString(fmt);
        }

        static DateTime dat0 = new DateTime(1970, 1, 2);

        public static DateTime javaDate(long x)
        {
            long tm = (x + dat0.Ticks / 10000) * 10000;
            return new DateTime(tm);
        }

        // 取得客户端当前时间
        static public long toJavaNTimeLong()
        {
            return toJavaDate(DateTime.Now);
        }

        public static long toJavaDate(DateTime dat)
        {
            DateTime d1 = new DateTime(1970, 1, 1);
            DateTime d2 = dat.ToUniversalTime();
            TimeSpan ts = new TimeSpan(d2.Ticks - d1.Ticks);
            return (long)ts.TotalMilliseconds;

            /*long v = (dat.Ticks - dat0.Ticks) / 10000;
            return v;*/
        }
        //服务器同步时间diffCSTime:表示客服端与服务器端的时间差，isCellMS:表示到秒，毫秒往上收了一秒
        public static long newDateLong(long diffCSTime = 0, bool isCellMS = false)
        {
            long time = diffCSTime + toJavaNTimeLong();
            if (isCellMS)
            {
                double tmT = time / (double)TIME_SECOND;
                tmT = System.Math.Ceiling(tmT);
                time = (long)tmT * TIME_SECOND;
            }
            return time;
        }

        public static long diffTimeWithServer = 0;

        public static long nowServerTime
        {
            get
            {
                return diffTimeWithServer + toJavaNTimeLong();
            }
        }

        // [0]=天，[1]=时，[2]=分，[3]=秒，[4]=毫秒
        static public int[] getTimeArray(long ms)
        {
            long tmpMs = ms;

            int ss = 1000;
            int mi = ss * 60;
            int hh = mi * 60;
            int dd = hh * 24;
            int day = 0, hour = 0, minute = 0, second = 0, milliSecond = 0;

            if (tmpMs > dd)
            {
                day = (int)(tmpMs / dd);
                tmpMs %= dd;
            }

            if (tmpMs > hh)
            {
                hour = (int)(tmpMs / hh);
                tmpMs %= hh;
            }

            if (tmpMs > mi)
            {
                minute = (int)(tmpMs / mi);
                tmpMs %= mi;
            }

            if (tmpMs > ss)
            {
                second = (int)(tmpMs / ss);
                tmpMs %= ss;
            }

            milliSecond = (int)tmpMs;

            return new int[] { day, hour, minute, second, milliSecond };
        }

        public static string toHHMMSS(long ms)
        {
            int[] ss = getTimeArray(ms);
            return ss[1] + ":" + ss[2] + ":" + ss[3];
        }

        // 时间格式化为:HH:mm:ss;
        public static string toStrEn(long ms)
        {
            int[] arr = getTimeArray(ms);
            int hour = arr[0] * 24 + arr[1];
            String strHour = "";
            String strMinute = "";
            String strSecond = "";
            if (hour > 0)
            {
                strHour = hour < 10 ? "0" + hour : "" + hour;
                strHour += ":";
            }
            int minute = arr[2];
            if (minute >= 0)
            {
                strMinute = minute < 10 ? "0" + minute : "" + minute;
                strMinute += ":";
            }
            int second = arr[3];
            if (second >= 0)
            {
                strSecond = second < 10 ? "0" + second : "" + second;
            }
            return strHour + strMinute + strSecond;
        }

        // 时间格式化为:HH时mm分ss秒;
        public static string toStrCn(long ms)
        {
            int[] arr = getTimeArray(ms);
            int hour = arr[0] * 24 + arr[1];
            String strHour = "";
            String strMinute = "";
            String strSecond = "";
            if (hour > 0)
            {
                strHour = hour < 10 ? "0" + hour : "" + hour;
                strHour += "时";
            }
            int minute = arr[2];
            if (minute > 0)
            {
                strMinute = minute < 10 ? "0" + minute : "" + minute;
                strMinute += "分";
            }
            int second = arr[3];
            if (second >= 0)
            {
                strSecond = second < 10 ? "0" + second : "" + second;
                strSecond += "秒";
            }
            return strHour + strMinute + strSecond;
        }

        public static string ToTimeStr2(long msec)
        {
            // 将毫秒数换算成x天x时x分x秒x毫秒
            int day = 0, hour = 0, minute = 0, second = 0;
            string retstr = "";

            long remainder;
            day = (int)(msec / 86400000);
            retstr = (day == 0) ? "" : day + Localization.Get("Day");

            remainder = msec % 86400000;
            if (remainder != 0)
            {
                hour = (int)remainder / 3600000;
            }
            //		hour += day * 24;
            //			retstr += ((retstr.Length > 0 || hour > 0) ? (hour < 10 ? "0" + hour + Localization.Get("Hour") : hour + Localization.Get("Hour")) : "");
            retstr += ((retstr.Length > 0 || hour > 0) ? (hour + Localization.Get("Hour")) : "");

            remainder = remainder % 3600000;
            if (remainder != 0)
            {
                minute = (int)remainder / 60000;
            }
            //			retstr += ((retstr.Length > 0 || minute > 0) ? (minute < 10 ? "0" + minute + Localization.Get("Minutes") : minute + Localization.Get("Minutes")) : "00" + Localization.Get("Minutes"));
            retstr += ((retstr.Length > 0 || minute > 0) ? (minute + Localization.Get("Minutes")) : "");

            second = (int)remainder % 60000;
            second = second / 1000;
            retstr += (second + Localization.Get("Second"));
            return retstr;
        }

        public static string ToTimeStr3(long msec)
        {
            // 将毫秒数换算成x天x时
            int day = 0, hour = 0, minute = 0, second = 0;
            string retstr = "";

            long remainder;
            day = (int)(msec / 86400000);
            retstr = (day == 0) ? "" : day + Localization.Get("Day");

            remainder = msec % 86400000;
            if (remainder != 0)
            {
                hour = (int)remainder / 3600000;
            }
            //		hour += day * 24;
            //			retstr += ((retstr.Length > 0 || hour > 0) ? (hour < 10 ? "0" + hour + Localization.Get("Hour") : hour + Localization.Get("Hour")) : "");
            retstr += ((retstr.Length > 0 || hour > 0) ? (hour + Localization.Get("Hour")) : "");
            //			
            //		remainder = remainder % 3600000;
            //		if (remainder != 0) {
            //			minute = (int)remainder / 60000;
            //		}
            //		retstr += ((retstr.Length > 0 || minute > 0) ? (minute < 10 ? "0" + minute + Utl.getLocString ("Minutes") : minute + Utl.getLocString ("Minutes")) : "00" + Utl.getLocString ("Minutes"));
            //			
            //		second = (int)remainder % 60000;
            //		second = second / 1000;
            //		retstr += (second < 10 ? "0" + second + Utl.getLocString ("Second") : second + Utl.getLocString ("Second"));
            return retstr;
        }

        public static string ToTimeCost(long msec)
        {
            int day = 0, hour = 0, minute = 0, second = 0;
            string retstr = "";

            long remainder;
            day = (int)(msec / 86400000);
            retstr = (day == 0) ? "" : day + Localization.Get("DayBefore");
            if (!string.IsNullOrEmpty(retstr))
            {
                return retstr;
            }

            remainder = msec % 86400000;
            if (remainder != 0)
            {
                hour = (int)remainder / 3600000;
            }
            //		hour += day * 24;
            retstr += ((retstr.Length > 0 || hour > 0) ? (hour + Localization.Get("HourBefore")) : "");
            if (!string.IsNullOrEmpty(retstr))
            {
                return retstr;
            }

            remainder = remainder % 3600000;
            if (remainder != 0)
            {
                minute = (int)remainder / 60000;
            }
            //			retstr += ((retstr.Length > 0 || minute > 0) ? (minute + Localization.Get("MinutesBefore")) : "0" + Localization.Get("MinutesBefore"));
            retstr += ((retstr.Length > 0 || minute > 0) ? (minute + Localization.Get("MinutesBefore")) : "");
            if (!string.IsNullOrEmpty(retstr))
            {
                return retstr;
            }

            second = (int)remainder % 60000;
            second = second / 1000;
            //			retstr += (second < 10 ? "0" + second + Localization.Get("SecondBefore") : second + Localization.Get("SecondBefore"));
            retstr += (second + Localization.Get("SecondBefore"));
            return retstr;
        }

        public static string ToTimeStr(long msec)
        {
            // 将毫秒数换算成x天x时x分x秒x毫秒
            int day = 0, hour = 0, minute = 0, second = 0;
            string retstr = "";

            long remainder;
            day = (int)(msec / 86400000);
            //retstr = (day == 0) ? "" : day + ":";

            remainder = msec % 86400000;
            if (remainder != 0)
            {
                hour = (int)remainder / 3600000;
            }
            hour += day * 24;
            retstr += ((retstr.Length > 0 || hour > 0) ? (hour < 10 ? "0" + hour + ":" : hour + ":") : "");

            remainder = remainder % 3600000;
            if (remainder != 0)
            {
                minute = (int)remainder / 60000;
            }
            retstr += ((retstr.Length > 0 || minute > 0) ? (minute < 10 ? "0" + minute + ":" : minute + ":") : "00:");

            second = (int)remainder % 60000;
            second = second / 1000;
            retstr += (second < 10 ? "0" + second + "" : second + "");
            return retstr;
        }

        static public long getLongJavaByHMS(string hms)
        {
            hms = hms.Replace("\\\\", "");
            string yyMMddHHmmss = format(fmt_yyyy_MM_dd) + " " + hms;
            return getLongJavaByYMDHMS(yyMMddHHmmss);
        }

        static public string nowStrYyyyMMdd()
        {
            return format(fmt_yyyyMMdd);
        }

        static public string nxtStrYyyyMMdd()
        {
            DateTime dt = DateTime.Now;
            DateTime nxtDt = dt.AddDays(1);
            return format(nxtDt, fmt_yyyyMMdd);
        }

        static public bool isSameDateStr(String dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
                return false;
            string nowStr = nowStrYyyyMMdd();
            int v = nowStr.CompareTo(dateStr);
            bool flag = v > -1;
            return flag;
        }


        static public string nowStrYyyyMMddHHmm()
        {
            return format(fmt_yyyyMMddHHmm);
        }

        static public string nxtStrYyyyMMddHHmm()
        {
            DateTime dt = DateTime.Now;
            DateTime nxtDt = dt.AddMinutes(1);
            return format(nxtDt, fmt_yyyyMMddHHmm);
        }

        static public bool isBeforeNow4yyMMddHHmm(String dateStr)
        {
            if (string.IsNullOrEmpty(dateStr))
                return false;
            string nowStr = nowStrYyyyMMddHHmm();
            int v = nowStr.CompareTo(dateStr);
            bool flag = v > -1;
            return flag;
        }

        static public long getLongJavaByYMDHMS(string yyMMddHHmmss)
        {
            try
            {
                yyMMddHHmmss = yyMMddHHmmss.Replace("\\\\", "");
                DateTime dt = DateTime.Parse(yyMMddHHmmss);
                long jl = toJavaDate(dt);
                return jl + diffTimeWithServer;
            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}