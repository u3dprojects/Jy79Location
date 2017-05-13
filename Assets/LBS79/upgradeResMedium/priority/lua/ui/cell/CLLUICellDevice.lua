-- 百度地图定位页面-自行车列表单元
do
  local format = string.format;

  local csSelf = nil;
  local transform = nil;
  local gameObject = nil;

  local gobjBox;
  local labName,togLock;

  local isFinishInit = false;
  local mData;
  local curTogVal;

  local uiCell = {}
  function uiCell.init(go)
    if (isFinishInit) then return end
    isFinishInit = true;

    gameObject = go.gameObject;
    transform = go.transform;

    gobjBox = gameObject;

    labName = getChild(transform, "Label"):GetComponent("UILabel");
    togLock = getChild(transform, "Toggle"):GetComponent("UIToggle");
  end

  function uiCell.show(go, data)
    addWdgCollider(gobjBox);
    mData = data;
    if mData then
      labName.text = format("%s",mData.deviceNo);
      curTogVal = mData.isLocked == true;
      togLock.value = curTogVal;
    else
      SetActive(gameObject,false);
    end
  end

  function uiCell.getData()
    return mData;
  end

  function uiCell.uiEventDelegate(go)
    local goName = go.name;
    if goName == "Toggle" then
      if curTogVal == togLock.value then
        return;
      end
      curTogVal = togLock.value;
      if togLock.value then
        altAdd("改变了状态 true！", Color.green, 1);
      else
        altAdd("改变了状态 false！", Color.red, 1);
      end
    end
  end

  return uiCell;
end
