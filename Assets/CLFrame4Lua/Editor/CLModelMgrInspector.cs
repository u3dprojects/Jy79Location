using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

#if UNITY_3_5
[CustomEditor(typeof(CLModelMgr))]
#else
[CustomEditor(typeof(CLModelMgr), true)]
#endif
public class CLModelMgrInspector : Editor
{
	CLModelMgr modelMgr;
	CLModel mat;
	bool isShowModelsRef = false;
	string buttonName = "";

	public override void OnInspectorGUI ()
	{
//		base.OnInspectorGUI ();
		modelMgr = (CLModelMgr)(target);
		GUI.color = Color.red;
		GUILayout.Label ("【特别注意】");
		GUI.color = Color.yellow;
		GUILayout.Label ("在使用该脚本时，同时也使用了CLTextureMgr，\n" +
		                 			"那么可以把FBX文件的设置中model选项卡里\n的“Import Materials“勾除掉");
		GUI.color = Color.white;
		if (GUILayout.Button ("Get Model Reference")) {
			setModelRef ();
		}
		if (GUILayout.Button ("Clean Model Reference")) {
			modelMgr.cleanModel ();
		}

		if (GUILayout.Button ("Reset Model Reference")) {
			modelMgr.resetModel ();
		}

		if (isShowModelsRef) {
			buttonName = "Hide  Model Reference";
		} else {
			buttonName = "Show  Model Reference";
		}
		if (GUILayout.Button (buttonName)) {
			isShowModelsRef = !isShowModelsRef;
		}
		if (isShowModelsRef) {
			for (int i=0; i < modelMgr.data.Count; i++) {
				CLEditorTools.BeginContents ();
				{
					mat = modelMgr.data [i];
					GUILayout.BeginHorizontal ();
					{
						GUILayout.BeginVertical ();
						{
							GUILayout.BeginHorizontal ();
							{
								if(mat.meshFilter != null) {
									EditorGUILayout.ObjectField (mat.meshFilter, typeof(UnityEngine.Object));
								} else {
									EditorGUILayout.ObjectField (mat.skinnedMesh, typeof(UnityEngine.Object));
								}
//								EditorGUILayout.ObjectField (mat.material, typeof(UnityEngine.Object));
							}
							GUILayout.EndHorizontal ();

							EditorGUILayout.TextField (mat.model);
							EditorGUILayout.TextField (mat.model4Editor);
							if (!mat.model4Editor.Contains ("/upgradeResMedium/")) {
								GUI.color = Color.yellow;
								GUILayout.Label("Model is not in [upgradeResMedium]!");
								GUI.color = Color.white;
							}
						}
						GUILayout.EndVertical ();
						GameObject go = (GameObject)(CLEditorTools.getObjectByPath (mat.model4Editor));
						Transform tr = null;
						if (go.name == mat.meshName) {
							tr = go.transform;
						} else {
							tr = go.transform.Find (mat.meshName);
						}
						MeshFilter mf = tr.GetComponent<MeshFilter>();
						if(mf != null) {
							EditorGUILayout.ObjectField ("", mf.sharedMesh, typeof(Mesh), false, GUILayout.MinWidth (0));
						} else {
							SkinnedMeshRenderer smr = tr.GetComponent<SkinnedMeshRenderer>();
							EditorGUILayout.ObjectField ("", smr.sharedMesh, typeof(Mesh), false, GUILayout.MinWidth (0));
						}
					}
					GUILayout.EndHorizontal ();
				}
				CLEditorTools.EndContents ();
			}
		}
	}

	/// <summary>
	/// Gets the mat textures reference.
	/// 取得材质球及贴图引用关系
	/// </summary>
	public void setModelRef ()
	{
		modelMgr.data.Clear ();
		getModelRef (modelMgr.transform);
	}
	
	public void getModelRef (Transform tr)
	{
		ArrayList meshList = new ArrayList ();
		MeshFilter[] rds = tr.GetComponents<MeshFilter> ();
		SkinnedMeshRenderer[] smds = tr.GetComponents<SkinnedMeshRenderer> ();
		meshList.AddRange (rds);
		meshList.AddRange (smds);
		Mesh mesh = null;
		object obj = null;
		for (int i = 0; i < meshList.Count; i++) {
			obj = meshList [i];
			if (obj == null)
				continue;
			MeshFilter mf = null;
			SkinnedMeshRenderer smr = null;
			if(obj is MeshFilter) {
				mf = (MeshFilter)obj;
				mesh = mf.sharedMesh;
			} else if(obj is SkinnedMeshRenderer) {
				smr = (SkinnedMeshRenderer)obj;
				mesh = smr.sharedMesh;
			}
			if (mesh != null) {
				CLModel clMat = new CLModel ();
				clMat.meshFilter = mf;
				clMat.skinnedMesh = smr;
//				clMat.mesh = rd.sharedMesh;
				clMat.meshName = mesh.name;
				clMat.model4Editor = CLEditorTools.getPathByObject (mesh);
				if (!clMat.model4Editor.Contains ("/upgradeResMedium/")) {
					Debug.LogError ("The Model is not in the [upgradeResMedium] Directory!!!!");
				}
				modelMgr.data.Add (clMat);
			}
		}

		for (int i=0; i < tr.childCount; i++) {
			getModelRef (tr.GetChild (i));
		}
	}
}
