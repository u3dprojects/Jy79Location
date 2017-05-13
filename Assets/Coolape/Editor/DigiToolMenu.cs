using UnityEngine;
using UnityEditor;
using System.Collections;
using Toolkit;
using System.IO;

static public class DigiToolMenu
{
	[MenuItem("Coolape/DigiTool Window", false, 1)]
	static public void LuaProject ()
	{
		EditorWindow.GetWindow<DigiToolWindow> (false, "DigiToolWindow", true);
	}
}
