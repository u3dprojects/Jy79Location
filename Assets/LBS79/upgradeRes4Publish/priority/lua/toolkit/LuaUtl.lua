--- lua工具方法
do
  -- Utl = luanet.import_type('Utl')
  -- Main = luanet.import_type('Main')
  local pnlShade = nil;

  function showHotWheel ( ... )
    if pnlShade == nil then
      pnlShade = CLPanelManager.getPanel ("PanelHotWheel");
    end
    local paras = {...};
    if(table.getn(paras) > 1) then
      local msg = paras[1];
      pnlShade:setData(msg);
    else
      pnlShade:setData("");
    end

    -- CLPanelManager.showPanel(pnlShade);
    pnlShade:show();
  end

  function hideHotWheel ( ... )
    if pnlShade == nil then
      pnlShade = CLPanelManager.getPanel ("PanelHotWheel");
    end
    -- CLPanelManager.hidePanel(pnlShade);
    local _func = pnlShade:getLuaFunction("hideSelf");
    if (type(_func) ~= "function") then
      _func = pnlShade.luaTable.hideSelf;
    end
    if (type(_func) == "function") then
      _func();
    end
  end

  function mapToColor ( map )
    local color = Color.white;
    if(map == nil) then return color end
    color = Color(
      MapEx.getNumber(map, "r"),
      MapEx.getNumber(map, "g"),
      MapEx.getNumber(map, "b"),
      MapEx.getNumber(map, "a")
    );
    return color;
  end

  function mapToVector2 ( map )
    local v = Vector2.zero;
    if(map == nil) then return v end
    v = Vector2(
      MapEx.getNumber(map, "x"),
      MapEx.getNumber(map, "y")
    );
    return v;
  end

  function mapToVector3 ( map )
    local v = Vector3.zero;
    if(map == nil) then return v end
    v = Vector3(
      MapEx.getNumber(map, "x"),
      MapEx.getNumber(map, "y"),
      MapEx.getNumber(map, "z")
    );
    return v;
  end

  function mapToVector4 ( map )
    local v = Vector4.zero;
    if(map == nil) then return v end
    v = Vector4(
      MapEx.getNumber(map, "x"),
      MapEx.getNumber(map, "y"),
      MapEx.getNumber(map, "z"),
      MapEx.getNumber(map, "w")
    );
    return v;
  end

  --  function getChild (root, ... )
  --    local args = {...};
  --    local tr = root;
  --    local count = table.getn(args);
  --    local i = 1
  --    while true do
  --      if(i > count) then break end
  --      if(tr == nil) then errMsg(args[i]); break; end
  --      tr = tr:FindChild(args[i]);
  --      i = i +1;
  --    end
  --    return tr;
  --  end

  function getChild(root, ...)
    local args = {... }
    local path = "";
    if(#args > 1) then
      local str =PStr.b();
      for i,v in ipairs(args) do
        str:a(v):a("/")
      end
      path = str:e();
    else
      path = args[1];
    end
    return root:Find(path);
  end

  --获取路径
  function stripfilename(filename)
    return string.match(filename, "(.+)/[^/]*%.%w+$") --*nix system
      --return string.match(filename, “(.+)\\[^\\]*%.%w+$”) — windows
  end
  --获取文件名
  function strippath(filename)
    return string.match(filename, ".+/([^/]*%.%w+)$") -- *nix system
      --return string.match(filename, “.+\\([^\\]*%.%w+)$”) — *nix system
  end
  --去除扩展名
  function stripextension(filename)
    local idx = filename:match(".+()%.%w+$")
    if(idx) then
      return filename:sub(1, idx-1)
    else
      return filename
    end
  end
  --获取扩展名
  function getextension(filename)
    return filename:match(".+%.(%w+)$")
  end
  function errMsg( msg )
    print("error:" .. msg);
  end
  function warnMsg( msg )
    print("warn:" .. msg);
  end

  function trim(s)
    return (s:gsub("^%s*(.-)%s*$", "%1"))
  end

  function startswith (str, substr)
    if str == nil or substr == nil then
      return nil, "the string or the sub-stirng parameter is nil"
    end
    if string.find(str, substr) ~= 1 then
      return false
    else
      return true
    end
  end

  -- 取得技能属性
  function getSkillAttr ( gid, lev)
    -- 取得属性
    return getSkillByGIDLev(gid, lev);
  end
  function getSkillByGIDLev ( gid, lev )
    return CLLDBCfg.getSkillByGIDAndLev(gid, lev);
  end

  -- 取得子弹属性
  function getBulletByID( id)
    local attr = nil;
    if (id > 0) then
      -- attr = Utl.callLuaFunc(Main.self.lua, "CLLDBCfg", "getBulletByID", id);
      -- attr = attr[0];
      return CLLDBCfg.getBulletByID(id);
    end
    return attr;
  end

  -- 取得物品属性
  function getPropByID( id )
    local attr = nil;
    if (id > 0) then
      -- attr = Utl.callLuaFunc(Main.self.lua, "CLLDBCfg", "getPropByID", id);
      -- attr = attr[0];
      return CLLDBCfg.getPropByID(id);
    end
    return attr;
  end

  -- 取得品级的图标
  function getGradeSprite(grade)
    if(grade == "D")then
      return "icon_idd";
    elseif(grade == "C") then
      return "icon_icc";
    elseif(grade == "B") then
      return "icon_ibb";
    elseif(grade == "A")then
      return "icon_iaa";
    elseif(grade == "S")then
      return "icon_iss";
    end
    return "";
  end

  -- 取得品级的颜色(绿:1，蓝:2,紫:3,橙:4,红:5)
  function getGradeColor ( grade )
    if(grade == 1) then
      return ColorEx.getColor(36,255,36);--Color.green;
    elseif(grade == 2) then
      return ColorEx.getColor(48,147,255); --Color.blue;
    elseif(grade == 3) then
      return ColorEx.getColor(255,56,250); --Color.magenta;
    elseif(grade == 4) then
      return ColorEx.getColor(255,80,0);
    elseif(grade == 5) then
      return ColorEx.getColor(255,35,35); --Color.red;
    else
      return ColorEx.getColor(255,248,0);
    end
  end

  -- 取得怪兽的prefab名称
  function getMonsterPrfabName ( gid )
    return "MD" .. NumEx.nStrForLen(gid, 3);
  end

  function getAction(act)
    if(act == "idel") then --,       //0 空闲
      return 0;
    elseif (act == "idel2") then--,      //1 空闲
      actionValue = 1;
    elseif (act == "walk") then--,     //2 走
      actionValue = 2;
    elseif (act == "run") then--,        //3 跑
      actionValue = 3;
    elseif (act == "jump") then--,     //4 跳
      actionValue = 4;
    elseif (act == "slide") then--,      //5 滑行，滚动，闪避
      actionValue = 5;
    elseif (act == "drop") then--,     //6 下落
      actionValue = 6;
    elseif (act == "attack") then--,     //7 攻击
      actionValue = 7;
    elseif (act == "attack2") then--,    //8 攻击2
      actionValue = 8;
    elseif (act == "skill") then--,        //9 技能
      actionValue = 9;
    elseif (act == "skill2") then--,     //10 技能2
      actionValue = 10;
    elseif (act == "skill3") then--,     //11 技能3
      actionValue = 11;
    elseif (act == "skill4") then--,     //12 技能4
      actionValue = 12;
    elseif (act == "hit") then--,        //13 受击
      actionValue = 13;
    elseif (act == "dead") then--,     //14 死亡
      actionValue = 14;
    elseif (act == "happy") then--,      //15 高兴
      actionValue = 15;
    elseif (act == "sad") then--,        //16 悲伤
      actionValue = 16;
    elseif (act == "up") then--,        //17 起立
      actionValue = 17;
    elseif (act == "down") then--,        //18 倒下
      actionValue = 18;
    elseif (act == "biggestAK") then--,        //19 最大的大招
      actionValue = 19;
    elseif (act == "dizzy") then--,        //20 晕
      actionValue = 20;
    elseif (act == "stiff") then--,        //21 僵硬
      actionValue = 21;
    elseif (act == "idel3") then--,        //21 空闲
      actionValue = 22;
    else
      actionValue = 0;
    end
    return actionValue;
  end

  function getMonster(mcidInt)
    return CLLData.getMonsterByMcid(mcidInt);
  end

  function strSplit(inputstr, sep)
    if sep == nil then
      sep = "%s"
    end
    local t={} ;
    local i=1
    for str in string.gmatch(inputstr, "([^"..sep.."]+)") do
      t[i] = str
      i = i + 1
    end
    return t;
  end

  -- 取得方法体
  function getLuaFunc(trace)
    if(trace == nil) then return nil end
    local list = strSplit(trace, ".");
    local func = nil;
    if(list ~= nil) then
      func = _G;
      for i,v in ipairs(list) do
        func = func[v];
      end
    end
    return func;
  end

  -- 动作回调toMap
  function ActCBtoList( ... )
    local paras = {...};
    if(table.getn( paras ) > 0) then
      local callbackInfor = ArrayList();
      for i,v in ipairs(paras) do
        callbackInfor:Add(v);
      end
      return callbackInfor;
    end
    return nil;
  end

  function NewColor( r,g,b,a )
    return Color.New(r/255, g/255, b/255, a/255);
  end

  function onLoadedPanel( p , paras)
    p:setData(paras);
    CLPanelManager.showTopPanel(p);
  end

  function onLoadedPanelTT( p , paras)
    p:setData(paras);
    CLPanelManager.showTopPanel(p, true, true);
  end

  function hideTopPanelExcept(p)
    CLPanelManager.hideAllPanel();
    CLPanelManager.showTopPanel(p);
  end

  function obj2String(obj)
    local luatype = type(obj)
    if luatype == 'userdata' then
      if obj.GetClassType == nil then
        return '['.. luatype .. ']' .. tostring(obj)
      else
        local ctype = obj:GetClassType()
        if type(obj.name) == 'string' then
          return '['.. ctype.FullName .. '|' .. obj.name .. ']' .. tostring(obj)
        end
        return '['.. ctype.FullName .. ']' .. tostring(obj)
      end
    else
      return '['.. luatype .. ']' .. tostring(obj)
    end
  end

  function printt(msg)
    print(traceback(msg))
  end

  function concatText(...)
    local t = {...}
    return table.concat(t) .. '\n'
  end

  function printTabStr(data)
    local txt = ''
    txt = txt .. concatText(' --------------------- ', tostring(data), ' : ')
    if data then
      if type(data)=='table' then
        for k, v in pairs(data or {}) do
          if k == 'table' then
            txt = txt .. concatText(k)
            txt = txt .. concatText('       :', v)
          else
            txt = txt .. concatText(string.format('%15s', k), ' [', type(v), ']:', tostring(v) )
          end
        end
      else
        txt = txt .. concatText('type:', type(data) )
      end
    end
    txt = txt .. concatText(' --------------------- ')
    print(txt)
  end

  -- 摄像机目标处理
  TargetTweenHelper = {
    listener = require('CLLClickListener').New(),
  }

  function TargetTweenHelper:bindEndFunc(endfunc, obj, param)
    -- 视点对齐处理
    local tp = self.viewpointTP
    if tp == nil then
      local lt = SCfg.self.mLookatTarget
      tp = lt:GetComponent('TweenPosition')
      self.viewpointTP = tp
    end
    self.listener:regsiterTweenerFinished(tp, endfunc, obj, param )
    return tp
  end

  function TargetTweenHelper:unbindEndFunc()
    local tp = self.viewpointTP
    if tp ~= nil then
      self.listener:unregsiterTweener(tp)
      self.viewpointTP = nil
    end
  end

end

module("LuaUtl",package.seeall)
