using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UICenterOnChild4Lua : UICenterOnChild{
    
    public GameObject target;
    public string finishFun;

    void Start() {
        onFinished = CallBackFished;
    }

    void CallBackFished() {
        if (enabled)
        {
            if (target != null) {
                target.SendMessage(finishFun, gameObject, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
