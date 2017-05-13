--- - 管理数据配置
do
    require("CLLDBCfgTool")
    local bio2Int = NumEx.bio2Int;
    local int2Bio = NumEx.int2Bio;
    local db = {} -- 经过处理后的数据
    -- 数据的路径
    local upgradeRes = "/upgradeRes"
    if (SCfg.self.isEditMode) then
        upgradeRes = "/upgradeRes4Publish";
    end;
    local priorityPath = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(PathCfg.self.basePath):a(upgradeRes):a("/priority/"):e();
    local cfgBasePath = PStr.b():a(priorityPath):a("cfg/"):e();

    -- 全局变量定义
    local cfgCfgPath = PStr.b():a(cfgBasePath):a("DBCFCfgData.cfg"):e();
    -- 角色
    local cfgRolePath = PStr.b():a(cfgBasePath):a("DBCFRoleData.cfg"):e();
    local cfgRoleLevPath = PStr.b():a(cfgBasePath):a("DBCFRoleLevData.cfg"):e();
    -- 道具
    local cfgPropPath = PStr.b():a(cfgBasePath):a("DBCFPropData.cfg"):e();


    CLLDBCfg = {};

    -- 取得数据列表
    function CLLDBCfg.getData(path)
        local dbMap = db[path];
        if (dbMap == nil) then
            if (path == cfgRolePath) then
                dbMap = CLLDBCfgTool.getRoleData(cfgRolePath, cfgRoleLevPath);
            elseif (path == cfgSkillPath) then
                dbMap = CLLDBCfgTool.pubGetBaseAndLevData(cfgSkillPath, cfgSkillLevPath);
            else -- 其它没有特殊处理的都以ID为key（因些在配置数据时，ID列必须是以1开始且连续）
            local tmp = nil;
            tmp, dbMap = CLLDBCfgTool.getDatas(path, true);
            end;
            db[path] = dbMap;
        end;
        return dbMap;
    end

    -- 取得常量配置
    function CLLDBCfg.getConstCfg(...)
        local datas = CLLDBCfg.getData(cfgCfgPath);
        if (datas == nil) then return nil end;
        return datas[1];
    end

    -- 常量配置
    GConstCfg = CLLDBCfg.getConstCfg();

    -- 取得子弹属性
    function CLLDBCfg.getStuffByID(id)
        local datas = CLLDBCfg.getData(cfgStuffPath);
        if (datas == nil) then return nil end;
        return datas[id];
    end

    -- 取得角色属性
    function CLLDBCfg.getRoleByGIDAndLev(gid, lev)
        local datas = CLLDBCfg.getData(cfgRolePath);
        if (datas == nil) then return nil end;
        local key = gid .. "_" .. lev;
        return datas[key];
    end

    -- 取得主角列表
    function CLLDBCfg.getHeros()
        local datas = CLLDBCfg.getData(cfgRolePath);
        return datas.heros;
    end

    -- 取得怪列表
    function CLLDBCfg.getMonsters()
        local datas = CLLDBCfg.getData(cfgRolePath);
        return datas.monsters;
    end

    -- 取得道具
    function CLLDBCfg.getPropByID(id)
        local datas = CLLDBCfg.getData(cfgPropPath);
        if (datas == nil) then return nil end;
        return datas[id];
    end
    --------------------------------------------------
    return CLLDBCfg;
end;

module("CLLDBCfg", package.seeall)
