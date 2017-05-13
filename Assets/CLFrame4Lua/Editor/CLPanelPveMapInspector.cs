using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using Toolkit;

//页面视图
#if UNITY_3_5
[CustomEditor(typeof(CLPanelPveMap))]
#else
[CustomEditor(typeof(CLPanelPveMap), true)]
#endif
public class CLPanelPveMapInspector : CLPanelLuaInspector
{
	CLPanelPveMap pnl;
    int mapIndex = 1;
    int pageSize = 10;
	public override void OnInspectorGUI()
	{
        base.OnInspectorGUI();
        pnl = target as CLPanelPveMap;
        GUILayout.BeginHorizontal();
        {
            mapIndex = EditorGUILayout.IntField("page:",mapIndex);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        {
            pageSize = EditorGUILayout.IntField("pageSize:", pageSize);
            if (GUILayout.Button("RecordMapPos")) {
                if (mapIndex > 0) {
                    int len = pageSize;
                    int size = mapIndex * len;
                    int sizeOld = 0;
                    // old value deal with those;
                    Vector3[] tmpV3s = null;
                    if (pnl.npcPos != null && pnl.npcPos.Length > 0)
                    {
                        sizeOld = pnl.npcPos.Length;
                        tmpV3s = new Vector3[sizeOld];
                        for (int i = 0; i < sizeOld; i++)
                        {
                            tmpV3s[i] = pnl.npcPos[i];
                        }
                    }


                    int curSize = size > sizeOld ? size : sizeOld;
                    pnl.npcPos = new Vector3[curSize];
                    int bgIndex = (mapIndex - 1) * len;
                    int edIndex = bgIndex + len;
                    for (int i = 0; i < curSize; i++)
                    {
                        if (i >= bgIndex && i < edIndex)
                        {
                            int v = i % pageSize + 1;
                            string inStr = v < 10 ? "0" + v : v + "";
                            Transform tmpTrsf = pnl.trsfNpcWrap.FindChild("CellNpc" + inStr);
                            if (tmpTrsf != null)
                            {
                                pnl.npcPos[i] = new Vector3(tmpTrsf.localPosition.x, tmpTrsf.localPosition.y, tmpTrsf.localPosition.z);
                            }
                        }else {
                            if (i < sizeOld)
                            {
                                pnl.npcPos[i] = tmpV3s[i];
                            }
                        }
                    }
                }
            }
        }
        GUILayout.EndHorizontal();
	}
}
