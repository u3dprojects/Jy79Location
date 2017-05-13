-- 页面档板
do

  
  local csSelf = nil;
  local transform = nil;
  local gameObject = nil;
  local lastClickTime = 0; -- 上一次点击时间

  PanelBackplate = {}

  function PanelBackplate.init(go)
    csSelf = go;
    transform = csSelf.transform;
    gameObject = csSelf.gameObject;
  end;

  function PanelBackplate.setData(pars)
  end;

  function PanelBackplate.show()
  end;

  function PanelBackplate.hide()
  end;

  function PanelBackplate.refresh()
  end;

  function PanelBackplate.procNetwork (cmd, succ, msg, pars)
  end;

  function PanelBackplate.OnClickBackplate(button)
    local currTime = DateEx.nowMS;
    if((currTime - lastClickTime)/1000 < 0.3) then -- 保证在短时间内只能点击一次
      return;
    end;
    lastClickTime = currTime;
    CLPanelManager.hideTopPanel();
  end;

  return PanelBackplate;
end
