-- 角色的一些特殊处理
do
    local speciLua = {};
    ------------------------------------------
    local transform;
    local csSelf = nil;
    local roleLua = nil;
    local attr = nil;
    local skillAttr = nil;
    local action;
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

    -- 攻击
    function speciLua.doAttack(...)
        --        SoundEx.playSound(AttackSound2[0], 1, 1);

        --        SEffect.play(AttackEffect2[0], transform.position, transform);
        roleLua.setAction("attack",
            ActCBtoList(
                10, speciLua.doAttackMove_1,
                50, speciLua.doAttacking_1,
                100, speciLua.doAttackComplete_4));
    end

    -- 攻击第一段的移动
    function speciLua.doAttackMove_1( act )
--        if(SCfg.self.mode == GameMode.normal) then
--            return
--        end
--        csSelf.tween:flyout(transform.forward, 0.5, 8, 0, nil, nil, true);
    end

    -- 攻击第一段的将要完成时
    function speciLua.doAttacking_1( act )
        roleLua.doTargetsHurt(roleLua.targets, nil);

--        if(lTargets.count > 0) then
--SScreenShakes.play(nil, 0, 0.3);
--            SoundEx.playSound("onhit", 0.8, 4);
--
--            local list = lTargets:ToArray();
--            local count = list.Length;
--            local target = nil;
--            for i = 0, count - 1 do
--                target = list[i];
--                target.luaTable.fallBack(self, 0.8,9,0);
--            end
--        end
    end

    function speciLua.doAttackComplete_1(act)
        speciLua._doAttackComplete(act, 1);
    end

    function speciLua._doAttackComplete(act, soundIndex)
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

