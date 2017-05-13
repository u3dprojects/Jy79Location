-- 角色的一些特殊处理
do
    local speciLua = {};
    ------------------------------------------
    local transform;
    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local csSelf = nil;
    local roleLua = nil;
    local attr = nil;
    local skillAttr = nil;
    local clickAttackTimes = 0;
    local action;
    local isSlideToTarget = false; -- 滑向敌人
    local isInited = false;

    function speciLua.init(_csSelf, _roleLua, _attr, _skillAttr)
        if (not isInited) then
            isInited = true;
            csSelf = _csSelf;
            transform = csSelf.transform;
            action = csSelf.action;
        end

        roleLua = _roleLua;
        attr = _attr;
        skillAttr = _skillAttr;
        -- 把函数设置成herolua，以便后面可以用invoke处理
    end

    -- 手动点击攻击时
    function speciLua.playAttack(...)
        clickAttackTimes = clickAttackTimes + 1;
        if (action.currActionValue == getAction("attack")
                or action.currActionValue == getAction("attack2")) then
            return;
        end

        --        if ((not isSlideToTarget) and csSelf.mTarget ~= nil and (not csSelf.mTarget.isDead)) then
        --            local dis = Vector3.Distance(transform.position, csSelf.mTarget.transform.position);
        --            if (dis > 2.5 and dis < 6) then
        --                isSlideToTarget = true;
        --                -- 直接移过去
        --                roleLua.setAction("slide",
        --                    ActCBtoList(100, roleLua.onCompleteOneActive));
        --
        --                csSelf.tween:flyout(transform.position, csSelf.mTarget.transform.position,
        --                    dis - 2, roleLua.data.moveSpeed * 0.7, 0, nil, speciLua.doAttack, true);
        --            else
        --                speciLua.doAttack();
        --            end
        --        else
        --            speciLua.doAttack();
        --        end
        speciLua.doAttack();
    end

    -- 攻击
    function speciLua.doAttack(...)
        isSlideToTarget = false;
        --        SoundEx.playSound(AttackSound2[0], 1, 1);

        --        SEffect.play(AttackEffect2[0], transform.position, transform);
        roleLua.setAction("attack",
            ActCBtoList(10, speciLua.doAttackMove_1,
                50, speciLua.doAttacking_1,
                --                21, speciLua.doAttackComplete_1,


                --                23, speciLua.doAttackMove_2,
                --                30, speciLua.doAttacking_2,
                --                36, speciLua.doAttackComplete_2,
                --
                --
                --                37, speciLua.doAttackMove_3,
                --                46, speciLua.doAttacking_3,
                --                60, speciLua.doAttackComplete_3,
                --
                --                68, speciLua.doAttackMove_4,
                --                71, speciLua.doAttacking_4,
                100, speciLua.doAttackComplete_4));
    end

    -- 攻击第一段的移动
    function speciLua.doAttackMove_1(act)
        if (SCfg.self.mode == GameMode.normal) then
            return
        end
        csSelf.tween:flyout(transform.forward, 0.5, 8, 0, nil, nil, true);
    end

    -- 攻击第一段的将要完成时
    function speciLua.doAttacking_1(act)
        if (roleLua.isHaveTargets()) then
            roleLua.doTargetsHurt(roleLua.targets, nil);
            --SScreenShakes.play(nil, 0, 0.3);
            SoundEx.playSound("onhit", 0.8, 4);
            for k, v in pairs(roleLua.targets) do
                v.luaTable.fallBack(csSelf, 0.8, 9, 0);
            end
        end
    end

    function speciLua.doAttackComplete_1(act)
        speciLua._doAttackComplete(act, 1);
    end

    function speciLua._doAttackComplete(act, soundIndex)
        clickAttackTimes = clickAttackTimes - 1;

        --        if(SCfg.self.mode == SCfg.GameMode.battlePVE) then
        --            if(not CLBattle.self.isAutoBattle) then
        --                if(clickAttackTimes <= 0) then
        --                    self:releaseAttackEffect();
        --                    self:onCompleteOneActive(act);
        --                    return;
        --                end
        --            end
        --        end
        --
        --        SoundEx.playSound (AttackSound2[soundIndex], 1, 3);
        --
        --        SEffect.play (AttackEffect2[soundIndex], transform.position, transform);
        --
        --        self.m_target = CLBattleToolkit.getTarget4Leader (self, -1);
        --        if(self.m_target ~= nil) then
        --            local dis = Vector3.Distance(self.m_target.transform.position, transform.position);
        --            local maxDis = 1;
        --            if(self.m_target.isTower) then
        --                maxDis = 4;
        --            end
        --            if(dis <= maxDis and not self.mTargets:Contains(self.m_target)) then
        --                self.mTargets:Add(self.m_target);
        --            end
        --            Utl.RotateTowards (transform, transform.position, self.m_target.transform.position);
        --        end
        --
        --        -- 通知ui主角攻击
        --        if(self.isLeader) then
        --            CLBattle.self:onMainRoleAttack();
        --        end
    end

    function speciLua.doAttackComplete_4(act)
        roleLua.onCompleteAction(act);
    end

    function speciLua.clean(...)
    end

    ------------------------------------------
    return speciLua;
end

