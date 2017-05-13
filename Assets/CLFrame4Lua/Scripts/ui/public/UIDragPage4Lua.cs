using UnityEngine;
using System.Collections;
using LuaInterface;

[RequireComponent(typeof(CLCellLua))]
public class UIDragPage4Lua : UIDragPageContents
{
	public CLCellLua uiLua;
	
	bool isFinishInit = false;
	LuaFunction lfInit = null;
	LuaFunction lfrefresh = null;
	LuaFunction lfrefreshCurrent = null;

	public override void init(object obj)
	{
		if (!isFinishInit) {
			isFinishInit = true;
			if(uiLua != null) {
				uiLua.setLua();
				lfInit = uiLua.getLuaFunction("init");
				lfrefresh = uiLua.getLuaFunction("refresh");
				lfrefreshCurrent = uiLua.getLuaFunction("refreshCurrent");
			}
			if (lfInit != null) {
				lfInit.Call (uiLua);
			}
		}
		
		if (lfrefresh != null) {
			lfrefresh.Call (obj);
		}
	}

	public override void refreshCurrent(int pageIndex, object obj)
	{
		init(obj);
		if (lfrefreshCurrent != null) {
			lfrefreshCurrent.Call (pageIndex, obj);
		}
	}
}
