--- 注册界面
do
  CLLPRegiste = {}

  local csSelf = nil;
  local transform = nil;
  local inpName,inpLgid,inpLgPwd,inpValid;
  local gobjBtn;

  -- 初始化，只会调用一次
  function CLLPRegiste.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    inpName = getChild(trsfOffset,"Grid/01Name/Input"):GetComponent("UIInput");
    inpLgid = getChild(trsfOffset,"Grid/02LgId/Input"):GetComponent("UIInput");
    inpLgPwd = getChild(trsfOffset,"Grid/05LgPwd/Input"):GetComponent("UIInput");
    inpValid = getChild(trsfOffset,"Grid/10LgValidate/Input"):GetComponent("UIInput");
    gobjBtn = getChild(trsfOffset,"Button").gameObject;
  end

  -- 设置数据
  function CLLPRegiste.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPRegiste.show()
    addWdgCollider(gobjBtn)
  end

  -- 刷新
  function CLLPRegiste.refresh()
  end

  -- 关闭页面
  function CLLPRegiste.hide()
    CLLPRegiste.clearInp();
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPRegiste.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPRegiste.uiEventDelegate(go)
    local goName = go.name;
    local lgIdStr = inpLgid.value;

    if goName == "Button" or goName == "LabelValida" then
      if lgIdStr == "" then
        altAdd("请输入正确的手机号码！", Color.red, 1);
        return;
      end

      if goName == "LabelValida" then
        showHotWheel();
        GameNetwork:validCode(lgIdStr,1,CLLPRegiste.call4NetBack)
      else
        local nameStr = inpName.value;
        if nameStr == "" then
          altAdd("请输入用户昵称！", Color.red, 1);
          return;
        end

        local lgPwdStr = inpLgPwd.value;
        if lgPwdStr == "" then
          altAdd("请输入的登录密码！", Color.red, 1);
          return;
        end

        local validStr = inpValid.value;
        if validStr ~= CLLData.regValid then
          altAdd("请输入的正确验证码！", Color.red, 1);
          return;
        end
        showHotWheel();
        GameNetwork:registe(lgIdStr,lgPwdStr,validStr,1,nameStr,CLLPRegiste.call4NetBack)
        -- CLPanelManager.getPanelAsy("PnlMineHome", onLoadedPanel);
      end
    elseif goName == "Back" then
      CLPanelManager.getPanelAsy("PnlLogin", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPRegiste.hideSelfOnKeyBack()
    return false;
  end

  --------------------------------------------

  function CLLPRegiste.clearInp()
    inpLgid.value = "";
    inpLgPwd.value = "";
    inpName.value = "";
    inpValid.value = "";
  end

  -- 回调函数
  function CLLPRegiste.call4NetBack(tab,pars)
    hideHotWheel();
    if tab and tab.error == 0 then
      if NET_CMD_Registe == tab.title then
        CLLData.regValid = nil;
        CLPanelManager.getPanelAsy("PnlLogin", onLoadedPanel);
      elseif NET_CMD_ValidCode == tab.title then
        CLLData.regValid = tab.message;
      end
    end
  end
  return CLLPRegiste;
end
