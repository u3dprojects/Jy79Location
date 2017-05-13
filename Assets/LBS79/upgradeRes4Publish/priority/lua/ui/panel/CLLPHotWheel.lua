-- 风火轮
do
  local pName = nil;
  local panel = nil;
  local transform = nil;
  local gameObject = nil;
  local LabelMsg = nil;
  local MaxShowTime = 10; --秒
  local msg = nil;

  local times = 0;
  PanelHotWheel = {}

  function PanelHotWheel.init (go)
    pName = go.name;
    panel = go;
    transform = panel.transform;
    gameObject = panel.gameObject;
    LabelMsg = getChild(transform, "LabelMsg"):GetComponent("UILabel");
  end;

  function PanelHotWheel.setData (pars)
    msg = pars;
    if(msg == nil or msg == "") then
      msg = Localization.Get("Loading");
    end;
  end;

  function PanelHotWheel.show ()
    times = times + 1;
    panel:invoke4Lua("hideSelf", MaxShowTime);
  end;

  function PanelHotWheel.refresh ()
    LabelMsg.text = msg;
  end;

  function PanelHotWheel.hideSelf ( ... )
    if(times <= 0) then
      times = 0;
      return;
    end;
    times = times - 1;
    if(times <= 0) then
      times = 0;
      -- NAlertTxt.add("hide PanelHotWheel==", Color.red, 2);
      panel:cancelInvoke4Lua("");
      CLPanelManager.hidePanel(panel);
    else
      panel:invoke4Lua("hideSelf", MaxShowTime);
    end;
  end;

  function PanelHotWheel.hide ()
    panel:cancelInvoke4Lua("");
  end;

  return PanelHotWheel;
end
