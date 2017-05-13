using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UIGridPage), true)]
public class CLUIGridPageInspector : UIGridEditor {

	public override void OnInspectorGUI ()
	{
//		base.OnInspectorGUI ();
		DrawDefaultInspector ();
	}
}
