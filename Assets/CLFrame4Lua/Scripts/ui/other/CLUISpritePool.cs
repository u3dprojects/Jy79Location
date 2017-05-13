using UnityEngine;
using System.Collections;

public class CLUISpritePool
{
	public static StarPool pool = new StarPool ();
	
	public static UISprite borrowSprite (string spriteName)
	{
		return pool.borrowObject (spriteName);
	}

	public static void returnSprite (UISprite sprite)
	{
		pool.resetObject (sprite);
	}
}

public class StarPool : AbstractObjectPool<UISprite>
{
	static UISprite prefab;
	#region implemented abstract members of AbstractObjectPool[UISprite]
	public override UISprite createObject (string key)
	{
		if (prefab == null) {
			GameObject go = new GameObject ();
			prefab = NGUITools.AddSprite (go, CLUIInit.self.emptAtlas, key);
			NGUITools.SetLayer(go, 8);
			NGUITools.SetActive(go, false);
			return prefab;
		} else {
			return (UISprite)(Object.Instantiate (prefab));
		}
	}

	public override UISprite resetObject (UISprite t)
	{
		return t;
	}
	#endregion
}
