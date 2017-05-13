using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

#if UNITY_3_5
[CustomEditor(typeof(CLBehaviour4Lua))]
#else
[CustomEditor(typeof(CLBehaviour4Lua), true)]
#endif
public class CLBehaviour4LuaInspector :CLBaseLuaInspector
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI();
	}
}
