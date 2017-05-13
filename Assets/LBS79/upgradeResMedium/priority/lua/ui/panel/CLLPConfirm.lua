-- 确认提示框
do
  local pName = nil;
  local panel = nil;
  local transform = nil;
  local gameObject = nil;
  local panelContent = nil;
  local table = nil;
  local LabelContent = nil;
  local ButtonCancel = nil;
  local ButtonOK = nil;
  local lbButtonCancel = nil;
  local lbButtonOK = nil;

  local onClickButtonCallback1 = nil;
  local onClickButtonCallback2 = nil;
  local datas = Stack(); -- 需要确认的消息椎
  local currData = nil;
  local panelContentDepth = 1;

  PanelConfirm = {}
  function PanelConfirm.init (go)
    pName = go.name;
    panel = go;
    transform = panel.transform;
    gameObject = panel.gameObject;
    panelContent = getChild(transform, "content", "PanelContent");
    table = getChild(panelContent, "Table");
    LabelContent = getChild(table, "LabelContent");
    LabelContent = LabelContent:GetComponent("UILabel");
    table = table:GetComponent("UITable");
    ButtonCancel = getChild(transform, "content", "ButtonCancel");
    lbButtonCancel = getChild(ButtonCancel, "Label"):GetComponent("UILabel");
    ButtonOK = getChild(transform, "content", "ButtonOK");
    lbButtonOK = getChild(ButtonOK, "Label"):GetComponent("UILabel");
    panelContent = panelContent:GetComponent("UIPanel");
    panelContentDepth = panelContent.depth;
  end;

  function PanelConfirm.setData ( pars )
    if(pars == nil) then return end;
    if(currData ~= nil and currData:get_Item(0) == pars:get_Item(0)) then return end; -- 相同消息只弹出一次
    datas:Push(pars);
  end;

  function PanelConfirm.show ()
    local baseDepth = panel:GetComponent("UIPanel").depth;
    panelContent.depth = baseDepth + panelContentDepth;

    currData = datas:Peek();
    if(currData == nil or currData.Count < 6) then
      PanelConfirm.checkLeftData();
      return;
    end;
    local msg = currData:get_Item(0);
    local isShowOneButton = currData:get_Item(1);
    local lbbutton1 = currData:get_Item(2);
    onClickButtonCallback1 = currData:get_Item(3);
    local lbbutton2 = currData:get_Item(4);
    onClickButtonCallback2 = currData:get_Item(5);

    LabelContent.text = msg;
    -- 重新计算collider
    NGUITools.AddWidgetCollider(LabelContent.gameObject);
    table.repositionNow = true;
    -- table:Reposition();
    lbButtonOK.text = lbbutton1;
    if (isShowOneButton) then
      NGUITools.SetActive(ButtonCancel.gameObject, false);
      ButtonOK.localPosition = Vector3(0, -109.7, 0);
    else
      ButtonCancel.localPosition = Vector3(120, -109.7, 0);
      ButtonOK.localPosition = Vector3(-120, -109.7, 0);
      NGUITools.SetActive(ButtonCancel.gameObject, true);
      lbButtonCancel.text = lbbutton2;
    end

    SoundEx.playSound2("Sounds/Alert" , 1);
  end;

  function PanelConfirm.hide ()
  end;

  function PanelConfirm.refresh ()
  end;

  function PanelConfirm.procNetwork (cmd, succ, msg, pars)
  end;

  function PanelConfirm.OnClickOK (button)
    if (onClickButtonCallback1 ~= nil) then
      Utl.doCallback(onClickButtonCallback1, nil);
    end
    PanelConfirm.checkLeftData();
  end;

  function PanelConfirm.OnClickCancel (button)
    if (onClickButtonCallback2 ~= nil) then
      Utl.doCallback(onClickButtonCallback2, nil);
    end
    PanelConfirm.checkLeftData();
  end;

  function PanelConfirm.checkLeftData ( ... )
    currData = datas:Pop();
    if(currData ~= nil) then
      currData:Clear();
      currData = nil;
    end;
    if(datas.Count > 0) then
      panel:show();
    else
      panel:hide();
    end;
  end;

  return PanelConfirm;
end
