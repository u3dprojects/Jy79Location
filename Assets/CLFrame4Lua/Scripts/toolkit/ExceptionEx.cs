using UnityEngine;
using System.Collections;

public class ExceptionEx
{
    static public string getExceptionStr(System.Exception ex, string desc) {
        string msg = ex.Message;
        string stack = ex.StackTrace;
        string error = " msg = " + msg + ",\r\n stack = " + stack;
        if(string.IsNullOrEmpty(desc)){
            return error;
        }
        return "desc = " + desc + ",\r\n " + error;
    }

    static public void sendHttpException(System.Exception ex, string desc)
    {
        string error = getExceptionStr(ex, desc);
        Hashtable map = new Hashtable();
        map["cmd"] = "error4Lua";
        map["uuid"] = Utl.uuid();
        map["device"] = SystemInfo.deviceModel;
        map["error"] = error;
        Net.self.sendHttp(map);
    }

    static public void sendException(System.Exception ex, string desc)
    {
        string error = getExceptionStr(ex, desc);
        Hashtable map = new Hashtable();
        map["cmd"] = "error4Lua";
        map["uuid"] = Utl.uuid();
        map["device"] = SystemInfo.deviceModel;
        map["error"] = error;
        Net.self.send(map);
    }
}
