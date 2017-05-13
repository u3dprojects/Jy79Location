using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using Toolkit;

public class CLPanelPveMap : CLPanelLua{
    
    public Vector3[] npcPos;
    public Transform trsfNpcWrap;

    public ArrayList getPagePostes(int page, int pageCount = 10)
    {
        ArrayList result = new ArrayList();
        if (npcPos != null && npcPos.Length > 0)
        {
            int maxLen = npcPos.Length;
            page = page < 1 ? 1 : page;
            int beg = (page - 1) * pageCount;
            int end = beg + pageCount;
            if (beg < maxLen)
            {
                for (int i = beg; i < end; i++)
                {
                    if (i < maxLen)
                    {
                        result.Add(npcPos[i]);
                    }
                }
            }
        }
        return result;
    }

    public Vector3 getOneNpcPost(int page, int index, int pageCount = 10) {
        if (npcPos != null && npcPos.Length > 0) {
            int maxLen = npcPos.Length;
            page = page < 1 ? 1 : page;
            int beg = (page - 1) * pageCount;
            int cur = beg + index;
            cur = index;
            if (cur < maxLen) {
                return npcPos[cur];
            }
        }
        return Vector3.zero;
    }
}
