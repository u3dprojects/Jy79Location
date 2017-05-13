-- 场景
do
    CLLScene = {}

    local csSelf = nil;
    local transform = nil;
    -- 当在图增加n列后，切换地图的风格
    local SwitchMapStyleLen = 15;
    local oldSwitchMapeStep = 0;

    local mapSizeX = 0;
    local mapSizeY = 0;
    local sideLeft = 0;
    local sideRight = 0;
    local MAX_Length = 30;
    local currTerrain = nil;
    local creatureCount = 0;
    local spin;
    local tiles = {};

    -- 初始化，只会调用一次
    function CLLScene.init(csObj)
        csSelf = csObj;
        transform = csObj.transform;
        spin = transform:GetComponent("Spin");
        spin.enabled = false;
    end

    -- 加载无限地图
    function CLLScene.loadInfiniteMap(x, y, speed, tileTimeout, defalutTerrainIndex, onFinishLoadMap)
        if (defalutTerrainIndex == nil) then
            defalutTerrainIndex = -1;
        end
        mapSizeX = x;
        mapSizeY = y;
        sideLeft = 0;
        sideRight = 0;
        if (defalutTerrainIndex < 0) then
            currTerrain = csSelf.terrainInfor[NumEx.NextInt(0, csSelf.terrainInfor.Count)];
        else
            currTerrain = csSelf.terrainInfor[defalutTerrainIndex];
        end
        sideRight = mapSizeX - 1;

        CLLScene.newMap(currTerrain, speed, onFinishLoadMap);
        --        csSelf:invoke4Lua("checkLeftSideTilesTimeout", tileTimeout, tileTimeout);
    end

    function CLLScene.newMap(terrainInfor, speed, onFinishLoadMap)
        creatureCount = 0;
        local tileInforList = {}
        for y = 0, mapSizeY - 1 do
            for x = 0, mapSizeX - 1 do
                --                csSelf:invoke4Lua("createTile", { x, y, terrainInfor}, x*y*0.2);
                table.insert(tileInforList, { x, y, terrainInfor,  x});
            end
        end
        CLLScene.createTile({ tileInforList, 1, speed, onFinishLoadMap});
    end

    function CLLScene.createTile(orgs)
        local list = orgs[1];
        local i = orgs[2];
        local speed = orgs[3];
        local onFinishLoadMap = orgs[4];

        local data = list[i];
        local x = data[1];
        local y = data[2]
        local terrainInfor = data[3]
