do

  local int2Bio = NumEx.int2Bio;
  local bio2Int = NumEx.bio2Int;
  local getByIntKey = MapEx.getByIntKey;

  Demo4BuildLua = {

    NChat = {
      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.type = getByIntKey(dataMap,3575610);-- 聊天类型 [int]
        r.fpcid = getByIntKey(dataMap,97634228);-- 说话人标识 [int]
        r.fpname = getByIntKey(dataMap,-1267985835);-- 说话人名称 [string]
        r.content = getByIntKey(dataMap,951530617);-- 说话内容 [string]
        r.creattime = getByIntKey(dataMap,598824662);-- 创建时间 [long]
        return r;
      end;

    };

    NChats = {
      maps_list = function(maps) 
        if(maps == nil) then
          return ArrayList();
        end;
        local len = maps.Count
        local r = ArrayList();
        for i=0,len-1 do
          local _e = maps:get_Item(i);
          local e = Demo4BuildLua.NChat.parse(_e);
          if(e ~= nil) then
            r:Add(e);
          end
        end
        return r;
      end;

      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.list = Demo4BuildLua.NChats.maps_list(getByIntKey(dataMap,3322014));--3322014
        return r;
      end;

    };

    NInt = {
      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.val = getByIntKey(dataMap,116513);-- [int]
        return r;
      end;

    };

    NInts = {
      maps_list = function(maps) 
        if(maps == nil) then
          return ArrayList();
        end;
        local len = maps.Count
        local r = ArrayList();
        for i=0,len-1 do
          local _e = maps:get_Item(i);
          local e = Demo4BuildLua.NInt.parse(_e);
          if(e ~= nil) then
            r:Add(e);
          end
        end
        return r;
      end;

      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.list = Demo4BuildLua.NInts.maps_list(getByIntKey(dataMap,3322014));--3322014
        return r;
      end;

    };

    NStr = {
      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.val = getByIntKey(dataMap,116513);-- [string]
        return r;
      end;

    };

    ReturnStatus = {
      parse = function(dataMap)
        if(dataMap == nil) then return nil; end;

        local r = {};
        r.succ = getByIntKey(dataMap,3541570);-- [int]
        r.msg = getByIntKey(dataMap,108417);-- [string]
        return r;
      end;

    };

   callNet = { 
    __sessionid = 0;

      -- 心跳
      heart = function()
        local _map = Hashtable();
        _map:set_Item(B2Int(-100), Demo4BuildLua.callNet.__sessionid);-- __sessionid
        _map:set_Item(B2Int(0), B2Int(99151942));-- cmd:heart
        return _map;
      end;

      -- 取得聊天内容集合
      getChatsByHttp = function(unqid)
        local _map = Hashtable();
        _map:set_Item(B2Int(-100), Demo4BuildLua.callNet.__sessionid);-- __sessionid
        _map:set_Item(B2Int(0), B2Int(652988484));-- cmd:getChatsByHttp
        _map:set_Item(B2Int(111440915), unqid);
        return _map;
      end;


   };

   --[[
    // //////////////////////////////////////////////
    // 请求回掉分发解析
    // //////////////////////////////////////////////
    --]]

    onCallNet = { 

      --[[
      // //////////////////////////////////////////////
      // 逻辑分发
      // //////////////////////////////////////////////
      --]]

      disp = function(map)
        local cmd = getByIntKey(map,0);
        Demo4BuildLua.onCallNet.disp_each(cmd, map);
      end;

      disp_each = function(cmd,map)
        local funMap = Demo4BuildLua_switch[cmd];
        if(funMap ~= nil) then
          local exFun = funMap["fun"];
          local exMethod = funMap["name"];
          exFun(exMethod, map);
        end;

      end;


      --[[
      // //////////////////////////////////////////////
      // 参数解析
      // //////////////////////////////////////////////
      --]]

      -- 心跳
      __onCallback_heart = function(cmd,map)
        local retVal = getByIntKey(map,1);
        local rst = Demo4BuildLua.ReturnStatus.parse(retVal);

        cllNetDis.dispatch(cmd,rst);
      end;

      -- 取得聊天内容集合
      __onCallback_getChatsByHttp = function(cmd,map)
        local retVal = getByIntKey(map,1);
        local rst = Demo4BuildLua.ReturnStatus.parse(retVal);
        local nchats = Demo4BuildLua.NChats.parse(getByIntKey(map,-1051136915));

        cllNetDis.dispatch(cmd,nchats, rst);
      end;

      -- 主动下行角色信息
      __onCallback_notifyPlayer = function(cmd,map)
        local retVal = getByIntKey(map,1);
        local rst = Demo4BuildLua.ReturnStatus.parse(retVal);
        local nchats = Demo4BuildLua.NChats.parse(getByIntKey(map,-1051136915));

        cllNetDis.dispatch(cmd,nchats, rst);
      end;

    };

  };

  --[[
  // //////////////////////////////////////////////
  // 请求回掉分发解析所对应的对象
  // //////////////////////////////////////////////
  --]]

  Demo4BuildLua_switch = {
    [99151942] = {["name"] = "heart"; fun = Demo4BuildLua.onCallNet.__onCallback_heart}; --心跳
    [652988484] = {["name"] = "getChatsByHttp"; fun = Demo4BuildLua.onCallNet.__onCallback_getChatsByHttp}; --取得聊天内容集合
    [1376043914] = {["name"] = "notifyPlayer"; fun = Demo4BuildLua.onCallNet.__onCallback_notifyPlayer}; --主动下行角色信息
  };

end;

module("Demo4BuildLua",package.seeall)
