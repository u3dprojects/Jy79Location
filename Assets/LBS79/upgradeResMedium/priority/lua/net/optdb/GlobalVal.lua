--- 全局变量
-- author : canyon
do
  local M = {};
  function M:init()
    if self.isInit then
      return;
    end;

    self.isInit = true;
    local _MG = _G;
    local _tab = {
      ["U_PL"] = "U_PL",
      ["U_PL_ListDevice"] = "U_PL_ListDevice",
      ["LgId_Pwd"] = "LgId_Pwd",
      ["GameNetwork"] = require("net.GameNetwork"),
      ["altAdd"] = NAlertTxt.add,
      ["addWdgCollider"] = NGUITools.AddWidgetCollider,
      ["SetActive"] = NGUITools.SetActive,
      ["NET_CMD_ValidCode"] = "1009",
      ["NET_CMD_Registe"] = "1001",
      ["NET_CMD_Login"] = "1002",
      ["NET_CMD_AddDevice"] = "1011",
      ["NET_CMD_MakeTradeNo"] = "1005",
      ["NET_CMD_PrePayWeiXin"] = "2000",
    }

    for key, var in pairs(_tab) do
      _MG[key] = var;
    end
  end
  M:init();
  return M;
end;