--        local _sideRight = data[4];
        local index = NumEx.NextInt(0, terrainInfor.tileTypes.Count);
        local tileType = terrainInfor.tileTypes:get_Item(index);
        local tileName = "tiles/" .. tileType:ToString();
        CLThingsPool.borrowObjAsyn(tileName, CLLScene.onGetTile, { x, y, speed, terrainInfor, list, i, onFinishLoadMap});
    end

    function CLLScene.onGetTile(name, obj, orgs)
        local tile = obj:GetComponent("CLMapTile");
        if (tile.luaTable == nil) then
            tile:setLua();
            tile.luaTable.init(tile);
        end
        CLLScene.addMapTileToMap(tile, orgs[1], orgs[2], 0);
        local speed = orgs[3];
        local list = orgs[5];
        local i = orgs[6];
        local onFinishLoadMap = orgs[7];
        local data = list[i];
        local _sideRight = data[4];

        if (#(list) > i) then
            csSelf:invoke4Lua("createTile", { list, i + 1, speed, onFinishLoadMap}, speed);
        else
            -- 已经加载完成
            list = nil;
            if (onFinishLoadMap ~= nil) then
                onFinishLoadMap(_sideRight);
            end
        end
    end

    -- 右边增加一列
    function CLLScene.addRightSideTiles(speed, onFinishAddSideTiles)
        sideRight = sideRight + 1;
        --切换地图风格
        local switchStep = NumEx.getIntPart(CLLScene.getSteps()/10);
        if(switchStep ~= oldSwitchMapeStep) then
            oldSwitchMapeStep = switchStep;
            currTerrain = csSelf.terrainInfor[NumEx.NextInt(0, csSelf.terrainInfor.Count)];
        end

        local tileInforList = {}
        for i = 0, mapSizeY - 1 do
            table.insert(tileInforList, { sideRight, i, currTerrain, sideRight});
        end
        CLLScene.createTile({ tileInforList, 1, speed, onFinishAddSideTiles});
    end

    function CLLScene.addMapTileToMap(tile, x, y, z)
        if (z == nil) then
            z = 0;
        end
        tile:GetComponent("Rigidbody").isKinematic = true;
        local topLeftPosition = Vector3(-0.5 * mapSizeX * CLMapTile.OffsetX, 0, 0.5 * mapSizeY * CLMapTile.OffsetY);
        local tilePos = topLeftPosition + CLLScene.getPos(x, -y, z);
        tile.mapX = x;
        tile.mapY = y;
        tile.mapZ = z;
        tile.ornamentOnTop = nil;
        tile.mapTileBelow = nil;
        tiles[tile.posStr] = tile;
        tile.transform.parent = transform;
        tile.transform.localEulerAngles = Vector3(-90, 90, 0);
        tile.transform.localScale = Vector3.one * 2;
        tile.luaTable.effectNew(tilePos, CLLScene.onFinishLoadOneTile);
        NGUITools.SetActive(tile.gameObject, true);
    end

    function CLLScene.getPos(x, y, z)
        local pos = Vector3(x * CLMapTile.OffsetX, z * CLMapTile.OffsetZ, y * CLMapTile.OffsetY);
        local off = y % 2;
        local rowIndexIsUneven = (off == 1 or off == -1);
        if (rowIndexIsUneven) then
            pos.x = pos.x + CLMapTile.RowOffsetX;
        end
        return pos;
    end

    function CLLScene.onFinishLoadOneTile(tile)
        if (tile.mapY == 0 or tile.mapY == 1) then
            -- 说明是最边上的两排，添加装饰物品
            local index = NumEx.NextInt(0, currTerrain.ornTypes.Count);
            local ornName = "tiles/" .. currTerrain.ornTypes[index]:ToString();
            CLThingsPool.borrowObjAsyn(ornName, CLLScene.addOrnament, tile);
        else
            if (NumEx.NextBool(0.01)) then
                -- 有概率出现障碍物
                local index = NumEx.NextInt(0, currTerrain.ornTypes.Count);
                local ornName = "tiles/" .. currTerrain.ornTypes[index]:ToString();
                CLThingsPool.borrowObjAsyn(ornName, CLLScene.addOrnament, tile);
            else
                creatureCount = creatureCount + 1;
            end
        end
    end

    function CLLScene.addOrnament(name, obj, orgs)
        local orn = obj:GetComponent("CLMapTile");
        if (orn.luaTable == nil) then
            orn:setLua();
            orn.luaTable.init(orn);
        end
        local tile = orgs;
        if (orn ~= nil) then
            orn.mapX = tile.mapX;
            orn.mapY = tile.mapY;
            orn.mapZ = tile.mapZ;
            orn.transform.position = tile.transform.position;
            orn.transform.parent = transform;
            orn.transform.localScale = Vector3.one * 2;
            orn.transform.localEulerAngles = Vector3(-90, 90, 0);
            orn.ornamentOnTop = nil;
            orn.mapTileBelow = tile;
            tile.ornamentOnTop = orn;
            tile.mapTileBelow = nil;
            NGUITools.SetActive(orn.gameObject, true);

            creatureCount = creatureCount + 1;
        end
    end

    -- Checks the left side tiles timeout.
    function CLLScene.checkLeftSideTilesTimeout(tileTimeout)
        local tile;
        local tile2;
        for i = 0, mapSizeY - 1 do
            tile = CLLScene.GetTileAt(sideLeft, i);
            if (tile ~= nil) then
                CLLScene.fallTile(tile);
            end
        end
        sideLeft = sideLeft + 1;

        while (sideLeft < sideRight) do
            tile = CLLScene.GetTileAt(sideLeft, 0);
            tile2 = CLLScene.GetTileAt(sideRight, 0);
            if (tile2 ~= nil and Vector3.Distance(tile.transform.position, tile2.transform.position) > MAX_Length) then
                for i = 0, mapSizeY - 1 do
                    tile = CLLScene.GetTileAt(sideLeft, i);
                    if (tile ~= nil) then
                        CLLScene.fallTile(tile);
                    end
                end
                sideLeft = sideLeft + 1;
            else
                break;
            end
        end

        csSelf:invoke4Lua("checkLeftSideTilesTimeout", tileTimeout, tileTimeout);
    end

    function CLLScene.fallTile(tile)
        tiles[tile.posStr] = nil;
        tile.luaTable.effectFall(CLLScene.onFinishFall);
    end

    function CLLScene.onFinishFall(tile)
        NGUITools.SetActive(tile.gameObject, false);
        tile.luaTable.clean();
        CLThingsPool.returnObj(tile.name, tile.gameObject);
    end

    function CLLScene.clean()
        csSelf:cancelInvoke4Lua("");
        for k, tile in pairs(tiles) do
            NGUITools.SetActive(tile.gameObject, false);
            tile.luaTable.clean();
            CLThingsPool.returnObj(tile.name, tile.gameObject);
        end
        tiles = {};
        oldSwitchMapeStep = 0;
    end

    function CLLScene.GetTileAt(x, y, z)
        if (z == nil) then
            z = 0;
        end
        local key = CLLScene.getPosStr(x, y, z);
        local obj = tiles[key];
        if (obj ~= nil) then
            return obj;
        end
        return nil;
    end


    function CLLScene.getPosStr(x, y, z)
        if (z == nil) then
            z = 0;
        end
        return PStr.begin():a(x):a("_"):a(y):a("_"):a(z):e();
    end

    function CLLScene.startSpin()
        spin.enabled = true;
    end

    function CLLScene.stopSpin()
        spin.enabled = fasle;
        transform.localEulerAngles = Vector3.zero;
    end

    -- 取得中心点的tile
    function CLLScene.getCenterTile()
        local x = NumEx.getIntPart(sideLeft + (sideRight - sideLeft)/2);
        local y = NumEx.getIntPart(mapSizeY/2);
        return CLLScene.GetTileAt(x, y);
    end

    -- 取得右边列中的一个空闲地块
    function CLLScene.getRightSieFreeTile(defaultSideRight)
        local x = 0;
        if(defaultSideRight == nil) then
            x = sideRight;
        else
            x = defaultSideRight;
        end
        local y = NumEx.NextInt(2, mapSizeY);

        local tile = CLLScene.GetTileAt(x, y);
        if(tile ~= nil) then
            if (tile.CanMoveTo) then
                return tile;
            else
                return CLLScene.getRightSieFreeTile();
            end
        else
            print("x====" .. x .. " ===" .. y);
            return nil;
        end
    end

    -- 取得空闲的tile位置
    function CLLScene.getFreeTile()
        if (sideLeft >= sideRight) then
            return nil;
        end
        local x = NumEx.NextInt(sideLeft, sideRight);
        local y = NumEx.NextInt(0, mapSizeY);

        local tile = CLLScene.GetTileAt(x, y);
        if(tile ~= nil) then
            if (tile.CanMoveTo) then
                return tile;
            else
                return CLLScene.getFreeTile();
            end
        else
            return nil;
        end
    end

    --[[
    /// <summary>
    /// Gets the map position.根据坐标取得在地图格子中的坐标
    /// </summary>
    /// <returns>
    /// The map position.
    /// </returns>
    /// <param name='pos'>
            /// Position.
    /// </param>
    --]]
    function CLLScene.getMapPos(pos)
        local flagX = 1;
        local flagY = 1
        local flagZ = 1;
        local x = 0
        local y = 0;
        if (pos.x >= 0) then
            flagX = 1;
        else
            flagX = -1;
        end

        if (pos.z >= 0) then
            flagY = 1;
        else
            flagY = -1;
        end
        if (pos.y >= 0) then
            flagZ = 1;
        else
            flagZ = -1;
        end

        local topLeftPosition = Vector3(-0.5 * mapSizeX * CLMapTile.OffsetX, 0, 0.5 * mapSizeY * CLMapTile.OffsetY);
--        local tilePos = topLeftPosition + CLLScene.getPos(x, -y, z);
        pos = pos - topLeftPosition;

--        y = (pos.z + flagY * (CLMapTile.OffsetY / 2)) / CLMapTile.OffsetY;
        y = (pos.z - (CLMapTile.OffsetY / 2)) / CLMapTile.OffsetY;
        y = NumEx.getIntPart(y);

        local off = NumEx.getIntPart(y % 2);
        local rowIndexIsUneven = (off == 1 or off == -1);
        if (rowIndexIsUneven) then
            x = (pos.x + flagX *(-CLMapTile.RowOffsetX + CLMapTile.OffsetX / 2)) / CLMapTile.OffsetX;
        else
--            x = (pos.x + flagX * (CLMapTile.OffsetX / 2)) / CLMapTile.OffsetX;
            x = (pos.x + (CLMapTile.OffsetX / 2)) / CLMapTile.OffsetX;
        end
        x = NumEx.getIntPart(x);

        local z = ((pos.y + flagZ * (CLMapTile.OffsetZ / 2)) / CLMapTile.OffsetZ);
        z = NumEx.getIntPart(z);
        return Vector3(x, -y, z);
    end

    -- 根据localPosition取得tile
    function CLLScene.getTileByLocalPos(pos)
        local mpos = CLLScene.getMapPos(pos);
        return CLLScene.GetTileAt(mpos.x, mpos.y, mpos.z);
    end

    -- 取得向前移动了几个步
    function CLLScene.getSteps()
        return sideRight - mapSizeX + 1;
    end
    --------------------------------------------
    return CLLScene;
end
