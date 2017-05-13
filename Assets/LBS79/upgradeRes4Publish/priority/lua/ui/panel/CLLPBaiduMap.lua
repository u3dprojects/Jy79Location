--- xx界面
do
  local cjson = require "cjson"
  CLLPBaiduMap = {}

  local csSelf = nil;
  local transform = nil;
  local webview;
  local rightDis = 300;
  local CarlistRoot = nil;
  local isShowList = false;
  local gridLoop;

  -- 初始化，只会调用一次
  function CLLPBaiduMap.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    webview = transform:GetComponent("CLWebView");

    CarlistRoot = getChild(transform, "AnchorTopRight", "CarlistRoot"):GetComponent("TweenPosition");
    gridLoop = getChild(transform,"AnchorTopRight/CarlistRoot/Panel/Grid"):GetComponent("CLUILoopGrid");
  end

  -- 设置数据
  function CLLPBaiduMap.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLPBaiduMap.show()
    local url = PStr.b():a("file://"):a(PathCfg.persistentDataPath):a("/"):a(PathCfg.self.basePath):a("/"):a(PathCfg.upgradeRes):a("/priority/html/79/baiduditu.html"):e();
    webview:init(CLLPBaiduMap.onCallFromJs);
    webview:SetMargins(0, CLLPMain.bottomBarHight, 0, CLLPMain.bottomBarHight);
    webview:show(url);

    local SpriteBg = getChild(transform, "AnchorTopRight", "CarlistRoot", "SpriteBg"):GetComponent("UISprite");
    local sizeAdjust = UIRoot.GetPixelSizeAdjustment(SpriteBg.gameObject);
    rightDis = SpriteBg.width/sizeAdjust;
  end

  function CLLPBaiduMap.onCallFromJs(json)
    local data = cjson.decode(json);
    if data.cmd == "onFinsihLoad" then
      CLLPBaiduMap.sendOne2Js()
    elseif data.cmd == "backHome" then
      CLLPMain.gobjBtn = nil;
      CLLPMain.resetBottomSize();
    end
  end

  -- 刷新
  function CLLPBaiduMap.refresh()
    local listDevice = CLLData:getListDevice();
    gridLoop:setList(listDevice,CLLPBaiduMap.initCell,true);
  end

  -- 关闭页面
  function CLLPBaiduMap.hide()
    isShowList = false;
    webview:hide();
  end

  -- 网络请求的回调；cmd：指命，succ：成功失败，msg：消息；paras：服务器下行数据
  function CLLPBaiduMap.procNetwork (cmd, succ, msg, paras)
  -- if(succ == 0) then
  --   if(cmd == "xxx") then
  --     -- TODO:
  --   end
  -- end
  end

  -- 处理ui上的事件，例如点击等
  function CLLPBaiduMap.uiEventDelegate( go )
    local goName = go.name;
    if (goName == "ButtonList") then
      isShowList = (not isShowList);
      CLLPBaiduMap.twPnlGrid(isShowList);
    end
  end

  -- 当按了返回键时，关闭自己（返值为true时关闭）
  function CLLPBaiduMap.hideSelfOnKeyBack( )
    CLLPMain.backToMain();
    return true;
  end

  --------------------------------------------
  function CLLPBaiduMap.sendList2Js()
    -- lua list {{,isLocked=true,L,D,No}}
    local obj = CLLData:getListDevice();
    local jsonStr = cjson.encode(obj);
    webview.webViewObject:EvaluateJS("showCarList("..  jsonStr .. ");");
  end

  function CLLPBaiduMap.sendOne2Js()
    local obj = CLLData:getListDevice();
    CLLPBaiduMap.sendOneObj2Js(obj[1]);
  end

  function CLLPBaiduMap.sendOneObj2Js(oneObj)
    -- lua one {,isLocked=true,L,D,No}
    local jsonStr = cjson.encode(oneObj);
    webview.webViewObject:EvaluateJS("showCarInfo("..  jsonStr .. ");");
  end

  function CLLPBaiduMap.twPnlGrid(isShow)
    isShow = isShow == true;
    if isShow then
      webview:SetMargins(0, CLLPMain.bottomBarHight, rightDis, CLLPMain.bottomBarHight);
    else
      webview:SetMargins(0, CLLPMain.bottomBarHight, 0, CLLPMain.bottomBarHight);
    end
    CarlistRoot:Play(isShow);
  end

  function CLLPBaiduMap.initCell(cellCs, data)
    cellCs:init(data,CLLPBaiduMap.onClickCell);
  end

  function CLLPBaiduMap.onClickCell(cellCs)
    local _data = cellCs.luaTable.getData();
    CLLPBaiduMap.sendOneObj2Js(_data);
    CLLPBaiduMap.twPnlGrid(false);
  end
  return CLLPBaiduMap;
end
