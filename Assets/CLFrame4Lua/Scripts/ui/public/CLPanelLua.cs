﻿using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using Toolkit;
using System.Collections.Generic;

public class CLPanelLua : CLPanelBase
{
	bool isLoadedLua = false;

	public void reLoadLua ()
	{
		isLoadedLua = false;
	}

	LuaFunction lfhideSelfOnKeyBack;
	LuaFunction lfhide;
	LuaFunction lfinit;
	LuaFunction lfsetData;
	LuaFunction lfprocNetwork;
	LuaFunction lfshow;
	LuaFunction lfrefresh;
	LuaFunction lfUIEventDelegate;

	public override void setLua ()
	{
		base.setLua ();
		lfhideSelfOnKeyBack = getLuaFunction ("hideSelfOnKeyBack");
		lfhide = getLuaFunction ("hide");
		lfinit = getLuaFunction ("init");
		lfsetData = getLuaFunction ("setData");
		lfprocNetwork = getLuaFunction ("procNetwork");
		lfshow = getLuaFunction ("show");
		lfrefresh = getLuaFunction ("refresh");
		lfUIEventDelegate = getLuaFunction ("uiEventDelegate");
	}

	public override bool hideSelfOnKeyBack ()
	{
		bool isHide = false;
		object[] rets = null;
		if (lfhideSelfOnKeyBack != null) {
			rets = lfhideSelfOnKeyBack.Call ("");
		}
		if (rets != null && rets.Length > 0) {
			isHide = (bool)(rets [0]);
		}
		if (isHide) {
			CLPanelManager.hideTopPanel ();
			return true;
		}
		return false;
	}

	public override void hide ()
	{
		if (lfhide != null)
			lfhide.Call ("");
		base.hide ();
	}

	public override void init ()
	{
		if (isFinishInit)
			return;
		setLua ();
//      base.init ();
		if (lfinit != null) {
			lfinit.Call (this);
		}
		if (Application.isPlaying) {
			isFinishInit = true;
		}
	}
    
	public override void setData (object pars)
	{
		init ();
		if (lfsetData != null) {
			lfsetData.Call (pars);
		}
	}

	public override void procNetwork (string cmd, int succ, string msg, object pars)
	{
		init ();
		base.procNetwork (cmd, succ, msg, pars);
		if (lfprocNetwork != null) {
			lfprocNetwork.Call (cmd, succ, msg, pars);
		}
	}
    
	public override void show (object pars)
	{
		base.show (pars);
	}

	public override void show ()
	{
		if (isNeedMask4Init) {
			Callback cb = onfinishShowMask;
			CLPanelMask4Panel.show (cb, null);
		} else {
			_show ();
		}
	}

	public void onfinishShowMask (params object[] para)
	{
		_show ();
	}

	public void _show ()
	{
		Callback callback = doShowing;
		base.showWithEffect (callback);
	}

	void doShowing (params object[] paras)
	{
		if (!isFinishInit) {
			init ();
		}
        
		if (lfshow != null) {
			lfshow.Call ("");
		}
		getSubPanelsDepth ();
		refresh ();
		if (isNeedMask4Init) {
			CLPanelMask4Panel.hide (null);
		}
	}

	public override void refresh ()
	{
		setSubPanelsDepth ();
		if (lfrefresh != null) {
			lfrefresh.Call ("");
		}
	}
    
	public void uiEventDelegate(GameObject go) {
		if(lfUIEventDelegate != null) {
			lfUIEventDelegate.Call(go);
		}
	}

	//== proc event ==============
	public void onClick4Lua (GameObject button, string functionName)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button);
		}
	}

	public void onDoubleClick4Lua (GameObject button, string functionName)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button);
		}
	}

	public void onHover4Lua (GameObject button, string functionName, bool isOver)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button, isOver);
		}
	}
    
	public void onPress4Lua (GameObject button, string functionName, bool isPressed)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button, isPressed);
		}
	}

	public void onDrag4Lua (GameObject button, string functionName, Vector2 delta)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button, delta);
		}
	}
    
	public void onDrop4Lua (GameObject button, string functionName, GameObject go)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button, go);
		}
	}
    
	public void onKey4Lua (GameObject button, string functionName, KeyCode key)
	{
		LuaFunction f = getLuaFunction (functionName);
		if (f != null) {
			f.Call (button, key);
		}
	}
	
}
