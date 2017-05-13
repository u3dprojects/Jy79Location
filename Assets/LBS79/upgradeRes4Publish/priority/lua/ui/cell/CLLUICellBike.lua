-- 我的Home页面-自行车列表单元
do
  local format = string.format;

  local csSelf = nil;
  local transform = nil;
  local gameObject = nil;
  local gobjBox;
  local labEqp,labVTK,labVTV,labSF;

  local isFinishInit = false;
  local mData;

  local uiCell = {}
  function uiCell.init(go)
    if (isFinishInit) then return end
    isFinishInit = true;

    gameObject = go.gameObject;
    transform = go.transform;

    gobjBox = gameObject;

    labEqp = getChild(transform, "Eqp/LabelVal"):GetComponent("UILabel");
    labVTV = getChild(transform, "ValidTime/LabelVal"):GetComponent("UILabel");
    labVTK = getChild(transform, "ValidTime/LabelKey"):GetComponent("UILabel");
    labSF = getChild(transform, "SurplusFlow/LabelVal"):GetComponent("UILabel");
    
    local trsfTmp = getChild(transform, "ValidTime");
    addWdgCollider(trsfTmp.gameObject);
    trsfTmp = getChild(transform, "SurplusFlow");
    addWdgCollider(trsfTmp.gameObject);
  end

  function uiCell.show(go, data)
    addWdgCollider(gobjBox);
    mData = data;
    if mData then
      labEqp.text = format("%s",mData.deviceNo);
      labSF.text = format("%dMB",mData.leftMB);
      labVTV.text = format("%s",mData.serviceEndDate);
    else
      SetActive(gameObject,false);
    end
  end

  function uiCell.getData()
    return mData;
  end
  
  function uiCell.uiEventDelegate(go)
    local goName = go.name;
    if goName == "ValidTime" then
      CLLData:go2Pay(mData.id);
    elseif goName == "SurplusFlow" then
      CLLData:go2Pay(mData.id);
    end
  end

  return uiCell;
end
