---3GU 渠道lua脚本
-- author : canyon
-- time : 2015-04-29
do
  CLGboChn = luanet.import_type('CLGboChn');
  require("LuaUtl");
  require("CLLDBCfg");


  local pName = nil;
  local self = nil;
  local transform = nil;
  local gameObject = nil;

  -- 第三方函数的local变量
  local toArrayByJson = Utl.toArrayByJson;
  local toMapByJson = Utl.toMapByJson;
  local getStrLen4Trim = StrEx.getStrLen4Trim;
  local chnSelf = CLGboChn.getInstance();
  local bio2Int = NumEx.bio2Int;

  -- 取得计费点表
  local getFee = CLLDBCfg.getFee; -- ( gid, chl )

  -- 对象
  local netDB = GLVar.dbData; -- 网络层数据对象

  -- 属性值变量

  ChnNetHandle = {};

  -- 请求打开登录界面
  function ChnNetHandle.reqLogin()
    chnSelf:reqLogin();
  end;

  -- 请求打开关闭界面
  function ChnNetHandle.reqExitGameVI()
    chnSelf:reqExitGameVI();
  end;

  -- 请求打开关更多游戏界面
  function ChnNetHandle.reqMoreGame()
    if GLVar.isMoreGame then
      chnSelf:reqMoreGame();
    end;
  end;

  -- 请求打开充值界面(price单位分)
  function ChnNetHandle.openPayUI(price,exp,goodsID,goodsName,info)
    local uuid = DBTools.getUnqid();
    chnSelf:reqPay(price, exp, goodsID, goodsName, info,uuid);
  end;

  -- 通过计费点GID来取得计费点对象，
  function ChnNetHandle.reqPayByGid(feeGid,exp,descript)
    local luaFun = LuaUtl.getLuaFunc(exp);
    -- 判断是否可以购买
    if netDB.pl ~= nil then
      if not netDB.pl.isCanBuy4RMB then
        if luaFun ~= nil then
          luaFun(-1,"今天买太多了哦，明天再来买吧！");
        else
          NAlertTxt.add("今天买太多了哦，明天再来买吧！",Color.red,1);
        end;
        return;
      end;
    end;

    local chn = SCfg.Channel;
    local feeEn = nil;

    local isNone = (chn == "none");
    if not isNone then
      if type(feeGid) == "number" then
        feeEn = getFee(feeGid,chn);
      end;
    end

    if feeEn == nil then
      if luaFun ~= nil then
        if isNone then
          luaFun(1,"渠道none，成功！");
        else
          luaFun(-1,"出现错误,计费点类型:" .. feeGid .. ",渠道:" ..chn);
        end;
      end;
    else
      local goodsName = feeEn.GoodsName;
      if descript ~= nil and descript ~= "" then
        goodsName = descript .. ",名称:" .. goodsName;
      end;

      local price = bio2Int(feeEn.Price);
      if GLVar.dbData.goodsFee == nil then
        GLVar.dbData.goodsFee = Hashtable();
      end;

      GLVar.dbData.goodsFee[feeGid] = price / 100;

      ChnNetHandle.openPayUI(price,exp,feeEn.GoodsID,goodsName,feeEn.GoodsCode);
    end;
  end;

  -- 数据统计
  -- 战斗开始
  function ChnNetHandle.beginPve(pveName)
    chnSelf:startPve(pveName);
  end;

  -- 战斗结束
  function ChnNetHandle.endPve(pveName,isPass)
    chnSelf:endPve(pveName,isPass);
  end;

  -- 增加游戏币(coinName[金币，宝石])
  function ChnNetHandle.gameCoinAdd(reason,coinName,num,curAll)
    chnSelf:gameCoinAdd(reason,coinName,num,curAll);
  end;

  -- 减少游戏币(coinName[金币，宝石])
  function ChnNetHandle.gameCoinLost(reason,coinName,num,curAll)
    chnSelf:gameCoinLost(reason,coinName,num,curAll);
  end;

  -- 自定义事件
  function ChnNetHandle.commonEvent(eventCont)
    chnSelf:commonEvent(eventCont);
  end;

  -- 道具购买
  function ChnNetHandle.itemBuy(goodsName,goodsType,buyAmount,coinName,lostCoinNum,buyLocation)
    chnSelf:itemBuy(goodsName,goodsType,buyAmount,coinName,lostCoinNum,buyLocation);
  end;

  -- 道具消耗
  function ChnNetHandle.itemConsume(goodsName,goodsType,lostAmount,reason)
    chnSelf:itemConsume(goodsName,goodsType,lostAmount,reason);
  end;

  -- 请求CDKey取得物品
  function ChnNetHandle.useCDKey(cdkStr)
    local userId = DBTools.getUnqid();
    chnSelf:useCDKey(userId,cdkStr);
  end;

  -- 默认请求
  function ChnNetHandle.reqDef(json)
    chnSelf:reqDef(json);
  end;
end;

module("ChnNetHandle",package.seeall);
