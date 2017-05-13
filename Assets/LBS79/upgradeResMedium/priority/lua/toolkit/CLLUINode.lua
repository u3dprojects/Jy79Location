require ('class')

  local nt_getActive = NGUITools.GetActive
  local nt_setActive = NGUITools.SetActive
  --
  -- 
  -- 
  CLLUINode = class('CLLUINode')
  function CLLUINode:ctor(root, data)
    -- print( 'slot info - root:' .. obj2String(root))
    self.data = data or {}
    self.root = root
    self.buttons = {}
    if root == nil then
      print( traceback('Missing Node root Transform!') )
      return
    end
    local subs = {}
    local cnt = root.childCount
    for i = 0, cnt-1 do
      local tran = root:GetChild(i)
--      print( 'child :' .. i .. '-' .. obj2String(tran) )
      local name = tran.name
      local f = string.sub(name, 1, 2)
      local component = nil
      if f == 'S_' then
         component = tran:GetComponent("UISprite")
      elseif f == 'L_' then
        component = tran:GetComponent("UILabel")
      
      elseif f == 'R_' then 
        component = tran:GetComponent("UIScrollView")
      
      elseif f == 'P_' then 
        component = tran:GetComponent("UIProgressBar")

      elseif f == 'B_' then
        local txt = 'CLLUINode:ctor :' ..  tran.name .. ', ' .. tostring(tran) .. '\n'
