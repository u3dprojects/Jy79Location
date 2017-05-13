using UnityEngine;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Text;
using Toolkit;
using System.Threading;

/** 
 *
 * @author:  chenbin
 * @date:    2011-12-21
 * 
 * desc：    封装c# socketNumber据传输协议
 *
 */

public delegate void NetCallback(object obj);
public class USocket
{
	public string host;
	public int port;
	public Socket mSocket;
	public int mTmpBufferSize;
	public byte[] mTmpBuffer;
	public MemoryStream mBuffer;
	private IPEndPoint ipe;
	NetCallback connectCallbackFunc;
	NetCallback OnReceiveCallback;
	private int failTimes = 0;
	public bool isActive = false;

	public USocket (string ihost, int iport)
	{
		host = ihost;
		port = iport;
		mSocket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		IPAddress ip = IPAddress.Parse (host);
		ipe = new IPEndPoint (ip, port);

		mTmpBufferSize = 1024;
		mTmpBuffer = new byte[mTmpBufferSize];
		mBuffer = new MemoryStream ();
	}

	public void connect ()
	{
		try {
			mSocket.Connect (ipe);
		} catch (Exception e) {
			Debug.Log (e);
			//ErrLog.RecordErr(e, ModuleName, "AsySocket", "");
		}
	}

	// 异步模式//////////////////////////////////////////////////////////////////
	// 异步模式//////////////////////////////////////////////////////////////////
	public  bool IsConnectionSuccessful = false;
	public  int timeoutMSec = 5000;
	public ManualResetEvent TimeoutObject = new ManualResetEvent (false);
	NetCallback offLineCallback;
	public void connectAsync (NetCallback callback, NetCallback offLineCallback)
	{
		this.offLineCallback = offLineCallback;
		IsConnectionSuccessful = false;
		connectCallbackFunc = callback;
		mSocket.BeginConnect (ipe, new AsyncCallback (connectCallback), this);
		
		if (TimeoutObject.WaitOne (timeoutMSec, false)) {
			if (IsConnectionSuccessful) {
				//return tcpclient;
				//callback (true);
			} else {
				//mSocket.Close ();
				callback (false);
			}
		} else {
			callback (false);
		}
	}

	public void close ()
	{
		if (mSocket != null)
			mSocket.Close ();
		isActive = false;
		//mSocket = null;
	}

	private static void connectCallback (IAsyncResult ar)
	{
		// 从stateobject获取socket.
		USocket client = (USocket)ar.AsyncState;
		try {
			if (client.mSocket.Connected) {
				// 完成连接.
				client.mSocket.EndConnect (ar);
				client.IsConnectionSuccessful = true;
				client.isActive = true;

				// isOpen始接Number据
				// client.ReceiveAsync ();
				
				client.connectCallbackFunc (true);
				client.failTimes = 0;
			} else {
				client.connectCallbackFunc (false);
				client.close ();
			}
		} catch (Exception e) {
			client.IsConnectionSuccessful = false;
			Debug.Log ("connect faile:" + e);
			client.failTimes++;
			client.connectCallbackFunc (false);
			client.close ();
		} finally {
			client.TimeoutObject.Set ();
		}
	}

	public void ReceiveAsync (NetCallback callback)
	{
		OnReceiveCallback = callback;
		// 从远程target接收Number据.
		this.mSocket.BeginReceive (mTmpBuffer, 0, mTmpBufferSize, 0,
		                           new AsyncCallback (ReceiveCallback), this);
	}

