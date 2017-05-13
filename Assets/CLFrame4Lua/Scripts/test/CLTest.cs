using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CLTest : MonoBehaviour {
	List<Vector3> raceList = new List<Vector3>();
	int times = 0;

	// Use this for initialization
	void Start () {
		times = 0;
//		addList();
	}
	int flag =1;
	public void addList() {
//		flag = times%2 == 0 ? 1 : -1;
		Vector3 v3 = VectorToolkits.getCirclePointV3(transform.position ,3, -transform.eulerAngles.y + flag*times*10);
		raceList.Add(v3);
		v3 = VectorToolkits.getCirclePointV3(transform.position ,3, -transform.eulerAngles.y - flag*times*10);
		raceList.Add(v3);
		times++;
		Invoke("addList" , 2);
	}

	public void fire(int numPoints, int numEach, float angle,SUnit attacker)
	{
		raceList.Clear();
		if (numPoints > 0) {
			// get fire point
			bool needFireMid = false;	//是否需要在中间发射（是奇数时需要）
			int half = numPoints / 2;
			if (numPoints % 2 == 0) {
				needFireMid = false;
			} else {
				needFireMid = true;
			}

			Vector3 pos2 = Vector3.zero;
			Vector3 dir = Vector3.zero;
			for (int i = 0; i < numEach; i++) {
				if (needFireMid) {
					raceList.Add(attacker.mbody.forward*1);
				}
				for (int j =1; j <= half; j++) {
					pos2 = VectorToolkits.getCirclePointStartWithYV3(transform.position, 2, attacker.mbody.eulerAngles.y - j * angle);
					raceList.Add(pos2);
					
					pos2 = VectorToolkits.getCirclePointStartWithYV3(transform.position, 2, attacker.mbody.eulerAngles.y + j * angle);
					raceList.Add(pos2);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	#if UNITY_EDITOR
	Matrix4x4  boundsMatrix;
	void OnDrawGizmos() {
//		if(center == null) return;
		
//		boundsMatrix.SetTRS (center.position, Quaternion.Euler (girdRotaion),new Vector3 (aspectRatio,1,1));
		//		AstarPath.active.astarData.gridGraph.SetMatrix();
		//		Gizmos.matrix =  AstarPath.active.astarData.gridGraph.boundsMatrix;
		//		Gizmos.matrix = boundsMatrix;
		Gizmos.color = Color.red;
		for(int i =0;i < raceList.Count ;i++) {
			Gizmos.DrawWireCube(raceList[i], Vector3.one*0.2f);
		}
		Gizmos.color = Color.white;
//		Gizmos.matrix = Matrix4x4.identity;
	}
	#endif
}
