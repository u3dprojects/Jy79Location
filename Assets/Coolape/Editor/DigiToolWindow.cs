using UnityEngine;
using UnityEditor;
using System.Collections;
using Toolkit;
using System.IO;
using System.Collections.Generic;
using System;

public class DigiToolWindow : EditorWindow
{
	Vector2 scrollPos = Vector2.zero;
	SerializedObject mSerialObj;

	public Color mTestColor = Color.white;
	public string mTestColorCode = "";
	public string mNewSpriteName = "";
	public string mWidgetFixDepth = "1";
	void OnGUI ()
	{
		if (mSerialObj == null) mSerialObj = new SerializedObject(this);

		scrollPos = EditorGUILayout.BeginScrollView (scrollPos);
		GUILayout.BeginHorizontal ();
		{
			if (GUILayout.Button ("Altas reset", GUILayout.Width (80))) {
				TestFunc1 ();
			}

			if (GUILayout.Button ("To EmptyAltas", GUILayout.Width (80))) {
				SetAllSpriteUseEmptyAltas();
			}

			GUI.contentColor = new Color(0.00f, 0.83f, 1.0f, 1.0f);
			if (GUILayout.Button ("Selction ObjPath", GUILayout.Width (80))) {
				TestFunc2 ();
			}
			GUI.contentColor = Color.white;
		}
		GUILayout.EndHorizontal ();

		if (NGUIEditorTools.DrawHeader("Widget Tools"))
		{
			GUILayout.BeginHorizontal ();
			{
				if (GUILayout.Button ("Bound", GUILayout.Width (100))) {
					TestWidgetFixByChild ();
				}
				if (GUILayout.Button ("Pos", GUILayout.Width (100))) {
					TestWidgetFixPosition ();
				}
			}
			GUILayout.EndHorizontal ();
			GUILayout.BeginHorizontal ();
			{
				GUILayout.Label ("Reset Depth, Star at:");
				mWidgetFixDepth = GUILayout.TextField(mWidgetFixDepth, GUILayout.MinWidth (32));
				// mWidgetFixDepth = EditorGUILayout.TextField("", mWidgetFixDepth, GUILayout.MinWidth (32));
				if (GUILayout.Button ("Reset", GUILayout.Width (60))) {
					TestWidgetFixDepth();
				}
			}
			GUILayout.EndHorizontal ();
		}

		NGUIEditorTools.BeginContents ();
		{
			GUI.color = Color.white;

			GUILayout.BeginHorizontal ();
			{
				GUILayout.BeginVertical();
				{
					//GUILayout.Space(5);
					// NGUIEditorTools.DrawProperty("Color", mSerialObj, "mTestColor", GUILayout.Width (240f));
					//GUILayout.Space(5);
				}
				GUILayout.EndVertical();
			}
			GUILayout.EndHorizontal ();

			Color buf = mTestColor;
			mTestColor = EditorGUILayout.ColorField("Color", mTestColor, GUILayout.Width (220f));
			if (buf != mTestColor) {
				Color clr = mTestColor;
				mTestColorCode = 
					string.Format (" new Color({0:F2}f,{1:F2}f,{2:F2}f,{3:F2}f); ",
					               clr.r, clr.g, clr.b, clr.a);
			}
			GUILayout.BeginHorizontal ();
			{
				mTestColorCode = EditorGUILayout.TextField("", mTestColorCode, GUILayout.MinWidth (80));
				if (GUILayout.Button ("Copy", GUILayout.MinWidth (80) )) {
					TestShowColorValue();
				}
			}
			GUILayout.EndHorizontal ();
		}
		NGUIEditorTools.EndContents ();


		if (NGUIEditorTools.DrawHeader("Sprite Tools"))
		{
			NGUIEditorTools.BeginContents();
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label ("Sprite Name:");
				mNewSpriteName = EditorGUILayout.TextField("", mNewSpriteName, GUILayout.MinWidth (50));
				if (GUILayout.Button ("Change", GUILayout.MinWidth (48) )) {
					ChangeSpriteName();
				}
			}
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			{
				GUILayout.Label ("Hero icon box:");
				if (GUILayout.Button ("Generate", GUILayout.MinWidth (48) )) {
					GenerateAltasSprite();
				}

				if (GUILayout.Button ("Resort", GUILayout.MinWidth (48) )) {
					ResortAltasSprite();
				}
			}
			GUILayout.EndHorizontal();

			NGUIEditorTools.EndContents();
		}

