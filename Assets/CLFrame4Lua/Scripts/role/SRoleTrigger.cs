using UnityEngine;
using System.Collections;

//check some one in scane
public class SRoleTrigger : CLBaseLua
{
	Callback onTriggerEnterCB;
	Callback onTriggerExitCB;
	Callback onTriggerStayCB;

	public EventDelegate onTriggerEnter;
	public EventDelegate onTriggerExit;
	public EventDelegate onTriggerStay;

	float oldColliderSize = 1;
	void Start()
	{
		oldColliderSize = collider.radius;
	}

	public void init(Callback onTriggerEnterCB, Callback onTriggerStayCB, Callback onTriggerExitCB)
	{
		this.onTriggerEnterCB = onTriggerEnterCB;
		this.onTriggerExitCB = onTriggerExitCB;
		this.onTriggerStayCB = onTriggerStayCB;
	}

	void OnTriggerEnter(Collider collider)
	{
		if(onTriggerEnterCB != null) {
			onTriggerEnterCB(collider);
		}
		if (onTriggerEnter != null) {
			onTriggerEnter.Execute (collider.gameObject);
		}
	}
	
//	void OnTriggerStay(Collider collider)
//	{
//		if(onTriggerStayCB != null) {
//			onTriggerStayCB(collider);
//		}
//	}

	void OnTriggerExit(Collider collider)
	{
		if(onTriggerExitCB != null) {
			onTriggerExitCB(collider);
		}
		if (onTriggerExit != null) {
			onTriggerExit.Execute (collider.gameObject);
		}
	}

	public void setColliderSize (float radius) {
		_collider.radius = radius;
	}

	public void resetCooliderSize() 
	{
		_collider.radius = oldColliderSize;
	}

	CapsuleCollider _collider;
	public CapsuleCollider collider {
		get {
			if(_collider == null) {
				_collider = GetComponent<CapsuleCollider>();
			}
			return _collider;
		}
	}
}
