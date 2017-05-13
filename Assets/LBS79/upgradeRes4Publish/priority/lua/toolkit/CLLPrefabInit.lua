-- 战斗资源加载
do
    -- local CLVerManager = luanet.import_type('CLVerManager')
    -- SBSliderBar = luanet.import_type('SBSliderBar')

    LuaUtl = require("LuaUtl");
    local finishCallback = nil;
    local onProgress = nil;

    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local roleCountMap = {}; -- 用来记数需要加载多少怪
    local roleAssets = Queue(); -- 需要加载的怪兽
    local effectAssets = Queue(); -- 需要加载的特效
    local soundAssets = Queue(); -- 需要加载的音效
    local bulletAssets = Queue(); -- 需要加载的子弹
    local thingAssets = Queue(); -- 需要加载的其它物件
    local roleGidsMap = ArrayList();
    local totalAssets = 0; -- 总数
    local currCount = 0; -- 已经完成加载数
    local battleMap = 1;
    local offData, defData, magics;
    local mType = 0;
    --[[

    1:only load role

    2:load role and sounds ,effectes recommend with the role

    3:load battle

   --]]

    CLLPrefabInit = {};
    -- 取得主城中英雄的资源
    function CLLPrefabInit.init4MainCityRoles(callback, progressCB)
        local offense = ArrayList();
        local role = CLLData.getMainHero(); -- 取得主英雄
        if (role ~= nil) then
            offense:Add(role);
        end
        -- role = CLLData.getFollowHero1(); -- 取得跟随者1
        -- if(role ~= nil) then
        --  offense:Add(role);
        -- end
        -- role = CLLData.getFollowHero2(); -- 取得跟随者2
        -- if(role ~= nil) then
        --  offense:Add(role);
        -- end
        CLLPrefabInit.initRoles(offense, callback, progressCB, false);
        offense:Clear();
        offense = nil;
    end

    -- 加载一个角色
    function CLLPrefabInit.initRole(data, callback, progressCB, isLoadAllRelatedRes)
        local list = {};
--        list:Add(data);
        table.insert(list, data);
        CLLPrefabInit._init(list, nil, callback, progressCB, (isLoadAllRelatedRes == true and 2 or 1));
