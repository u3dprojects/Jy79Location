-- 战斗
do
    CLLBattle = {}
    local csSelf = CLBattle.self;
    CLLBattle.isPaused = false;
    CLLBattle.isEndBattle = false;

    -- 初始化，只会调用一次
    function CLLBattle.init()
        CLLBattle.isPaused = false;
        CLLBattle.isEndBattle = false;
    end

    function CLLBattle.begain()
        -- load player
        local playerData = CLLData.player;
        local attr = CLLDBCfg.getRoleByGIDAndLev(bio2Int(playerData.gid), bio2Int(playerData.lev));
        CLRolePool.borrowUnitAsyn(attr.base.PrefabName, CLLBattle.onLoadedPlayer, { playerData, attr });
    end

    function CLLBattle.onLoadedPlayer(name, unit, orgs)
        SCfg.self.player = unit;
        local playerData = orgs[1];
        --        local attr = orgs[2];
        ---------------------------------
        SCfg.self.player.transform.parent = csSelf.transform;
        SCfg.self.player.transform.position = CLLScene.getCenterTile().transform.position;
        SCfg.self.player.transform.localScale = Vector3.one;
        SCfg.self.player.transform.localEulerAngles = Vector3.zero;
        SCfg.self.mLookatTarget.transform.parent = SCfg.self.player.transform;
        SCfg.self.mLookatTarget.transform.localPosition = Vector3.zero;
        SCfg.self.mLookatTarget.transform.localEulerAngles = Vector3.zero;

        NGUITools.SetActive(SCfg.self.player.gameObject, true);
        SCfg.self.player:init(bio2Int(playerData.gid), 0, bio2Int(playerData.lev), true, nil);
        csSelf.offense:Add(SCfg.self.player);

        ---------------------------------
        -- 地图块掉落
        CLLScene.checkLeftSideTilesTimeout(5);
        -- 加载怪
        CLLBattle.loadMonster(3);
    end

    -- 加载怪
    function CLLBattle.loadMonster(num, pos)
        local gid;
        local list = CLLDBCfg.getMonsters();
        local index;
        local attr;
        local lev = 1;
        for i = 0, num - 1 do
            index = NumEx.NextInt(1, (#list) + 1);
            attr = list[index];
            CLRolePool.borrowUnitAsyn(attr.base.PrefabName, CLLBattle.onLoadedMonster, { attr, lev, pos});
        end
    end

    function CLLBattle.onLoadedMonster(name, unit, orgs)
        local attr = orgs[1];
        local lev = orgs[2];
        local pos= orgs[3];
        ---------------------------------
        if(pos == nil) then
            pos = CLLScene.getFreeTile().transform.position;
        end
        unit.transform.parent = csSelf.transform;
        unit.transform.position = pos;
        unit.transform.localScale = Vector3.one;
        unit.transform.localEulerAngles = Vector3.zero;

        NGUITools.SetActive(unit.gameObject, true);
        unit:init(bio2Int(attr.base.GID), 0, lev, false, nil);
        csSelf.defense:Add(unit);
    end

    function CLLBattle.endBattle()
        CLLBattle.isEndBattle = true;
        CLLPBattle.endBattle();
    end

    function CLLBattle.exit()
        CLLBattle.isEndBattle = true;
        CLLBattle.clean();
    end

    function CLLBattle.clean()
        csSelf:cancelInvoke4Lua("");
        csSelf:cancelFixedInvoke4Lua("");
        CLLBattle.isPaused = false;
        local count = csSelf.offense.Count;
        local unit;
        for i = 0, count - 1 do
            unit = csSelf.offense:get_Item(i);
            unit:clean();
            NGUITools.SetActive(unit.gameObject, false);
            CLRolePool.returnUnit(unit);
        end
        csSelf.offense:Clear();

        count = csSelf.defense.Count;
        for i = 0, count - 1 do
            unit = csSelf.defense:get_Item(i);
            unit:clean();
            NGUITools.SetActive(unit.gameObject, false);
            CLRolePool.returnUnit(unit);
        end
        csSelf.defense:Clear();
    end

    -- 有英雄扣血
    function CLLBattle.onHeroHurt(unit)
        if (unit == SCfg.self.player) then
            CLLPBattle.onPlayerHurt();
        end
    end

    -- 有角色死亡
    function CLLBattle.someOnDead(unit)
        -- 选通知敌对方的所有人，有人死了
        local list = nil;
        if (unit.isOffense) then
            list = csSelf.defense
        else
            list = csSelf.offense;
        end
        local count = list.Count;
        local role = nil;
        for i = 0, count - 1 do
            role = list:get_Item(i);
            -- 通知敌对方有目标死亡了，不用再攻击他了
            role.luaTable.onSomeOneDead(unit);
        end

        if (SCfg.self.player == unit) then
            -- 主角死亡，战斗结束
            CLLBattle.endBattle();
            return;
        end

        -- 增加一列地块
        CLLScene.addRightSideTiles(0.02, CLLBattle.onFinishAddSideTiles);
        -- 通知ui
        CLLPBattle.someOnDead(unit);
    end

    function CLLBattle.onFinishAddSideTiles(sideRight)
        -- 因为地表块还要掉落下来，有一个过程，因些简单处理下，等待一下
        csSelf:invoke4Lua("addMonster", sideRight , 2.5);
        csSelf:invoke4Lua("addProp", sideRight , 2.5);
    end

    function CLLBattle.addMonster(sideRight)
        -- 增加怪
        local n = 1;
        if (NumEx.NextBool(0.01)) then
            n = 2;
        elseif(csSelf.defense.Count > 2 and NumEx.NextBool(0.1))then
            n = 0;
        end

        local pos = CLLScene.getRightSieFreeTile(sideRight).transform.position;
        CLLBattle.loadMonster(n, pos);
    end

    -- 增加道具
    function CLLBattle.addProp(sideRight)
        local tile = CLLScene.getRightSieFreeTile(sideRight);
        local propId = 1;
        if(NumEx.NextBool()) then
            propId = 4;
        end
        local attr = CLLDBCfg.getPropByID(propId);
        CLThingsPool.borrowObjAsyn(attr.PrefabName, CLLBattle.onGetProp, {tile, attr});
    end

    function CLLBattle.onGetProp(name, obj, orgs)
        local tile = orgs[1];
        local attr = orgs[2];
        local pos = tile.transform.position;
        obj.transform.parent = csSelf.transform;
        obj.transform.position = pos + (Vector3.up * 0.02);

        NGUITools.SetActive(obj, true);
        local prop = obj:GetComponent("CLBaseLua");
        if(prop.luaTable == nil) then
            prop:setLua();
            prop.luaTable.init(prop);
        end
        prop.luaTable.show(attr);
        tile.luaTable.addProp(prop);
    end
    --------------------------------------------
    return CLLBattle;
end
