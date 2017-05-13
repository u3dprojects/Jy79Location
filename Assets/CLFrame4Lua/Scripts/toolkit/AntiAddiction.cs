using UnityEngine;
using System.Collections;

//防沉迷
public class AntiAddiction : MonoBehaviour
{
	public static AntiAddiction self;
	public static float rate = 1.0f;	//获得资源经验的比例
	static long loginTimes = 0;	//登陆时间
	
	int AntiAddictionlev1 = 3 * 60;
	int AntiAddictionlev2 = 4 * 60;
	int AntiAddictionlev3 = 5 * 60;
	int alertLev1 = 60 * 60;
	int alertLev2 = 30 * 60;
	int alertLev3 = 15 * 60;
	
#if CHL_QH360
	public AntiAddiction() {
		self = this;
	}
	
	void OnApplicationPause (bool isPause)
	{
		if (isPause) {
			onLogout();
		} else {
			onLogin();
		}
	}
	
	public  void onLogin ()
	{
		loginTimes = DateEx.nowMS ();
		long lastLogout = NumEx.stringToLong (DBPrefs.getLastLogoutTime ());
		int diffM = (int)((DateEx.nowMS () - lastLogout) / 60000);
		int offlineM = DBPrefs.getOffLineDuration ();
		if (offlineM + diffM >= 300) {	//下线时间已满5小时，则累计在线时间清零
			DBPrefs.setOnLineDuration (0);
			DBPrefs.setOffLineDuration (0);
		} else {
			DBPrefs.setOffLineDuration (offlineM + diffM);
		}
	}
	
	public  void onLogout ()
	{
		DBPrefs.setLastLogoutTime (DateEx.nowMS ());
		int diffM = (int)(DateEx.nowMS () - loginTimes) / 60000;
		int onLineM = DBPrefs.getOnLineDuration ();
		DBPrefs.setOnLineDuration (onLineM + diffM); 
	}
	public void start() {
		startCheckOnLineDuration();
	}
	public  void startCheckOnLineDuration ()
	{
		if(loginTimes == 0)  {
			onLogin();
		}
		CancelInvoke ("reCheckOnLineDuration");
		int diffM = (int)(DateEx.nowMS () - loginTimes) / 60000;
		int onLineM = DBPrefs.getOnLineDuration () + diffM;
		if (onLineM <AntiAddictionlev1) {		//每累计在线时间满1小时时，应提醒一次：“您累计在线时间已满1小时。”至累计在线时间满3小时，应提醒：“您累计在线时间已满3小时，请您下线休息，做适当身体活动。”
			rate = 1;
			Invoke ("reCheckOnLineDuration", alertLev1);
		} else if (onLineM > AntiAddictionlev2 && onLineM <= AntiAddictionlev3) {//在开始进入时应在画面显著位置做出警示：“您已经进入疲劳游戏时间，您的游戏收益将降为正常值的50%，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活。”此后，应每30分钟警示一次。
			rate = 0.5f;
			NPanelAlert.show (AlertSize.SmallAlert, "您已经进入疲劳游戏时间，您的资源产量将降为正常值的50%，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活。", null, false);
			Invoke ("reCheckOnLineDuration", alertLev2);
		} else {//在开始进入时就应做出警示：“您已进入不健康游戏时间，为了您的健康，请您立即下线休息。如不下线，您的身体将受到损害，您的收益已降为零，直到您的累计下线时间满5小时后，才能恢复正常”。此后，应每15分钟警示一次。
			rate = 0;
			NPanelAlert.show (AlertSize.SmallAlert, "您已进入不健康游戏时间，为了您的健康，请您立即下线休息。如不下线，您的身体将受到损害，您的资源产量已降为零，直到您的累计下线时间满5小时后，才能恢复正常", null, false);
			Invoke ("reCheckOnLineDuration", alertLev3);
		}
	}
	public void stop() {
		CancelInvoke ("reCheckOnLineDuration");
	}
	public  void reCheckOnLineDuration ()
	{
		if(loginTimes == 0)  {
			onLogin();
		}
		CancelInvoke ("reCheckOnLineDuration");
		int diffM = (int)(DateEx.nowMS () - loginTimes) / 60000;
		int onLineM = DBPrefs.getOnLineDuration () + diffM;
		if (onLineM < AntiAddictionlev1) {		//每累计在线时间满1小时时，应提醒一次：“您累计在线时间已满1小时。”至累计在线时间满3小时，应提醒：“您累计在线时间已满3小时，请您下线休息，做适当身体活动。”
			rate = 1;
			NAlertTxt.add ("您累计在线时间已满1小时", Color.red, 1);
			Invoke ("reCheckOnLineDuration", alertLev1);
		} else if (onLineM > AntiAddictionlev2 && onLineM <= AntiAddictionlev3) {//在开始进入时应在画面显著位置做出警示：“您已经进入疲劳游戏时间，您的游戏收益将降为正常值的50%，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活。”此后，应每30分钟警示一次。
			rate = 0.5f;
			NPanelAlert.show (AlertSize.SmallAlert, "您已经进入疲劳游戏时间，您的资源产量将降为正常值的50%，为了您的健康，请尽快下线休息，做适当身体活动，合理安排学习生活。", null, false);
			Invoke ("reCheckOnLineDuration", alertLev2);
		} else {//在开始进入时就应做出警示：“您已进入不健康游戏时间，为了您的健康，请您立即下线休息。如不下线，您的身体将受到损害，您的收益已降为零，直到您的累计下线时间满5小时后，才能恢复正常”。此后，应每15分钟警示一次。
			rate = 0;
			NPanelAlert.show (AlertSize.SmallAlert, "您已进入不健康游戏时间，为了您的健康，请您立即下线休息。如不下线，您的身体将受到损害，您的资源产量已降为零，直到您的累计下线时间满5小时后，才能恢复正常", null, false);
			Invoke ("reCheckOnLineDuration", alertLev3);
		}
	}
#endif
}
