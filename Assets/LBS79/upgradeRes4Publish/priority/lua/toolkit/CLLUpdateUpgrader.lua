-- 更新热更器处理
do
  local Path = luanet.import_type('System.IO.Path');
  local Directory = luanet.import_type('System.IO.Directory');
  -- local FileEx = luanet.import_type('Toolkit.FileEx')

  local localVer = Hashtable();
  local serverVer = Hashtable();
  local serverVerStr = "";
  local upgraderVer = "upgraderVer.json"; -- 热更新器的版本
  local localVerPath = upgraderVer; -- PStr.begin():a(PathCfg.self.basePath):a("/"):a (upgraderVer):e ();
  local upgraderName = PStr.b():a(PathCfg.self.basePath):a ("/upgradeRes/priority/lua/toolkit/CLLVerManager.lua"):e ();
  local channelName = "channels.txt"; -- 控制渠道更新的
  local finishCallback = nil; -- finishCallback(isHaveUpdated)

  local isUpdatedUpgrader = false; -- 是否更新的热更新器
  ----------------------------------
  CLLUpdateUpgrader = {};
  function CLLUpdateUpgrader.checkUpgrader( ifinishCallback )
    isUpdatedUpgrader = false;
    finishCallback = ifinishCallback;
    CLVerManager.self:StartCoroutine(FileEx.readNewAllText(localVerPath, CLLUpdateUpgrader.onGetLocalUpgraderVer));
  end;

  function CLLUpdateUpgrader.onGetLocalUpgraderVer( content )
    localVer = JSON.DecodeMap(content);
    localVer = localVer == nil and Hashtable() or localVer;
    local url = PStr.b():a(CLVerManager.self.baseUrl):a("/"):a(upgraderVer):e();
    url = Utl.urlAddTimes(url);

    WWWEx.newWWW(CLVerManager.self, url, CLAssetType.text,
      3, 3, CLLUpdateUpgrader.onGetServerUpgraderVer,
      CLLUpdateUpgrader.onGetServerUpgraderVer,
      CLLUpdateUpgrader.onGetServerUpgraderVer, nil);
  end;

  function CLLUpdateUpgrader.onGetServerUpgraderVer( content, orgs )
    serverVerStr = content;
    serverVer = JSON.DecodeMap(content);
    serverVer = serverVer == nil and Hashtable() or serverVer;
    -- print("MapEx.getInt(localVer, upgraderVer)==" .. MapEx.getInt(localVer, "upgraderVer"))
    -- print("MapEx.getInt(serverVer, upgraderVer)==" .. MapEx.getInt(serverVer, "upgraderVer"))
    if(MapEx.getInt(localVer, "upgraderVer") < MapEx.getInt(serverVer, "upgraderVer")) then
      CLLUpdateUpgrader.updateUpgrader();
    else
      CLLUpdateUpgrader.checkChannelVer(false);
    end;
  end;

  function CLLUpdateUpgrader.updateUpgrader( ... )
    local url = "";
    local verVal = MapEx.getInt(serverVer, "upgraderVer");
    if(verVal > 0) then
      url = PStr.b():a(CLVerManager.self.baseUrl):a("/"):a(upgraderName):a("."):a(verVal):e ();
    else
      url = PStr.b():a(CLVerManager.self.baseUrl):a("/"):a(upgraderName):e ();
    end;
    WWWEx.newWWW(CLVerManager.self, url, CLAssetType.bytes,
      3, 5, CLLUpdateUpgrader.ongetNewestUpgrader,
      CLLUpdateUpgrader.ongetNewestUpgrader,
      CLLUpdateUpgrader.ongetNewestUpgrader, upgraderName);
  end;

  function CLLUpdateUpgrader.ongetNewestUpgrader( content, orgs )
    if(content ~= nil) then
      local file = PStr.begin ():a (PathCfg.persistentDataPath):a ("/"):a (upgraderName):e ();
      Directory.CreateDirectory (Path.GetDirectoryName (file));
      File.WriteAllBytes (file, content);

      file = PStr.begin ():a (PathCfg.persistentDataPath):a ("/"):a (localVerPath):e ();
      File.WriteAllText (file, serverVerStr);

      CLLUpdateUpgrader.checkChannelVer( true );
    else
      CLLUpdateUpgrader.checkChannelVer( false );
    end;
  end;

  -- 取得最新的渠道更新控制信息
  function CLLUpdateUpgrader.checkChannelVer( hadUpdatedUpgrader )
    isUpdatedUpgrader = hadUpdatedUpgrader;

    if(MapEx.getInt(localVer, "channelVer") < MapEx.getInt(serverVer, "channelVer")) then
      CLLUpdateUpgrader.getChannelInfor();
    else
      if(finishCallback ~= nil) then
        finishCallback(isUpdatedUpgrader);
      end;
    end;
  end;

  function CLLUpdateUpgrader.getChannelInfor( ... )
    local verVal = MapEx.getInt(serverVer, "channelVer");
    local url = PStr.b():a(CLVerManager.self.baseUrl):a("/"):a(channelName):a("."):a(verVal):e(); -- 注意是加了版本号的，会使用cdn
    WWWEx.newWWW(CLVerManager.self, url, CLAssetType.text,
      3, 5, CLLUpdateUpgrader.onGetChannelInfor,
      CLLUpdateUpgrader.onGetChannelInfor,
      CLLUpdateUpgrader.onGetChannelInfor, channelName);
  end;

  function CLLUpdateUpgrader.onGetChannelInfor( content, orgs )
    if(content ~= nil) then
      local file = PStr.b():a(PathCfg.persistentDataPath):a ("/"):a (channelName):e();
      Directory.CreateDirectory (Path.GetDirectoryName (file));
      File.WriteAllText(file, content);
    end;

    if(finishCallback ~= nil) then
      finishCallback(isUpdatedUpgrader);
    end;
  end;
end

module("CLLUpdateUpgrader",package.seeall)
