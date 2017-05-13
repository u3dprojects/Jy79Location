//#define FIRST
//#define SECOND
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
public class DetectLeaks : MonoBehaviour
{
	void OnGUI ()
	{
#if FIRST
		GUI.BeginGroup (new Rect(0,0,200,200));
		GUI.Box(new Rect(0, 0, 200, 200), "");
		GUILayout.Label ("All " + FindObjectsOfType (typeof(UnityEngine.Object)).Length);
		GUILayout.Label ("Textures " + FindObjectsOfType (typeof(Texture)).Length);
		GUILayout.Label ("AudioClips " + FindObjectsOfType (typeof(AudioClip)).Length);
		GUILayout.Label ("Meshes " + FindObjectsOfType (typeof(Mesh)).Length);
		GUILayout.Label ("Materials " + FindObjectsOfType (typeof(Material)).Length);
		GUILayout.Label ("GameObjects " + FindObjectsOfType (typeof(GameObject)).Length);
		GUILayout.Label ("Components " + FindObjectsOfType (typeof(Component)).Length);
		GUI.EndGroup();
#endif 
		
#if SECOND
		GUI.BeginGroup (new Rect(400,-200,200,960));
		GUI.Box (new Rect (0, 0, 200, 960), "");
		Object[] objects = FindObjectsOfType (typeof(UnityEngine.Object));
 
		Dictionary<string, int> dictionary = new Dictionary<string, int> ();
 
		foreach (Object obj in objects) {
			string key = obj.GetType ().ToString ();
			if (dictionary.ContainsKey (key)) {
				dictionary [key]++;
			} else {
				dictionary [key] = 1;
			}
		}
 
		List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>> (dictionary);
		myList.Sort (
			delegate(KeyValuePair<string, int> firstPair,
			KeyValuePair<string, int> nextPair)
		{
			return nextPair.Value.CompareTo ((firstPair.Value));
		}
		);
 
		foreach (KeyValuePair<string, int> entry in myList) {
			GUILayout.Label (entry.Key + ": " + entry.Value);
		}
		GUI.EndGroup ();
#endif
	}
}
