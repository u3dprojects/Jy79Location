--- - 管理数据配置
do
    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local mdb = {} -- 原始数据
    local mMaps4ID = {}

    CLLDBCfgTool = {};

    -- 把json数据转成对象
    function CLLDBCfgTool.getDatas(cfgPath, isParseWithID)
        local list = mdb[cfgPath];
        local map4ID = {};
        if (list == nil) then
            list = {};
            local _list = Utl.fileToObj(cfgPath);
            if (_list == nil or _list.Count < 2) then
                mdb[cfgPath] = list;
                return list, map4ID;
            end;

            local count = _list.Count;
            local n = 0;
            local keys = _list:get_Item(0);
            local cellList = nil;
            local cell = nil;
            local value = 0;
            for i = 1, count - 1 do
                cellList = _list:get_Item(i);
                n = cellList.Count;
                cell = {};
                for j = 0, n - 1 do
                    value = cellList:get_Item(j);
                    if (type(value) == "number") then
                        cell[keys:get_Item(j)] = int2Bio(value);
                    else
                        cell[keys:get_Item(j)] = value;
                    end;
                end;
                if (isParseWithID) then
                    map4ID[bio2Int(cell.ID)] = cell;
                end;
                table.insert(list, cell);
            end;
            mdb[cfgPath] = list;
            mMaps4ID[cfgPath] = map4ID;
        else
            map4ID = mMaps4ID[cfgPath];
        end;
        return list, map4ID;
    end

    -- 取得角色的数据
    function CLLDBCfgTool.getRoleData(cfgRolePath, cfgRoleLevPath)
        local tmp, roleBaseData = CLLDBCfgTool.getDatas(cfgRolePath, true);
        local roleLevData = CLLDBCfgTool.getDatas(cfgRoleLevPath);
        local key = "";
        local gid = 0;
        local lev = 0;
        local heros = {};
        local monsters = {};

        list = {}
        for i, v in pairs(roleLevData) do
            gid = bio2Int(v.GID);
            lev = bio2Int(v.Lev);
            key = gid .. "_" .. lev;
            local m = {}
            m.base = roleBaseData[gid];
            m.vals = v;
            list[key] = m;
            if (lev == 1) then
                if (m.base.IsHero) then
                    table.insert(heros, m);
                else
                    table.insert(monsters, m);
                end
            end
        end
        list.heros = heros;
        list.monsters = monsters;

        return list;
    end

    -- 通用取得有base数据和lev数据的表
    function CLLDBCfgTool.pubGetBaseAndLevData(baseDataPath, levDataPath)
        local tmp, baseData = CLLDBCfgTool.getDatas(baseDataPath, true);
        local levData = CLLDBCfgTool.getDatas(levDataPath);
        local key = "";
        local gid = 0;
        local lev = 0;

        list = {}
        for i, v in pairs(levData) do
            gid = bio2Int(v.GID);
            lev = bio2Int(v.Lev);
            key = gid .. "_" .. lev;
            local m = {}
            m.base = baseData[gid];
            m.vals = v;
            list[key] = m;
        end
        return list;
    end

    return CLLDBCfgTool;
end

module("CLLDBCfgTool", package.seeall)
