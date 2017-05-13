using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

//页面视图
using System.Collections.Generic;


#if UNITY_3_5
[CustomEditor(typeof(PathCfg))]
#else
[CustomEditor(typeof(PathCfg), true)]
#endif

public class PathCfgInspector : Editor
{
	PathCfg instance;

	public override void OnInspectorGUI()
	{
		instance = target as PathCfg;

		NGUIEditorTools.BeginContents();
		{
			GUILayout.Space(3);
			
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Project Name");
				instance.basePath = EditorGUILayout.TextField(instance.basePath);
				if (GUILayout.Button("Reset Path")) {
					resetPath();
					EditorUtility.SetDirty(instance);
				}
			}
			GUILayout.EndHorizontal();
		}
		NGUIEditorTools.EndContents();

		DrawDefaultInspector();
	}

	public void resetPath()
	{
		instance.resetPath(instance.basePath);
	}

}
