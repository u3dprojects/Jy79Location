-- 需要先加载的部分
do
  -------------------------------------------------------
  -- 加载lua引用路径
  local i = 0;
  local count = PathCfg.self.luaPackgePath.Length;
  while(true) do
    if(i >= count) then break end;
    Util.AddLuaPath(PathCfg.luaBasePath .. PathCfg.self.luaPackgePath[i]);
    -- package.path = PathCfg.luaBasePath .. PathCfg.self.luaPackgePath[i] .. ";" .. package.path
    i = i + 1;
  end;

  -------------------------------------------------------
  -- 反射模式
  -- Queue = luanet.import_type('System.Collections.Queue')
  Resources = luanet.import_type('UnityEngine.Resources')
  Stack = luanet.import_type('System.Collections.Stack')
  MyMainCamera = luanet.import_type('MyMainCamera')
  FogMode = luanet.import_type('UnityEngine.FogMode')
  LayerMask= luanet.import_type('UnityEngine.LayerMask')
  UIRoot= luanet.import_type('UIRoot')

  
  -------------------------------------------------------
  -- 重新命名
  MapEx = Toolkit.MapEx
  NumEx2 = Toolkit.NumEx
  FileEx = Toolkit.FileEx
  JSON = Toolkit.JSON
  DateEx = Toolkit.DateEx
  SystemInfo = UnityEngine.SystemInfo
  ArrayList = System.Collections.ArrayList
  Hashtable = System.Collections.Hashtable
  PStr = Toolkit.PStr
  PlayerPrefs = UnityEngine.PlayerPrefs
  SoundEx = Toolkit.SoundEx
  Queue = System.Collections.Queue
  File = System.IO.File
  GC = System.GC
  WWW = UnityEngine.WWW;
  WWWForm = UnityEngine.WWWForm;

  -------------------------------------------------------
  -- require
  cjson = require "cjson"
  require("NumEx");
  require("Demo4BuildLua");  -- 服务器接口

  -------------------------------------------------------
  -- 全局变量
  __version__ = SVersion.version; -- "1.0";
  CallNet = Demo4BuildLua.callNet;   -- 网络接口
  -------------------------------------------------------
  bio2Int = NumEx.bio2Int;
  int2Bio = NumEx.int2Bio;
  -------------------------------------------------------
end;

--module("CLInclude",package.seeall)
