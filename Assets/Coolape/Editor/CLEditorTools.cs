using UnityEngine;
using System.Collections;
using UnityEditor;

public static class CLEditorTools
{

	/// <summary>
	/// Gets the path by object.取得工程对象的路径，但不包含Assets;
	/// </summary>
	/// <returns>The path by object.</returns>
	/// <param name="obj">Object.</param>
	public static string getPathByObject (Object obj)
	{
		if (obj == null)
			return "";
		string tmpPath = AssetDatabase.GetAssetPath (obj.GetInstanceID ());
		if(string.IsNullOrEmpty(tmpPath)) {
			Debug.LogError("Cannot get path! [obj name]=="  + obj.name);
			return "";
		}
		int startPos = 0;
		startPos = tmpPath.IndexOf ("Assets/");
		startPos += 7;
		tmpPath = tmpPath.Substring (startPos, tmpPath.Length - startPos);
		return  tmpPath;
	}

	/// <summary>
	/// Gets the object by path.
	/// </summary>
	/// <returns>The object by path.</returns>
	/// <param name="path">Path.</param>
	public static Object getObjectByPath (string path)
	{
		string tmpPath = path;
		if (!tmpPath.StartsWith ("Assets/")) {
			tmpPath = "Assets/" + tmpPath;
		}
		return AssetDatabase.LoadAssetAtPath (
			tmpPath, typeof(UnityEngine.Object));
	}

	static public void BeginContents ()
	{
		GUILayout.BeginHorizontal();
		EditorGUILayout.BeginHorizontal ("AS TextArea", GUILayout.MinHeight (10f));
		GUILayout.BeginVertical();
		GUILayout.Space(2f);
	}
	
	/// <summary>
	/// End drawing the content area.
	/// </summary>
	
	static public void EndContents ()
	{
		GUILayout.Space (3f);
		GUILayout.EndVertical ();
		EditorGUILayout.EndHorizontal ();
		
		GUILayout.Space (3f);
		GUILayout.EndHorizontal ();
		GUILayout.Space (3f);
	}

}
