-- xx单元
do
    local _cell = {}
    local csSelf = nil;
    local transform = nil;
    local mData = nil;
    local usedCounter = 0;

    -- 初始化，只调用一次
    function _cell.init(csObj)
        csSelf = csObj;
        transform = csSelf.transform;
        --[[
        上的组件：getChild(transform, "offset", "Progress BarHong"):GetComponent("UISlider");
        --]]
    end

    -- 显示，
    -- 注意，c#侧不会在调用show时，调用refresh
    function _cell.show(data)
        mData = data;
        usedCounter = 0;
    end

    -- 取得数据
    function _cell.getData()
        return mData;
    end

    -- 使用
    function _cell.use()
        usedCounter = usedCounter + 1;
    end

    -- 能否使用
    function _cell.canUse()
        if (usedCounter > bio2Int(mData.MaxUseTimes)) then
            -- 说明已经到达最大使用次数
            return false;
        end
        return true;
    end

    function _cell.install(parent)
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.one;
        transform.localEulerAngles = Vector3.zero;
    end

    --------------------------------------------
    return _cell;
end
