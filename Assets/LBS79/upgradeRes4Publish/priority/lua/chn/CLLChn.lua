---3GU 渠道lua脚本
-- author : canyon
-- time : 2015-04-29
do
  require("ChnNetHandle");


  local pName = nil;
  local self = nil;
  local transform = nil;
  local gameObject = nil;

  -- 第三方函数的local变量
  local toArrayByJson = Utl.toArrayByJson;
  local toMapByJson = Utl.toMapByJson;
  local getStrLen4Trim = StrEx.getStrLen4Trim;
  local bio2Int = NumEx.bio2Int;
  local int2Bio = NumEx.int2Bio;

  local netDB = GLVar.dbData; -- 网络层数据对象
  local netLcl = GLVar.dbLocalData;

  -- 界面元素对象

  -- 属性值变量

  Channel = {};

  function Channel.init(go)
    pName = go.name;
    self = go:GetComponent('CLGboChn');
    transform = self.transform;
    gameObject = self.gameObject;
  end;

  function Channel.setData(pars)
  end;

  function Channel.show()
  end;

  function Channel.hide()
  end;

  function Channel.refresh()
  end;

  function Channel.procNetwork(cmd, succ, msg, pars )
  end;

  -- 初始化回调
  function Channel.OnCallInit(jsonStr)

  end;

  -- 登录回调
  function Channel.OnCallLogin(jsonStr)

  end;

  -- 充值回调
  function Channel.OnCallPay(jsonStr)
    -- NAlertTxt.add("jsonStr==" .. jsonStr, Color.red, 2);
    local map = toMapByJson(jsonStr);
    if map == nil then
      return;
    end;
    local exp = nil;
    local feeGID = -1;
    if map.payData ~= nil and map.payData.payInfo ~= nil then
      exp = map.payData.payInfo.exp;
      local enGoods = CLLDBCfg.getFeeByGoodsID( map.payData.payInfo.number,SCfg.Channel);
      if enGoods ~= nil then
        feeGID = bio2Int(enGoods.GID);
      end;
    end;
    local lens4Exp = getStrLen4Trim(exp);
    if lens4Exp == 0 then
      return;
    end;

    local luaFun = LuaUtl.getLuaFunc(exp);
    if luaFun == nil then
      return;
    end;
    --- [1时为成功,0时为取消,负数为错]
    -- luaFun(map.code,map.msg);
    luaFun(map.code,nil);

    -- 处理成功时候的回调
    if feeGID > 0 and map.code == 1 then
      local price = GLVar.dbData.goodsFee[feeGID];
      if type(price) == "number" then
        local cur = bio2Int(netDB.pl.costRMB4CurDay);
        cur = cur + price;
        netLcl.pl.costRMB4CurDay = int2Bio(cur);
        netDB.pl.costRMB4CurDay = int2Bio(cur);
      end;
    end;
  end;

  -- 版本回调
  function Channel.OnCallVersion(jsonStr)
    local map = toMapByJson(jsonStr);
    if map == nil then
      return;
    end;
    GLVar.sdkVer = map.recBuyStyle;
    -- 移动  mm,电信 ctcc, 联通 unipay, 移动和游戏 mmand
    if map.chn then
      SCfg.Channel = map.chn;
    else
      SCfg.Channel = "mm";
    end;
    GLVar.isCanOpenClose3Party = not (not map.isThirdExit);
    GLVar.isMoreGame = not (not map.isMoreGame);

    GLVar.dbData.IsSwitchAccount = map.IsSwitchAccount;

    GLVar.dbData.SubChannel = map.SubChannel;

    if map.isMusicEnabled ~= nil then
      local isMusic = not (not map.isMusicEnabled);
      SoundEx.musicSwitch = isMusic;
      SoundEx.soundEffSwitch = isMusic;
      if(isMusic) then
        SoundEx.playMainMusic();
      else
        SCfg.self.mainAudio:Pause();
      end;
    end;

  -- NAlertTxt.add("OnCallVersion==" .. jsonStr ..",recBuyStyle==" .. map.recBuyStyle, Color.red, 1);
  end;

  function Channel.OnCallCDKey(jsonStr)
    -- NAlertTxt.add("=== OnCallCDKey==" .. jsonStr, Color.red, 2);
    -- print("=== OnCallCDKey==" .. jsonStr);

    local map = toMapByJson(jsonStr);
    local isFail = false;
    local giftId = 0;
    if map == nil then
      isFail = true;
    end;
    if not isFail then
      local code = tonumber("" .. map.code);
      if code == 1 and map.data ~= nil then
        local data = map.data;
        if data == nil or data.Count <= 0 then
          isFail = true;
        else
          giftId = (data[0]).goodsid;
        end;
      else
        isFail = true;
      end;
    end;
    PanelCdk.getByStatus(not isFail, giftId);
  end;

  function Channel.OnCallBackDef(jsonStr)

  end;
end;
