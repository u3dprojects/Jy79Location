using UnityEditor;
using UnityEngine;
using System.Collections;


#if UNITY_3_5
[CustomEditor(typeof(CombineChildren))]
#else
[CustomEditor(typeof(CombineChildren), true)]
#endif
public class CombineChildrenInspector : Editor {
	
	CombineChildren combine;
	Object luaAsset = null;
	
	public override void OnInspectorGUI ()
	{
		combine = (CombineChildren)target;
		base.OnInspectorGUI();
		if(GUILayout.Button("Combine to Save")) {
			combine.combineChildren(true);
			EditorUtility.SetDirty(combine);
		}
		if(GUILayout.Button("Combine")) {
			combine.combineChildren();
		}
		
		if(GUILayout.Button("Explain")) {
			combine.explainChildren();
		}

	}
}
