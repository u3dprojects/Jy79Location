using UnityEngine;
using System.Collections;

public class CLLifebarTiled : MonoBehaviour
{
	public UISlider slider;
	public float totalLength = 0;
	public float tileLength = 1;
	public float HPperTile = 1;
	public int maxN = 50;

	public void init (float maxHP)
	{
		if (HPperTile > 0) {
			float n = maxHP / HPperTile;
			n = n > maxN ? maxN : n;
			int len = Mathf.CeilToInt (tileLength * n);
			slider.foregroundWidget.width = len;
			Vector3 v3 = slider.foregroundWidget.transform.localScale;
			v3.x = totalLength / len;
			slider.foregroundWidget.transform.localScale = v3;
		}
	}
}
