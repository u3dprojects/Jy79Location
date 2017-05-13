using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AppConst {
    public const bool UsePbc = false;                           //PBC
    public const bool UseLpeg = false;                          //LPEG
    public const bool UsePbLua = false;                         //Protobuff-lua-gen
    public const bool UseCJson = true;                         //CJson
    public const bool UseSproto = false;                        //Sproto

    public static string uLuaPath {
        get {
            return Application.dataPath + "/uLua/";
        }
    }
}
