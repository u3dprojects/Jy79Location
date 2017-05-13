using UnityEngine;
using System.Collections;
using LuaInterface;

public class WWWEx  :MonoBehaviour
{
	public static  Hashtable wwwMapUrl = new Hashtable ();
	public static  Hashtable wwwMap4Check = new Hashtable ();
	public static Hashtable wwwMap4Get = new Hashtable();
	
	/// <summary>
    /// Checks the WWW timeout.
    /// </summary>
    /// <param name="go">Go.</param>
    /// <param name="www">Www.</param>
    /// <param name="checkProgressSec">Check progress sec.</param>
    /// <param name="timeOutSec">Time out sec.</param>
    /// <param name="timeoutCallback">Timeout callback.</param>
    public static void checkWWWTimeout (MonoBehaviour go, WWW www, float checkProgressSec, float timeOutSec, object timeoutCallback, object orgs)
    {
        if (www == null || www.isDone)
            return;
        if (go == null)
            return;
        checkProgressSec = checkProgressSec <= 0 ? 2 : checkProgressSec;
#if UNITY_4_6 || UNITY_5
        Coroutine cor = go.StartCoroutine(doCheckWWWTimeout(go, www, checkProgressSec, timeOutSec, timeoutCallback, 0, 0, orgs));
        wwwMap4Check[www] = cor;
#else
        go.StartCoroutine (doCheckWWWTimeout (go, www, checkProgressSec, timeOutSec, timeoutCallback, 0, 0, orgs));
		wwwMap4Check [www] = true;
#endif

    }

    public static IEnumerator doCheckWWWTimeout (MonoBehaviour go, WWW www, float checkProgressSec, 
	                                             float timeOutSec, object timeoutCallback, float oldProgress, float totalCostSec, object orgs)
    {
        yield return new WaitForSeconds (checkProgressSec);
        totalCostSec = totalCostSec + checkProgressSec;
        try {
            if (www != null) {
                if (www.isDone) {
					wwwMap4Check.Remove (www);
				} else {
                    if (www.progress == oldProgress) { //说明没有变化，可能网络不给力
						wwwMap4Check.Remove (www);
						string url = www.url;
						Coroutine corout = (Coroutine)(wwwMap4Get[url]);
						if(corout != null) {
							go.StopCoroutine(corout);
							wwwMap4Check.Remove(url);
						}
						www.Dispose ();
                        www = null;
                        doCallback (timeoutCallback, null, orgs);
                    } else if (timeOutSec > 0 && totalCostSec >= timeOutSec) {
						wwwMap4Check.Remove (www);
						string url = www.url;
						Coroutine corout = (Coroutine)(wwwMap4Get[url]);
						if(corout != null) {
							go.StopCoroutine(corout);
							wwwMap4Check.Remove(url);
						}
						www.Dispose ();
                        www = null;
                        doCallback (timeoutCallback, null, orgs);
                    } else {
                        #if UNITY_4_6 || UNITY_5
                    Coroutine cor = go.StartCoroutine(doCheckWWWTimeout(go, www, checkProgressSec, timeOutSec, timeoutCallback, 0, 0, orgs));
						wwwMap4Check[www] = cor;
						#else
                        go.StartCoroutine (doCheckWWWTimeout (go, www, checkProgressSec, timeOutSec, timeoutCallback, 0, 0, orgs));
						wwwMap4Check [www] = true;
						#endif
                    }
                }
            }
        } catch (System.Exception e) {
            go.StopCoroutine("doCheckWWWTimeout");
            Debug.LogError (e);
        }
    }

    public static void uncheckWWWTimeout (MonoBehaviour go, WWW www)
    {
#if UNITY_4_6 || UNITY_5
		Coroutine cor = (Coroutine)(wwwMap4Check[www]);
        if(cor != null) {
            go.StopCoroutine(cor);
        }
#else
        go.StopCoroutine ("doCheckWWWTimeout");
#endif
		wwwMap4Check.Remove (www);
    }

    public static void doCallback (object callback, object obj, object orgs)
    {
        if (callback == null)
            return;
        if (typeof(LuaFunction) == callback.GetType ()) {
            ((LuaFunction)callback).Call (obj, orgs);
        } else if (typeof(Callback) == callback.GetType ()) {
            ((Callback)callback) (obj, orgs);
        }
    }
    
    public static void newWWW (MonoBehaviour go, string url, CLAssetType type, 
                               float checkProgressSec, float timeOutSec, object finishCallback, 
                               object exceptionCallback, object timeOutCallback, object orgs)
    {
        if (string.IsNullOrEmpty (url))
			return;
#if UNITY_4_6 || UNITY_5
		Coroutine cor = go.StartCoroutine (doNewWWW (go, url, type, checkProgressSec, timeOutSec, finishCallback, exceptionCallback, timeOutCallback, orgs));
		wwwMap4Get[url] = cor;
#else
#endif
    }

    public static IEnumerator doNewWWW (MonoBehaviour go, string url, CLAssetType type, 
                                        float checkProgressSec, float timeOutSec, object finishCallback, 
	                                    object exceptionCallback, object timeOutCallback, object orgs)
    {
        WWW www = new WWW (url);
        checkWWWTimeout (go, www, checkProgressSec, timeOutSec, timeOutCallback, null);
		wwwMapUrl[url] = www;
        yield return www;
		try {
			uncheckWWWTimeout (go, www);
			if (string.IsNullOrEmpty (www.error)) {
                object content = null;
                switch (type) {
                case CLAssetType.text:
                    content = www.text;
                    break;
                case CLAssetType.bytes:
                    content = www.bytes;
                    break;
                case CLAssetType.texture:
                    content = www.texture;
                    break;
                case CLAssetType.assetBundle:
                    content = www.assetBundle;
                    break;
                }
                doCallback (finishCallback, content, orgs);
            } else {
                doCallback (exceptionCallback, null, orgs);
            }
            www.Dispose ();
            www = null;
			wwwMapUrl.Remove(url);
        } catch (System.Exception e) {
			Debug.LogError (url+":" +e);
			wwwMapUrl.Remove(url);
            if(www != null) {
                www.Dispose ();
                www = null;
            }
        }
    }

	public static WWW getWwwByUrl(string Url) {
		if(string.IsNullOrEmpty(Url)) return null;
		return (WWW)(wwwMapUrl[Url]);
	}
}
