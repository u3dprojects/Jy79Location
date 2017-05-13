using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(CLUIPlaySound), true)]
public class CLUIPlaySoundInspector : Editor {
	
	CLUIPlaySound instance;
	Object asset = null;
	
	public override void OnInspectorGUI ()
	{
		instance = target as CLUIPlaySound;
		DrawDefaultInspector ();
		
		if (instance != null) {
			init ();
			NGUIEditorTools.BeginContents ();
			{
				GUILayout.BeginHorizontal ();{
					EditorGUILayout.LabelField ("AudioClip", GUILayout.Width (100));
					asset = EditorGUILayout.ObjectField (asset, typeof(UnityEngine.Object), GUILayout.Width (125));
				}
				GUILayout.EndHorizontal ();
				string soundPath = CLEditorTools.getPathByObject (asset);
				instance.soundFileName = Path.GetFileName(soundPath);
				instance.soundName = Path.GetFileNameWithoutExtension(soundPath);
				EditorUtility.SetDirty (instance);
			}
			NGUIEditorTools.EndContents ();
			
		}
	}
	
	bool isFinishInit = false;
	
	void init ()
	{
		if (!isFinishInit || asset == null) {
			isFinishInit = true;
			
			if (!string.IsNullOrEmpty (instance.soundFileName) && PathCfg.self != null) {
				string tmpPath = PathCfg.self.basePath+"/upgradeResMedium/other/sound/" + instance.soundFileName;
				asset =  CLEditorTools.getObjectByPath(tmpPath);
			}
		}
	}
}
