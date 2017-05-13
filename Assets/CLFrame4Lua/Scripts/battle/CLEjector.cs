using UnityEngine;
using System.Collections;

/// <summary>
/// CL ejector.发射器
/// </summary>
using Toolkit;
using LuaInterface;

public class CLEjector : MonoBehaviour
{
	public SUnit role;
	Transform _transform;
	ListPool listPool = new ListPool ();
	public Transform[] firePoints;

	public Transform transform {
		get {
			if(_transform == null) {
				_transform = gameObject.transform;
			}
			return _transform;
		}
	}
	
	public void fire (int numPoints, int numEach, float angle, SUnit attacker, SUnit target, object attr, object data, object callbak)
	{
		fire (-1, numPoints, numEach, angle, attacker, target, attr, data, callbak);
	}

	public void fire (int firePointIndex, int numPoints, int numEach, float angle, SUnit attacker, SUnit target, object attr, object data, object callbak)
	{
		if(attacker == null || attr == null) {
			return;
		}
#if UNITY_EDITOR
		CLTest cltest = GetComponent<CLTest>();
		if(cltest == null) {
			cltest = gameObject.AddComponent<CLTest>();
		}
		cltest.fire ( numPoints, numEach, angle, attacker);
#endif

		Transform firePoint = null;
		if (firePointIndex < 0 || firePoints == null || firePoints.Length <= firePointIndex) {
			firePoint = transform;
		} else {
			firePoint = firePoints [firePointIndex];
		}

		int h = NumEx.bio2Int (MapEx.getBytes (attr, "High"));
		bool isZeroY = h > 0 ? true : false;
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
					dir = attacker.mbody.forward;
					if (isZeroY) {
						dir.y = 0;
					}
//					StartCoroutine (createBullet (attacker, target, firePoint.position, dir, attr, data, callbak, i * 0.1f));
					object[] list = {
						attacker,
						target,
						firePoint.position,
						dir,
						attr,
						data,
						callbak
					};
					role.fixedInvoke ((Callback)createBullet2, list, i * 0.1f);
				}
				for (int j =1; j <= half; j++) {
					pos2 = VectorToolkits.getCirclePointStartWithYV3 (firePoint.position, 2, attacker.mbody.eulerAngles.y - j * angle);
					if (isZeroY) {
						pos2.y = 0;
					}
					dir = pos2 - firePoint.position;
//					StartCoroutine (createBullet (attacker, target, firePoint.position, dir, attr, data, callbak, i * 0.1f));
					object[] list = {
						attacker,
						target,
						firePoint.position,
						dir,
						attr,
						data,
						callbak
					};
					role.fixedInvoke ((Callback)createBullet2, list, i * 0.1f);

					pos2 = VectorToolkits.getCirclePointStartWithYV3 (firePoint.position, 2, attacker.mbody.eulerAngles.y + j * angle);
					if (isZeroY) {
						pos2.y = 0;
					}
					dir = pos2 - firePoint.position;
//					StartCoroutine (createBullet (attacker, target, firePoint.position, dir, attr, data, callbak, i * 0.1f));
					object[] list2 = {
						attacker,
						target,
						firePoint.position,
						dir,
						attr,
						data,
						callbak
					};
					role.fixedInvoke ((Callback)createBullet2, list2, i * 0.1f);
				}
			}
		}
	}
	
	void createBullet2 (params object[] paras)
	{
		if (paras == null)
			return;
		object[] list = (object[])(paras [0]);
		if (list.Length >= 7) {
			SUnit attacker = (SUnit)(list [0]);
			SUnit target = (SUnit)(list [1]);
			Vector3 orgPos = (Vector3)(list [2]);
			Vector3 dir = (Vector3)(list [3]); 
			object attr = (object)(list [4]); 
			object data = (object)(list [5]); 
			object callbak = (object)(list [6]);
			CLBullet.fire (attacker, target, orgPos, dir, attr, data, callbak);
		}
		list = null;
	}

	IEnumerator createBullet (SUnit attacker, SUnit target, Vector3 orgPos, Vector3 dir, object attr, object data, object callbak, float waitSeconds)
	{
		yield return new WaitForSeconds (waitSeconds);
		CLBullet.fire (attacker, target, orgPos, dir, attr, data, callbak);
	}
}
