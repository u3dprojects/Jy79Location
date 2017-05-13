using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using Toolkit;
using System.Collections.Generic;

//战斗
public class CLBattle : CLBaseLua
{
	public bool isAutoBattle = false;		// 自动战斗
	public bool isEndBattle = false;		// end战斗
//	public bool isPaused = false;
//	public bool isTDmode = false;			//是否塔防
//	public bool isReplayMode = false;	//战斗回放
	public ArrayList offense = new ArrayList ();		//进攻方（左方）
	public ArrayList defense = new  ArrayList ();		// 防守方（右方）

//	public int pveLevID = 0; //关卡id
//	public CLBattleMap scene4Battle;
//	public AssetBundle scene4BattleAsset;
//	public CLGround ground;
	
	public static CLBattle self;
	
	public CLBattle ()
	{
		self = this;
	}

}
