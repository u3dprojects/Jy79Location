using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Toolkit;

#if UNITY_EDITOR
using UnityEditor;
#endif
/// <summary>
/// CL texture mgr.
/// 1.这个脚本可以取得物体及物体子对象上所有引用的Material及textures，并把这种引用关系保存起来
/// 2.在Start函数中，把引用关系中用到的Material及textures都取出来，并设置给对应的render
/// 3.当OnDestroy销毁该对象时，还回引用的资源
/// 4.当生成assetbundle时，要去掉引用
/// 5.该脚本只能挂在prefab的最外层
/// </summary>
public class CLModelMgr : MonoBehaviour
{
	object finishCallback = null;
	[SerializeField]
	public List<CLModel>
		data = new List<CLModel> ();
	bool isFinishInited = false;
	bool isAllModelLoaded = false;
	// Use this for initialization
	public void Start ()
	{
		if (isFinishInited)
			return;
		isFinishInited = true;
		resetModel ();
	}

	public void init (object finishCallback)
	{
		this.finishCallback = finishCallback;
		
		if (isAllModelLoaded) {
			if (finishCallback != null) {
				if (finishCallback is LuaInterface.LuaFunction) {
					((LuaInterface.LuaFunction)finishCallback).Call ();
				} else if (finishCallback is Callback) {
					((Callback)finishCallback) ();
				}
			}
		} else {
			Start ();
		}
	}

	public void OnDestroy ()
	{
		CLModel clMod;
		Texture tex = null;
		for (int i=0; i < data.Count; i++) {
			clMod = data [i];
			if (clMod.meshFilter != null) {
				CLModelPool.returnModel (clMod.model);
			} else if(clMod.skinnedMesh != null) {
				CLModelPool.returnModel (clMod.model);
			}
		}
	}

	
	/// <summary>
	/// Cleans the mat.清除对材质球的引用
	/// </summary>
	public void cleanModel ()
	{
		CLModel clMod;
		for (int i=0; i < data.Count; i++) {
			clMod = data [i];
			if(clMod.meshFilter != null) {
				clMod.meshFilter.mesh = null;
			} else if(clMod.skinnedMesh != null) {
				clMod.skinnedMesh.sharedMesh = null;
			}
		}
	}
	
	public void resetModel ()
	{
		CLModel clMod;
		Mesh mesh = null;
		Transform tr = null;
		for (int i=0; i < data.Count; i++) {
			clMod = data [i];
			if ((clMod.meshFilter == null && clMod.skinnedMesh == null) || string.IsNullOrEmpty (clMod.meshName))
				continue;
#if UNITY_EDITOR
			string tmpPath = clMod.model4Editor;
			if(Application.isPlaying) {
				if(SCfg.self.isEditMode) {
					tmpPath = clMod.model.Replace("/upgradeRes/", "/upgradeRes4Publish/");
					CLModelPool.borrowAsyn (tmpPath, clMod.meshName, (Callback)onGetModel, clMod);
				} else {
					CLModelPool.borrowAsyn (clMod.model, clMod.meshName, (Callback)onGetModel, clMod);
				}
			} else {
				if (!tmpPath.StartsWith ("Assets/")) {
					tmpPath = "Assets/" + tmpPath;
				}
				GameObject go = AssetDatabase.LoadAssetAtPath (
					tmpPath, typeof(UnityEngine.Object)) as GameObject;

				if (go.name == clMod.meshName) {
					tr = go.transform;
				} else {
					tr = go.transform.Find (clMod.meshName);
				}
				
				MeshFilter mf = tr.GetComponent<MeshFilter>();
				if(mf != null) {
					mesh = mf.sharedMesh;
				} else {
					SkinnedMeshRenderer smr = tr.GetComponent<SkinnedMeshRenderer>();
					mesh = smr.sharedMesh;
				}
				if(clMod.meshFilter != null) {
					clMod.meshFilter.mesh = mesh;
				} else if(clMod.skinnedMesh != null) {
					clMod.skinnedMesh.sharedMesh = mesh;
				}
			}
#else
			CLModelPool.borrowAsyn (clMod.model, clMod.meshName, (Callback)onGetModel, clMod);
#endif
		}
	}
	
	int counter = 0;

	void onGetModel (object[] paras)
	{
		if (paras != null && paras.Length > 2) {
			counter++;
			string path = paras [0].ToString ();
			Mesh mesh = paras [1] as Mesh;
			CLModel mod = paras [2] as CLModel;
			try {
				if (mod != null) {
					if(mod.meshFilter != null) {
						mod.meshFilter.mesh = mesh;
					}else if(mod.skinnedMesh != null) {
						mod.skinnedMesh.sharedMesh = mesh;
					}
				}
				if (counter >= data.Count) {
					isAllModelLoaded = true;
					if (finishCallback != null) {
						if (finishCallback is LuaInterface.LuaFunction) {
							((LuaInterface.LuaFunction)finishCallback).Call ();
						} else if (finishCallback is Callback) {
							((Callback)finishCallback) ();
						}
					}
				}
			} catch (System.Exception e) {
				Debug.LogError ("name===" + name + ",err:" + e);
			}
		}
	}
}


[System.Serializable]
public class CLModel
{
	public MeshFilter meshFilter;
	public SkinnedMeshRenderer skinnedMesh;
	//	[System.NonSerialized]
	//	public Mesh  mesh;
	public string meshName;
	public string model4Editor;
	[System.NonSerialized]
	static Hashtable
		modelPathCache = new Hashtable ();
	
	public string model {
		get {
			string texPath = MapEx.getString (modelPathCache, model4Editor);
			if (string.IsNullOrEmpty (texPath) && !string.IsNullOrEmpty (model4Editor)) {
				texPath = PStr.b ().a (Path.GetDirectoryName (model4Editor)).a ("/").a (PathCfg.self.platform).a ("/").a (Path.GetFileNameWithoutExtension (model4Editor)).a (".unity3d").e ();
				texPath = texPath.Replace ("/upgradeResMedium/", "/upgradeRes/");
				modelPathCache [model4Editor] = texPath;
			}
			return texPath;
		}
	}
}

