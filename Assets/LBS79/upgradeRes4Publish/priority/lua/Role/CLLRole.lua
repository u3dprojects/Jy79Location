--[[
//                    ooOoo
//                   8888888
//                  88" . "88
//                  (| -_- |)
//                  O\  =  /O
//               ____/`---'\____
//             .'  \\|     |//  `.
//            /  \\|||  :  |||//  \
//           /  _||||| -:- |||||-  \
//           |   | \\\  -  /// |   |
//           | \_|  ''\---/''  |_/ |
//            \ .-\__  `-`  ___/-. /
//         ___ `. .' /--.--\  `. . ___
//      ."" '<  `.___\_<|>_/___.'  >' "".
//     | | : ` - \`.;`\ _ /`;.`/- ` : | |
//     \ \ `-.    \_ __\ /__ _/   .-` / /
//======`-.____`-.___\_____/___.-`____.-'======
//                   `=---='
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
//           佛祖保佑       永无BUG
//           游戏大卖       公司腾飞
//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
--]]
-- 英雄
do
    local CLLRole = {};

    local State = {};
    State.none = 0;
    State.idel = 1;
    State.searchTarget = 2;
    State.attack = 3;
    State.moving = 4;
    State.fall = 5 --摔倒

    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local csSelf = nil;
    local speciLua = {};
    local transform = nil;
    local gameObject = nil;
    CLLRole.attr = nil; -- 属性
    local attr = nil; -- 属性
    CLLRole.skillAttr = nil; -- 技能属性
    local skillAttr = nil; -- 技能属性
    local data = nil; -- 数据
    CLLRole.data = nil;
    local currSkill = nil;
    --    local moveSpeed = 1;
    local lifeBar = nil; -- 血条的
    local pubCounter = 0; -- 通用计数
    local hudAnchor = nil;
    local effectObj = nil; -- 特效对象
    local isOffense = false;
    --    local atkSpeed = 0; -- 攻击速度，注意这是指fixedUpdate的帧数
    local nextAtkTime = 0; -- 下一次攻击的时间，记录的是fixedUpdate的帧数
    local lockingTarget = nil; -- 锁定的目标
    local things = {}; -- 物件对象
    local attackConter = 0; -- 攻击次数
    local callMoveToTime = 0; -- 当调用寻路时帧
    local WAIT_AIPATH_TIME = 10; -- 等待寻路的时间帧，为了保证每次寻路用的时间都一样
    local isInited = false;
    local oldSpeciLuaName = "";
    local isPlayingSkill = false;

    local isFalling = false;
    local rigidbody;
    local pathRay;
    local equip; -- 装备

    local mState = State.idel
    CLLRole.targets = {}; -- 所有可攻击的目标
    local hitEffectCount = 0;

    function CLLRole.init(selfObj, id, star, lev, _isOffense, other)
        if (not isInited) then
            isInited = true;
            csSelf = selfObj;
            transform = selfObj.transform;
            gameObject = selfObj.gameObject;
            rigidbody = transform:GetComponent("Rigidbody");
            pathRay = csSelf:GetComponent("CLAIPathByRaySimple");
        end

        isOffense = _isOffense;
        if (rigidbody ~= nil) then
            rigidbody.isKinematic = true;
        end

        csSelf.shadow.transform.localPosition = Vector3(0, 0.05, 0);

        -- 初始化随机因子
        --        if (CLBattle.self.isReplayMode) then
        --            csSelf.RandomFactor = other[1];
        --            csSelf.instanceID = other[2]; -- 重新设置instanceID，回放时可能要用到
        --        else
        csSelf:initRandomFactor();
        --        end

        csSelf.canFixedInvoke = true; --可以处理fixed update

        -- 取得属性配置
        attr = CLLDBCfg.getRoleByGIDAndLev(id, lev);
        CLLRole.attr = attr;
        local skillID = bio2Int(attr.base.SkillID);
        if (skillID > 0) then
            skillAttr = CLLDBCfg.getSkillByIDAndLev(skillID, 1);
        else
            skillAttr = nil;
        end
        CLLRole.skillAttr = skillAttr;

        -- 数据初始化
        CLLRole.initData();

        -- 设置aiPath
        local r = bio2Int(attr.base.AttackRadius) / 10;
        local offset = csSelf:fakeRandom(0, 50);
        --        csSelf.aiPath.endReachedDistance = r * (1 - offset / 100);
        csSelf.aiPath.endReachedDistance = 0.2;
        if (csSelf.isOffense) then
            csSelf.aiPath.speed = data.moveSpeed;
        else
            csSelf.aiPath.speed = data.moveSpeed * (1 + offset / 100);
        end

        -- 加载特殊处理的lua
        local speciLuaName = attr.base.SpeciLua;
        if (oldSpeciLuaName ~= speciLuaName and speciLuaName ~= nil and speciLuaName ~= "") then
            oldSpeciLuaName = speciLuaName;
            local luaPath = PStr.b():a(PathCfg.luaBasePath):a(PathCfg.self.basePath):a("/"):a(PathCfg.upgradeRes):a("/priority/lua/Role/"):a(speciLuaName):a(".lua"):e();
            speciLua = Utl.doLua(csSelf.lua, luaPath);
            if (speciLua ~= nil) then
                speciLua = speciLua[0];
            else
                speciLua = {};
            end
        end

        if (speciLua.init ~= nil) then
            speciLua.init(csSelf, CLLRole, attr, skillAttr);
        end

        -- 设置血条
        lifeBar = csSelf.lifeBar; -- 在创建的时候已经设置了anchor
        NGUITools.SetActive(csSelf.lifeBar.gameObject, true);
        lifeBar.luaTable.init(csSelf.lifeBar.gameObject);
        lifeBar.luaTable.show(csSelf.lifeBar.gameObject, csSelf);

        -- 影子
        NGUITools.SetActive(csSelf.shadow, true);
        if (isOffense) then
            NGUITools.SetActive(csSelf.shadow2, true);
        else
            NGUITools.SetActive(csSelf.shadow2, false);
        end

        mState = State.none;
        -- 战斗处理
        if (SCfg.self.mode == GameMode.battle) then
            if (SCfg.self.player ~= csSelf) then
                CLLRole.doSearchTarget();
            end
        else
            CLLRole.IamIdel(false);
        end
    end

    function CLLRole.initData()
        data = {}
        data.HP = attr.vals.Hitpoints; -- 设置总血量
        data.currHP = attr.vals.Hitpoints; -- 设置当前血量

        -- 伤害
        data.Atk = attr.vals.Damage;

        -- 移动速度
        data.moveSpeed = bio2Int(attr.base.MoveSpeed);
        -- 攻击速度，注意这是指fixedUpdate的帧数
        data.atkSpeed = (bio2Int(attr.base.AttackSpeed) / 1000) / Time.fixedDeltaTime;

        CLLRole.data = data;
    end

    function CLLRole.addEquipAttr(equipAttr)
        local addHP = bio2Int(equipAttr.HP);
        if(addHP > 0) then
            local tmpHP = bio2Int(data.currHP) + addHP;
            if (tmpHP > bio2Int(data.HP)) then
                data.currHP = data.HP;
            else
                data.currHP = int2Bio(tmpHP); -- 设置当前血量
            end

            -- 飘血条
            lifeBar.luaTable.cutHP(addHP);
        end

        -- 伤害
        data.Atk = int2Bio(bio2Int(data.Atk) + bio2Int(equipAttr.Damage));

        CLLRole.data = data;
    end

    function CLLRole.rmEquipAttr(equipAttr)
        -- 伤害
        data.Atk = int2Bio(bio2Int(data.Atk) - bio2Int(equipAttr.Damage));

        CLLRole.data = data;
    end

    function CLLRole.IamIdel(isGoSomeWhere)
        mState = State.idel;
        csSelf.aiPath:stop();
        CLLRole.setAction("idel");
        if (isGoSomeWhere) then
            csSelf:invoke4Lua("goSomeWhere", NumEx.NextInt(0, 5) / 10);
        end
    end

    function CLLRole.goSomeWhere()
        local tile = CLLScene.getFreeTile();
        if (tile ~= nil) then
            CLLRole.moveTo(tile.transform.position);
        end
    end

    function CLLRole.getAttr(...)
        return attr;
    end

    function CLLRole.getData(...)
        return data;
    end

    -- 清除数据，最好不要直接调用lua的clean，而是调用cs对象的clean。因为cs那边还有做其它的清理工作
    function CLLRole.clean(...)
        if (speciLua ~= nil and speciLua.clean ~= nil) then
            speciLua.clean();
        end
        if (csSelf ~= nil) then
            csSelf:cancelFixedInvoke4Lua("");
            csSelf:cancelInvoke4Lua("");
        end

        nextAtkTime = 0;
        attackConter = 0;
        callMoveToTime = 0;
        lockingTarget = nil;
        isFalling = false;
        hitEffectCount = 0;
        CLLRole.targets = {};

        -- 释放特效对象
        if (effectObj ~= nil) then
            effectObj:onFinish(nil);
            effectObj = nil;
        end

        -- 释放things
        for k, v in pairs(things) do
            if (v ~= nil) then
                CLThingsPool.returnObj(v.name, v.gameObject);
                NGUITools.SetActive(v.gameObject, false);
            end
        end
        things = {};

        CLLRole.releaseEquip();

        if (csSelf == SCfg.self.player) then
            SCfg.self.player = nil;
            SCfg.self.mLookatTarget.parent = CLMain.self.transform;
        end
    end

    -- 释放装备
    function CLLRole.releaseEquip()
        if (equip ~= nil) then
            -- 属性值从角色身上减去
            CLLRole.rmEquipAttr(equip.luaTable.getData());

            NGUITools.SetActive(equip.gameObject, false);
            equip.transform.parent = nil;
            CLThingsPool.returnObj(equip.name, equip.gameObject);
            equip = nil;
        end
    end

    -- 动作
    function CLLRole.setAction(...)
        local paras = { ... };
        local len = table.getn(paras);
        if (len == 0) then
            print("The action name is none, must send to");
            return
        end

        local actionName = paras[1];

        if (csSelf.isDead and actionName ~= "dead") then
            return;
        end

        if (len == 1) then
            if (actionName == "idel" or
                    actionName == "idel2" or
                    actionName == "run" or
                    actionName == "walk") then
                -- 这些都是loop的动作
                csSelf.action:setAction(getAction(actionName), nil);
            else
                csSelf.action:setAction(getAction(actionName),
                    ActCBtoList(100, CLLRole.onCompleteAction));
            end
        elseif (len == 2) then
            local callbackInfor = paras[2];
            csSelf.action:setAction(getAction(actionName),
                callbackInfor);
        end
    end

    -- 完成一组动作的回调
    function CLLRole.onCompleteAction(act)
        local curActVal = act.currActionValue;
        if (getAction("idel") == curActVal or
                getAction("idel2") == curActVal or
                getAction("run") == curActVal or
                getAction("walk") == curActVal) then
            return;
        end

        if (getAction("dead") ~= curActVal
                and getAction("down") ~= curActVal) then
            CLLRole.setAction("idel");
        end
        if (getAction("attack") == curActVal or
                getAction("attack2") == curActVal) then
            -- 判断装备能否还能用
            if (equip ~= nil) then
                if (not equip.luaTable.canUse()) then
                    CLLRole.releaseEquip();
                end
            end

            if (mState == State.attack and SCfg.self.player ~= csSelf) then
                csSelf:cancelFixedInvoke4Lua("_doAttack");
                mState = State.idel;
                CLLRole.doAttack();
            else
                mState = State.idel;
            end
        elseif (getAction("hit") == curActVal) then
            if (mState ~= State.fall) then
                mState = State.none;
                CLLRole.doSearchTarget();
            end
        elseif (getAction("up") == curActVal) then
            CLLRole.formation();
        elseif (getAction("dead") == curActVal) then
            if (not isFalling) then
                CLLRole.IamDead();
            end
        end
    end

    -- 向前移动
    function CLLRole.moveForward(_dir)
        local dir = SCfg.self.mainCamera.transform:TransformDirection(_dir);
        dir.y = 0;

        -- 攻击和移动不能同时
        if (isPlayingSkill or
                mState == State.attack or
                mState == State.fall or csSelf.isDead or
                CLLBattle.isEndBattle or isFalling) then
            csSelf.tween:stopMoveForward();
            if (mState == State.attack) then
                Utl.RotateTowards(transform, dir);
            end
            return
        end

        if (csSelf.action.currActionValue == getAction("attack") or
                csSelf.action.currActionValue == getAction("attack2")) then
            csSelf.tween:stopMoveForward();
            return -- 放技能时不能控制移动
        end
        --------------------------------------------
        Utl.RotateTowards(transform, dir);
        csSelf.tween:moveForward(data.moveSpeed);
        CLLRole.checkFall();

        -- 判断是否捡到装备、道具
        CLLRole.checkPickupProp();

        if ((not isPlayingSkill) and csSelf.action.currAction ~= getAction("attack2")) then
            CLLRole.setAction("run");
        end
    end

    function CLLRole.checkFall()
        if (not Physics.Raycast(transform.position + transform.up, transform.up * -1, 2, LayerMask.GetMask("Ground"))) then
            isFalling = true;
            rigidbody.isKinematic = false;
            CLLRole.onDead();
            csSelf:invoke4Lua("IamDead", 1.5);
        end
    end

    -- 当完成寻路
    function CLLRole.onPathComplete(p)
        --        csSelf:cancelFixedInvoke4Lua("setCanMove");
        --        local leftFrame = callMoveToTime + WAIT_AIPATH_TIME - csSelf.frameCounter;
        --        if (leftFrame > 0) then
        --            csSelf:fixedInvoke4Lua("setCanMove", leftFrame * Time.fixedDeltaTime);
        --        else
        --            csSelf:fixedInvoke4Lua("setCanMove", 0);
        --        end
        CLLRole.setCanMove();
    end

    function CLLRole.setCanMove()
        CLLRole.setAction("run");
        csSelf.aiPath.canMove = true;
    end

    -- 当移动时
    function CLLRole.onMoving()
        if (SCfg.self.player ~= csSelf) then
            if (CLLRole.canDoAttack()) then
                -- 设置一次状态，不然isInControled=false 时，后面onArrived的逻辑还是进不去
                csSelf.state = CLRoleState.searchTarget;
                CLLRole.onArrived();
            end
        end
        if (not isOffense) then
            CLLRole.checkFall();
        else
            -- 判断是否捡到装备、道具
            CLLRole.checkPickupProp();
        end
    end

    --判断是否捡到装备、道具
    function CLLRole.checkPickupProp()
        local tile = CLLScene.getTileByLocalPos(transform.localPosition);
        if (tile == nil) then return end
        local prop = tile.luaTable.getProp();
        if (prop ~= nil) then
            SEffect.play("PickupEffect", tile.transform.position, nil);
            local propAttr = prop.luaTable.getData();
            tile.luaTable.rmProp();
            CLLRole.installProp(propAttr);
            return true;
        end
        return false;
    end

    -- 装上装备、道具
    function CLLRole.installProp(propAttr)
        local gid = bio2Int(propAttr.GID);
        if (gid == 1) then
            -- 装备
            -- 先把之前的装备卸载下来
            CLLRole.releaseEquip();

            local func = function(name, obj, orgs)
                local prop = obj:GetComponent("CLBaseLua");
                if (prop.luaTable == nil) then
                    prop:setLua();
                    prop.luaTable.init(prop);
                end
                prop.luaTable.show(orgs);
                prop.luaTable.install(csSelf.avata.bonesMap:get_Item("RightHand"));
                NGUITools.SetActive(obj, true);
                equip = prop;
                -- 属性值加到角色身上
                CLLRole.addEquipAttr(orgs);
            end
            CLThingsPool.borrowObjAsyn(propAttr.PrefabName, func, propAttr);
        elseif (gid == 2) then
            -- 道具
            CLLRole.addEquipAttr(propAttr);
        end
    end

    -- 当移动到达目标地
    function CLLRole.onArrived()
        CLLRole.log("onArrived");
        csSelf.aiPath:stop();

        if (isFalling or csSelf.isDead) then
            CLLRole.setAction("idel");
            return;
        end

        if (SCfg.self.player ~= csSelf) then
            if (SCfg.self.mode == GameMode.battle) then
                if (CLLRole.canDoAttack()) then
                    local diff = csSelf.mTarget.transform.position - transform.position;
                    diff.y = 0;
                    Utl.RotateTowards(transform, diff);
                    if (mState ~= State.attack) then
                        -- 要判断这个状态，否则在onTriggerEnter时，可能正好在播放攻击动作
                        CLLRole.setAction("idel");
                    end
                    CLLRole.doAttack();
                else
                    CLLRole.IamIdel(true);
                    CLLRole.doSearchTarget();
                end
            else
                CLLRole.IamIdel(false);
            end
        else
            if (mState ~= State.attack) then
                -- 要判断这个状态，否则在onTriggerEnter时，可能正好在播放攻击动作
                CLLRole.IamIdel(false);
            end
        end
    end

    -- 寻敌
    function CLLRole.doSearchTarget(...)
        CLLRole.log("doSearchTarget");
        if (mState == State.searchTarget or csSelf.isDead or CLLBattle.isEndBattle) then
            return;
        end
        if (SCfg.self.player == csSelf) then
            return
        end

        pubCounter = 0;
        lockingTarget = nil;
        csSelf.mTarget = CLBattleToolkit.getNearestTarget(csSelf, bio2Int(attr.base.TriggerRadius) / 10, -1);
        if (csSelf.mTarget ~= nil and (not csSelf.mTarget.isDead)) then
            csSelf:cancelInvoke4Lua("goSomeWhere")
            csSelf:cancelFixedInvoke4Lua("_doAttack");
            mState = State.searchTarget;
            CLLRole.moveTo(csSelf.mTarget.transform.position);
        else
            if (mState ~= State.idel) then
                mState = State.idel;
                -- 只执行一次
                CLLRole.IamIdel(true);
            end

            csSelf:cancelFixedInvoke4Lua("doSearchTarget");
            csSelf:fixedInvoke4Lua("doSearchTarget", 0.3);
        end
    end

    function CLLRole.moveTo(pos)
        CLLRole.log("moveTo");
        pathRay:searchPath(pos, CLLRole.onGetPath);
    end

    function CLLRole.onGetPath(p)
        csSelf.aiPath:moveWithPath(p);
    end

    -- 判断能否攻击
    function CLLRole.canDoAttack(...)
        if (csSelf.isDead or CLLBattle.isEndBattle) then return false end
        -- 重新取目标
        local tmpTarget = CLBattleToolkit.getNearestTarget(csSelf, bio2Int(attr.base.TriggerRadius) / 10, -1);
        if (tmpTarget == nil or tmpTarget.isDead) then
            return false
        end

        if (CLLRole.isHaveTargets()) then
            csSelf.mTarget = tmpTarget;
            return true;
        end

        local dis = Vector3.Distance(transform.position, tmpTarget.transform.position);
        local AttackRadius = bio2Int(attr.base.AttackRadius) / 10;
        if (dis <= AttackRadius) then
            csSelf.mTarget = tmpTarget;
            return true;
        end
        return false;
    end

    -- 主角操作攻击
    function CLLRole.playAttack()
        if (isPlayingSkill or mState == State.fall or csSelf.isDead) then
            return;
        end

        if (csSelf.action.currActionValue == getAction("attack") or
                csSelf.action.currActionValue == getAction("attack2")) then
            if (speciLua ~= nil and speciLua.playAttack ~= nil) then
                speciLua.playAttack();
            end
            return;
        end

        csSelf.aiPath:stop();
        currSkill = nil;
        mState = State.attack;
        local target = CLBattleToolkit.getNearestTarget(csSelf, NumEx.bio2Int(MapEx.getBytes(attr.base, "TriggerRadius")), -1);

        if (target ~= null) then
            -- 自动锁定
            csSelf.mTarget = target;
            Utl.RotateTowards(transform, transform.position, target.transform.position);
        end
        local sound = MapEx.getString(attr.base, "AttackSound");
        if (not startswith(sound, '<')) then
            SoundEx.playSound(sound, 1, 2);
        end

        local effectName = MapEx.getString(attr.base, "AttackEffect");

        if (effectName ~= nil and effectName ~= "" and (not startswith(effectName, '<'))) then
            if ((effectObj == nil or effectObj.effectName ~= effectName)) then
                CLLRole.releaseAttackEffect();
                SEffectPool.setPrefab(effectName, CLLRole.onSetEffect);
            end
        end
        if (equip ~= nil) then
            equip.luaTable.use();
        end
        if (speciLua ~= nil and speciLua.playAttack ~= nil) then
            speciLua.playAttack();
        end
    end

    -- 当特效的prefab设置完成
    function CLLRole.onSetEffect(effect, orgs)
        effectObj = SEffect.play(effect.name, transform.position, transform);
        if (isPlayingSkill and effectObj ~= nil) then
            local el = effectObj:GetComponent("CLEffectLev");
            if (el ~= nil) then
                el.setLev(MapEx.getInt(currSkill, "sth") + 1);
            end
        end
    end

    -- 攻击
    function CLLRole.doAttack()
        if (csSelf.isDead) then return end
        if (mState == State.attack) then return end
        mState = State.attack;
        CLLRole._doAttack();
    end

    function CLLRole._doAttack()
        CLLRole.log("CLLRole._doAttack");
        if (CLLRole.canDoAttack()) then
            csSelf:cancelInvoke4Lua("goSomeWhere")
            -- 可以播放技能
            if (attackConter > 3 and skillAttr ~= nil and (not CLLBattle.isPlayingSkill)) then
                CLLBattle.chgHeroSkillState(csSelf, true);
            end
            -- 判断是否可以攻击（满足攻击频率）
            local diff = nextAtkTime - csSelf.frameCounter;
            if (diff > 0.00001) then
                csSelf:cancelFixedInvoke4Lua("_doAttack");
                csSelf:fixedInvoke4Lua("_doAttack", diff * Time.fixedDeltaTime);
            else
                if (speciLua ~= nil and speciLua.doAttack ~= nil) then
                    speciLua.doAttack();
                end

                attackConter = attackConter + 1;
                nextAtkTime = csSelf.frameCounter + data.atkSpeed;
                csSelf:fixedInvoke4Lua("_doAttack", data.atkSpeed * Time.fixedDeltaTime);
            end
        else
            csSelf:cancelFixedInvoke4Lua("_doAttack");
            mState = State.none;
            CLLRole.doSearchTarget();
        end
    end

    function CLLRole.doTargetHurt(target, skill)
        if (target ~= nil) then
            target.luaTable.onHurt(bio2Int(data.Atk), skill, csSelf);
        end
    end

    -- 处理目标的伤害
    function CLLRole.doTargetsHurt(targets, skill)
        if (targets == nil) then
            if (csSelf.mTarget ~= nil) then
                CLLRole.doTargetHurt(csSelf.mTarget, skill);
            end
        else
            for k, v in pairs(targets) do
                CLLRole.doTargetHurt(v, skill);
            end
        end
    end

    -- 受伤害
    function CLLRole.onHurt(hurt, skill, attacker)
        if (csSelf.isDead or CLBattle.self.isEndBattle) then return end
        csSelf:cancelFixedInvoke4Lua("doSearchTarget");
        csSelf:cancelFixedInvoke4Lua("_doAttack");

        -- 说明是技能攻击
        if (skill ~= nil) then
            hurt = bio2Int(skill.vals.Atk);
        end

        -- 减血
        local currHP = bio2Int(data.currHP);
        currHP = currHP - hurt;
        currHP = currHP < 0 and 0 or currHP;
        local persent = currHP / bio2Int(data.HP);
        data.currHP = int2Bio(currHP);

        -- 飘血条
        lifeBar.luaTable.cutHP(-hurt);

        -- 通知战场有英雄扣血
        CLLBattle.onHeroHurt(csSelf);

        -- 播放受击特效
        if (hitEffectCount < 1) then
            hitEffectCount = hitEffectCount + 1;
            if (attacker ~= null and attacker.isOffense) then
                SEffect.play("effect_hit2", csSelf.mBody.position + Vector3.up * 0.5, CLLRole.onFinishPlayHitEffect, nil);
            else
                SEffect.play("effect_hit", csSelf.mBody.position + Vector3.up * 0.5, CLLRole.onFinishPlayHitEffect, nil);
            end
        end

        -- sound
        SoundEx.playSound("onhit", 0.8, 3);

        csSelf.aiPath:stop();
        CLLRole.setAction("hit");

        -- 判断是否已经死亡
        if (currHP <= 0) then
            CLLRole.onDead();
        end
    end

    function CLLRole.fallBack(attacker, dis, speed, height)
        csSelf.tween:stop();
        csSelf.aiPath:stop();
        mState = State.fall;
        csSelf.tween:flyout(attacker.transform.position, transform.position,
            dis, speed, height, nil, CLLRole.onFinishHitFlyOut, true);
    end

    function CLLRole.onFinishHitFlyOut()
        --        if (mState == State.fall) then
        --            return;
        --        end
        mState = State.none;
        if (csSelf ~= SCfg.self.player) then
            csSelf:invoke4Lua("doSearchTarget", 0.3);
        end
    end

    function CLLRole.onFinishPlayHitEffect()
        hitEffectCount = hitEffectCount - 1;
        hitEffectCount = hitEffectCount < 0 and 0 or hitEffectCount;
    end

    -- 死亡
    function CLLRole.onDead()
        if (csSelf.isDead) then return end
        csSelf.isDead = true;
        csSelf:cancelFixedInvoke4Lua("");
        csSelf:cancelInvoke4Lua("");
        csSelf.aiPath:stop();
        csSelf.tween:stop();
        csSelf.tween:stopMoveForward();

        NGUITools.SetActive(csSelf.shadow, false);
        NGUITools.SetActive(csSelf.shadow2, false);

        -- 播放死亡动作
        CLLRole.setAction("dead");
        SoundEx.playSound(attr.base.DeadSound, 1, 1);
    end

    function CLLRole.IamDead(...)
        -- 从战场中的进攻方、防守方中移除，不然可能会被多次还回对象池，使用时就会出问题
        if (csSelf.isOffense) then
            CLBattle.self.offense:Remove(csSelf);
        else
            CLBattle.self.defense:Remove(csSelf);
        end
        -- 通知其它目标，我已经嗝屁了，就不要再攻击我了
        CLLBattle.someOnDead(csSelf);

        NGUITools.SetActive(gameObject, false);
        -- 把死亡对象还回对象池，可以重复使用
        CLRolePool.returnUnit(csSelf);
        -- 播放死亡效果
        --        if (not csSelf.isOffense) then
        --            SEffect.play ("effect_Dead", transform.position);
        --        end

        if (speciLua ~= nil and speciLua.IamDead ~= nil) then
            speciLua.IamDead();
        end

        -- 必须调用c#侧的clean方法，因为c#则还有些其它的处理
        csSelf:clean();
    end

    function CLLRole.pause(...)
        for i, v in ipairs(soldiers) do
            v:pause();
        end
    end

    function CLLRole.regain(...)
        for i, v in ipairs(soldiers) do
            v:regain();
        end
    end

    -- 技能
    function CLLRole.playSkill(pos)
        if (skillAttr == nil) then return end

        csSelf:invoke4Lua("releaseSkillRange", 1.5);

        CLLBattle.setHeroCollider(true);
        attackConter = 0;

        -- 类型
        -- local roundType = bio2Int(skillAttr.base.Type);
        -- 更新角色技能状态
        CLLBattle.chgHeroSkillState(csSelf, false);

        CLLRole.log({ playSkill = { fram = csSelf.frameCounter } });

        if (speciLua.playSkill ~= nil) then
            speciLua.playSkill(pos);
            return;
        else
            -- 播放特效
            SEffect.play(skillAttr.base.SkillEffect, pos, CLLRole.onFinishSkillEffect, nil);
        end
    end

    function CLLRole.releaseAttackEffect()
        if (effectObj ~= nil) then
            effectObj:onFinish(nil);
        end
        effectObj = nil;
    end

    function CLLRole.onTriggerEnter(go)
        if (go.layer ~= LayerMask.NameToLayer("Role")) then return end
        local role = go:GetComponent("CLUnit4Lua");
        if (role == nil) then
            role = go:GetComponentInParent(CLUnit4Lua.GetClassType());
        end
        if (role ~= nil and role ~= csSelf and csSelf.isOffense ~= role.isOffense) then
            CLLRole.targets[role.instanceID] = role;

            --            csSelf.state = CLRoleState.searchTarget;
            CLLRole.onArrived();
        end
    end

    function CLLRole.onTriggerExit(go)
        if (go.layer ~= LayerMask.NameToLayer("Role")) then return end
        local role = go:GetComponent("CLUnit4Lua");
        if (role == nil) then
            role = go:GetComponentInParent(CLUnit4Lua.GetClassType());
        end

        if (role ~= nil and role ~= csSelf and csSelf.isOffense ~= role.isOffense) then
            CLLRole.targets[role.instanceID] = nil;
        end
    end

    -- 是否有攻击的目标
    function CLLRole.isHaveTargets()
        for k, v in pairs(CLLRole.targets) do
            return true;
        end
        return false;
    end

    function CLLRole.onSomeOneDead(unit)
        CLLRole.targets[unit.instanceID] = nil;
    end

    function CLLRole.log(msg)
        --        if (not csSelf.isOffense) then
        --            print(msg);
        --        end
    end

    --＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝＝
    return CLLRole;
end
