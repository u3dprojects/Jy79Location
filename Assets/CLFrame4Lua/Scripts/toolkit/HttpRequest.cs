using UnityEngine;
using System;
using System.Net;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System.Text;
using Toolkit;

public class HttpRequest
{
//	readonly static string head = "POST /apple HTTP/1.1\r\nHost: " + NetworkPackage.URL + ":" + NetworkPackage + "\r\nContent-Type: text/html;\r\nContent-Length: {0:G} \r\n\r\n";
	
	public static byte[] httpRequest (string host, int port, string method, byte[] data,int count)
	{
		string head = PStr.begin().a("POST /").a(method).a(" HTTP/1.1\r\nHost: ").a(host).a(":").a (port).a("\r\nContent-Type: text/html;\r\nContent-Length: {0:G} \r\n\r\n").end();
		Debug.Log("head = " + head);
		byte[] result = null;
		try {
		byte[] headBytes = System.Text.Encoding.Default.GetBytes (string.Format (head, data.Length));
		TcpClient client = new TcpClient ();
		//client = new TcpClient ();
		
		client.SendTimeout = 5 * 10000;
		client.ReceiveTimeout = 5 * 10000;
		client.Connect (host, port);
		NetworkStream ns = client.GetStream ();
		ns.Write (headBytes, 0, headBytes.Length);
		ns.Write (data, 0, data.Length);
		ns.Flush ();

		int len = 0;
		
		for (int n = 0; n < 100; n ++) {
			string line = readLine (ns);
		
			//Debug.Log(line);
			//Debug.Log("rrrr+"+line.IndexOf("\r"));
			bool b = line.StartsWith ("Content-Length");
			if (b) {
				string sub = line.Substring (line.IndexOf (":") + 1);
				len = int.Parse (sub);
			}
			if (line == null || line.Equals ("")) {
				break;
			}
			
		}
		//ns.ReadByte();
		//ns.ReadByte();
		result = new byte[len];
		//ns.Read (result, 0, len);
		readFully(ns,result,0,len);
		//Debug.Log("http:length========"+len);
		//Debug.Log(BitConverter.ToString(result));
		
		ns.Close ();
		client.Close ();
		} catch(System.Exception e) {
			if(count<=0){
				Debug.LogError(e);
			}else{
				Debug.Log("try again");
				httpRequest(host,port, method, data,--count);
			}
			
		}
		return result;
	}
	public static void readFully(	NetworkStream ns,byte[] b, int off, int len){
		if (len < 0)
            return;
        int n = 0;
        while (n < len) {
            int count = ns.Read(b,off+n,len-n);
            if (count < 0)
                return;
            n += count;
        }
	}
	public static String readLine (NetworkStream ns)
	{
		
		StringBuilder sb = new StringBuilder ();
		for (int n=0; n<100; n++) {
			int b = ns.ReadByte ();
			//Debug.Log(b+"-"+((int)'\r'));
			if (b != '\r') {
				sb.Append ((char)b);			
			} else {
				ns.ReadByte ();
				return sb.ToString ();	
			}
		}
		return sb.ToString ();
		
	}
}
