using UnityEngine;
using System.Collections;
using LuaInterface;

[ExecuteInEditMode]
public class CLReposition : MonoBehaviour
{
	object finishRepositionCallback;
	object onMove;
	public AnimationCurve curve;
	public float speed = 1;
	public Vector3 mFromPos = Vector3.zero;
	public Vector3 mToPos = Vector3.zero;
	public Vector3 offset = Vector3.zero;
	public bool isMoveNow = false;
	public float turningSpeed = 1;
	public float slowdownDistance = 0;
	bool isInit = true;
	Vector3 mDistance = Vector3.zero;
	float arriveDistance = 0;
	float minMoveScale = 0.05f;
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
	float curveValue = 0;
	float time = 0;
	
	// Update is called once per frame
//	void FixedUpdate ()
	void Update ()
	{
		if (isMoveNow) {
			if (isInit) {
				if(path == null || path.Count <= 0) {
					isArrived = true;
					onArrive ();
					return;
				}
				time = 0;
				mFromPos = transform.position;
				mToPos = (Vector3)(path [index]);
				mDistance = mToPos - mFromPos;
				//Debug.Log("mDistance=== "+ mDistance);
				isInit = false;
				index++;
			}
			
			RotateTowards (mDistance);
			time += Mathf.Lerp (0.01f, 0.4f, Time.deltaTime * speed * (1 / mDistance.magnitude));
			if (time >= 1) {
				time = 1;
				isMoveNow = false;
				isArrived = true;
			}
			
			curveValue = curve.Evaluate (time);
			transform.position = mFromPos + (mDistance * curveValue);
			
			if (onMove != null) {
				if (typeof(LuaFunction) == onMove.GetType ()) {
					((LuaFunction)onMove).Call ();
				} else if (typeof(Callback) == onMove.GetType ()) {
					((Callback)onMove) ();
				}
			}
			if (isArrived) {
				onArrive ();
			}
		}
	}
	
	void onArrive ()
	{
		if (path != null && index < path.Count) {
			isArrived = false;
			isInit = true;
			isMoveNow = true;
		} else {
			isMoveNow = false;
			isArrived = true;
			isInit = true;
			if (finishRepositionCallback != null) {
				if (typeof(LuaFunction) == finishRepositionCallback.GetType ()) {
					((LuaFunction)finishRepositionCallback).Call (this);
				} else if (typeof(Callback) == finishRepositionCallback.GetType ()) {
					((Callback)finishRepositionCallback) (this);
				}
			}
		}
	}

	Vector3 CalculateVelocity (Vector3 fromPos)
	{
		if (isFollowTarget && target != null) {
			mToPos = target.position;
		}
		Vector3 dir = mToPos - fromPos;
//		dir = new Vector3(dir.x * ignoreVector.x, dir.y * ignoreVector.y, dir.z * ignoreVector.z);
		
		float targetDist = dir.magnitude;
		
		float slowdown = Mathf.Clamp01 (targetDist / slowdownDistance);
		
		this.targetDirection = dir;
//		this.targetPoint = targetPosition;
//		Debug.Log(currentWaypointIndex +"       " +  (vPath.Count-1)  + "         " + targetDist +"              "+ endReachedDistance);
		if (targetDist <= arriveDistance) {
			if (!isArrived) {
				isArrived = true;
				onArrive ();
			}
			//Send a move request, this ensures gravity is applied
			return Vector3.zero;
		}
		Vector3 forward = Vector3.zero;
		forward = transform.forward;//  + dir.y * Vector3.up;
		
		float dot = Vector3.Dot (dir.normalized, forward);
		float sp = speed * Mathf.Max (dot, minMoveScale) * slowdown;
		
		if (Time.deltaTime > 0) {
			sp = Mathf.Clamp (sp, 0, targetDist / (Time.deltaTime));
		}
		return  forward * sp;// + dir.y * Vector3.up * sp;
	}

	public bool isArrived = false;
	Transform target;
	bool isFollowTarget = false;
	ArrayList path;
	int index = 0;

//	public void repositionNow (ArrayList path)
//	{
//		repositionNow (path, null, null, Vector3.zero);
//	}

	public void repositionNow (ArrayList path, object onMove, object callback, Vector3 offset)
	{
		this.offset = offset;
		finishRepositionCallback = callback;
		this.onMove = onMove;
//		this.arriveDistance = arriveDistance;
		this.path = path;
		index = 0;
		mFromPos = transform.position;
		isInit = true;
		isArrived = false;
		isMoveNow = true;
	}

	public void stop ()
	{
		isMoveNow = false;
	}
	
	protected virtual void RotateTowards (Vector3 dir)
	{
		Utl.RotateTowards(transform, dir, turningSpeed);
	}
}
