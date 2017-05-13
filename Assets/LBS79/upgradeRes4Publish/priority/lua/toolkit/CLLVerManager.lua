-- 资源更新器
do
  -- local FileEx = luanet.import_type('Toolkit.FileEx')
  local Path = luanet.import_type('System.IO.Path');
  local Directory = luanet.import_type('System.IO.Directory');
  local MemoryStream = luanet.import_type('System.IO.MemoryStream');
  local B2OutputStream = luanet.import_type('Toolkit.B2OutputStream')

  -- 服务器
  local baseUrl = CLVerManager.self.baseUrl; --"http://gamesres.ultralisk.cn/cdn/test";
  local platform = "";
  local newestVerPath = "newestVers";
  local resVer = "resVer";
  local versPath = "VerCtl";
  local fverVer = "VerCtl.ver";   --本地所有版本的版本信息
  local localverVer = Hashtable ();
  local serververVer = Hashtable ();
  --========================
  local verPriority = "priority.ver";
  local localPriorityVer = Hashtable ();  --本地优先更新资源
  local serverPriorityVer = Hashtable (); --服务器优先更新资源

  local verOthers = "other.ver";
  local otherResVerOld = Hashtable (); --所有资源的版本管理
  local otherResVerNew = Hashtable (); --所有资源的版本管理

  local tmpUpgradePirorityPath = "tmpUpgrade4Pirority";
  local haveUpgrade = false;
  local is2GNetUpgrade = CLVerManager.self.is2GNetUpgrade;
  local is3GNetUpgrade = CLVerManager.self.is3GNetUpgrade;
  local is4GNetUpgrade = CLVerManager.self.is4GNetUpgrade;

  local onFinishInit = nil;
  local progressCallback = nil;
  local mVerverPath = "";
  local mVerPrioriPath = "";
  local mVerOtherPath = "";

  local needUpgradeVerver = Hashtable ();
  local progress = 0;

  local isNeedUpgradePriority = false;
  local needUpgradePrioritis = Queue();
  local isSucessUpgraded = false;

  CLLVerManager = {};

  -- 更新初始化
  --[[
    iprogressCallback: 进度回调，回调有两个参数
    ifinishCallback: 完成回调
    isdoUpgrade: 是否做更新处理
    --]]
  function CLLVerManager.init( iprogressCallback,  ifinishCallback, isdoUpgrade)
    haveUpgrade = false;
    CLVerManager.self.haveUpgrade = false;
    isNeedUpgradePriority = false;
    localverVer:Clear ();
    serververVer:Clear ();
    localPriorityVer:Clear ();
    serverPriorityVer:Clear ();
    otherResVerOld:Clear ();
    otherResVerNew:Clear ();
    platform = PathCfg.self.platform;
    CLVerManager.self.platform = platform;

    mVerverPath = PStr.begin ():a (PathCfg.self.basePath):a ("/"):a (resVer):a ("/"):a (platform):a ("/"):a (fverVer):e ();
    mVerPrioriPath = PStr.begin ():a (PathCfg.self.basePath):a ("/"):a (resVer):a ("/"):a (platform):a ("/"):a (versPath):a ("/"):a (verPriority):e ();
    mVerOtherPath = PStr.begin ():a (PathCfg.self.basePath):a ("/"):a (resVer):a ("/"):a (platform):a ("/"):a (versPath):a ("/"):a (verOthers):e ();
    CLVerManager.self.mVerverPath = mVerverPath;
    CLVerManager.self.mVerPrioriPath = mVerPrioriPath;
    CLVerManager.self.mVerOtherPath = mVerOtherPath;

    progressCallback = iprogressCallback;
    onFinishInit = ifinishCallback;

    if(not isdoUpgrade) then
      CLLVerManager.loadPriorityVer ();
      CLLVerManager.loadOtherResVer (false);
      return;
    end;
    --[[*
        ///     None 无网络
        ///     WiFi
        ///     2G
        ///     3G
        ///     4G
        ///     Unknown
        */
        --]]
    local netState = Utl.getNetState();
    local netActived = true;
    if(netState == "None") then
      netActived = false;
    elseif(netState == "2G") then
      if(not is2GNetUpgrade) then
        netActived = false;
      end;
    elseif(netState == "3G") then
      if(not is3GNetUpgrade) then
        netActived = false;
      end;
    elseif(netState == "4G") then
      if(not is4GNetUpgrade) then
        netActived = false;
      end;
    elseif(netState == "Unknown") then
      netActived = true;
    end;

    local canDoUpgrade = false;
    if(platform == "Android") then
      if (not SCfg.self.isEditMode and netActived) then
        canDoUpgrade = true;
      end;
    else
      if (not SCfg.self.isEditMode and Utl.netIsActived()) then
        canDoUpgrade = true;
      end;
    end;
    if(canDoUpgrade) then
      CLLVerManager.netWorkActived ();
    else
      -- 说明是编辑器环境
      if (onFinishInit ~= nil) then
        onFinishInit(true);
      end;
    end;
  end;

  -- 验证网络是否可用
  function CLLVerManager.netWorkActived ()
    local url = Utl.urlAddTimes(baseUrl .. "/netState.txt");
    WWWEx.newWWW(CLVerManager.self, url, CLAssetType.text,
      5, 5, CLLVerManager.onCheckNetSateSuc,
      CLLVerManager.onCheckNetSateFail,
      CLLVerManager.onCheckNetSateFail, nil);
  end;

  function CLLVerManager.onCheckNetSateSuc ( ... )
    CLVerManager.self:StartCoroutine (FileEx.readNewAllBytes (mVerverPath,
      CLLVerManager.onGetlcalVerverMap));
  end;

  function CLLVerManager.onCheckNetSateFail( ... )
    LuaUtl.warnMsg ("Cannot connect Server or Net !!!");
    -- NAlertTxt.add ("Cannot connect Server or Net !!!", Color.yellow, 1);
    CLLVerManager.loadPriorityVer ();
    CLLVerManager.loadOtherResVer (false);
  end;

  --[[
    /// <summary>
    /// Ons the get verver map.取得本地版本文件的版本信息
    /// </summary>
    /// <param name='buff'>
    /// Buff.
    /// </param>
    --]]
  function CLLVerManager.onGetlcalVerverMap (buff)
    if (buff ~= nil) then
      localverVer = CLVerManager.self:toMap (buff);
    else
      localverVer = Hashtable ();
    end;
    CLLVerManager.getServerVerverMap ();
  end;

  --[[
    /// <summary>
    /// Gets the server verver map.取得服务器版本文件的版本信息
    /// </summary>
    --]]
  function CLLVerManager.getServerVerverMap( ... )
    local url = PStr.begin():a(baseUrl):a("/"):a(mVerverPath):e();

    WWWEx.newWWW(CLVerManager.self, Utl.urlAddTimes(url),
      CLAssetType.bytes,
      3, 5, CLLVerManager.onGetServerVerverBuff,
      CLLVerManager.onGetServerVerverBuff,
      CLLVerManager.onGetServerVerverBuff, nil);
  end;

  function CLLVerManager.onGetServerVerverBuff( content, orgs )
    if (content ~= nil) then
      serververVer = CLVerManager.self:toMap (content);
    else
      serververVer = Hashtable ();
    end;
    --判断哪些版本控制信息需要更新
    CLLVerManager.checkVervers ();
  end;

  function CLLVerManager.checkVervers ()
    progress = 0;
    needUpgradeVerver:Clear ();
    isNeedUpgradePriority = false;
    local ver = nil;
    local keysList = MapEx.keys2List(serververVer);
    local count = keysList.Count;
    local key = "";
    for i=0,count-1 do
      key = keysList:get_Item(i);
      ver = localverVer:get_Item(key);
      if (ver == nil or ver < serververVer:get_Item(key)) then
        needUpgradeVerver:set_Item(key, false);
      end;
    end;
    keysList:Clear();
    keysList = nil;

    if (needUpgradeVerver.Count > 0) then
      if (progressCallback ~= nil) then
        progressCallback(needUpgradeVerver.Count, 0);
      end;

      keysList = MapEx.keys2List(needUpgradeVerver);
      count = keysList.Count;
      key = "";
      for i=0,count-1 do
        key = keysList:get_Item(i);
        CLLVerManager.getVerinfor(key, serververVer:get_Item(key));
      end;
      keysList:Clear();
      keysList = nil;
    else
      CLLVerManager.loadPriorityVer ();
      CLLVerManager.loadOtherResVer (true);
    end;
  end;

  -- 取得版本文件
  function CLLVerManager.getVerinfor (fPath, verVal)
    local url = PStr.b():a(baseUrl):a("/"):a(fPath):a("."):a(verVal):e(); -- 注意是加了版本号的，可以使用cdn
    WWWEx.newWWW(CLVerManager.self,
      url, CLAssetType.bytes,
      3, 9, CLLVerManager.onGetVerinfor,
      CLLVerManager.onGetVerinfor,
      CLLVerManager.onGetVerinfor, fPath);
  end;

  function CLLVerManager.onGetVerinfor( content, orgs )
    if (content ~= nil) then
      local fPath = orgs;
      progress = progress + 1;
      localverVer:set_Item(fPath, serververVer:get_Item(fPath));

      local fName = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(newestVerPath):a("/"):a(fPath):e();
      if (Path.GetFileName(fName) == "priority.ver") then     -- 优先更新需要把所有资源更新完后才记录
        isNeedUpgradePriority = true;
        serverPriorityVer = CLVerManager.self:toMap (content);

      else
        Directory.CreateDirectory (Path.GetDirectoryName (fName));
        File.WriteAllBytes (fName, content);
      end;

      needUpgradeVerver:set_Item(fPath, true);

      if (progressCallback ~= nil) then
        progressCallback(needUpgradeVerver.Count, progress);
      end;

      -- if (isFinishAllGet ()) then
      if(needUpgradeVerver.Count == progress) then
        if (not isNeedUpgradePriority) then
          -- 说明没有优先资源需要更新，刚可以不做其它处理了
          --同步到本地
          local ms = MemoryStream();
          B2OutputStream.writeMap(ms, localverVer);
          local vpath = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(mVerverPath):e();
          Directory.CreateDirectory(Path.GetDirectoryName (vpath));
          File.WriteAllBytes (vpath, ms:ToArray());

          CLLVerManager.loadPriorityVer();
          CLLVerManager.loadOtherResVer(true);
        else
          CLLVerManager.checkPriority();   --处理优先资源更新
        end;
      end;
    else
      CLLVerManager.initFailed ();
    end;
  end;


  function CLLVerManager.checkPriority ()
    --取得本地优先更新资源版本信息
    CLVerManager.self:StartCoroutine (
      FileEx.readNewAllBytes (mVerPrioriPath,
        CLLVerManager.onGetNewPriorityMap)
    );
  end;

  function CLLVerManager.onGetNewPriorityMap (buff)
    if (buff ~= nil) then
      localPriorityVer = CLVerManager.self:toMap (buff);
    else
      localPriorityVer = Hashtable ();
    end;
    CLVerManager.self.localPriorityVer = localPriorityVer; -- 同步到c#

    progress = 0;
    needUpgradeVerver:Clear ();
    needUpgradePrioritis:Clear ();
    local ver = nil;
    local keysList = MapEx.keys2List(serverPriorityVer);
    local key = nil;
    local count = keysList.Count;
    for i=0,count-1 do
      key = keysList:get_Item(i);
      ver = localPriorityVer:get_Item(key);
      if (ver == nil or NumEx.stringToInt (ver) < MapEx.getInt(serverPriorityVer, key)) then
        needUpgradeVerver:set_Item(key, false);
        needUpgradePrioritis:Enqueue (key);
      end;
    end;
    keysList:Clear();
    keysList = nil;

    if (needUpgradePrioritis.Count > 0) then
      haveUpgrade = true;
      CLVerManager.self.haveUpgrade = true;
      if (progressCallback ~= nil) then
        progressCallback(needUpgradeVerver.Count, 0);
      end;
      CLLVerManager.getPriorityFiles (needUpgradePrioritis:Dequeue());
    else
      --同步总的版本管理文件到本地
      local ms = MemoryStream ();
      B2OutputStream.writeMap (ms, localverVer);
      local vpath = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(mVerverPath):e();
      Directory.CreateDirectory (Path.GetDirectoryName (vpath));
      File.WriteAllBytes (vpath, ms:ToArray ());

      CLLVerManager.loadOtherResVer (true);
    end;
  end;

  -- 取得优先更新的资源
  function CLLVerManager.getPriorityFiles (fPath)
    local Url = "";
    local verVal = MapEx.getInt (serverPriorityVer, fPath);
    if (verVal > 0) then
      Url = PStr.begin ():a (baseUrl):a ("/"):a (fPath):a ("."):a (verVal):e (); -- 把版本号拼在后面
    else
      Url = PStr.begin ():a (baseUrl):a ("/"):a (fPath):e ();
    end;
    -- print("Url==" .. Url);

    WWWEx.newWWW(CLVerManager.self,
      Url, CLAssetType.bytes,
      3, 0, CLLVerManager.onGetPriorityFiles,
      CLLVerManager.initFailed,
      CLLVerManager.initFailed, fPath);

    if (progressCallback ~= nil) then
      progressCallback(needUpgradeVerver.Count, progress, WWWEx.getWwwByUrl(Url));
    end;
  end;

  function CLLVerManager.onGetPriorityFiles(content, orgs)
    if (content == nil) then
      CLLVerManager.initFailed();
      return;
    end;

    local fPath = orgs;
    progress = progress + 1;
    -- 先把文件放在tmp目录，等全部下载好后再移到正式目录
    local fName = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(tmpUpgradePirorityPath):a("/"):a(fPath):e();
    Directory.CreateDirectory (Path.GetDirectoryName (fName));
    File.WriteAllBytes (fName, content);

    --同步到本地
    localPriorityVer:set_Item(fPath, serverPriorityVer:get_Item(fPath));
    needUpgradeVerver:set_Item(fPath, true);
    CLVerManager.self.localPriorityVer = localPriorityVer;

    if (progressCallback ~= nil) then
      progressCallback(needUpgradeVerver.Count, progress);
    end;

    if (needUpgradePrioritis.Count > 0) then
      CLLVerManager.getPriorityFiles (needUpgradePrioritis:Dequeue ());
    else
      --已经把所有资源取得完成
      -- 先把文件放在tmp目录，等全部下载好后再移到正式目录
      local keysList = MapEx.keys2List(needUpgradeVerver);
      local count =  keysList.Count;
      local key = nil;
      local fromFile = "";
      local toFile = "";
      for i=0,count-1 do
        key = keysList:get_Item(i);
        fromFile = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(tmpUpgradePirorityPath):a("/"):a(key):e();
        toFile = PStr.begin():a(PathCfg.persistentDataPath):a("/"):a(key):e();
        Directory.CreateDirectory(Path.GetDirectoryName(toFile));
        File.Copy(fromFile, toFile, true);
      end;
      Directory.Delete(PStr.b():a(PathCfg.persistentDataPath):a("/"):a(tmpUpgradePirorityPath):e(), true);
      keysList:Clear();
      keysList = nil;

      --同步优先资源更新的版本管理文件到本地
      local ms = MemoryStream();
      B2OutputStream.writeMap(ms, localPriorityVer);
      local vpath = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(mVerPrioriPath):e();
      Directory.CreateDirectory(Path.GetDirectoryName(vpath));
      File.WriteAllBytes(vpath, ms:ToArray ());

      --同步总的版本管理文件到本地
      ms = MemoryStream();
      B2OutputStream.writeMap (ms, localverVer);
      vpath = PStr.b():a(PathCfg.persistentDataPath):a("/"):a(mVerverPath):e();
      Directory.CreateDirectory(Path.GetDirectoryName(vpath));
      File.WriteAllBytes(vpath, ms:ToArray ());

      CLLVerManager.loadOtherResVer (true);
    end;
  end;


  function CLLVerManager.loadPriorityVer ()
    CLVerManager.self:StartCoroutine (FileEx.readNewAllBytes (mVerPrioriPath, CLLVerManager.onGetVerPriority));
  end;

  function CLLVerManager.onGetVerPriority (buff)
    if (buff ~= nil) then
      localPriorityVer = CLVerManager.self:toMap (buff);
    else
      localPriorityVer = Hashtable ();
    end;
    CLVerManager.self.localPriorityVer = localPriorityVer;
  end;

  function CLLVerManager.loadOtherResVer (sucessProcUpgrade)
    isSucessUpgraded = sucessProcUpgrade;
    CLVerManager.self:StartCoroutine (FileEx.readNewAllBytes (mVerOtherPath, CLLVerManager.onGetVerOther));
  end;

  function CLLVerManager.onGetVerOther (buff)
    if (buff ~= nil) then
      otherResVerOld = CLVerManager.self:toMap (buff);
    else
      otherResVerOld = Hashtable ();
    end;
    CLVerManager.self.otherResVerOld = otherResVerOld;
    local path = PStr.b():a(newestVerPath):a("/"):a(mVerOtherPath):e();
    CLVerManager.self:StartCoroutine (FileEx.readNewAllBytes (path, CLLVerManager.onGetNewVerOthers));
  end;

  function CLLVerManager.onGetNewVerOthers (buff)
    if (buff ~= nil) then
      otherResVerNew = CLVerManager.self:toMap (buff);
    else
      otherResVerNew = Hashtable ();
    end;
    CLVerManager.self.otherResVerNew = otherResVerNew;

    progressCallback = nil;
    if (onFinishInit ~= nil) then
      onFinishInit(isSucessUpgraded);
    end;
  end;

  function CLLVerManager.initFailed (...)
    if (progressCallback ~= nil) then
      progressCallback(needUpgradeVerver.Count, progress, nil);
    end;
    CLLVerManager.loadPriorityVer ();
    CLLVerManager.loadOtherResVer (false);
    LuaUtl.warnMsg ("initFailed");
  end;

  function CLLVerManager.isHaveUpgrade( ... )
    return haveUpgrade;
  end;

  return CLLVerManager;
end

module("CLLVerManager",package.seeall)
