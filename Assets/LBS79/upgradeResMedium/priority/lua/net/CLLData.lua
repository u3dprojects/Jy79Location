
do
  require("GlobalVal");
  CLLData = {};
  local the = CLLData;
  local setPVal = PlayerPrefs.SetString;
  local getPVal = PlayerPrefs.GetString;
  local deleteKey = PlayerPrefs.DeleteKey;
  local deleteAll = PlayerPrefs.DeleteAll;
  local cjson = require("cjson");
  local _math = math;

  function the:setPrefsVal(keyStr,valStr )
    if type(keyStr) ~= "string" or type(valStr) ~= "string" then
      return;
    end
    setPVal(keyStr, valStr);
  end

  function the:getPrefsVal(keyStr)
    if type(keyStr) ~= "string" then
      return;
    end
    return getPVal(keyStr);
  end

  function the:removePrefsKey(keyStr)
    deleteKey(keyStr);
  end

  function the:clearAllPres()
    deleteAll();
  end

  function the:saveLuaVal(keyStr,valTab )
    if type(keyStr) ~= "string" or type(valTab) ~= "table" then
      return;
    end
    setPVal(keyStr, cjson.encode(valTab));
  end

  function the:getLuaVal(keyStr)
    if type(keyStr) ~= "string" then
      return;
    end
    local valStr = getPVal(keyStr);
    if valStr ~= nil then
      return cjson.decode(valStr);
    end
  end

  ------------------------------------

  function the:getPl()
    --    if self.player == nil and U_PL ~= self.U_PL then
    --      self.U_PL = U_PL;
    --      self.player = self:getLuaVal(U_PL);
    --      if self.player then
    --        self.player_id = self.player.id;
    --      end
    --    end
    return self.player;
  end

  function the:setPl(_pl)
    self.player = _pl;
    if self.player ~= nil then
      self.player_id = self.player.id;
    --      self:saveLuaVal(U_PL,self.player);
    end
  end

  function the:getPlId()
    return self.player_id;
  end

  function the:getListDevice()
    --    if self.listDevice == nil and U_PL_ListDevice ~= self.U_PL_ListDevice then
    --      self.U_PL_ListDevice = U_PL_ListDevice;
    --      self.listDevice = self:getLuaVal(U_PL_ListDevice);
    --    end
    return self.listDevice;
  end

  function the:getListJson()
    return self.json4LitDevice;
  end

  function the:setListDevice(listDevice)
    if type(listDevice) ~= "table" then
      return;
    end
    if nil == self.listDevice then
      self.listDevice = listDevice;
    else
      local tmp,tmp2;
      for key, var in ipairs(listDevice) do
        for i = 1,#self.listDevice do
          tmp = self.listDevice[i];
          tmp2 = tmp.id == var.id;
          if tmp2 then
            break;
          end
        end
        if not tmp2 then
          table.insert(self.listDevice,var);
        end
      end
    end
    if self.listDevice ~= nil then
      self:addTest4Device(self.listDevice);
      --      self:saveLuaVal(U_PL_ListDevice,self.listDevice);
      self.json4LitDevice = cjson.encode(self.listDevice);
    end
  end

  function the:addTest4Device(listDevice)
    if type(listDevice) ~= "table" then
      return;
    end
    -- 添加测试数据
    local isLocked,L,D,No;
    local defL = 116.404;
    local defD = 39.915;

    for key, val in ipairs(listDevice) do

      -- 添加测试数据
      isLocked = not (isLocked);
      L = defL + (key * 0.08);
      D = defD + (key * 0.05);
      No = _math.ceil((_math.random() * 100000));
      
      val.L = L;
      val.D = D;
      val.No = No;
      val.isLocked = isLocked;
    end
  end

  function the:getLgIdPwd()
    if self.lgIdPwd == nil and LgId_Pwd ~= self.LgId_Pwd then
      self.LgId_Pwd = LgId_Pwd;
      self.lgIdPwd = self:getLuaVal(LgId_Pwd);
    end
    return self.lgIdPwd;
  end

  function the:setLgIdPwd(_tab)
    if _tab ~= nil then
      local isSame = _tab == self.lgIdPwd;
      if _tab.isRem == true then
        self.lgIdPwd = _tab;
      else
        self.lgIdPwd = nil;
        self:removePrefsKey(LgId_Pwd);
      end;
      if not isSame and self.lgIdPwd ~= nil then
        self:saveLuaVal(LgId_Pwd,self.lgIdPwd);
      end
    end
  end

  function the:go2Pay(id)
    local tab = {id=id};
    CLPanelManager.getPanelAsy("PnlPay", onLoadedPanelTT,tab);
  end

  function the:setLgType(_type)
    -- 1 = wifi, 没定位,2 = 79定位,多一个定位
    self.lgType = tonumber(_type) or 1;
  end

  function the:getLgType()
    return self.lgType;
  end

  function the:outLogin()
    self.player = nil;
    self.player_id = nil;
    self.listDevice = nil;
    self.json4LitDevice = nil;
    CLPanelManager.getPanelAsy("PnlLogin", onLoadedPanel);
  end

  return CLLData;
end

module("CLLData", package.seeall);
