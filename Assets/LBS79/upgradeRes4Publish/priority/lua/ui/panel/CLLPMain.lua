--- 主界面
do
  CLLPMain = {}

  local csSelf = nil;
  local transform = nil;
  local bottomBtnSize=0;
  local buttonSelected;
  local LabelTitle;
  local Button01;
  local gobjBtn02;

  -- 底部的bar的实际高度，这个在后面设置webview的时候有用
  CLLPMain.bottomBarHight = 1;
  CLLPMain.gobjBtn = nil;
  CLLPMain.isShowed = false;

  -- 初始化，只会调用一次
  function CLLPMain.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;

    local AnchorBottom = getChild(transform, "AnchorBottom");
    buttonSelected = getChild(AnchorBottom , "selected");
    Button01 = getChild(AnchorBottom, "Grid", "Button01").gameObject;
    gobjBtn02 = getChild(AnchorBottom, "Grid/Button02").gameObject;
    LabelTitle = getChild(transform, "AnchorTop", "LabelTitle"):GetComponent("UILabel");
    CLLPMain.gobjBtn = nil;
  end

  -- 设置数据
  function CLLPMain.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPMain.show()
    -- 要等执行了onEnable后才能执行该方法，因此等一下
    if not CLLPMain.isShowed then
      CLLPMain.isShowed = true;
      csSelf:invoke4Lua("resetBottomSize", 0.1);
    end
  end

  function CLLPMain.resetBottomSize()
    local AnchorBottom = getChild(transform, "AnchorBottom");
    local SpriteBg = getChild(AnchorBottom, "SpriteBg"):GetComponent("UISprite");
    local _tp = CLLData:getLgType();
    if _tp == 2 then
      bottomBtnSize = SpriteBg.width/3;
      gobjBtn02:SetActive(false)
    else
      bottomBtnSize = SpriteBg.width/4;
      gobjBtn02:SetActive(true)
    end
    local sizeAdjust = UIRoot.GetPixelSizeAdjustment(SpriteBg.gameObject);
    CLLPMain.bottomBarHight = SpriteBg.height/sizeAdjust;

    local SpriteSelected = getChild(buttonSelected, "SpriteSelected"):GetComponent("UISprite");
    SpriteSelected.width = bottomBtnSize;


    local grid = getChild(AnchorBottom, "Grid"):GetComponent("UIGrid");
    grid.cellWidth = bottomBtnSize;

    grid:Reposition();

    local _gobj = CLLPMain.gobjBtn or Button01;
    CLLPMain.uiEventDelegate(_gobj);
  end

  function CLLPMain.backToMain()
    csSelf:invoke4Lua("uiEventDelegate", Button01, 0.05);
  end

  local tileObj = nil;
  -- 刷新
  function CLLPMain.refresh()
  end

  -- 关闭页面
  function CLLPMain.hide()
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPMain.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPMain.uiEventDelegate(go)
    local goName = go.name;
    CLLPMain.gobjBtn = go;
    hideTopPanelExcept(csSelf);
    if goName == "Button01" then
      CLLPMain.setButtonSelected(go);
      LabelTitle.text = "首页";
      CLPanelManager.getPanelAsy("PnlIndex2", onLoadedPanelTT);
    elseif goName == "Button02" then
      CLLPMain.setButtonSelected(go);
      LabelTitle.text = "定位";
      local _pl = CLLData:getPl();
      if not _pl then
        altAdd("请先登录！", Color.red, 1);
        return;
      end
      local obj = CLLData:getListDevice();
      if not obj or #obj <= 0 then
        altAdd("请先添加设备！", Color.red, 1);
        return;
      end
      CLPanelManager.getPanelAsy("PanelBaiduMap", onLoadedPanelTT);
    elseif goName == "Button03" then
      CLLPMain.setButtonSelected(go);
      LabelTitle.text = "语音";
      CLPanelManager.getPanelAsy("PnlVoice", onLoadedPanelTT);
    elseif goName == "Button04" then
      CLLPMain.setButtonSelected(go);
      LabelTitle.text = "我";
      local _pl = CLLData:getPl();
      if _pl == nil then
        CLPanelManager.getPanelAsy("PnlLogin", onLoadedPanelTT);
      else
        CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanelTT);
      end
    end
  end

  function CLLPMain.setButtonSelected(go)
    local pos =go.transform.position;
    buttonSelected.transform.position = pos;
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPMain.hideSelfOnKeyBack()
    return false;
  end

  --------------------------------------------
  return CLLPMain;
end
