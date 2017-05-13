using UnityEngine;
using System.Collections;
using System.IO;
using Toolkit;

public class Tcp
{
	
	public string host;
	public int port;
	public bool connected = false;		//是否连接
	public bool isStopping = false;
	public long haertConnteRate = 10000;	//心跳连接频率 毫秒
	const int MaxReConnectTimes = 0;
	
	System.Threading.Timer timer;
	USocket socket;
	int reConnectTimes = 0;
	public const string CONST_Connect = "connectCallback";
	public const string CONST_OutofNetConnect = "outofNetConnect";
	NetCallback mDispatcher;
	
	public Tcp(NetCallback dispatcher) {
		mDispatcher = dispatcher;
	}
	
	public void init (string host, int port)
	{
		this.host = host;
		this.port = port;
	}
	
	public void connect (object obj = null)
	{
		connected = true;
		isStopping = false;
		socket = new USocket (host, port);
#if UNITY_EDITOR
		Debug.Log ("connect ==" + host + ":" + port);
#endif
		socket.connectAsync (connectCallback, outofLine);
	}
	
	public void connectCallback (object result)
	{
		if ((bool)result) {//connectCallback
#if UNITY_EDITOR
			Debug.Log ("connectCallback    success");
#endif
			connected = true;
			reConnectTimes = 0;
			//心跳
//			if (haertConnteRate > 0) {
//				TimerEx.schedule (doHeartConnect, null, haertConnteRate);
//			}
			socket.ReceiveAsync (onReceive);
			
			CLPanelManager.topPanel.onNetwork(CONST_Connect, 0, "", this);
		} else {
			Debug.Log ("connectCallback    fail" + host + ":" + port + "," + isStopping);
			connected = false;
			if (!isStopping) {
				outofNetConnect ();
			}
		}
	}
	
	void onReceive (object obj)
	{
		try {
//			dispach.Call ((Hashtable)obj);
			mDispatcher(obj);
		} catch (System.Exception e) {
			Debug.Log (e);
		}
	}
	
//	void doHeartConnect (object obj = null)
//	{
//		if (System.DateTime.Now.ToFileTime () - nextHeartConnect > 0) {
////			dispacher.heartbeat();
//			nextHeartConnect = System.DateTime.Now.AddSeconds (30).ToFileTime ();
//		}
//	}
	
	public void send (object obj)
	{
		socket.SendAsync (obj);
	}

	void outofNetConnect ()
	{
		if (isStopping)
			return;
		if (reConnectTimes < MaxReConnectTimes) {
			reConnectTimes++;
			if (timer != null) {
				timer.Dispose ();
			}
			timer = TimerEx.schedule (connect, null, 5000);
		} else {
			if (timer != null) {
				timer.Dispose ();
			}
			timer = null;
			outofLine(socket);
		}
	}
	
	public void stop ()
	{
		isStopping = true;
		connected = false;
		if (socket != null) {
			socket.close ();
		}
	}
	
	public void send (System.Collections.Hashtable map)
	{
		socket.SendAsync (map);
	}
	
	void outofLine(object obj) {
		if(!isStopping) {
			CLPanelManager.topPanel.onNetwork (CONST_OutofNetConnect, -9999, "server connect failed!", null);
			CLMain.self.onOffline ();
		}
	}
}
