using UnityEngine;
using System.Collections;

/// <summary>
/// S role forward.
/// </summary>
public class SRoleForward : MonoBehaviour
{

	bool _isEnterObstruct = false;
	RaycastHit hitInfor;
	public LayerMask obstrucLayer;
	public float obsDis = 1f;

	Transform _tr;
	public Transform transform {
		get {
			if(_tr == null) {
				_tr = gameObject.transform;
			}
			return _tr;
		}
	}

	public bool isEnterObstruct {
		get {
//			if (!_isEnterObstruct) {
//            Debug.DrawRay(transform.position - transform.forward.normalized*3, transform.forward*4, Color.yellow, 0);
            if (Physics.Raycast(transform.position - transform.forward.normalized*2, transform.forward*3, obsDis*3, obstrucLayer.value)) {
				_isEnterObstruct = true;
			} else {
				_isEnterObstruct = false;
			}
//			}
			return _isEnterObstruct;
		}
	}

//	public bool canMoveTo4Dir(Vector3 dir) {
//		if (Physics.Raycast(transform.position, dir, out hitInfor, obsDis, obstrucLayer.value)) {
//			return false;
//		} else {
//			return true;
//		}
//	}
	
	Callback onTriggerEnterCB;
	Callback onTriggerExitCB;
	Callback onTriggerStayCB;

	public void init(Callback onTriggerEnterCB, Callback onTriggerStayCB, Callback onTriggerExitCB)
	{
		_isEnterObstruct = false;
		this.onTriggerEnterCB = onTriggerEnterCB;
		this.onTriggerExitCB = onTriggerExitCB;
		this.onTriggerStayCB = onTriggerStayCB;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.layer == 9) {
			_isEnterObstruct = true;
			if (onTriggerEnterCB != null) {
				onTriggerEnterCB(collider);
			}
		}
	}
	
//	void OnTriggerStay(Collider collider)
//	{
//		if (collider.gameObject.layer == 9) {
//			_isEnterObstruct = true;
//			if (onTriggerStayCB != null) {
//				onTriggerStayCB(collider);
//			}
//		}
//	}
	
	void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.layer == 9) {
			_isEnterObstruct = false;
			if (onTriggerExitCB != null) {
				onTriggerExitCB(collider);
			}
		}
	}
}
