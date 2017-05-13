--- 支付界面
do
  local cjson = require("cjson");
  CLLPPay = {}

  local csSelf = nil;
  local transform = nil;
  local csJBridge = nil;

  local tabPars;

  -- 初始化，只会调用一次
  function CLLPPay.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local gobjBridge = GameObject();
    gobjBridge.transform.parent = transform;
    gobjBridge.transform.localPosition = Vector3.zero;
    gobjBridge.transform.localEulerAngles = Vector3.zero;
    gobjBridge.transform.localScale = Vector3.one;
    csJBridge = gobjBridge:AddComponent(ULJavaBridge:GetClassType());
  end

  -- 设置数据
  function CLLPPay.setData(pars)
    tabPars = pars;
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPPay.show()
  end

  -- 刷新
  function CLLPPay.refresh()
  end

  -- 关闭页面
  function CLLPPay.hide()
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPPay.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPPay.uiEventDelegate(go)
    local goName = go.name;
    if goName == "BgAlipay" then
      -- altAdd("单击了支付宝！", Color.red, 1);
      showHotWheel();
      GameNetwork:makeTradeNo(CLLData:getPlId(),tabPars.id,1,CLLPPay.call4NetBack,1);
    elseif goName == "BgWeiXin" then
      -- altAdd("单击了微信！", Color.red, 1);
      showHotWheel();
      GameNetwork:makeTradeNo(CLLData:getPlId(),tabPars.id,1,CLLPPay.call4NetBack,2);
    elseif goName == "Back" then
      CLPanelManager.hideTopPanel();
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPPay.hideSelfOnKeyBack()
    return false;
  end

  --------------------------------------------

  -- 回调函数
  function CLLPPay.call4NetBack(tab,pars)
    hideHotWheel();
    if tab and tab.error == 0 then
      if tab.title == NET_CMD_MakeTradeNo then
        showHotWheel();
        local trade = tab.listOrder[1];
        local _tabPars = {
          tradeNo = trade.id,
          subject = "购买套餐",
          body = "购买79元/年的套餐,享受定位",
          price = "0.01",
          isDebug = true,
        };
        if pars == 2 then
          showHotWheel();
          GameNetwork:prePayWeiXin(trade.id,CLLPPay.call4NetBack,_tabPars);
        else
          csJBridge.Init("com.sdkplugin.extend.PluginAlipay",CLLPPay.call4PayBack);
          csJBridge.SendToJava(cjson.encode(_tabPars));
        end
      elseif tab.title == NET_CMD_PrePayWeiXin then
        csJBridge.Init("com.sdkplugin.extend.PluginWeixin",CLLPPay.call4PayBack);
        local _tabPars = tab.payRequest;
        _tabPars.isDebug = true;
        csJBridge.SendToJava(cjson.encode(_tabPars));
      end
    end
  end

  -- 支付回调
  function CLLPPay.call4PayBack(json)
    hideHotWheel();
    print("== CLLPPay.call4PayBack==")
    print(tostring(json));
    altAdd(tostring(json), Color.red, 1);
  end

  return CLLPPay;
end
