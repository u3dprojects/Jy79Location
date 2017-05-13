--- 我的Home页面
do
  CLLPMyHome = {}
  -- local altAdd = NAlertTxt.add;
  -- local addWdgCollider = NGUITools.AddWidgetCollider;

  local csSelf = nil;
  local transform = nil;
  local labName,labPhone,gridLoop;
  local gobjBox;
  -- local

  -- 初始化，只会调用一次
  function CLLPMyHome.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    labName = getChild(trsfOffset,"Top/Label"):GetComponent("UILabel");
    labPhone = getChild(trsfOffset,"Top/BgPhone/LabelVal"):GetComponent("UILabel");
    gobjBox = getChild(trsfOffset,"BgBox").gameObject;
    gridLoop = getChild(trsfOffset,"PnlWrap/Grid"):GetComponent("CLUILoopGrid");
  end

  -- 设置数据
  function CLLPMyHome.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPMyHome.show()
    addWdgCollider(gobjBox);
    local trsfTmp = getChild(transform, "Offset/Top/BgTop");
    addWdgCollider(trsfTmp.gameObject);

    local _pl = CLLData:getPl();
    labName.text = _pl.custName;
    labPhone.text = _pl.phone;
  end

  -- 刷新
  function CLLPMyHome.refresh()
    local listDevice = CLLData:getListDevice();
    gridLoop:setList(listDevice,CLLPMyHome.initCell,true);
  end

  -- 关闭页面
  function CLLPMyHome.hide()
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPMyHome.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPMyHome.uiEventDelegate(go)
    local goName = go.name;
    if goName == "Add" then
      CLPanelManager.getPanelAsy("PnlBikeAdd", onLoadedPanel);
    elseif goName == "BgTop" then
      CLPanelManager.getPanelAsy("PnlMineInfo", onLoadedPanel);
    elseif goName == "Back" then
      CLPanelManager.getPanelAsy("PnlLogin", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPMyHome.hideSelfOnKeyBack()
    return false;
  end

  function CLLPMyHome.initCell(cellCs, data)
    cellCs:init(data,CLLPMyHome.onClickCell);
  end

  function CLLPMyHome.onClickCell(cellCs)
    local _data = cellCs.luaTable.getData();
    CLPanelManager.getPanelAsy("PnlBikeInfo", onLoadedPanel,_data);
  end

  --------------------------------------------
  return CLLPMyHome;
end
