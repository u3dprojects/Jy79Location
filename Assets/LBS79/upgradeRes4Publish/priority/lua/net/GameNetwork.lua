--- 游戏数据:与服务器交互的数据请求
-- Anchor : Canyon
-- Time : 2016-03-19 17:30
-- Desc :

local cjson = require("cjson");
local WWWForm = WWWForm or UnityEngine.WWWForm;
local WWWNetwork = require("WWWNetwork");
local altAdd = NAlertTxt.add;

local insert = table.insert;
local mathL = math;

local URL_DEF = "http://112.23.2.188:29002/mobileInterface/service";

local M = {};

function M:callFunc4Net(callFunc)
  return function(wwwData,pars)
    local _tab = nil;
    if wwwData.text then
      print(wwwData.text);
      _tab = cjson.decode(wwwData.text);
      if _tab and _tab.error == 1 then
        altAdd(_tab.message, Color.red, 1);
      end
    end
    if callFunc ~= nil then
      callFunc(_tab,pars);
    end;
  end
end

-- 获取短信验证妈
function M:validCode(phone,stype,callFunc,pars)
  local _params = {};
  _params.phone = tostring(phone);
  _params.shortType = tostring(stype);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_ValidCode .. "&params=" .. jsonStr;
  -- _url = System.Uri.EscapeUriString (_url);
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end

-- 注册
function M:registe(phone,password,activeCode,shortType,customerName,callFunc,pars)
  local _params = {};
  _params.phone = tostring(phone);
  _params.shortType = tostring(shortType);
  _params.password = tostring(password);
  _params.activeCode = tostring(activeCode);
  _params.customerName = tostring(customerName);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_Registe .. "&params=" .. jsonStr;
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end

-- 登录
function M:login(phone,password,loginType,callFunc,pars)
  local _params = {};
  _params.phone = tostring(phone);
  _params.password = tostring(password);
  _params.loginType = tostring(loginType);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_Login .. "&params=" .. jsonStr;
  print(_url)
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end

-- 添加设备
function M:addDevice(customerId,deviceNo,VIN,name,idCard,callFunc,pars)
  local _params = {};
  _params.customerId = tostring(customerId);
  _params.deviceNo = tostring(deviceNo);
  _params.VIN = tostring(VIN);
  _params.name = tostring(name);
  _params.idCard = tostring(idCard);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_AddDevice .. "&params=" .. jsonStr;
  print(_url)
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end

-- 生成订单
function M:makeTradeNo(customerId,deviceId,serviceTime,callFunc,pars)
  local _params = {};
  _params.customerId = tostring(customerId);
  _params.deviceId = tostring(deviceId);
  _params.serviceTime = tostring(serviceTime);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_MakeTradeNo .. "&params=" .. jsonStr;
  print(_url)
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end

-- 微信统一下单
function M:prePayWeiXin(orderId,callFunc,pars)
  local _params = {};
  _params.orderId = tostring(orderId);

  local jsonStr = cjson.encode(_params);

  local _url = URL_DEF .. "?api=" .. NET_CMD_PrePayWeiXin .. "&params=" .. jsonStr;
  print(_url)
  local call4Succes = self:callFunc4Net(callFunc);

  WWWNetwork:startWww(_url,call4Succes,call4Succes,pars)
end
return M
