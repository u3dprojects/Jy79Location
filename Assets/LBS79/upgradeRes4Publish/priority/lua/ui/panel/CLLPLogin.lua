--- 登录界面
do
  CLLPLogin = {}

  local csSelf = nil;
  local transform = nil;
  local inpLgid,inpLgPwd,togRemember;

  -- 初始化，只会调用一次
  function CLLPLogin.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    local trsfOffset = getChild(transform, "Offset");
    inpLgid = getChild(trsfOffset,"LgId/Input"):GetComponent("UIInput");
    inpLgPwd = getChild(trsfOffset,"LgPwd/Input"):GetComponent("UIInput");
    togRemember = getChild(trsfOffset,"LgRemeber/Toggle"):GetComponent("UIToggle");
  end

  -- 设置数据
  function CLLPLogin.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPLogin.show()
    local remTab = CLLData:getLgIdPwd();
    if remTab ~= nil then
      togRemember.value = true;
      inpLgid.value = remTab.lgid;
      inpLgPwd.value = remTab.lgpwd;
    end
  end

  -- 刷新
  function CLLPLogin.refresh()
  end

  -- 关闭页面
  function CLLPLogin.hide()
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPLogin.procNetwork(cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPLogin.uiEventDelegate(go)
    local goName = go.name;
    if goName == "BtnLoginWifi" or goName == "BtnLogin79" then
      local lgIdStr = inpLgid.value;
      if lgIdStr == "" then
        altAdd("请输入的登录帐号！", Color.red, 1);
        return;
      end
      local lgPwdStr = inpLgPwd.value;
      if lgPwdStr == "" then
        altAdd("请输入的登录密码！", Color.red, 1);
        return;
      end
      local isRem = togRemember.value == true;
      local lgType = goName == "BtnLoginWifi" and 2 or 1;
      CLLData:setLgType(lgType);
      local pars = {lgid=lgIdStr,lgpwd=lgPwdStr,isRem=isRem};
      showHotWheel();
      GameNetwork:login(lgIdStr,lgPwdStr,lgType,CLLPLogin.call4NetBack,pars);
    elseif goName == "Label_Forget" then
      altAdd("单击了忘记密码！", Color.red, 1);
    elseif goName == "Label_Regist" then
      CLPanelManager.getPanelAsy("PnlRegiste", onLoadedPanel);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPLogin.hideSelfOnKeyBack()
    return false;
  end

  --------------------------------------------

  -- 回调函数
  function CLLPLogin.call4NetBack(tab,pars)
    hideHotWheel();
    inpLgid.value = "";
    inpLgPwd.value = "";
    togRemember.value = false;
    if tab and tab.error == 0 then
      if tab.title == NET_CMD_Login then
        if pars and pars.isRem then
          CLLData:setLgIdPwd(pars);
        end

        if tab.customerInfo then
          CLLData:setPl(tab.customerInfo);
        end

        if tab.listDevice then
          CLLData:setListDevice(tab.listDevice);
        end
        CLLPMain.resetBottomSize();
      end
    end
  end

  return CLLPLogin;
end
