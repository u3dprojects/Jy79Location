using UnityEngine;
using System.Collections;

public class CLEffectLev : MonoBehaviour {
	public GameObject[] levObjs;

	public void setLev(int lev) {
		int m = lev > levObjs.Length?levObjs.Length : lev;
		int i = 0;
		for(i =0; i< m; i++) {
			NGUITools.SetActive(levObjs[i], true);
		}
		for(; i < levObjs.Length; i++) {
			NGUITools.SetActive(levObjs[i], false);
		}
	}
}
