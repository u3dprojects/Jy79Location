require ('class')
--- 按钮事件处理器，用于页面中存在多个按钮，名称相同，或动态生成的按钮


-- local listener_Get = UIEventListener.Get

CLLClickListener = class('CLLClickListener') 

function CLLClickListener:ctor(...)
  self.buttons = {}
  self.tweeners = {}
  self.progresshdr = {}
  self.onClickedForListener = function (gobj)
    self:onClickedForListenerImp(gobj)
  end
end

function CLLClickListener:getKey(go)
	local button = go.transform:GetComponent('UIButton')
	if button then
		return tostring(button)
	end
end

function CLLClickListener:handleClicked(go)
	local key = self:getKey(go)
	local info  = self.buttons[key]
	
	-- print( 'handleClicked:' .. key .. '' ' .. tostring(info) )
	if info then
		local btn = info[1]
		local clickfunc = info[2]
		local node = info[3]
		local param = info[4]
		clickfunc(node, btn, param)
	end
end

function CLLClickListener:regsiter(btn, clickfunc, node, param)
	local key =  self:getKey(btn)
	self.buttons[key] = { btn, clickfunc, node, param }
  -- print( 'regsiter:' .. key .. ',' .. tostring(clickfunc))
end

function CLLClickListener:unregsiter(btn)
	local key = self:getKey(btn)
	local v = self.buttons[key]
	if v then
		Util.RemoveButtonClick(btn)
	end
	-- print('-- unregsiter ', key)
	self.buttons[key] = nil
end

function CLLClickListener:regsiter2(btn, clickfunc, node, param)
	local key = self:getKey(btn)
	self.buttons[key] = { btn, clickfunc, node, param }
  -- print( 'regsiter2:' .. key .. ',' .. tostring(clickfunc))
  Util.SetButtonClick(btn, self.onClickedForListener)
	-- listener_Get(btn.gameObject).onClick = self.onClickedForListener
end

function CLLClickListener:onClickedForListenerImp(gobj)
	local key = self:getKey(gobj)
	local info = self.buttons[key]
	local btn = info[1]
	local clickfunc = info[2]
	local node = info[3]
	local param = info[4]
	clickfunc(node, btn, param)
end

function CLLClickListener:onTweenerFinishedImp(gobj)
	local key = gobj:GetInstanceID()
--	printt('call twn key=' .. key)
	local info = self.tweeners[key]
	if info then
		local component = info[1]
		local callfunc = info[2]
		local node = info[3]
		local param = info[4]
		callfunc(node, component, param)
	end
end

function CLLClickListener:regsiterTweenerFinished(twn, endfunc, node, param)
	local key = twn.gameObject:GetInstanceID()
--	printt('twn key=' .. key)
	self.tweeners[key] = { twn, endfunc, node, param }
  Util.SetTweenFinished(twn, function (gobj)
    self:onTweenerFinishedImp(gobj)
  end)
end

function CLLClickListener:unregsiterTweener(twn)
	local key = twn.gameObject:GetInstanceID()
	self.tweeners[key] = nil
	Util.RemoveTweenFinished(twn)
end


function CLLClickListener:regsiterProgress(progressbar, updatefunc, node, param)
	local key = self:unregsiterProgress(progressbar)
	table.insert(self.progresshdr, { key=key, node=node, param=param, updatefunc=updatefunc } )
end

function CLLClickListener:unregsiterProgress(progressbar)
	local key = progressbar.gameObject:GetInstanceID()
	for i, v in ipairs(self.progresshdr) do
		if v.key == key then
			table.remove( self.progresshdr, i )
			break
		end
	end
	return key
end

function CLLClickListener:handleProgress()
	local ret = false
	for i, v in ipairs(self.progresshdr) do
		local updatefunc = v.updatefunc
		if type(v.updatefunc) == 'function' then
			if updatefunc(v.node, v.param) then
				ret = true
			end
		end
	end
	return ret
end

function CLLClickListener:clearProgress()
	self.progresshdr = {}
end


return CLLClickListener
