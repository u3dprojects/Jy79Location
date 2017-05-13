using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Toolkit
{
    public class CalcEx
    {
        // 百分比
        public static float percent(float v1, float max)
        {
            if (max == 0) return 0;
            return v1 / max;
        }

        public static double percent(double v1, double max)
        {
            if (max == 0) return 0;
            return v1 / max;
        }

        public static int percentInt(double v1, double max)
        {
            if (max == 0) return 0;
            double v = v1 / max;
            return (int)Math.Ceiling((v * 100));
        }

        // 总页数
        public static int pageCount(int count, int pageSize)
        {
            int page = count / pageSize;

            page = count == page * pageSize ? page : page + 1;
            return page;
        }

        // 取某一页的数据
        public static ArrayList getPage(ArrayList datas, int page, int pageSize)
        {
            int count = datas.Count;
            int begin = (int)(page * pageSize);
            int end = (int)(begin + pageSize);
            if (begin > count || begin < 0 || end < 0)
                return new ArrayList();
            end = count < end ? count : end;
            if (end <= begin)
                return new ArrayList();
            int num = end - begin;
            return datas.GetRange(begin, num);
        }

        public static float Distance(GameObject g1, GameObject g2)
        {
            if (g1 == null || g2 == null)
                return 0;
            Vector3 x1 = g1.transform.localPosition;
            Vector3 x2 = g2.transform.localPosition;
            float d = Vector3.Distance(x1, x2);
            return d;
        }
    }

    public class DistanceComparer : IComparer
    {
        public int Compare(object o1, object o2)
        {
            if (!(o1 is GameObject) || !(o2 is GameObject))
                return 0;

            GameObject g1 = (GameObject)o1;
            GameObject g2 = (GameObject)o2;
            float d = CalcEx.Distance(g1, g2);
            return d > 0 ? -1 : 1;
        }
    }

    /*
    public class DistanceComparer2 : IComparer
    {
        private GameObject go;

        public DistanceComparer2 (GameObject go)
        {
            this.go = go;
        }
	
        public int Compare (object o1, object o2)
        {
            if (!(o1 is Fleet) || !(o2 is Fleet))
                return 0;
		
            GameObject g1 = ((Fleet)o1).gameObject;
            GameObject g2 = ((Fleet)o2).gameObject;
		
            float d1 = CalcEx.Distance (go, g1);
            float d2 = CalcEx.Distance (go, g2);
		
            return (d1 - d2) > 0 ? -1 : 1;
        }
    }
    */
}