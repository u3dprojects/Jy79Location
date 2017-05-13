using UnityEngine;
using System.Collections;
using Toolkit;

public class DebugEx
{
    static public DebugEn en4Log = new DebugEn(DebugEn.Layer4Debug.Info);

    /** 设置可以打的Debug模式 */
    static public void resetLogLayer(DebugEn.Layer4Debug logLayer)
    {
        en4Log.layer4Debug = logLayer;
    }

    static public void logInfo(object info)
    {
        en4Log.logInfo(info);
    }

    static public void logWarning(object info)
    {
        en4Log.logWarning(info);
    }

    static public void logError(object erro_info)
    {
        en4Log.logError(erro_info);
    }

    
    static public void logException(System.Exception ex)
    {
        en4Log.logException(ex);
    }

    static public void logException(System.Exception ex, object msg)
    {
        en4Log.logException(ex, msg);
    }
}

/// <summary>
/// 日志实体
/// </summary>
public class DebugEn
{
    // 分级别
    // None = 0,标识什么都不打印
    // Error = 1,标识只打印Error的
    // Warning = 2 ,标识打印Error,Warning
    // Info = 3,标识打印Error,Warning,Log
    public enum Layer4Debug
    {
        None = 0,
        Error = 1,
        Warning = 2,
        Info = 3
    };

    // Debug输出的模式
    public Layer4Debug layer4Debug = Layer4Debug.None;

    // Info模式
    public bool isDebugInfo
    {
        get
        {
            return layer4Debug == Layer4Debug.Info;
        }
    }

    // 警告Warning模式
    public bool isDebugWarning
    {
        get
        {
            int tmp_int = (int)layer4Debug;
            return tmp_int >= 2;
        }
    }

    // 错误Error模式
    public bool isDebugError
    {
        get
        {
            int tmp_int = (int)layer4Debug;
            return tmp_int >= 1;
        }
    }

    // Class 的type，反射
    public System.Type clazzType
    {
        get;
        set;
    }

    // Class的全部名字
    public string fullClazzName
    {
        get
        {
            if (this.clazzType != null)
            {
                return this.clazzType.FullName;
            }
            return "";
        }
    }

    public DebugEn()
    {
        this.clazzType = null;
        this.layer4Debug = Layer4Debug.None;
    }

    public DebugEn(Layer4Debug ldebug)
    {
        this.clazzType = null;
        this.layer4Debug = ldebug;
    }

    public DebugEn(System.Type type)
    {
        this.clazzType = type;
        this.layer4Debug = Layer4Debug.None;
    }

    public DebugEn(System.Type type, Layer4Debug ldebug)
    {
        this.clazzType = type;
        this.layer4Debug = ldebug;
    }

    public void logInfo(object obj)
    {
        if (!isDebugInfo)
        {
            return;
        }
        string info = "";
        if (obj != null)
        {
            info = obj.ToString();
        }

        logInfo4Str(info);
    }

    public void logInfo4Str(string info)
    {
        if (!isDebugInfo)
        {
            return;
        }

        if (string.IsNullOrEmpty(info))
        {
            return;
        }

        info = PStr.b(fullClazzName).a("_info = (").a(info).a(")").e();
        Debug.Log(info);
    }

    public void logWarning(object obj)
    {
        if (!isDebugWarning)
        {
            return;
        }

        string info = "";
        if (obj != null)
        {
            info = obj.ToString();
        }

        logWarning4Str(info);
    }

    public void logWarning4Str(string info)
    {
        if (!isDebugWarning)
        {
            return;
        }

        if (string.IsNullOrEmpty(info))
        {
            return;
        }

        info = PStr.b(fullClazzName).a("_warn = (").a(info).a(")").e();
        Debug.LogWarning(info);
    }

    public void logError(object obj)
    {
        if (!isDebugError)
        {
            return;
        }

        string erro_info = "";
        if (obj != null)
        {
            erro_info = obj.ToString();
        }

        logError4Str(erro_info);
    }

    public void logError4Str(string erro_info)
    {
        if (!isDebugError)
        {
            return;
        }

        if (string.IsNullOrEmpty(erro_info))
        {
            return;
        }

        erro_info = PStr.b(fullClazzName).a("_error = (").a(erro_info).a(")").e();
        Debug.LogError(erro_info);
    }

    public void logException(System.Exception ex)
    {
        if (!isDebugError)
        {
            return;
        }
        Debug.LogError(fullClazzName + "=== error ===");
        Debug.LogException(ex);
    }

    public void logException(System.Exception ex, object obj)
    {
        if (!isDebugError)
        {
            return;
        }

        string msg = "";
        if (obj != null)
        {
            msg = obj.ToString();
        }

        logException4Str(ex, msg);
    }

    public void logException4Str(System.Exception ex, string msg)
    {
        if (!isDebugError)
        {
            return;
        }

        if (string.IsNullOrEmpty(msg))
        {
            msg = "";
        }

        Debug.LogError(fullClazzName + "== error_msg == (" + msg+")");
        Debug.LogException(ex);
    }
}