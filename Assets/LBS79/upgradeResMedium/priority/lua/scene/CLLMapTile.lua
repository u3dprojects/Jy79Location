-- tile单元
do
    local _cell = {}
    local csSelf = nil;
    local transform = nil;
    local mData = nil;
    local onFinishEffectNew;
    local onFinishFallCallback;
    local isPlayFall = false;
    local rigidbody;
    local propObj; -- 道具对象

    -- 初始化，只调用一次
    function _cell.init(csObj)
        csSelf = csObj;
        transform = csSelf.transform;
        rigidbody = transform:GetComponent("Rigidbody");
        --[[
        上的组件：getChild(transform, "offset", "Progress BarHong"):GetComponent("UISlider");
        --]]
    end

    -- 显示，
    -- 注意，c#侧不会在调用show时，调用refresh
    function _cell.show(go, data)
        mData = data;
        --[[
        TODO:
        --]]
    end

    -- 注意，c#侧不会在调用show时，调用refresh
    function _cell.refresh(paras)
        --[[
        if(paras == 1) then   -- 刷新血
          -- TODO:
        elseif(paras == 2) then -- 刷新状态
          -- TODO:
        end
        --]]
    end

    -- 取得数据
    function _cell.getData()
        return mData;
    end

    function _cell.clean()
        if (csSelf.ornamentOnTop ~= nil) then
            csSelf.ornamentOnTop.luaTable.clean();
            NGUITools.SetActive(csSelf.ornamentOnTop.gameObject, false);
            CLThingsPool.returnObj(csSelf.ornamentOnTop.name, csSelf.ornamentOnTop.gameObject);
            csSelf.ornamentOnTop = nil;
        end
        csSelf.mapTileBelow = nil;

        _cell.rmProp();

    end

    function _cell.effectNew(pos, callback)
        onFinishEffectNew = callback;

        isPlayFall = false;
        local offset = NumEx.NextInt(1, 10) / 20;
        csSelf.tweenPosition.from = pos + Vector3.up * 20;
        csSelf.tweenPosition.to = pos;
        csSelf.tweenPosition.duration = 1 + offset;
        csSelf.tweenPosition.animationCurve = csSelf.fallCurve;

        csSelf.tweenPosition:ResetToBeginning();
        csSelf.tweenPosition:PlayForward();
    end

    function _cell.effectFall(callback)
        if (csSelf.ornamentOnTop ~= nil) then
            csSelf.ornamentOnTop.luaTable.effectFall(_cell.onFinishOrnamentFall);
            csSelf.ornamentOnTop = nil;
        end

        isPlayFall = true;
        onFinishFallCallback = callback;
        local offset = NumEx.NextInt(1, 10) / 20.0;
        csSelf.tweenPosition.from = transform.position + Vector3.forward * offset;
        csSelf.tweenPosition.to = transform.position - Vector3.forward * offset;
        csSelf.tweenPosition.duration = 1 + offset;
        csSelf.tweenPosition.animationCurve = csSelf.shakeCurve;

        csSelf.tweenPosition:ResetToBeginning();
        csSelf.tweenPosition:PlayForward();
    end

    function _cell.onFinishOrnamentFall(tile)
        NGUITools.SetActive(tile.gameObject, false);
        tile.luaTable.clean();
        CLThingsPool.returnObj(tile.name, tile.gameObject);
    end

    function _cell.onNotifyLua(...)
        if (isPlayFall) then
            rigidbody.isKinematic = false;
            csSelf:invoke4Lua("onFinishFallEffcet", 1.5);
        else
            Utl.doCallback(onFinishEffectNew, csSelf);
        end
    end

    function _cell.onFinishFallEffcet(...)
        rigidbody.isKinematic = true;
        Utl.doCallback(onFinishFallCallback, csSelf);
    end

    function _cell.getProp()
        return propObj;
    end

    -- 增加道具
    function _cell.addProp(prop)
        _cell.rmProp();
        propObj = prop;
    end

    -- 移除道具
    function _cell.rmProp()
        if(propObj ~= nil) then
            NGUITools.SetActive(propObj.gameObject, false);
            CLThingsPool.returnObj(propObj.name, propObj.gameObject);
            propObj = nil;
        end
    end

    --------------------------------------------
    return _cell;
end
