using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

[CanEditMultipleObjects]
#if UNITY_3_5
[CustomEditor(typeof(CLBaseLua))]
#else
[CustomEditor(typeof(CLBaseLua), true)]
#endif
public class CLBaseLuaInspector :Editor
{
	CLBaseLua instance;
	Object luaAsset = null;

	public override void OnInspectorGUI ()
	{
		instance = target as CLBaseLua;
		DrawDefaultInspector ();
		if (instance != null) {
			init ();
			NGUIEditorTools.BeginContents ();
			{
				GUILayout.BeginHorizontal ();{
					EditorGUILayout.LabelField ("Lua Text", GUILayout.Width (100));
					luaAsset = EditorGUILayout.ObjectField (luaAsset, typeof(UnityEngine.Object), GUILayout.Width (125));
				}
				GUILayout.EndHorizontal ();
				string luaPath = AssetDatabase.GetAssetPath (luaAsset);
				instance.luaPath = Utl.filterPath (luaPath);
				EditorUtility.SetDirty (instance);
				
				GUI.contentColor = Color.yellow;
				EditorGUILayout.LabelField("注意：绑定的lua要求返回luatable");
				GUI.contentColor = Color.white;
			}
			NGUIEditorTools.EndContents ();

		}
	}
	
	bool isFinishInit = false;

	void init ()
	{
		if (!isFinishInit || luaAsset == null) {
			isFinishInit = true;
			
			if (!string.IsNullOrEmpty (instance.luaPath)) {
				string tmpPath = instance.luaPath.Replace("/upgradeRes", "/upgradeResMedium");
				luaAsset = AssetDatabase.LoadMainAssetAtPath ("Assets/" + tmpPath);
			}
		}
	}
}
