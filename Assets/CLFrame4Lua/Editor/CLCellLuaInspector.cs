using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

//页面视图
#if UNITY_3_5
[CustomEditor(typeof(CLCellLua))]
#else
[CustomEditor(typeof(CLCellLua), true)]
#endif
public class CLCellLuaInspector : CLBehaviour4LuaInspector
{
	CLCellLua cell;

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI();
	}

	public static void doSaveAsset(CLCellLua cell) {
		if (cell.isNeedResetAtlase) {
			CLPanelManager.resetAtlasAndFont(cell.transform, true);
		}
		string dir = Application.dataPath + "/" + CLEditorTools.getPathByObject (cell.gameObject);
		dir = Path.GetDirectoryName (dir);
		CreatUnity3dType.createAssets4Upgrade(dir, cell.gameObject, true);
		
		if (cell != null && cell.isNeedResetAtlase) {
			CLPanelManager.resetAtlasAndFont(cell.transform, false);
		}
	}
}