		EditorGUILayout.EndScrollView ();
	}

	void OnInspectorUpdate() {
		Repaint();
	}
	void OnSelectionChange() { Repaint(); }

	enum AtlasType
	{
		Normal,
		Reference,
	}

	AtlasType GetAtlasType(UIAtlas atlas)
	{
		if (atlas.replacement != null)
		{
			return AtlasType.Reference;
		}
		return AtlasType.Normal;
	}

	void SetAllSpriteUseEmptyAltas()
	{
		UnityEngine.Object selectObj = Selection.activeObject;
		if (selectObj == null) {
			Debug.Log ("Not found Selection.activeObject.");
			return;
		}

		string emptypath = "Assets/new3g/Resources/Atlas/EmptyAltas.prefab";
		UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath (emptypath, typeof(UnityEngine.Object));
		if(obj == null) {
			Debug.Log ("Not found EmptyAltas.");
			return;
		}
	
		{
			UIAtlas emptyAtlas = ((GameObject)obj).GetComponent<UIAtlas>();

			string text = "SelectObj Type=" + selectObj.GetType().FullName;
			Debug.Log(text);

			if (selectObj.GetType() == typeof(GameObject) )
			{
				GameObject root = selectObj as GameObject;
				UISprite[] sprites = root.GetComponentsInChildren<UISprite>();
				int imax = sprites.Length;
				int changedCount = 0;
				for (int i = 0; i < imax; ++i)
				{
					UISprite s = sprites[i];
					if (s.atlas == null || s.atlas.name != "EmptyAltas")
					{
						s.atlas = emptyAtlas;
						changedCount++;
					}
				}
				text = "Got sprite count=" + imax + ", changed=" + changedCount;
				Debug.Log (text);
			}
			return;
		}
	}

	void TestFunc1 ()
	{
		string filepath = "Assets/new3g/Resources/Atlas/EmptyAltas.prefab";
		string refpath = "Assets/new3g/upgradeResMedium/priority/atlas/atlasAllReal.prefab";

		UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath (filepath, typeof(UnityEngine.Object));
		if(obj != null) {
			UIAtlas emptyAtlas = ((GameObject)obj).GetComponent<UIAtlas>();

			AtlasType type = GetAtlasType(emptyAtlas);
			if (type == AtlasType.Reference)
			{
				Debug.Log ("EmptyAltas is Reference!");
			}
			else
			{
				UnityEngine.Object refobj = AssetDatabase.LoadAssetAtPath (refpath, typeof(UnityEngine.Object));
				if (refobj == null) {
					Debug.Log ("Not found altasAllReal.");
					return;
				}
				UIAtlas altasAllReal = ((GameObject)refobj).GetComponent<UIAtlas>();

				if (altasAllReal != null) {
					NGUIEditorTools.RegisterUndo("Altas Change", emptyAtlas);
					emptyAtlas.replacement = altasAllReal;
					NGUITools.SetDirty(emptyAtlas);
				}
				Debug.Log ("EmptyAltas reset!");
			}
		} else {
			Debug.Log ("Not found EmptyAltas.");
		}
	}
    
	void TestFunc2()
	{
		UnityEngine.Object selectObj = Selection.activeObject;
		if (selectObj == null) {
			Debug.Log ("Not found Selection.activeObject.");
		} else {
			string path = AssetDatabase.GetAssetPath(selectObj);
			CopyTextToClip(path);
		}
	}

	void CopyTextToClip(string text)
	{
		TextEditor te = new TextEditor();//很强大的文本工具
		te.content = new GUIContent(text);
		te.OnFocus();
		te.Copy();
		
		Debug.Log ("Copyed:\n" + text);
	}

	void TestShowColorValue()
	{
		CopyTextToClip(mTestColorCode);
	}

	void SwitchChildren(Transform a, Transform b)
	{
		int cnt = a.childCount;
		if ( cnt > 0 ) {
			Transform[] cache = new Transform[cnt];
			for (int i = 0; i < cnt; i++)
			{
				cache[i] = a.GetChild(i);
			}
			for (int i = 0; i < cnt; i++)
			{
				Transform c = cache[i];
				c.parent = b;
			}
		}
	}

	void TestWidgetFixByChild()
	{
		UnityEngine.Object selectObj = Selection.activeObject;
		UIWidget rootWidget = ((GameObject)selectObj).GetComponent<UIWidget>();
		if (rootWidget == null) {
			Debug.Log ("Selection is not UIWidget!");
			return;
		}
		rootWidget.enabled = false;
		{
			Transform t = rootWidget.transform;

			Transform p = t.parent;
			GameObject tmp = NGUITools.AddChild(p.gameObject);

			SwitchChildren(t, tmp.transform);
			{
				Bounds b = NGUIMath.CalculateRelativeWidgetBounds(tmp.transform, false);
				Vector3 c = b.center;
				t.localPosition = new Vector3(Mathf.RoundToInt(c.x), 
				                              Mathf.RoundToInt(c.y), 
				                              Mathf.RoundToInt(c.z) );
				rootWidget.width = (int)b.size.x;
				rootWidget.height = (int)b.size.y;
				Debug.Log ("Widgets Fix => pos" + b.center + " size="+ rootWidget.width + "x" + rootWidget.height);
			}
			SwitchChildren(tmp.transform, t);
			NGUITools:DestroyImmediate(tmp);
		}
		rootWidget.enabled = true;
	}

	void TestWidgetFixPosition()
	{
		UnityEngine.Object selectObj = Selection.activeObject;
		UIWidget rootWidget = ((GameObject)selectObj).GetComponent<UIWidget>();
		if (rootWidget == null) {
			Debug.Log ("Selection is not UIWidget!");
			return;
		}
		Transform root = rootWidget.transform;
		UIWidget[] ws = root.GetComponentsInChildren<UIWidget>();
		int imax = ws.Length;
		int chng = 0;
		for (int i = 0; i< imax; ++i)
		{
			UIWidget w = ws[i];
			Transform t = w.transform;
			Vector3 c = w.transform.localPosition;
			Vector3 n = new Vector3(Mathf.RoundToInt(c.x), 
			                		Mathf.RoundToInt(c.y), 
			            		    Mathf.RoundToInt(c.z) );
			if (n != c ) {
				t.localPosition = n;
				chng++;
			}
		}
		Debug.Log ("Widget ["+root.name+"] position Fixed! changed cnt="+ chng);
	}

	void TestWidgetFixDepth()
	{
		int start_depth = 1;
		if (Int32.TryParse(mWidgetFixDepth, out start_depth))
		{
			UnityEngine.Object[] selections = Selection.objects;
			int imax = selections.Length;
			int chng = 0;
			for (int i = 0; i< imax; ++i)
			{
				GameObject o = selections[i] as GameObject;
				UIWidget[] wes = o.GetComponentsInChildren<UIWidget>();
				int jmax = wes.Length;
				for (int j = 0; j < jmax; ++j)
				{
					UIWidget w = wes[j];
					if ( w != null ) {
						w.depth = start_depth + chng;
						chng++;
					}
				}
			}
			Debug.Log ("Widgets depth Fixed! changed cnt="+ chng);
		}
		else
		{
			Debug.Log ("String could not be parsed.");
		}
	}

	void ChangeSpriteName()
	{
		UnityEngine.Object[] selections = Selection.objects;
		int imax = selections.Length;
		int chng = 0;
		for (int i = 0; i< imax; ++i)
		{
			GameObject o = selections[i] as GameObject;
			UISprite s = o.GetComponent<UISprite>();
			if ( s != null ) {
				s.spriteName = mNewSpriteName;
				chng++;
			}
		}
		Debug.Log ("Sprite change to ["+mNewSpriteName+"] !cnt="+ chng);
	}


	void GenerateAltasSprite()
	{
		string refpath = "Assets/new3g/upgradeResMedium/priority/atlas/atlasAllReal.prefab";
		UnityEngine.Object refobj = AssetDatabase.LoadAssetAtPath (refpath, typeof(UnityEngine.Object));
		if (refobj == null) {
			Debug.Log ("Not found altasAllReal.");
			return;
		}
		UIAtlas altasAllReal = ((GameObject)refobj).GetComponent<UIAtlas>();
		int chng = 0;
		if (altasAllReal != null) {
			Hashtable spriteMap = altasAllReal.spriteMap;
			List<string> duplist = new List<string>();
			int imax = 10;
			for (int i = 1; i < imax; i++) {
				string spname = string.Format("hero_{0}_b", i);
				string hdname = string.Format("hero_{0}_h", i);
				UISpriteData spd = altasAllReal.GetSprite(spname);
				UISpriteData head = altasAllReal.GetSprite(hdname);

				string text = "Change:" + spname + "[" + (spd != null) + "]->" + hdname 
					+ "[" + (head != null) + "]";
//				Debug.Log (text);

				if (spd == null )
					break;

				if ( head == null)
				{
					string dupname = UIAtlasMaker.DuplicateSprite(altasAllReal, spname); 
					if (dupname != null) {
						head = altasAllReal.GetSprite(dupname);
						head.name = hdname;
						head.x = 0;
						head.y = 69;
						head.width = 110;
						head.height = 110;
						chng++;
					}
				}
			}

			if (chng>0)
			{
				altasAllReal.spriteMap.Clear ();
				List<UISpriteData> spriteList = altasAllReal.spriteList;
				int imax2 = spriteList.Count;
				for (int i = 0; i < imax2; i++) {
					UISpriteData tmpsp = spriteList[i];
					altasAllReal.spriteMap [tmpsp.name] = i;
				}
				NGUITools.SetDirty(altasAllReal);
				UIAtlasMaker.instance.Repaint();
			}
		}
		Debug.Log ("altasAllReal changed!"+" cnt="+ chng);
	}

	void ResortAltasSprite()
	{
		string refpath = "Assets/new3g/upgradeResMedium/priority/atlas/atlasAllReal.prefab";
		UnityEngine.Object refobj = AssetDatabase.LoadAssetAtPath (refpath, typeof(UnityEngine.Object));
		if (refobj == null) {
			Debug.Log ("Not found altasAllReal.");
			return;
		}
		UIAtlas altasAllReal = ((GameObject)refobj).GetComponent<UIAtlas>();
		int chng = 0;
		if (altasAllReal != null) {

			List<UISpriteData> spriteList = altasAllReal.spriteList;
			spriteList.Sort(delegate(UISpriteData r1, UISpriteData r2) {
				return r2.name.CompareTo(r1.name) * -1; });

			altasAllReal.spriteMap.Clear ();
			int imax2 = spriteList.Count;
			for (int i = 0; i < imax2; i++) {
				UISpriteData tmpsp = spriteList[i];
				altasAllReal.spriteMap [tmpsp.name] = i;
			}
			NGUITools.SetDirty(altasAllReal);
			UIAtlasMaker.instance.Repaint();
		}
		Debug.Log ("altasAllReal resort!"+" cnt="+ chng);
	}
}
