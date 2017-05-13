using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;
using Toolkit;

public class CLEditorUtl {

	//get map cell's attr
	public static  Hashtable getCfgData(string cfgFileName) {
		Hashtable map = new Hashtable ();
		string path =  Application.dataPath + "/" +  PathCfg.self.basePath + "/DBCfg/DBJson/"+cfgFileName+".json";
		string content = File.ReadAllText (path);
		ArrayList list = JSON.DecodeList (content);
		if (list == null || list.Count < 2) {
			return map;
		}
		ArrayList keyList = (ArrayList)(list[0]);
		ArrayList _list = null;
		Hashtable val = null;
		for(int i = 1; i < list.Count; i++) {
			_list = (ArrayList)(list[i]);
			val = new Hashtable();
			for(int j = 0; j < _list.Count; j++) {
				val[keyList[j]] = _list[j];
			}
			map[val["ID"].ToString()] = val;
		}
		return map;
	}

	public static string getHierarchyPath(Transform tr, bool needRoot) {
		if (tr == null)
			return "";
		string outPath = tr.name;
		if (tr.parent != null) {
			if(needRoot) {
				outPath = getHierarchyPath (tr.parent, needRoot) + "/" + outPath;
			} else {
				if(tr.parent.parent != null) {
					outPath = getHierarchyPath (tr.parent, needRoot) + "/" + outPath;
				}
			}
		}
		return outPath;
	}
}
