using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

#if UNITY_3_5
[CustomEditor(typeof(CLTextureMgr))]
#else
[CustomEditor(typeof(CLTextureMgr), true)]
#endif
public class CLTextureMgrInspector : Editor
{
	CLTextureMgr textureMgr;
	CLTexture mat;
	bool isShowTexturesRef = false;
	string buttonName = "";

	public override void OnInspectorGUI ()
	{
//		base.OnInspectorGUI ();
		textureMgr = (CLTextureMgr)(target);
		
		if (GUILayout.Button ("Get Material Reference")) {
			setMatTexturesRef ();
		}
		if (GUILayout.Button ("Clean Material Reference")) {
			textureMgr.cleanMat ();
		}

		if (GUILayout.Button ("Reset Material Reference")) {
			textureMgr.resetMat ();
		}

		if (isShowTexturesRef) {
			buttonName = "Hide  Material Reference";
		} else {
			buttonName = "Show  Material Reference";
		}
		if (GUILayout.Button (buttonName)) {
			isShowTexturesRef = !isShowTexturesRef;
		}
		if (isShowTexturesRef) {
			for (int i=0; i < textureMgr.data.Count; i++) {
				CLEditorTools.BeginContents ();
				{
					mat = textureMgr.data [i];

					GUILayout.BeginHorizontal ();
					{

						GUILayout.BeginVertical ();
						{
							GUILayout.BeginHorizontal ();
							{
								EditorGUILayout.ObjectField (mat.render, typeof(UnityEngine.Object));
								EditorGUILayout.ObjectField (mat.material, typeof(UnityEngine.Object));
							}
							GUILayout.EndHorizontal ();

							EditorGUILayout.TextField (mat.texture);
							EditorGUILayout.TextField (mat.texture4Editor);
							if (!mat.texture4Editor.Contains ("/upgradeResMedium/")) {
								GUI.color = Color.yellow;
								GUILayout.Label("Texture is not in [upgradeResMedium]!");
								GUI.color = Color.white;
							}
						}
						GUILayout.EndVertical ();
						EditorGUILayout.ObjectField ("", (Texture2D)(CLEditorTools.getObjectByPath (mat.texture4Editor)), 
						                             typeof(Texture2D), false, GUILayout.MinWidth (0));
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
	public void setMatTexturesRef ()
	{
		textureMgr.data.Clear ();
		getMatTexturesRef (textureMgr.transform);
	}
	
	public void getMatTexturesRef (Transform tr)
	{
		Renderer[] rds = tr.GetComponents<Renderer> ();
		Renderer rd = null;
		for (int r = 0; r < rds.Length; r++) {
			rd = rds [r];
			if (rd == null)
				continue;
//			if (rd.materials != null && rd.materials.Length > 0) {
//				for (int i =0; i < rd.materials.Length; i++) {
//					if (rd.materials [i] == null)
//						continue;
//					if (rd.sharedMaterial == rd.materials [i]) {
//						continue;
//					}
//					CLTexture clMat = new CLTexture ();
//					clMat.render = rd;
//					clMat.material = rd.materials [i];
//					if (rd.materials [i].mainTexture != null) {
//						clMat.texture = CLEditorTools.getPathByObject (rd.materials [i].mainTexture);
//						clMat.texture = clMat.texture.Replace ("/upgradeResMedium/", "/upgradeRes/");
//					}
//					textureMgr.data.Add (clMat);
//				}
//			}

			if (rd.sharedMaterial != null && rd.sharedMaterial.mainTexture != null) {
				CLTexture clMat = new CLTexture ();
				clMat.render = rd;
				clMat.material = rd.sharedMaterial;
				clMat.texture4Editor = CLEditorTools.getPathByObject (rd.sharedMaterial.mainTexture);
				if (!clMat.texture4Editor.Contains ("/upgradeResMedium/")) {
					Debug.LogError ("The texture is not in the [upgradeResMedium] Directory!!!!");
				}
				textureMgr.data.Add (clMat);
			}
		}

		for (int i=0; i < tr.childCount; i++) {
			getMatTexturesRef (tr.GetChild (i));
		}
	}
}
