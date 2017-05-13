--- 个人信息页面
do
  CLLPMyInfo = {}
  -- local altAdd = NAlertTxt.add;
  -- local addWdgCollider = NGUITools.AddWidgetCollider;

  local csSelf = nil;
  local transform = nil;
  local labName,labSex,labArea;
  -- local

  -- 初始化，只会调用一次
  function CLLPMyInfo.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    labName = getChild(trsfOffset,"Top/Label"):GetComponent("UILabel");
    labSex = getChild(trsfOffset,"Grid/001Sex/LabelVal"):GetComponent("UILabel");
    labArea = getChild(trsfOffset,"Grid/002Area/LabelVal"):GetComponent("UILabel");
  end

  -- 设置数据
  function CLLPMyInfo.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPMyInfo.show()
    local trsfTmp = getChild(transform, "Offset/Top/BgTop");
    addWdgCollider(trsfTmp.gameObject);

    local _pl = CLLData:getPl();
    labName.text = _pl.custName;
    labSex.text = _pl.gender or "未填写";
    labArea.text = _pl.address or "未填写";
  end

  -- 刷新
  function CLLPMyInfo.refresh()
  end

  -- 关闭页面
  function CLLPMyInfo.hide()
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPMyInfo.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPMyInfo.uiEventDelegate(go)
    local goName = go.name;
    if goName == "BtnOut" then
      CLLData:outLogin();
    elseif goName == "Back" then
      CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPMyInfo.hideSelfOnKeyBack()
    return false;
  end
  --------------------------------------------
  return CLLPMyInfo;
end
