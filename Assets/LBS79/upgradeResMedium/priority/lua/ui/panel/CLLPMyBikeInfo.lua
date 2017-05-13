--- 设备信息列表
do
  CLLPMyBikeInfo = {}
  local format = string.format;

  local csSelf = nil;
  local transform = nil;

  local labName,labIdCard,labDevice,
    labVIN,labVTK,labVTV,labSF;

  local mData;

  -- 初始化，只会调用一次
  function CLLPMyBikeInfo.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    labName = getChild(trsfOffset, "Grid/001Name/LabelVal"):GetComponent("UILabel");
    labIdCard = getChild(trsfOffset, "Grid/002CardID/LabelVal"):GetComponent("UILabel");
    -- labPhone = getChild(trsfOffset, "Grid/003Phone/LabelVal"):GetComponent("UILabel");
    labDevice = getChild(trsfOffset, "Grid/004EqpSheBei/LabelVal"):GetComponent("UILabel");
    labVIN = getChild(trsfOffset, "Grid/005Bike/LabelVal"):GetComponent("UILabel");
    labVTK = getChild(trsfOffset, "Grid/006ValidTime/LabelKey"):GetComponent("UILabel");
    labVTV = getChild(trsfOffset, "Grid/006ValidTime/LabelVal"):GetComponent("UILabel");
    labSF = getChild(trsfOffset, "Grid/007SurplusFlow/LabelVal"):GetComponent("UILabel");
    
    local trsfTmp = getChild(trsfOffset, "Grid/006ValidTime");
    addWdgCollider(trsfTmp.gameObject);
    trsfTmp = getChild(trsfOffset, "Grid/007SurplusFlow");
    addWdgCollider(trsfTmp.gameObject);
  end

  -- 设置数据
  function CLLPMyBikeInfo.setData(paras)
    mData = paras;
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPMyBikeInfo.show()
    if mData then
      labName.text = format("%s",mData.name);
      labIdCard.text = format("%s",mData.idCard);
      -- labPhone.text = format("%s",mData.deviceNo);
      labVIN.text = format("%s",mData.VIN);
      labDevice.text = format("%s",mData.deviceNo);
      labSF.text = format("%dMB",mData.leftMB);
      labVTV.text = format("%s",mData.serviceEndDate);
    end
  end

  -- 刷新
  function CLLPMyBikeInfo.refresh()
  end

  -- 关闭页面
  function CLLPMyBikeInfo.hide()
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
    if goName == "006ValidTime" then
      CLLData:go2Pay(mData.id);
    elseif goName == "007SurplusFlow" then
      -- altAdd("单击了购买流量！", Color.red, 1);
      CLLData:go2Pay(mData.id);
    elseif goName == "Back" then
      CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPMyBikeInfo.hideSelfOnKeyBack()
    return true;
  end

  --------------------------------------------
  return CLLPMyBikeInfo;
end
