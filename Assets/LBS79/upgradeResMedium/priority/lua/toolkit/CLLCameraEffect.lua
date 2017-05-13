-- camera 界面
do
  CLLCameraEffect = {}

  local csSelf = nil;
  local transform = nil;
  local bloomLens = nil;
  local colorCorrection = nil;
  local depthField = nil;


  -- 初始化，只会调用一次
  function CLLCameraEffect.init(csObj)
    csSelf = csObj;
    transform = csObj.transform;
    --[[
    上的组件：getChild(transform, "offset", "Progress BarHong"):GetComponent("UISlider");
    --]]

    bloomLens = transform:GetComponent("BloomAndLensFlares");
    colorCorrection = transform:GetComponent("ColorCorrectionCurves");
    depthField = transform:GetComponent("DepthOfField34");
  end

  -- 设置数据
  function CLLCameraEffect.setData(paras)
  end

  -- 显示，在c#中。show为调用refresh，show和refresh的区别在于，当页面已经显示了的情况，当页面再次出现在最上层时，只会调用refresh
  function CLLCameraEffect.show()
  end

  -- 刷新
  function CLLCameraEffect.refresh()
  end

  -- 关闭页面
  function CLLCameraEffect.hide()
  end

  function CLLCameraEffect.enabled( val )
    bloomLens.enabled = val;
    colorCorrection.enabled = val;
    depthField.enabled = val;
  end

  function CLLCameraEffect.setFocalPoint( val )
    -- body
    depthField.focalPoint = val;
  end
  
  --------------------------------------------
  return CLLCameraEffect;
end
