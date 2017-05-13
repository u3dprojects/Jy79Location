using UnityEngine;
using System.Collections;
using LuaInterface;

[ExecuteInEditMode]
public class MyReposition : MonoBehaviour
{
	object finishRepositionCallback;
	public float speed = 1;
	public Vector3 mFromPos = Vector3.zero;
	public Vector3 mToPos = Vector3.zero;
	public Vector3 offset = Vector3.zero;
	public bool isMoveNow = false;
	public float turningSpeed = 1;
	public float slowdownDistance = 0;
	bool isInit = true;
	Vector3 mDistance = Vector3.zero;
	bool isWorldMode = false;
	float arriveDistance = 0;
	float minMoveScale = 0.05F;
	Vector3 newpos ;
	Transform _tr;

	public Transform transform {
		get {
			if (_tr == null) {
				_tr = gameObject.transform;
			}
			return _tr;
		}
	}

	protected Vector3 targetDirection = Vector3.zero;
	
	public enum RepsositionType
	{
		move,
		up,
	}
	RepsositionType type;
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if (isMoveNow) {
			if (isInit) {
				//Debug.Log("mDistance=== "+ mDistance);
				isInit = false;
			}
			
			mDistance = CalculateVelocity(transform.position);
			
			//Rotate towards targetDirection (filled in by CalculateVelocity)
			if (targetDirection != Vector3.zero && type != RepsositionType.up) {
				RotateTowards(targetDirection);
			}
			transform.Translate((mDistance + offset) * Time.deltaTime, Space.World);
			
			if (onMove != null) {
				if (onMove.GetType() == typeof(LuaFunction)) {
					((LuaFunction)onMove).Call(this);
				} else if (onMove.GetType() == typeof(Callback)) {
					((Callback)onMove)(this);
				}
			}
		}
	}
	
	void onArrive()
	{
		isMoveNow = false;
		isArrived = true;
		isInit = true;
		if (finishRepositionCallback != null) {
			if (finishRepositionCallback.GetType() == typeof(LuaFunction)) {
				((LuaFunction)finishRepositionCallback).Call(this);
			} else if (finishRepositionCallback.GetType() == typeof(Callback)) {
				((Callback)finishRepositionCallback)(this);
			}
		}
	}

	Vector3 CalculateVelocity(Vector3 fromPos)
	{
		if (isFollowTarget && target != null) {
			mToPos = target.position;
		}
		Vector3 dir = mToPos - fromPos;
//		dir = new Vector3(dir.x * ignoreVector.x, dir.y * ignoreVector.y, dir.z * ignoreVector.z);
		
		float targetDist = dir.magnitude;
		
		float slowdown = Mathf.Clamp01(targetDist / slowdownDistance);
		
		this.targetDirection = dir;
//		this.targetPoint = targetPosition;
//		Debug.Log(currentWaypointIndex +"       " +  (vPath.Count-1)  + "         " + targetDist +"              "+ endReachedDistance);
		if (targetDist <= arriveDistance) {
			if (!isArrived) {
				isArrived = true;
				onArrive();
			}
			//Send a move request, this ensures gravity is applied
			return Vector3.zero;
		}
		Vector3 forward = Vector3.zero;
		if (type == RepsositionType.up) {
			forward = transform.up;
		} else {
			forward = transform.forward;//  + dir.y * Vector3.up;
		}
		
		float dot = Vector3.Dot(dir.normalized, forward);
		float sp = speed * Mathf.Max(dot, minMoveScale) * slowdown;
		
		if (Time.deltaTime > 0) {
			sp = Mathf.Clamp(sp, 0, targetDist / (Time.deltaTime));
		}
		return  forward * sp;// + dir.y * Vector3.up * sp;
	}

	public bool isArrived = false;
	Transform target;
	bool isFollowTarget = false;

	public void repositionNow(Transform target, float arriveDistance, 
	                           object callback, Vector3 offset, bool isWorld = true)
	{
		repositionNow(target, arriveDistance, callback, offset, RepsositionType.move, isWorld);
	}

	public void repositionNow(Transform target, float arriveDistance, 
	                           object callback, Vector3 offset, RepsositionType type, bool isWorld = true)
	{
		
		this.offset = offset;
		this.target = target;
		repositionNow(target.position, arriveDistance, null, callback, offset, type, isWorld);
		isFollowTarget = true;
	}

	public void repositionNow(Vector3 toPos, object callback, 
		Vector3 offset, RepsositionType type, bool isWorld = true)
	{
		isFollowTarget = false;
		repositionNow(toPos, 0, null, callback, offset, type, isWorld);
	}
	
	public void repositionNow(Vector3 toPos, object callback)
	{
		isFollowTarget = false;
		repositionNow(toPos, 0, null, callback, Vector3.zero, RepsositionType.move, true);
	}

	public void repositionNow(Vector3 toPos, float arriveDistance, 
	                           object onMove, object callback, 
		Vector3 offset, RepsositionType type, bool isWorld = true)
	{
		isFollowTarget = false;
		Vector3 fromPos;
		if (isWorld) {
			fromPos = transform.position;
		} else {
			fromPos = transform.localPosition;
		}
		repositionNow(fromPos, toPos, arriveDistance, onMove, callback, offset, type, isWorld);
	}
	
	object onMove;

	public void repositionNow(Vector3 fromPos, Vector3 toPos, 
		float arriveDistance, 
		object onMove, 
      	object callback, 
		Vector3 offset, RepsositionType type,
		bool isWorld = false)
	{
//		enabled = true;
		this.type = type;
		this.offset = offset;
		finishRepositionCallback = callback;
		isWorldMode = isWorld;
		this.onMove = onMove;
		this.arriveDistance = arriveDistance;
		mFromPos = fromPos;
		mToPos = toPos;
		Vector3 diff = toPos - fromPos;
		if (isWorld) {
			transform.position = fromPos + Vector3.up * diff.y;
		} else {
			transform.localPosition = fromPos + Vector3.up * diff.y;
		}
		isArrived = false;
		isMoveNow = true;
	}

	public void stop()
	{
		isMoveNow = false;
	}
	
	protected virtual void RotateTowards(Vector3 dir)
	{
		try {
			if (!isMoveNow) {
				return;
			}
			Utl.RotateTowards(transform, dir, turningSpeed);
		} catch (System.Exception e) {
			Debug.Log("name==" + name + "   " + e);
		}
	}
}
