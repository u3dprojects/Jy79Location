using UnityEngine;
using System.Collections;
using LuaInterface;
using System.Collections.Generic;
using Toolkit;

public class CLLuaTimer : MonoBehaviour {

    public static CLLuaTimer self;
    public CLLuaTimer() {
        self = this;
    }

    object callFun;

    void doCallback()
    {
        if (callFun != null)
        {
            if (callFun.GetType() == typeof(Callback))
            {
                ((Callback)(callFun))(this);
            }
            else if (callFun.GetType() == typeof(LuaFunction))
            {
                ((LuaFunction)(callFun)).Call(this);
            }
        }
    }

    public void startInvoke(int rep,object cfun)
    {
        callFun = cfun;
        if (rep > 0)
        {
            if (IsInvoking("doCallback"))
                return;

            InvokeRepeating("doCallback", 0, rep);
        }
        else
        {
            doCallback();
        }
    }


    public void exceCancelInvoke()
    {
        CancelInvoke();
    }
}
