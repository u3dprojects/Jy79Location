/*
 * Copyright (C) 2012 GREE, Inc.
 * 
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */
using System.Collections;
using UnityEngine;
using Toolkit;

public class BMWebView : MonoBehaviour
{
	public string Url;
	public string SameDomainUrl;
	//	public GUIText status;
	WebViewObject webViewObject;

	IEnumerator Start()
	{
#if UNITY_EDITOR
		string url = "file://" + Application.streamingAssetsPath + "/79/baiduditu.html";
#elif UNITY_ANDROID
		string url = Application.streamingAssetsPath + "/79/baiduditu.html";
#else
		string url = "file://" + Application.streamingAssetsPath + "/79/baiduditu.html";
#endif
		
		var src = System.IO.Path.Combine(Application.streamingAssetsPath+"/79/", "baiduditu.html");
		var dst = System.IO.Path.Combine(Application.persistentDataPath+"/79/", "baiduditu.html");
		var result = "";
		if (src.Contains("://")) {
			var www = new WWW(src);
			yield return www;
			result = www.text;
		} else {
			result = System.IO.File.ReadAllText(src);
		}

		System.IO.File.WriteAllText(dst, result);

		init ();
		show (url);
	}

	bool isInited = false;
	void _init ()
	{
		if (isInited)
			return;
		isInited = true;
		webViewObject =
			(new GameObject ("WebViewObject")).AddComponent<WebViewObject> ();
		webViewObject.Init ((msg) => {
//						Debug.Log(string.Format("CallFromJS[{0}]", msg));
			onCallFromJS (msg);
			//			if(status != null) {
			//				status.text = msg;
			//				status.GetComponent<Animation>().Play();
			//			}
		});
		
		SetMargins (5, 40, 5, 5);
	}

	public void onCallFromJS (string msg)
	{
		string json = System.Uri.UnescapeDataString (msg);
		Debug.Log (string.Format ("CallFromJS[{0}]", json));
		Hashtable map = JSON.DecodeMap (json);
		string cmd = map ["cmd"] == null ? "" : map ["cmd"].ToString ();
		switch (cmd) {
		case "onFinsihLoad":		//
			onFinishLoadHtml();
			break;
		}
	}

	public void onFinishLoadHtml(){
			webViewObject.EvaluateJS("showCarInfor({\"isLocked\":true});");
	}

	public void init ()
	{
		_init ();
	}

	public void setData (object pars)
	{
		Url = pars.ToString ();
	}

	public void show (string url)
	{
		Url = url;
		webViewObject.SetVisibility (true);
		if (!string.IsNullOrEmpty (Url)) {
			StartCoroutine (openUrl (Url));
		}
	}
	
	public void hide ()
	{
		webViewObject.SetVisibility (false);
	}
	
	public void SetMargins (int left, int top, int right, int bottom)
	{
		webViewObject.SetMargins (left, top, right, bottom);
	}
	
	IEnumerator openUrl (string Url)
	{
		yield return null;
		switch (Application.platform) {
		case RuntimePlatform.OSXEditor:
		case RuntimePlatform.OSXPlayer:
		case RuntimePlatform.IPhonePlayer:
		case RuntimePlatform.Android:
//			var dst = System.IO.Path.Combine(PathCfg.persistentDataPath + "/" + PathCfg.self.basePath + "/" + PathCfg.upgradeRes + "/priority/", Url);
			Debug.Log (Url);
			//			webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
			webViewObject.LoadURL (Url.Replace (" ", "%20"));
			if (Application.platform != RuntimePlatform.Android) {
				webViewObject.EvaluateJS (
					"window.addEventListener('load', function() {" +
					"	window.Unity = {" +
					"		call:function(msg) {" +
					"			var iframe = document.createElement('IFRAME');" +
					"			iframe.setAttribute('src', 'unity:' + msg);" +
					"			document.documentElement.appendChild(iframe);" +
					"			iframe.parentNode.removeChild(iframe);" +
					"			iframe = null;" +
					"		}" +
					"	}" +
					"}, false);");
			}
			break;
		case RuntimePlatform.WebGLPlayer:
			webViewObject.LoadURL (Url.Replace (" ", "%20"));
			webViewObject.EvaluateJS (
				"parent.$(function() {" +
				"	window.Unity = {" +
				"		call:function(msg) {" +
				"			parent.unityWebView.sendMessage('WebViewObject', msg)" +
				"		}" +
				"	};" +
				"});");
			break;
		}
	}
}