--[[
--        local ct = component:GetClassType()
        local ct = type(component)
        txt = txt .. 'CLLUINode:ctor :' .. i .. ', [' .. tostring(ct) .. ']' .. tostring(component)

        txt = txt .. '\n' .. 'go:' .. tostring(component.gameObject)
        print( txt )
]]
        component = tran:GetComponent("UIButton") -- UIButton

      elseif f == 'T_' then
        component = tran.gameObject
      end

      if component then
        subs[name] = component
      end
    end
    self.subs = subs
    if self.init then self:init() end
  end
  
  function CLLUINode:switchState(statename)
    local subs = self.subs
    for k, lst in pairs(self.states) do
      if k ~= statename then
        for i, v in ipairs(lst) do
          local ch = subs[v]
          if ch == nil then
            print(traceback('missing ui component ' .. v .. '!') )
            break
          end
          nt_setActive(ch.transform.gameObject, false)
        end
      end
    end
    local curcomps = self.states[statename]
    for i, v in ipairs(curcomps) do
      local ch = subs[v]
      if ch == nil then
        print('missing ui component ' .. v .. '!')
        break
      end
      nt_setActive(ch.transform.gameObject, true)
    end
  end

  function CLLUINode:setEmpty()
    local subs = self.subs
    local herocomps = self.states['using']
    for i, v in ipairs(herocomps) do
      local ch = subs[v]
      if ch == nil then
        print('missing ui component ' .. v .. '!')
        break
      end
      nt_setActive(ch.transform.gameObject, false)
    end
    
    local emptycomps = self.states['empty']
    for i, v in ipairs(emptycomps) do
      local ch = subs[v]
      if ch == nil then
        print('missing ui component ' .. v .. '!')
        break
      end
      nt_setActive(ch.transform.gameObject, true)
    end
  end

  function CLLUINode:setBtnText(name, text)
    local btn = self.subs[name]
    if btn == nil then
      printt('missing ui component ' .. name .. '!')
      return
    end
    local t = btn.transform:FindChild('Label')
    if t == nil then
      printt('Need Label child [' .. name .. ']!')
      return
    end
    local lab = t:GetComponent('UILabel')
    if lab == nil then
      printt('missing ui/Label component ' .. name .. '!')
      return
    end
    lab.text = text
  end

  function CLLUINode:setBtnTextColor(name, clr)
    local btn = self.subs[name]
    if btn == nil then
      printt('missing ui component ' .. name .. '!')
      return
    end
    local t = btn.transform:FindChild('Label')
    if t == nil then
      printt('Need Label child [' .. name .. ']!')
      return
    end
    local lab = t:GetComponent('UILabel')
    if lab == nil then
      printt('missing ui/Label component ' .. name .. '!')
      return
    end
    lab.color = clr
  end


  function CLLUINode:setBtnBackground(name, spriteName)
    local btn = self.subs[name]
    if btn == nil then
      printt('missing ui component ' .. name .. '!')
      return
    end
    if type(spriteName) == 'string' then
      Util.SetButtonSpriteNormal(btn, spriteName)
    end
  end

  function CLLUINode:setBtnColor(name, clr)
    local btn = self.subs[name]
    if btn == nil then
      printt('missing ui component ' .. name .. '!')
      return
    end
    if clr then
      Util.SetButtonColorNormal(btn, clr)
    end
  end


  

  function CLLUINode:setText(name, text)
    local lab = self.subs[name]
    if lab == nil then
      printt('missing UILabel component ' .. name .. '!')
      return
    end
    lab.text = text
  end
  
  function CLLUINode:setSprit(name, spriteName)
    local sp = self.subs[name]
    if sp == nil then
      print('missing UILabel component ' .. name .. '!')
      return
    end
    sp.spriteName = spriteName
  end
  function CLLUINode:setColor(name, value)
    local widget = self.subs[name]
    if widget == nil then
      print('missing UIWidget component ' .. name .. '!')
      return
    end
    widget.color = value
  end
    
  function CLLUINode:setShown(shown)
    if shown then
      self:show()
    else
      self:hide()
    end
  end

  function CLLUINode:show()
    nt_setActive(self.root.gameObject, true)
  end
  
  function CLLUINode:hide()
    nt_setActive(self.root.gameObject, false)
  end

  function CLLUINode:showChildByName(name, state)
    local tr = self.root:FindChild(name)
    if tr then
      nt_setActive(tr.gameObject, state)
    end
  end
  

  function CLLUINode:unregsiterClick(clickListener)
    for i, v in ipairs(self.buttons) do
        clickListener:unregsiter(v)
    end
  end

  function CLLUINode:regsiterClick(clickListener, name, func, isDelegate, param)
    local btn = self.subs[name]
    if btn then
      if isDelegate then
        clickListener:regsiter2(btn, func, self, param)
      else
        clickListener:regsiter(btn, func, self, param)
      end
      table.insert(self.buttons, btn)
    else
      printt('missing UIButton component ' .. name .. '!')
    end
  end

  function CLLUINode:showSub(name, shown)
    local sub = self.subs[name]
    if sub then
      nt_setActive(sub.transform.gameObject, shown and true or false)
    end
  end

  function CLLUINode:showTween()
    local transform = self.root
    local tw = transform.gameObject:GetComponent('UITweener')
    if tw then

      tw:ResetToBeginning()
      tw:Play(true)
    else
      printt('No Tweener found, transform=' .. transform.name)
    end
    return tw
    --local complist = gameobj:GetComponentsInChildren( UITweener.GetClassType() )
    --[[
    local transform = self.root
    local tp = transform.gameObject:GetComponent('TweenPosition')
    if tp then
      local from = tp.from
      local to = tp.to
      local cur = transform.position

      if cur ~= to then
        local delta = to - from
        printt('1 from =' .. tostring(from) .. ' to=' .. tostring(to) .. ' cur=' .. tostring(cur) )
        to = cur
        from = cur - delta
        tp.from = from
        tp.to = to

        printt('2 from =' .. tostring(from) .. ' to=' .. tostring(to) .. ' cur=' .. tostring(cur) )
      end
      tp:ResetToBeginning()
      tp:Play(true)
    end
    ]]
  end

  -- 位移
  function CLLUINode:showTween1(duration, delay)
    local transform = self.root
    local parent = transform.parent
    local from = parent:FindChild("G_movefrom")
    local to = parent:FindChild("G_moveto")
    local originpos = self.originpos or transform.localPosition

    local posfrom = originpos + from.localPosition
    local posto = originpos + to.localPosition
