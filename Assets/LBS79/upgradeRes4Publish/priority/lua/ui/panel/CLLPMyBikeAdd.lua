--- 登录界面
do
  CLLPMyBikeInfo = {}

  local csSelf = nil;
  local transform = nil;
  local gobjBtn;
  local inpName,inpIdCard,inpDevice,
    inpVIN;

  -- 初始化，只会调用一次
  function CLLPMyBikeInfo.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    inpName = getChild(trsfOffset, "Grid/001Name/Input"):GetComponent("UIInput");
    inpIdCard = getChild(trsfOffset, "Grid/002CardID/Input"):GetComponent("UIInput");
    inpDevice = getChild(trsfOffset, "Grid/004EqpSheBei/Input"):GetComponent("UIInput");
    inpVIN = getChild(trsfOffset, "Grid/005Bike/Input"):GetComponent("UIInput");
    gobjBtn = getChild(trsfOffset,"BtnAdd").gameObject;
  end

  -- 设置数据
  function CLLPMyBikeInfo.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPMyBikeInfo.show()
    addWdgCollider(gobjBtn);
  end

  -- 刷新
  function CLLPMyBikeInfo.refresh()
  end

  -- 关闭页面
  function CLLPMyBikeInfo.hide()
    CLLPMyBikeInfo.clearInp();
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPMyBikeInfo.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPMyBikeInfo.uiEventDelegate(go)
    local goName = go.name;
    if goName == "BtnAdd" then
      local strName = inpName.value;
      local strVIN = inpVIN.value;
      local strDevice = inpDevice.value;
      local strIdCard = inpIdCard.value;
      if strName == "" then
        altAdd("请输入的昵称！", Color.red, 1);
        return;
      end

      if strIdCard == "" then
        altAdd("请输入的身份证！", Color.red, 1);
        return;
      end

      if strDevice == "" then
        altAdd("请输入的设备号！", Color.red, 1);
        return;
      end

      if strVIN == "" then
        altAdd("请输入的车辆识别码！", Color.red, 1);
        return;
      end
      showHotWheel();
      GameNetwork:addDevice(CLLData:getPlId(),strDevice,strVIN,strName,strIdCard,CLLPMyBikeInfo.call4NetBack);
    elseif goName == "Back" then
      -- CLPanelManager.hideTopPanel();
      CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPMyBikeInfo.hideSelfOnKeyBack()
    return false;
  end

  --------------------------------------------

  function CLLPMyBikeInfo.clearInp()
    inpDevice.value = "";
    inpIdCard.value = "";
    inpName.value = "";
    inpVIN.value = "";
  end

  -- 回调函数
  function CLLPMyBikeInfo.call4NetBack(tab,pars)
    hideHotWheel();
    if tab and tab.error == 0 then
      if NET_CMD_AddDevice == tab.title then
        if nil ~= tab.listDevice then
          CLLData:setListDevice(tab.listDevice)
        end
        CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanel);
      end
    end
  end

  return CLLPMyBikeInfo;
end
