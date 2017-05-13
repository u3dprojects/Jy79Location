-- --[[
-- //                    ooOoo
-- //                   8888888
-- //                  88" . "88
-- //                  (| -_- |)
-- //                  O\  =  /O
-- //               ____/`---'\____
-- //             .'  \\|     |//  `.
-- //            /  \\|||  :  |||//  \
-- //           /  _||||| -:- |||||-  \
-- //           |   | \\\  -  /// |   |
-- //           | \_|  ''\---/''  |_/ |
-- //            \ .-\__  `-`  ___/-. /
-- //         ___`. .'  /--.--\  `. . ___
-- //      ."" '<  `.___\_<|>_/___.'  >' "".
-- //     | | : ` - \`.;`\ _ /`;.`/- ` : | |
-- //     \ \ `-.    \_ __\ /__ _/   .-` / /
-- //======`-.____`-.___\_____/___.-`____.-'======
-- //                   `=---='
-- //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
-- //           佛祖保佑       永无BUG
-- //           游戏大卖       公司腾飞
-- //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
-- --]]
do
    ---------------------------
    ------ include start--------
    local includePath = Toolkit.PStr.b():a(PathCfg.persistentDataPath):a("/"):a(PathCfg.self.basePath):a("/upgradeRes/priority/lua/public/CLLInclude.lua"):e();
    Utl.doLua(CLMain.self.lua, includePath);
    ---------------------------
    ---------------------------

    LuaUtl = require("LuaUtl");
    require("CLLPrefs");
    require("CLLUpdateUpgrader");

    -- require("GboConstant");   -- 接口常量定义
    -- require("BuilderGBaoSng");
    -- require("CLLDataProc");
    -- require("ChnNetHandle");
    require("CLLData");

    CLMainLua = {};

    SCfg.self.useBio4Battle = false; -- 战斗中是否使用bio做计算

    -- UIAtlas.releaseSpriteTime = 15; -- 释放ui资源的时间（秒）

    SCfg.self.mainCamera.clearFlags = CameraClearFlags.SolidColor;

    -- 设置是否可以成多点触控
    SCfg.self.uiCamera:GetComponent("UICamera").allowMultiTouch = false;

--    print("SystemInfo.systemMemorySize==" .. SystemInfo.systemMemorySize);
--    if (SystemInfo.systemMemorySize < 2048) then
--        SCfg.self.isFullEffect = false;
--    end

    --设置帧率
    Application.targetFrameRate = 15;

    -- 设置是否测试环境
    if (Prefs.getTestMode()) then
        local url = Prefs.getTestModeUrl();
        if (url ~= "") then
            NAlertTxt.add("Test...", Color.red, -1, 1, false);
            CLVerManager.self.baseUrl = url;
        end
    end

    -- 当离线调用
    function CLMainLua.onOffline(...)
        NAlertTxt.add("网络连接已经断开，请重新登陆！", Color.red, 1);
    end

    -- 退出游戏确认
    function CLMainLua.exitGmaeConfirm(...)
        if (SCfg.self.isGuidMode) then
            return;
        end
        -- if GLVar.isCanOpenClose3Party then
        --   ChnNetHandle.reqExitGameVI();
        -- else

        print("CLMainLua.exitGmaeConfirm==" .. CLPanelManager.topPanel.name);
        print(CLPanelManager.topPanel:hideSelfOnKeyBack());
        if (CLPanelManager.topPanel == nil or
                (not CLPanelManager.topPanel:hideSelfOnKeyBack())) then
            CLUIUtl.showConfirm(Localization.Get("MsgExitGame"), CLMainLua.doExitGmae, nil);
        end
        -- end
    end

    -- 退出游戏
    function CLMainLua.doExitGmae(...)
        Application.Quit();
    end

    -- 暂停游戏或恢复游戏
    function CLMainLua.OnApplicationPause(isPause)
        if (isPause) then
            -- 内存释放
            GC.Collect(); -- 内存释放
        end
    end

    function CLMainLua.OnApplicationQuit(...)
    end

    function CLMainLua.showPanelStart()
        if (CLPanelManager.topPanel ~= nil and
                CLPanelManager.topPanel.name == "PanelStart") then
            CLPanelManager.topPanel:show();
        else
            --异步方式打开页面
            CLPanelManager.getPanelAsy("PanelSplash", CLMainLua.onGetPanel);
        end
    end

    function CLMainLua.onGetPanel(p)
        CLPanelManager.showTopPanel(p, true, true);
    end

    --------------------------------------------
    ---------- 验证热更新器是否需要更新---------------
    --------------------------------------------
    function CLMainLua.onCheckUpgrader(isHaveUpdated)
        if (isHaveUpdated) then
            -- 说明热更新器有更新，需要重新加载lua
            CLMain.self:reStart();
        else
            -- init sdk
            -- CLGboChn.getInstance():StartInit();

            --主初始化完后，打开下一个页面
            -- CLMainLua.showPanelStart();
            CLMain.self:invoke4Lua("showPanelStart", 0.5);
        end
    end

    function CLMainLua.init()

      Main();
      
      -- 处理开始
      if (SCfg.self.isEditMode) then
        CLMainLua.onCheckUpgrader(false);
      else
        -- 更新热更新器
        CLLUpdateUpgrader.checkUpgrader(CLMainLua.onCheckUpgrader);
      end
    end
    --------------------------------------------
    --------------------------------------------

    CLMainLua.init();
    
    return CLMainLua;
end