--    printt( ' -- pos = ' .. tostring(posfrom) .. '->' .. tostring(posto) )

    local tp = transform.gameObject:GetComponent('TweenPosition')
    if tp then
      transform.localPosition = posfrom
      tp.from = posfrom
      tp.to = posto
      tp.delay = delay or 0
      tp.duration = duration or 0.8
      tp:ResetToBeginning()
      tp:Play(true)
    end
    return tp

  end

  function CLLUINode:showTween2(trans, from, to, duration, delay, immPlay)
    trans.localPosition = from
    local tp = trans.gameObject:GetComponent('TweenPosition')
    -- local tp = TweenPosition.Begin(trans.gameObject, delay, to)
    if tp then
      tp.from = from
      tp.to = to
      tp.duration = duration or 1
      tp.delay = delay or 0
      tp:ResetToBeginning()
      if immPlay then
        tp:Play(true)
      end
    end
    return tp
  end

  function CLLUINode:extrenTweener(eventListener, flag)
    flag = flag or 'all'
    local rootObj = self.root.gameObject
    
    if flag =='all' or string.find(flag, 'tween', 1, true) then
      self.activeTweener = rootObj:GetComponent('UITweener')
      if eventListener then
        self.onShowTweenerToEnd = function(node, tw, endfunc)
          eventListener:unregsiterTweener(tw)
          if type(endfunc) == 'function' then
              endfunc(node)
          end
        end
      end
      self.showTweenerEffect = 
      function(node, from, to, duration, delay, immPlay, endfunc)
        local tw = node.activeTweener
        if tw then
          tw.from = from
          tw.to = to
          tw.duration = duration or 0.2
          tw.delay = delay or 0
          tw:ResetToBeginning()
          if immPlay then tw:Play(true) end
          if eventListener then
            eventListener:regsiterTweenerFinished(tw, self.onShowTweenerToEnd, self, endfunc)
          end
        end
        if eventListener == nil and type(endfunc) == 'function' then
          printt('Need eventListener using extrenAlphaTween.')
        end
        return tw
      end

      self.showTweenerOut = function(node, duration, delay, immPlay, endfunc)
        return node:showTweenerEffect(1, 0, duration, delay, immPlay, endfunc)
      end
      self.showTweenerIn = function(node, duration, delay, immPlay, endfunc)
        return node:showTweenerEffect(0, 1, duration, delay, immPlay, endfunc)
      end
    end

    if flag =='all' or string.find(flag, 'alpha', 1, true) then
      self.alphaTweener = rootObj:GetComponent('TweenAlpha')
      if eventListener then
        self.onShowAlphaToHideEnd = function(node, tw, endfunc)
          eventListener:unregsiterTweener(tw)
          if type(endfunc) == 'function' then
              endfunc(node)
          end
        end
      end
      self.showAlphaEffect = 
      function(node, from, to, duration, delay, immPlay, endfunc)
        local tw = node.alphaTweener
        if tw then
          tw.from = from or 0
          tw.to = to or 1
          tw.duration = duration or 0.2
          tw.delay = delay or 0
          tw:ResetToBeginning()
          if immPlay then tw:Play(true) end
          if eventListener then
            eventListener:regsiterTweenerFinished(tw, self.onShowAlphaToHideEnd, self, endfunc)
          end
        end
        if eventListener == nil and type(endfunc) == 'function' then
          printt('Need eventListener using extrenAlphaTween.')
        end
        return tw
      end

      self.showAlphaFadeOut = function(node, duration, delay, immPlay, endfunc)
        return node:showAlphaEffect(1, 0, duration, delay, immPlay, endfunc)
      end
      self.showAlphaFadeIn = function(node, duration, delay, immPlay, endfunc)
        return node:showAlphaEffect(0, 1, duration, delay, immPlay, endfunc)
      end
    end
    -- 
    if flag =='all' or string.find(flag, 'flip', 1, true) then
      local ts = rootObj:GetComponent('TweenScale')
      if eventListener then
        self.onShowFlipEffectEnd = function(node, ts, endfunc)
          eventListener:unregsiterTweener(ts)
          if type(endfunc) == 'function' then
              endfunc(node)
          end
        end
      end

      self.showFlipEffect = function(node, from, to, duration, delay, immPlay, endfunc)
        if ts then
          ts.from = Vector3(from, 1, 1)
          ts.to = Vector3(to, 1, 1)
          ts.duration = duration or 0.2
          ts.delay = delay or 0
          ts:ResetToBeginning()
          if immPlay then ts:Play(true) end
          if eventListener then
            eventListener:regsiterTweenerFinished(ts, self.onShowFlipEffectEnd, self, endfunc)
          end
        end
        if eventListener == nil and type(endfunc) == 'function' then
          printt('Need eventListener using extrenAlphaTween.')
        end
        return ts
      end

      self.showFlipIn = function(node, duration, delay, immPlay, endfunc)
        return node:showFlipEffect(0.001, 1, duration, delay, immPlay, endfunc)
      end
      self.showFlipOut = function(node, duration, delay, immPlay, endfunc)
        return node:showFlipEffect(1, 0.001, duration, delay, immPlay, endfunc)
      end
    end
  end

  return CLLUINode