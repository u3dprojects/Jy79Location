using UnityEditor;
using UnityEngine;
using System.Collections;

//页面视图
using System.Collections.Generic;


#if UNITY_3_5
[CustomEditor(typeof(SRoleAction))]
#else
[CustomEditor(typeof(SRoleAction), true)]
#endif
public class CLRoleActionInspector :  Editor
{
	
	SRoleAction roleAction;
	SEffect effect;
	SRoleAction.Action action = SRoleAction.Action.idel;
	static List<int> pausePersent = new List<int> ();
	static int onePersent = 100;
	static int index = 0;
	
	void onActionCallback (params object[] args) {
		roleAction.pause();
	}
	void onFinishActionCallback (params object[] args) {
		roleAction.regain();
		roleAction.setAction(SRoleAction.Action.idel, null);
	}

	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		NGUIEditorTools.BeginContents ();
		{
			roleAction = (SRoleAction)target;

			GUILayout.BeginHorizontal ();
			{
				action = (SRoleAction.Action)EditorGUILayout.EnumPopup ("Action", action);
				if (GUILayout.Button ("Play")) {
					roleAction.regain();
					index = 0;
					if(pausePersent.Count ==0) return;
					Callback cb = onActionCallback;
					Hashtable cbs = new Hashtable();
					for(int i=0; i < pausePersent.Count;i++) {
						cbs[pausePersent[i]] = cb;
					}
					cbs[100] = (Callback)onFinishActionCallback;
					roleAction.setAction (action, cbs);
					if(effect != null) {
						effect.gameObject.SetActive(true);
					}
				}
				if(GUILayout.Button("Continue")) {
					index++;
					roleAction.regain();
					if(index > pausePersent.Count) {
						index = 0;
						roleAction.setAction(SRoleAction.Action.idel, null);
						return;
					}
				}
			}
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal();
			{
				EditorGUILayout.LabelField("Effect object");
				effect = (SEffect)(EditorGUILayout.ObjectField(effect, typeof(SEffect)));
			}
			GUILayout.EndHorizontal ();
			
			for (int i=0; i < pausePersent.Count; i++) {
				GUILayout.BeginHorizontal ();
				{
					pausePersent[i] = EditorGUILayout.IntField (pausePersent[i], GUILayout.Width (100));
					if (GUILayout.Button ("-")) {
						pausePersent.RemoveAt(i);
						break;
					}
				}
				GUILayout.EndHorizontal ();
			}
			
			GUILayout.BeginHorizontal ();
			{
				onePersent = EditorGUILayout.IntField (onePersent, GUILayout.Width (100));
				if (GUILayout.Button ("+")) {
					onePersent = 100;
					pausePersent.Add(onePersent);
					return;
				}
			}
			GUILayout.EndHorizontal ();
		}
		NGUIEditorTools.EndContents ();
	}
}
