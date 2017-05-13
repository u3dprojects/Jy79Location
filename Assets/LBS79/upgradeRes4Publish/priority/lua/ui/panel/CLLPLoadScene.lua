-- 切换场景管理器
do
    require("CLLPrefabInit");
    local dragSetting = CLUIDrag4World.self;
    local smoothFollow = SCfg.self.mainCamera:GetComponent("CLSmoothFollow");

    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local csSelf = nil;
    local transform = nil;
    local progressBar = nil;
    local LabelTips = nil;
    local spriteBg = nil;
    local data = nil;
    --[[data.type = home, goPVE, showMainCity，rePlay, map
       data.callback
    --]]

    PanelLoadScene = {}

    function PanelLoadScene.init(go)
        transform = go.transform;
        csSelf = go;
        progressBar = getChild(transform, "Progress Bar"):GetComponent("UISlider");
        LabelTips = getChild(transform, "LabelTips"):GetComponent("UILabel");
        spriteBg = getChild(transform, "SpriteBg"):GetComponent("UISprite");
    end

    function PanelLoadScene.setData(pars)
        data = pars;
    end

    function PanelLoadScene.show()
        progressBar.value = 0;
        spriteBg.color = NewColor(0, 0, 0, 255);
        NGUITools.SetActive(progressBar.gameObject, false);
        LabelTips.text = Localization.Get("Loading");
        if (data.type == "home") then
            csSelf:invoke4Lua("gotoHome", 0.1);
        elseif(data.type == "battle") then
            csSelf:invoke4Lua("gotoBattle", 0.1);
        end
    end

    function PanelLoadScene.releaseRes(...)
        CLUIInit.self.emptAtlas:releaseAllTexturesImm();
        CLMain.self.lua:LuaGC(nil);
        SAssetsManager.self:releaseAsset(true);
        GC.Collect(0); -- 内存释放
        GC.Collect(1); -- 内存释放
        Resources.UnloadUnusedAssets();
    end

    function PanelLoadScene.onProgress(all, curr)
        NGUITools.SetActive(progressBar.gameObject, true);
        progressBar.value = curr / all;
    end

    function PanelLoadScene.hide()
    end

    function PanelLoadScene.refresh()
    end

    function PanelLoadScene.gotoHome(...)
        PanelLoadScene.releaseRes();

        spriteBg.color = NewColor(0, 0, 0, 64);
        -- 设置模式
        SCfg.self.mode = GameMode.normal;
        ---------------------------------
        smoothFollow.distance = 8;
        smoothFollow.height = 4;
        SCfg.self.mLookatTarget.localEulerAngles = Vector3(0, 0, 0);
        SCfg.self.mLookatTarget.position = Vector3(0, 0,-10);

        SCfg.self.mainCamera.fieldOfView = 50;
        SCfg.self.mainCamera.clearFlags = CameraClearFlags.Skybox;
        SCfg.self.mainCamera.transform.localEulerAngles = Vector3.zero;

        ---------------------------------
        dragSetting.canRotation = false;
        dragSetting.canScale = false;
        dragSetting.scaleMini = 5;
        dragSetting.scaleMax = 10;
        dragSetting.scaleHeightMini = 5;
        dragSetting.scaleHeightMax = 10;

        ---------------------------------
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogColor = NewColor(154, 180, 255, 255);
        RenderSettings.fogStartDistance = 8;
        RenderSettings.fogEndDistance = 30;
        RenderSettings.fog = false;
        -- RenderSettings.fogDensity = 0;

        ---------------------------------
        CLLCameraEffect.enabled(false);
        CLLCameraEffect.setFocalPoint(10);

        ---------------------------------
        SCfg.self.mode = GameMode.normal;
--        PanelLoadScene.loadCityRes();
        CLLScene.stopSpin();
        CLLScene.loadInfiniteMap(15, 12, 0.01, 5, -1, PanelLoadScene.onLoadMap);
    end

    function PanelLoadScene.onLoadMap()
        PanelLoadScene.showCityUI();
    end

    function PanelLoadScene.gotoBattle()
        PanelLoadScene.releaseRes();

--        spriteBg.color = NewColor(0, 0, 0, 64);
        -- 设置模式
        SCfg.self.mode = GameMode.normal;
        ---------------------------------
        smoothFollow.distance = 7;
        smoothFollow.height = 6;
        SCfg.self.mLookatTarget.localEulerAngles = Vector3(0, 0, 0);
        SCfg.self.mLookatTarget.position = Vector3(0, 0,-10);

        SCfg.self.mainCamera.fieldOfView = 60;
        SCfg.self.mainCamera.clearFlags = CameraClearFlags.Skybox;
        SCfg.self.mainCamera.transform.localEulerAngles = Vector3(38, 0, 0);

        ---------------------------------
        dragSetting.canRotation = false;
        dragSetting.canScale = false;
        dragSetting.scaleMini = 5;
        dragSetting.scaleMax = 10;
        dragSetting.scaleHeightMini = 5;
        dragSetting.scaleHeightMax = 10;

        ---------------------------------
        RenderSettings.fogMode = FogMode.Linear;
        RenderSettings.fogColor = NewColor(154, 180, 255, 255);
        RenderSettings.fogStartDistance = 8;
        RenderSettings.fogEndDistance = 30;
        RenderSettings.fog = false;
        -- RenderSettings.fogDensity = 0;

        ---------------------------------
        CLLCameraEffect.enabled(false);
        CLLCameraEffect.setFocalPoint(10);

        ---------------------------------
        CLLScene.stopSpin();

        ---------------------------------
        SCfg.self.mode = GameMode.battle;
        CLUIOtherObjPool.setPrefab("LifeBar", PanelLoadScene.onSetLifeBar, nil);
    end

    function PanelLoadScene.onSetLifeBar(...)
        -- load role
        local data = {}
        data.gid = 1;
        data.lev = 1;
        CLLPrefabInit.initRole(data, PanelLoadScene.showBattleUI, PanelLoadScene.onProgress, true);
    end

    function PanelLoadScene.showCityUI(...)
        CLPanelManager.hideTopPanel();
        CLPanelManager.getPanelAsy("PanelMain", onLoadedPanel);
    end

    function PanelLoadScene.showBattleUI()
        CLLBattle.init();
        CLPanelManager.getPanelAsy("PanelBattle", onLoadedPanel);
    end

    --------------------------------
    return PanelLoadScene;
end