--        list:Clear();
        list = nil;
    end

    -- 加载一组
    function CLLPrefabInit.initRoles(list, callback, progressCB, isLoadAllRelatedRes)
        CLLPrefabInit._init(list, nil, callback, progressCB, (isLoadAllRelatedRes == true and 2 or 1));
    end

    -- 战场初始化
    --[[
    pveAttr：pve地图配置,
    ioffData：进攻方角色列表,
    idefData：防守方角色列表,
    callback：加载完成回调 ,
    progressCB：加载进度回调
   --]]
    function CLLPrefabInit.init4Battle(pveMapName, ioffData, idefData, callback, progressCB)
        finishCallback = callback;
        onProgress = progressCB;
        offData = ioffData;
        defData = idefData;
        roleAssets:Clear();
        effectAssets:Clear();
        soundAssets:Clear();
        bulletAssets:Clear();
        roleCountMap = {};

        currCount = 0;

        -- 隐藏主城
        -- NGUITools.SetActive(SCfg.self.scene4Home, false);
        -- 加载战场
        -- if(CLBattle.self.scene4Battle ~= nil and
        --   CLBattle.self.scene4Battle.name ~= pveAttr.BattlePrefab) then
        --  -- release old scene
        --  GameObject.DestroyImmediate(CLBattle.self.scene4Battle, true);
        --  CLBattle.self.scene4Battle = nil;
        --  if(CLBattle.self.scene4BattleAsset ~= nil) then
        --   CLBattle.self.scene4BattleAsset:Unload(true);
        --   CLBattle.self.scene4BattleAsset = nil;
        --  end
        -- end

        if (CLBattle.self.scene4Battle == nil) then
            local path = PathCfg.self.basePath .. "/" .. PathCfg.upgradeRes .. "/other/scene/" .. PathCfg.self.platform .. "/" .. pveMapName .. ".unity3d";
            CLVerManager.self:getNewestRes(path, CLAssetType.assetBundle, CLLPrefabInit.onfinishloadMap, nil);
        else
            CLLPrefabInit.showScene(CLBattle.self.scene4Battle);
        end
    end

    function CLLPrefabInit.onfinishloadMap(path, content, org)
        if (content ~= nil) then
            local scene = GameObject.Instantiate(content.mainAsset);
            scene.name = content.mainAsset.name;
            content:Unload(false);
            content = nil;
            CLBattle.self.scene4BattleAsset = content;
            CLLPrefabInit.showScene(scene);
        end
    end

    function CLLPrefabInit.showScene(scene)
        scene.transform.parent = CLBattle.self.transform;
        scene.gameObject.isStatic = true;
        -- lm = scene:GetComponent("CLSceneLightMapping");
        -- lm:setLightmapping();
        NGUITools.SetActive(scene, true);
        -- 刷新A星
        -- AstarPath.active:Scan();
        CLBattle.self.scene4Battle = scene:GetComponent("CLBattleMap");
        -- --雾化
        -- CLBattle.self.scene4Battle.fog = false; -- 先把雾去掉（可能发热要好点）
        RenderSettings.fog = CLBattle.self.scene4Battle.fog;
        if (RenderSettings.fog) then
            RenderSettings.fogMode = CLBattle.self.scene4Battle.fogMode;
            RenderSettings.fogColor = CLBattle.self.scene4Battle.fogColor;
            RenderSettings.fogStartDistance = CLBattle.self.scene4Battle.fogStartDis;
            RenderSettings.fogEndDistance = CLBattle.self.scene4Battle.fogEndDis;
            RenderSettings.fogDensity = CLBattle.self.scene4Battle.fogDensity;
        end

        -- 加载角色相关资源
        CLLPrefabInit._init(offData, defData, finishCallback, onProgress, 3);
    end

    function CLLPrefabInit._init(ioffData, idefData, callback, progressCB, type)
        finishCallback = callback;
        onProgress = progressCB;
        offData = ioffData;
        defData = idefData;
        roleAssets:Clear();
        effectAssets:Clear();
        soundAssets:Clear();
        bulletAssets:Clear();
        roleGidsMap:Clear();
        roleCountMap = {};

        currCount = 0;

        -- 取得角色相关的资源（角色、特效、音效、子弹）
        if (offData ~= nil) then
            CLLPrefabInit.doInit(offData, type);
        end

        if (defData ~= nil) then
            CLLPrefabInit.doInit(defData, type);
        end
        if (type == 3) then -- 加载战场
        -- 打击特效
        --        CLLPrefabInit.enqueue(effectAssets, "effects_xue");
        -- CLLPrefabInit.enqueue(effectAssets, "effect_hit2");
        -- -- 死亡特效
        -- CLLPrefabInit.enqueue(effectAssets, "effect_Dead");
        -- CLLPrefabInit.enqueue(effectAssets, "effect_BossDead");
        -- -- 传送门
        -- CLLPrefabInit.enqueue(effectAssets, "effect_portalMonster");
        -- CLLPrefabInit.enqueue(effectAssets, "effect_portalPlayer");
        -- -- 收集金币箱子效果
        -- CLLPrefabInit.enqueue(effectAssets, "effect_CollectGold");
        -- CLLPrefabInit.enqueue(effectAssets, "effect_CollectGold2");
        -- CLLPrefabInit.enqueue(effectAssets, "effect_CollectBox");

        -- -- 基地爆炸
        -- CLLPrefabInit.enqueue(effectAssets, "effect_jidibaozha");

        -- -- 点击特效
        --        CLLPrefabInit.enqueue(effectAssets, "effect_Pos");

        -- -- 眩晕
        -- CLLPrefabInit.enqueue(effectAssets, "effect_dizzy");

        -- -- 变身
        -- CLLPrefabInit.enqueue(effectAssets, "effect_bianshen");
        -- -- 合体
        -- CLLPrefabInit.enqueue(effectAssets, "effect_heti");
        -- -- 传送门
        -- CLLPrefabInit.enqueue(effectAssets, "effect_chuansongmen");

        -- CLLPrefabInit.enqueue(soundAssets, "sound_heti_1");
        -- CLLPrefabInit.enqueue(soundAssets, "sound_heti_2");
        -- CLLPrefabInit.enqueue(soundAssets, "sound_heti_3");

        -- 机甲变身
        -- soundAssets:Enqueue("12bianshen");


        -- 血条初始化
        SBSliderBar.init();
        end

        -- 加载,先加载特效，再加载音效,再加载子弹,最后加载怪兽（因为要用到前面加载的特效）
        totalAssets = roleAssets.Count + effectAssets.Count + soundAssets.Count + bulletAssets.Count + thingAssets.Count;
        -- 加载特效
        CLLPrefabInit.effectInit();
    end

    -- 向队列中加入，如果有相同的都不加入
    function CLLPrefabInit.enqueue(queue, content)
        if (content == nil or content == "") then return end
        if (not queue:Contains(content)) then
            queue:Enqueue(content);
            return true;
        end
        return false;
    end

    -- 统计需要加载的怪数
    function CLLPrefabInit.recodeRoleNum(PrefabName, data)
        local n = data.num;
        n = n == nil and 1 or n;
        local num = roleCountMap[PrefabName];
        num = num == nil and 0 or num;
        num = num + n;
        -- print("num==" .. num);
        roleCountMap[PrefabName] = num;
    end

    -- 执行加载角色资源
    function CLLPrefabInit.doInit(monsters, itype)
        if (monsters ~= nil) then
            for i, v in pairs(monsters) do
                CLLPrefabInit.loadOneRole(v, itype);
            end
        end
    end

    -- 加载一个主色相关的资源
    function CLLPrefabInit.loadOneRole(monster, itype)
        if (monster == nil) then return end
        local attr = nil;
        local lvl = 0;
        local gid = 0;
        local star = 0;
        if (type(monster.gid) == "number") then
            gid = monster.gid;
        else
            gid = bio2Int(monster.gid);
        end

        if (type(monster.lev) == "number") then
            lvl = monster.lev;
        else
            lvl = bio2Int(monster.lev);
        end

        -- if(type(monster.star) == "number") then
        --  star = monster.star;
        -- else
        --  star = bio2Int(monster.star);
        -- end

        attr = monster.attr;
        if (attr == nil) then
            attr = CLLDBCfg.getRoleByGIDAndLev(gid, lvl);
        end
        if (attr ~= nil) then
            -- 记数角色的数量
            CLLPrefabInit.recodeRoleNum(attr.base.PrefabName, monster);
        end
        if (attr ~= nil and (not roleGidsMap:Contains(gid))) then
            roleGidsMap:Add(gid);
            -- 加载怪兽
            if (CLLPrefabInit.enqueue(roleAssets, attr.base.PrefabName)) then
            end

            -- 加载与角色相关的资源，特效，音效，子弹
            if (itype == 2 or itype == 3) then
                -- 加载特效
                if (attr.base.AttackHitEffect ~= nil and attr.base.AttackHitEffect ~= "") then
                    CLLPrefabInit.enqueue(effectAssets, attr.base.AttackHitEffect);
                end
                if (attr.base.AttackEffect ~= nil and attr.base.AttackEffect ~= "") then
                    if (attr.base.IsHero) then
                        if (attr.base.AttackEffect2 ~= nil and attr.base.AttackEffect2.Count > 0) then
                            local count = attr.base.AttackEffect2.Count;
                            for i = 0, count - 1 do
                                CLLPrefabInit.enqueue(effectAssets, attr.base.AttackEffect2[i]);
                            end
                        end
                    else
                        CLLPrefabInit.enqueue(effectAssets, attr.base.AttackEffect);
                    end
                end
                -- if (attr.base.AttackEffect2 ~= nil and attr.base.AttackEffect2 ~= "") then
                --  CLLPrefabInit.enqueue(effectAssets,attr.base.AttackEffect2);
                -- end

                -- 技能1
                local skillAttr = monster.skill;
                if (skillAttr == nil) then
                    local skillGid = bio2Int(attr.base.SkillID);
                    if (skillGid > 0) then
                        skillAttr = CLLDBCfg.getSkillByIDAndLev(skillGid, 1);
                    end
                end
                if (skillAttr ~= nil) then
                    CLLPrefabInit.skillInit2(skillAttr);
                end

                -- 加载音效
                if (attr.base.IdelSound ~= "") then
                    if (attr.base.IsHero) then
                        if (attr.base.IdelSound2 ~= nil) then
                            local count = attr.base.IdelSound2.Count;
                            for i = 0, count - 1 do
                                CLLPrefabInit.enqueue(soundAssets, attr.base.IdelSound2[i]);
                            end
                        end
                    else
                        CLLPrefabInit.enqueue(soundAssets, attr.base.IdelSound);
                    end
                end

                if (attr.base.MoveSound ~= "") then
                    CLLPrefabInit.enqueue(soundAssets, attr.base.MoveSound);
                end
                if (attr.base.AttackSound ~= "") then
                    if (attr.base.IsHero) then
                        local count = attr.base.AttackSound2.Count;
                        for i = 0, count - 1 do
                            CLLPrefabInit.enqueue(soundAssets, attr.base.AttackSound2[i]);
                        end
                    else
                        CLLPrefabInit.enqueue(soundAssets, attr.base.AttackSound);
                    end
                end
                if (attr.base.HitSound ~= "") then
                    CLLPrefabInit.enqueue(soundAssets, attr.base.HitSound);
                end
                if (attr.base.DeadSound ~= "") then
                    CLLPrefabInit.enqueue(soundAssets, attr.base.DeadSound);
                end

                -- 加载子弹
                local bulletID = bio2Int(attr.base.Projectile);
                if (bulletID > 0) then
                    CLLPrefabInit.bulletInforInit(bulletID);
                end
                bulletID = bio2Int(attr.base.Projectile2);
                if (bulletID > 0) then
                    CLLPrefabInit.bulletInforInit(bulletID);
                end
            end
        end
    end

    function CLLPrefabInit.soundInit()
        if (soundAssets.Count > 0) then
            local name = soundAssets:Dequeue();
            if (name == nil) then return end

            -- NAlertTxt.add("name==" .. name, Color.red, 1);
            if (SSoundPool.havePrefab(name) == false) then
                SSoundPool.setPrefab(name,
                    CLLPrefabInit.onSetSoundPrab);
            else
                CLLPrefabInit.loadSound();
            end
        else
            -- 加载子弹
            CLLPrefabInit.bulletInit();
        end
    end

    function CLLPrefabInit.onSetSoundPrab(unit)
        CLLPrefabInit.loadSound(name);
    end

    function CLLPrefabInit.loadSound(name)
        CLLPrefabInit.onFinishOne();
        CLLPrefabInit.soundInit();
    end

    function CLLPrefabInit.bulletInforInit(id)
        local attr = CLLDBCfg.getBulletByID(id);
        if (attr ~= nil) then
            CLLPrefabInit.bulletInforInit2(attr);
        end
    end

    function CLLPrefabInit.bulletInforInit2(attr)
        if (attr.PrefabName ~= nil and attr.PrefabName ~= "") then
            if (attr.IsOnlyAEffect) then
                CLLPrefabInit.enqueue(effectAssets, attr.PrefabName);
            else
                CLLPrefabInit.enqueue(bulletAssets, attr.PrefabName);
            end
        end
        -- 击中特效
        if (attr.HitEffect ~= nil and attr.HitEffect ~= "") then
            CLLPrefabInit.enqueue(effectAssets, attr.HitEffect);
        end
    end

    function CLLPrefabInit.skillInit(id)
        local attr = CLLDBCfg.getSkillByIDAndLev(id, 1);
        CLLPrefabInit.skillInit2(attr);
    end

    function CLLPrefabInit.skillInit2(attr)
        if (attr == nil) then return end
        local base = attr.base == nil and attr or attr.base;
        if (base == nil) then return end
        -- 加载技能特效
        if (base.SkillEffect ~= "") then
            CLLPrefabInit.enqueue(effectAssets, base.SkillEffect);
        end

        -- 击中特效
        if (base.HitEffect ~= "") then
            CLLPrefabInit.enqueue(effectAssets, base.HitEffect);
        end

        -- 加载音效
        -- if(base.Sound2 ~= nil and base.Sound2.Count > 0) then
        --   local n = base.Sound2.Count;
        --   for i=0,n-1 do
        --     CLLPrefabInit.enqueue(soundAssets,base.Sound2[i]);
        --   end
        -- else
        if (base.SkillSound ~= nil and base.SkillSound ~= "") then
            CLLPrefabInit.enqueue(soundAssets, base.SkillSound);
        end
        -- end

        -- 加载子弹
        local bulletID = bio2Int(base.Projectile);
        if (bulletID > 0) then
            CLLPrefabInit.bulletInforInit(bulletID);
        end

        bulletID = bio2Int(base.Projectile2);
        if (bulletID > 0) then
            CLLPrefabInit.bulletInforInit(bulletID);
        end
    end

    function CLLPrefabInit.effectInit()
        if (effectAssets.Count > 0) then
            local name = effectAssets:Dequeue();
            -- if(name == nil) then return end
            if (SEffectPool.havePrefab(name) == false) then
                SEffectPool.setPrefab(name,
                    CLLPrefabInit.onSetEffectPrab);
            else
                CLLPrefabInit.loadEffect(name);
            end
        else
            -- 加载音效
            CLLPrefabInit.soundInit();
        end
    end

    function CLLPrefabInit.onSetEffectPrab(effect)
        CLLPrefabInit.loadEffect(effect.name);
    end

    function CLLPrefabInit.loadEffect(name)
        local count = 1;
        local list = {};
        if (name == "effect_hit") then
            count = 10;
        elseif (name == "effect_hit2") then
            count = 6;
        elseif (name == "effect_Dead") then
            count = 5;
        elseif (string.find(name, "effect_attack") ~= nil) then
            count = 1;
        end

        for i = 0, count - 1 do
            local unit = SEffectPool.borrowEffect(name);
            list[i] = unit;
            NGUITools.SetActive(unit.gameObject, false);
        end
        for i = 0, count - 1 do
            SEffectPool.returnEffect(name, list[i]);
        end
        list = {};

        CLLPrefabInit.onFinishOne();
        CLLPrefabInit.effectInit();
    end

    function CLLPrefabInit.doRoleInit()
        if (roleAssets.Count > 0) then
            local name = roleAssets:Dequeue();
            if (CLRolePool.havePrefab(name) == false) then
                CLRolePool.setPrefab(name,
                    CLLPrefabInit.onSetMonsterPrab);
            else
                CLLPrefabInit.loadMonster(name);
            end
        else
            CLLPrefabInit.loadThing();
        end
    end

    function CLLPrefabInit.onSetMonsterPrab(unit)
        CLLPrefabInit.loadMonster(unit.name);
    end

    function CLLPrefabInit.loadMonster(name)
        local num = roleCountMap[name];
        num = num == nil and 1 or num;
        num = num < 1 and 1 or num;
        num = num > 6 and 5 or num;
        local list = {};
        local unit = nil;
        for i = 1, num do
            unit = CLRolePool.borrowUnit(name);
            unit:setLua();
            list[i] = unit;
            NGUITools.SetActive(list[i].gameObject, false);
        end

        for i = 1, num do
            CLRolePool.returnUnit(list[i]);
        end
        list = {};

        CLLPrefabInit.onFinishOne();
        CLLPrefabInit.doRoleInit();
    end

    function CLLPrefabInit.bulletInit()
        if (bulletAssets.Count > 0) then
            local name = bulletAssets:Dequeue();
            if (CLBulletPool.havePrefab(name) == false) then
                CLBulletPool.setPrefab(name,
                    CLLPrefabInit.onSetBulletPrab);
            else
                CLLPrefabInit.loadBullet(name);
            end
        else
            CLLPrefabInit.doRoleInit();
        end
    end

    function CLLPrefabInit.onSetBulletPrab(bullet)
        CLLPrefabInit.loadBullet(bullet.name);
    end

    function CLLPrefabInit.loadBullet(name)
        local count = 3;
        local list = {};
        for i = 0, count - 1 do
            local unit = CLBulletPool.borrowBullet(name);
            list[i] = unit;
            NGUITools.SetActive(unit.gameObject, false);
        end
        for i = 0, count - 1 do
            CLBulletPool.returnBullet(list[i]);
        end
        list = {};

        CLLPrefabInit.onFinishOne();
        CLLPrefabInit.bulletInit();
    end

    function CLLPrefabInit.loadThing()
        if (thingAssets.Count > 0) then
            local name = thingAssets:Dequeue();
            if (CLThingsPool.havePrefab(name) == false) then
                CLThingsPool.setPrefab(name,
                    CLLPrefabInit.onLoadThing, nil);
            else
                CLLPrefabInit.onLoadThing();
            end
        else
            CLLPrefabInit.checkFinishLoad();
        end
    end

    function CLLPrefabInit.onLoadThing(...)
        CLLPrefabInit.loadThing();
    end

    function CLLPrefabInit.onFinishOne(...)
        currCount = currCount + 1;
        --print("finisPercent==" .. (currCount/totalAssets));
        if (onProgress ~= nil) then
            onProgress(totalAssets, currCount);
        end
    end

    -- 判断是否已经加载完成
    function CLLPrefabInit.checkFinishLoad(...)
        if (finishCallback ~= nil) then
            finishCallback();
        end
    end
end

module("CLLPrefabInit", package.seeall)
