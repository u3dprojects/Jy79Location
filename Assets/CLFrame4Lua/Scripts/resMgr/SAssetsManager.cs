using UnityEngine;
using System.Collections;

//管理assetsBundle的加载释放
public class SAssetsManager : MonoBehaviour
{
	public static SAssetsManager self;
    public static bool isForceRelease = false;

	public SAssetsManager()
	{
		self = this;
	}
	
	public static int realseTime = 5000;	//10 minute,未使用超过x时间就释放该资源
//	public Hashtable assetsMap = new Hashtable ();
	public Hashtable assetsMap = System.Collections.Hashtable.Synchronized(new Hashtable());
	public class AssetsInfor
	{
		public string name;
		public long lastUsedTime;
		public int usedCount;
		public AssetBundle asset;
		public Callback doRealse;
	}
	
	public void addAsset(string _name, AssetBundle asset, Callback onRealse)
	{
		#if UNITY_EDITOR
		string name = _name.Replace("/upgradeRes4Publish/", "/upgradeRes/");
		#else
		string name = _name;
		#endif

		AssetsInfor ai = new AssetsInfor();
		ai.name = name;
		ai.lastUsedTime = System.DateTime.Now.ToFileTime();
		ai.usedCount = 0;
		ai.asset = asset;
		ai.doRealse = onRealse;
		assetsMap [ai.name] = ai;
	}
	
	public void useAsset(string _name)
	{
#if UNITY_EDITOR
		string name = _name.Replace("/upgradeRes4Publish/", "/upgradeRes/");
#else
		string name = _name;
#endif
		AssetsInfor ai = (AssetsInfor)(assetsMap [name]);
		if (ai != null) {
			ai.usedCount++;
			ai.lastUsedTime = System.DateTime.Now.ToFileTime();
			assetsMap [ai.name] = ai;
//            Debug.Log(ai.usedCount + "====useAsset===" + ai.name);
		}
	}
	
	public void unUseAsset(string _name)
	{
#if UNITY_EDITOR
		string name = _name.Replace("/upgradeRes4Publish/", "/upgradeRes/");
#else
		string name = _name;
#endif
		AssetsInfor ai = (AssetsInfor)(assetsMap [name]);
		if (ai != null) {
			ai.usedCount--;
			ai.lastUsedTime = System.DateTime.Now.ToFileTime();
            assetsMap [ai.name] = ai;
//            Debug.Log(ai.usedCount + "===unUseAsset====" + ai.name);
		}
	}

	public object getAsset(string name)
	{
		AssetsInfor ai = (AssetsInfor)(assetsMap [name]);
		if (ai != null) {
			return ai.asset;
		}
		return null;
	}
	
	void Start()
	{
		InvokeRepeating("_releaseAsset", 10, 6);	
	}

	void OnDestroy() {
		CancelInvoke ();
	}

	public void _releaseAsset() {
		releaseAsset();
	}
	
	public void releaseAsset(bool forced = false)
	{
		try {
			if (SCfg.self != null && 
				SCfg.self.mode != GameMode.normal
                && !isForceRelease) {
				return;//战斗模式不能释放资源，只有回到主城才能释放
			}
			AssetsInfor ai = null;
			ArrayList list = new ArrayList();
			list.AddRange(assetsMap.Values);
			for (int i = 0; i < list.Count; i++) {
				ai = (AssetsInfor)(list [i]);
				if (ai == null) {
					continue;
				}
				if (ai.usedCount <= 0 && 
				    ((System.DateTime.Now.ToFileTime() - ai.lastUsedTime) / 10000 > realseTime || forced)) {
					if (ai.doRealse != null) {
						ai.doRealse(ai.name);
					}
					assetsMap.Remove(ai.name);
                    if(ai.asset != null) {
    					ai.asset.Unload(true);
                        ai.asset = null;
                    }
					ai = null;
				}
            }
//            UnityEngine.Resources.UnloadUnusedAssets();
			list.Clear();
			list = null;
		} catch (System.Exception e) {
			Debug.LogError(e);
		}
	}

//	public static void unloadAsset(GameObject go) {
//		return;
//		Renderer[] renders = go.GetComponentsInChildren<Renderer>();
//		int count = renders.Length;
//		Renderer render = null;
//		Material material = null;
//		for(int i=0; i < count; i++) {
//			render = renders[i];
//			for(int j=0; j < render.materials.Length; j++) {
//				material = render.materials[j];
//				if(material.mainTexture != null) {
//					Resources.UnloadAsset(material.mainTexture);
//					material.mainTexture = null;
//				}
//				Resources.UnloadAsset(material);
//			}
//			render.material = null;
//			render.materials = null;
//		}
//		
//		SkinnedMeshRenderer[] skinRenders = go.GetComponentsInChildren<SkinnedMeshRenderer>();
//		count = skinRenders.Length;
//		SkinnedMeshRenderer skinRender = null;
//		for(int i=0; i < count; i++) {
//			skinRender = skinRenders[i];
//			for(int j=0; j < skinRender.materials.Length; j++) {
//				material = skinRender.materials[j];
//				if(material.mainTexture != null) {
//					Resources.UnloadAsset(material.mainTexture);
//					material.mainTexture = null;
//				}
//				Resources.UnloadAsset(material);
//			}
//			skinRender.material = null;
//			skinRender.materials = null;
//
//			if(skinRender.sharedMesh != null) {
//				Resources.UnloadAsset(skinRender.sharedMesh);
//				skinRender.sharedMesh = null;
//			}
//		}
//
//		MeshFilter[] mfs = go.GetComponentsInChildren<MeshFilter>();
//		count = mfs.Length;
//		MeshFilter mf = null;
//		for(int i = 0; i < count; i++) {
//			mf = mfs[i];
//			if(mf.mesh != null) {
//				Resources.UnloadAsset(mf.mesh);
//				mf.mesh = null;
//			}
//		}
//		
//		AudioSource[] ass = go.GetComponentsInChildren<AudioSource>();
//		count = ass.Length;
//		AudioSource au = null;
//		for(int i = 0; i < count; i++) {
//			au = ass[i];
//			if(au.clip != null) {
//				Resources.UnloadAsset(au.clip);
//				au.clip = null;
//			}
//		}
//
//		Animator[] anis = go.GetComponentsInChildren<Animator>();
//		count = anis.Length;
//		Animator ani = null;
//		for(int i=0; i < count; i++) {
//			ani = anis[i];
//			if(ani.runtimeAnimatorController != null) {
//				Resources.UnloadAsset(ani.runtimeAnimatorController);
//				ani.runtimeAnimatorController = null;
//				Debug.LogError("ani.runtimeAnimatorController");
//			}
//			if(ani.avatar != null) {
//				Resources.UnloadAsset(ani.avatar);
//				ani.avatar = null;
//				Debug.LogError("ani.avatar");
//			}
//		}
//	}

}
