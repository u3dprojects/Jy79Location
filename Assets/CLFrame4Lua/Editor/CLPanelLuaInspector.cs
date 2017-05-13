using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

//页面视图
#if UNITY_3_5
[CustomEditor(typeof(CLPanelLua))]
#else
[CustomEditor(typeof(CLPanelLua), true)]
#endif
public class CLPanelLuaInspector : CLBehaviour4LuaInspector
{
	CLPanelLua panel;
	Object panelData;

	public override void OnInspectorGUI()
	{
		panel = target as CLPanelLua;
		base.OnInspectorGUI();
		NGUIEditorTools.BeginContents();
		{
			GUILayout.Space(3);
//			if (GUILayout.Button("Reload Lua")) {
//				reloadLua();
//			}
			if (GUILayout.Button("Reset Atlas & Font")) {
				if (panel.isNeedResetAtlase) {
					CLPanelManager.resetAtlasAndFont(panel.transform, false);
					CLUIInit.self.clean();
				}
			}
			if (GUILayout.Button("Save Panel 2 U3dType")) {
				saveToU3d();
			}
		}
		NGUIEditorTools.EndContents();
		GUILayout.Space(5);
	}

	void reloadLua()
	{
		panel.setLua();
	}

	void saveToU3d()
	{
		doSaveAsset(panel);
		EditorUtility.DisplayDialog("success", "cuccess!", "Okey");
	}
	public static void doSaveAsset(CLPanelLua panel) {
		if(panel == null) return;
		Debug.Log(panel.name);
		if (panel.isNeedResetAtlase) {
			CLPanelManager.resetAtlasAndFont(panel.transform, true);
		}
		
        string dir = Application.dataPath + "/" + PathCfg.self.basePath + "/upgradeRes4Publish/priority/ui/panel";
//		string path = EditorUtility.SaveFilePanel ("Save UI to data", dir, panel.name, "unity3d");
//		if (string.IsNullOrEmpty (path))
//			return;
		CreatUnity3dType.createAssets4Upgrade(dir, panel.gameObject, true);
		
		if (panel != null && panel.isNeedResetAtlase ) {
			CLPanelManager.resetAtlasAndFont(panel.transform, false);
		}
	}
}
