---3GU
-- author : canyon
-- time : 2014-11-25
do
  require("CLLDBCfg");
  -- 第三方函数的local变量
  local setActive = NGUITools.SetActive;
  local getRoleAttr = CLLDBCfg.getRoleByGIDAndLev;--取得角色的属性
  -- 界面元素对象

  -- 属性值变量
  local parList = ArrayList(); --list集合里面套用Hashtable(map),map[gid,lev]
  local gidMap = Hashtable();
  local curNumLoad,maxNumLoad = 0,0;
  local excFun = nil;
  local actFun = nil; -- 播放动画结束后回调函数

  LoadPreRole = {};

  -- 初始化对象
  function LoadPreRole.init(pars,loadAll)
    if pars == nil or pars.Count == nil or pars.Count == 0 then
      return false;
    end;

    curNumLoad = 0;
    maxNumLoad = pars.Count;
    excFun = loadAll;
    parList:Clear();
    gidMap:Clear();
    return true;
  end;

  --初始化对象，并进行内存加载的判断
  function LoadPreRole.initList(pars,loadAll)
    local there = LoadPreRole;
    if not there.init(pars,loadAll) then
      loadAll();
      return ;
    end;

    for i = 0,maxNumLoad - 1 do
      local map = pars[i];
      local gid = map["gid"];
      if type(gid) == "number" then
        if gidMap[gid] == nil then
          gidMap[gid] = true;
          parList:Add(map);
        end;
      end
    end;

    maxNumLoad = parList.Count;
    there.loadRole();
  end;

  function LoadPreRole.initMap(pars,loadAll)
    local there = LoadPreRole;
    if not there.init(pars,loadAll) then
      loadAll();
      return ;
    end;
    maxNumLoad = 1;
    there.loadRoleByMap(pars);
  end;

  -- 释放还原role的prefab对象
  function LoadPreRole.releaseRole( role )
    if(role ~= nil) then
      setActive(role.gameObject, false);
      role.transform.parent = nil;
      role.transform.localPosition = Vector3.zero;
      role.transform.localEulerAngles = Vector3.zero;
      role.transform.localScale = Vector3.one;
      -- if(role.rigidbody ~= nil) then
      --   role.rigidbody.isKinematic = false;
      -- end;
      CLRolePool.returnUnit(role);
    end;
  end;

  -- 加载英雄模型
  function LoadPreRole.loadRole()
    if maxNumLoad == 0 then
      return;
    end;
    local there = LoadPreRole;
    for i = 0,maxNumLoad - 1 do
      local map = parList[i];
      there.loadRoleByMap(map);
    end;
  end;

  -- 加载英雄模型
  function LoadPreRole.loadRoleByMap(map)
    if map == nil or map["gid"] == nil then
      return;
    end;

    local there = LoadPreRole;
    local gid = map["gid"];
    local lev = map["lev"];
    local star = map["star"];
    lev = lev == nil and 1 or lev;
    star = star == nil and 1 or star;
    local attr = getRoleAttr(gid, lev);
    if attr ~= nil then
      local name = attr.base.PrefabName;
      if (CLRolePool.havePrefab(name) == false) then
        CLRolePool.setPrefab(name,there.onSetRolePrab);
      else
        there.onLoadPre(name);
      end;
    end;
  end;

  -- 加载
  function LoadPreRole.onLoadPre( name )
    curNumLoad = curNumLoad + 1;
    if(curNumLoad >= maxNumLoad) then
      local there = LoadPreRole;
      there.loadAllFinish();
    end;
  end;

  -- 加载英雄模型(到内存) -- 成功后回调
  function LoadPreRole.onSetRolePrab( obj )
    local there = LoadPreRole;
    there.onLoadPre(obj.name);
  end;

  -- 全部加载成功
  function LoadPreRole.loadAllFinish()
    if excFun ~= nil then
      excFun();
    end;
  end;

  -- 主要英雄的静止时候的动作Action
  function LoadPreRole.actIdelMain(rolePrefab,index,funExc)
    if rolePrefab == nil then
      return 0;
    end
    local idels = {"idel2","idel3", "attack", "skill", "skill2", "skill3", "skill4"};
    if index ==nil then
      index = NumEx.NextInt(1,table.getn(idels));
    else
      index = index + 1;
      index = index % 7;
      if index == 0 then
        index = 7;
      end;
    end;
    actFun = funExc;
    local v = idels[index];
    local av = LuaUtl.getAction(v);
    --rolePrefab:setAction(v);
    -- rolePrefab.roleAction:setAction(av,LoadPreRole.actEndFun);
    rolePrefab:playAction(av, LoadPreRole.actEndFun);
    return index;
  end;

  -- 小伙伴的静止时候的动作Action
  function LoadPreRole.actIdelPartner(rolePrefab,index,funExc)
    if rolePrefab == nil then
      return 0;
    end
    local idels = {"attack","skill"};
    if index ==nil then
      index = NumEx.NextInt(1,3);
    else
      index = index + 1;
      index = index % 2;
      if index == 0 then
        index = 2;
      end;
    end;
    actFun = funExc;
    local v = idels[index];
    local av = LuaUtl.getAction(v);
    -- rolePrefab.roleAction:setAction(av,LoadPreRole.actEndFun);
    rolePrefab:playAction(av, LoadPreRole.actEndFun);
    return index;
  end;

  -- 动作播放完回调函数
  function LoadPreRole.actEndFun(action)
    if action ~= nil then
      action:setAction(LuaUtl.getAction("idel"),nil);
    end;
    if actFun ~= nil then
      actFun(action);
    end;
  end;

  -- 播放效果(播放完成回调
  function LoadPreRole.playEffect(effect_name,pos,callBack)
    if type(effect_name) ~= "string" then
      return;
    end;
    local loadFinish = function()
      SEffect.play(effect_name,pos,callBack,nil);
    end;
    SEffectPool.setPrefab(effect_name,loadFinish);
  end;
end;

-- module的名字必须和文件名字一样
module("LoadPreRole",package.seeall);