	private static void ReceiveCallback (IAsyncResult ar)
	{
		USocket client = (USocket)ar.AsyncState;
		try {
			if (client.isActive) {
				//从远程设备读取Number据
				int bytesRead = client.mSocket.EndReceive (ar);
				if (bytesRead > 0) {
//					Debug.Log ("receive len==" + bytesRead);
					// 有Number据，存储.
					client.mBuffer.Write (client.mTmpBuffer, 0, bytesRead);
					client.parseMsg ();
				} else if (bytesRead < 0) {
					if(client.offLineCallback != null) {
						client.offLineCallback(client);
					}
					client.connectCallbackFunc (false);
					client.close ();
				} else {
					// 所有Number据读取完毕.
					Debug.Log ("receive zero=====" + bytesRead);
					if(client.offLineCallback != null) {
						client.offLineCallback(client);
					}
					client.connectCallbackFunc (false);
					client.close ();
					return;
				}

				// 继续读取.
				if (client.mSocket.Connected) {
					client.mSocket.BeginReceive (client.mTmpBuffer, 0, client.mTmpBufferSize, 0,
					                             new AsyncCallback (ReceiveCallback), client);
				}
			} else {
				if(client.offLineCallback != null) {
					client.offLineCallback(client);
				}
				client.connectCallbackFunc (false);
				client.close ();
			}
		} catch (Exception e) {
			if(client.offLineCallback != null) {
				client.offLineCallback(client);
			}
			client.connectCallbackFunc (false);
			client.close ();
			Debug.Log (e);
		}
	}

	static MemoryStream os = new MemoryStream ();
	static MemoryStream os2 = new MemoryStream ();

	public byte[] createMessage (object obj)
	{
		os.Position = 0;
		os2.Position = 0;

		B2OutputStream.writeObject (os, obj);
		int len = (int)os.Position;
		B2OutputStream.writeInt (os2, len);
//		os2.Write (os.GetBuffer (), 0, len);
		os2.Write (os.ToArray (), 0, len);
		int pos = (int)os2.Position;
		byte[] result = new byte[pos];
		os2.Position = 0;
		os2.Read (result, 0, pos);
		return result;
	}

	public void SendAsync (object obj)
	{
		try {
			//Debug.Log ("send msg ======" + Utl.getStringFromMap ((Hashtable)obj));
			byte[] data = createMessage (obj);
			// isOpen始发送Number据到远程设备.
			mSocket.BeginSend (data, 0, data.Length, 0,
			                   new AsyncCallback (SendCallback), this);
		} catch (System.Exception e) {
			Debug.LogError(e);
			if(offLineCallback != null) {
				offLineCallback(this);
			}
			close ();
		}

	}

	private static void SendCallback (IAsyncResult ar)
	{
		USocket client = (USocket)ar.AsyncState;
		// 完成Number据发送.
		int bytesSent = client.mSocket.EndSend (ar);
		if (bytesSent <= 0) { //发送失败
			if(client.offLineCallback != null) {
				client.offLineCallback(client);
			}
			client.close ();
		}
		client.failTimes = 0;
	}

	private void parseMsg ()
	{
		bool isLoop = true;
		while (isLoop) {
			long currentPostion = mBuffer.Position;
			if (currentPostion > 4) {
				mBuffer.Position = 0;
				long len = B2InputStream.readInt (mBuffer);
				if (len <= 0 || len > 1024 * 1024) {
					// 网络Number据错误。断isOpen网络
//					Main.self.onOffline ();
					connectCallbackFunc (false);
					close ();
					isLoop = false;
				} else {
					long cp2 = mBuffer.Position;
					if (cp2 + len <= currentPostion) {
						object o = B2InputStream.readObject (mBuffer);
						//Dispatch.dispatcher ((Hashtable)o);  //回调主处理
						OnReceiveCallback (o);
						long cp3 = mBuffer.Position;
						long less = currentPostion - cp3;
						if (less > 0) {
							byte[] lessBuff = new byte[less];
							mBuffer.Read (lessBuff, 0, (int)less);
							mBuffer.Position = 0;
							mBuffer.Write (lessBuff, 0, (int)less);
						} else {
							mBuffer.Position = 0;
							isLoop = false;
						}
					} else {
						mBuffer.Position = currentPostion;
						isLoop = false;
					}
				}
			} else {
				isLoop = false;
			}
		}
	}
}
