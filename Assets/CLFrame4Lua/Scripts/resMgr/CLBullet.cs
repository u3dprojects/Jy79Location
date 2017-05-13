using UnityEngine;
using System.Collections;
using LuaInterface;
using Toolkit;

/// <summary>
/// CL bullet.子弹
/// </summary>
public class CLBullet : MonoBehaviour
{
	public AnimationCurve curveSpeed = new AnimationCurve (new Keyframe (0, 0, 0, 1), new Keyframe (1, 1, 1, 0));
	public AnimationCurve curveHigh = new AnimationCurve (new Keyframe (0, 0, 0, 4), new Keyframe (0.5f, 1, 0, 0), new Keyframe (1, 0, -4, 0));
	BoxCollider _boxCollider;

	public BoxCollider boxCollider {
		get {
			if (_boxCollider == null) {
				_boxCollider = gameObject.GetComponent<BoxCollider> ();
			}
			return _boxCollider;
		}
	}

	public object attr;		//子弹悔恨
	public object data = null;	//可以理解为透传参数
	public bool isFireNow = false;
	public bool isFollow = false;
	public bool isMulHit = false;
	public bool isStoped = false;
	public bool needRotate = false;
//	public bool isCheckTrigger = true;
	public float slowdownDistance = 0;
	public float arriveDistance = 0.3f;
	public float turningSpeed = 1;
	float minMoveScale = 0.05F;
	float curveTime = 0;
	Vector3 v3Diff = Vector3.zero;
	Vector3 subDiff = Vector3.zero;
	public float speed = 1;
	public float high = 0;
	Vector3 origin = Vector3.zero;
	object onFinishCallback;
	Vector3 targetDirection = Vector3.zero;
	public SUnit attacker;
	public SUnit target;
	public SUnit hitTarget;
	
	// cach transform
	Transform _transform;
	
	public Transform transform {
		get {
			if(_transform == null) {
				_transform = gameObject.transform;
			}
			return _transform;
		}
	}

	public bool haveCollider = true;

#if UNITY_EDITOR
	void Start()
	{
		Utl.setBodyMatEdit(transform);
	}
#endif

	void OnTriggerEnter (Collider collider)
	{
		SUnit unit = collider.gameObject.GetComponent<SUnit> ();
		if (unit != null && unit.isOffense != attacker.isOffense && !unit.isDead) {
			hitTarget = unit;
			onFinishFire (!isMulHit);
		}
	}
	
	public virtual void doFire (SUnit attacker, SUnit target, Vector3 orgPos, Vector3 dir, object attr, object data, object callbak)
	{
		this.attr = attr;
		this.data = data;
		this.attacker = attacker;
		this.target = target;
		onFinishCallback = callbak;

		int RandomFactor = NumEx.bio2Int (MapEx.getBytes (attr, "RandomFactor")) * 10;
		speed = (NumEx.bio2Int (MapEx.getBytes (attr, "Speed"))) / 10.0f;
		if (RandomFactor > 0) {
			speed = speed + attacker.fakeRandom (-RandomFactor, RandomFactor) / 100.0f;
		}
		high = NumEx.bio2Int (MapEx.getBytes (attr, "High"));
		if(MapEx.getBool(attr, "IsHighOffset")) {
			high = high*(1.0f+ attacker.fakeRandom(-200,200)/1000.0f);
		}
		bool isZeroY = high > 0 ? true : false;

		float dis = NumEx.bio2Int (MapEx.getBytes (attr, "Range"))/10.0f;
		isFollow = MapEx.getBool (attr, "IsFollow");
		isMulHit = MapEx.getBool (attr, "IsMulHit");
		needRotate = MapEx.getBool (attr, "NeedRotate");
		dir.y = 0;
		Utl.RotateTowards (transform, dir);

		origin = orgPos;
		transform.position = origin;
		Vector3 toPos = Vector3.zero;
		if (target != null && dis <= 0) {
			toPos = target.transform.position;
		} else {
			toPos = origin + dir.normalized * dis;
			toPos.y = 0;
		}
		if (isZeroY) {
			toPos.y = 0;
		}
		if (MapEx.getBool(attr, "CheckTrigger")) {
			boxCollider.enabled = true;
		} else {
			boxCollider.enabled = false;
		}
		haveCollider = (boxCollider != null && boxCollider.enabled);

		v3Diff = toPos - origin;
		magnitude = v3Diff.magnitude == 0 ? 1 : 1.0f / v3Diff.magnitude;

		hitTarget = null;
		curveTime = 0;
		isStoped = false;
		isFireNow = true;

		CancelInvoke ("timeOut");
		int stayTime = NumEx.bio2Int (MapEx.getBytes (attr, "MaxStayTime"));
		if (stayTime > 0.00001) {
			Invoke ("timeOut", stayTime / 10.0f);
		}
	}

	RaycastHit hitInfor;
	float magnitude = 1f;

	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!isFireNow) {
			return;
		}
		if (!isFollow) {
			curveTime += Time.fixedDeltaTime * speed * 10 * magnitude;
			subDiff = v3Diff * curveSpeed.Evaluate (curveTime);
			subDiff.y += high * curveHigh.Evaluate (curveTime);
			if (!isMulHit && haveCollider) {
				if (Physics.Raycast (transform.position, v3Diff, out hitInfor, 1f)) {
					OnTriggerEnter (hitInfor.collider);
				}
			}
			
			if (needRotate) {
				if (subDiff != Vector3.zero) {
					Utl.RotateTowards (transform, origin + subDiff - transform.position);
				}
			}
			transform.position = origin + subDiff;
			if (curveTime >= 1) {
				hitTarget = null;
				onFinishFire (true);
			}
		} else {
			if (target == null || target.isDead) {
				resetTarget ();
			}
			subDiff = CalculateVelocity (transform.position);
			if (!isMulHit) {
				if (Physics.Raycast (transform.position, v3Diff, out hitInfor, 1f)) {
					OnTriggerEnter (hitInfor.collider);
				}
			}
			//Rotate towards targetDirection (filled in by CalculateVelocity)
			if (targetDirection != Vector3.zero) {
				Utl.RotateTowards (transform, targetDirection, turningSpeed);
			}
			transform.Translate (subDiff.normalized * Time.fixedDeltaTime * speed * 10, Space.World);
		}
	}

	public void resetTarget ()
	{
		if (attacker == null) {
			return;
		}
		object[] list = null;
		if (attacker.isOffense) {
			list = CLBattle.self.defense.ToArray ();
		} else {
			list = CLBattle.self.offense.ToArray ();
		}
		int count = list.Length;
		if (count == 0) {
			return;
		}
		int index = attacker.fakeRandom (0, count);
		target = (SUnit)(list [index]);
		list = null;
	}
	
	Vector3 mToPos = Vector3.zero;
	Vector3 dir = Vector3.zero;
	float targetDist = 0;
	Vector3 forward = Vector3.zero;
	float dot = 0;
	float sp = 0;

	Vector3 CalculateVelocity (Vector3 fromPos)
	{
		mToPos = Vector3.zero;
		if (isFollow && target != null) {
			mToPos = target.transform.position;
		}
		dir = mToPos - fromPos;
		targetDist = dir.magnitude;
		this.targetDirection = dir;
//		Debug.Log(currentWaypointIndex +"       " +  (vPath.Count-1)  + "         " + targetDist +"              "+ endReachedDistance);
		if (!isFollow || target == null) {
			if (targetDist <= arriveDistance) {
				if (!isStoped) {
					onFinishFire (true);
				}
				//Send a move request, this ensures gravity is applied
				return Vector3.zero;
			}
		}
		forward = Vector3.zero;
		forward = transform.forward;//  + dir.y * Vector3.up;
		
		dot = Vector3.Dot (dir.normalized, forward);
		sp = speed * Mathf.Max (dot, minMoveScale);//* slowdown;
		
		if (Time.fixedDeltaTime > 0) {
			sp = Mathf.Clamp (sp, 0, targetDist / (Time.fixedDeltaTime));
		}
		return  forward * sp;// + dir.y * Vector3.up * sp;
	}

	public void timeOut ()
	{
		onFinishFire (true);
	}

	public void stop ()
	{
		if (isStoped) {
			return;
		}
		CancelInvoke ("timeOut");
		isStoped = true;
		isFireNow = false;
		NGUITools.SetActive (gameObject, false);
		CLBulletPool.returnBullet (this);
	}

	public void onFinishFire (bool needRelease)
	{
		if (needRelease) {
			isFireNow = false;
			stop ();
		}
		if (onFinishCallback != null) {
			if (onFinishCallback.GetType () == typeof(Callback)) {
				((Callback)onFinishCallback) (this);
			} else if (onFinishCallback.GetType () == typeof(LuaFunction)) {
				((LuaFunction)onFinishCallback).Call (this);
			}
		}
	}

	public static CLBullet fire (SUnit attacker, SUnit target, Vector3 orgPos, 
	                            Vector3 dir, object attr, object data, object callbak)
	{
		if (attr == null || attacker == null) {
			Debug.LogError ("bullet attr is null");
			return null;
		}
        
		string bulletName = MapEx.getString (attr, "PrefabName");
		if (!CLBulletPool.havePrefab (bulletName)) {
			ArrayList list = new ArrayList ();
			list.Add (attacker);
			list.Add (target);
			list.Add (orgPos);
			list.Add (dir);
			list.Add (attr);
			list.Add (data);
			list.Add (callbak);
			CLBulletPool.setPrefab (bulletName, (Callback)onFinishSetPrefab, list);
			return null;
		}

		CLBullet bullet = CLBulletPool.borrowBullet (bulletName);
		if (bullet == null) {
			return null;
		}

		bullet.doFire (attacker, target, orgPos, dir, attr, data, callbak);
		NGUITools.SetActive (bullet.gameObject, true);
//		bullet.FixedUpdate();
		return bullet;
	}

	static void onFinishSetPrefab (params object[] args)
	{
		CLBullet bullet = (CLBullet)(args [0]);
		if (bullet != null) {
			ArrayList list = (ArrayList)(args [1]);
			SUnit attacker = (SUnit)(list [0]);
			SUnit target = (SUnit)(list [1]);
			Vector3 orgPos = (Vector3)(list [2]);
			Vector3 dir = (Vector3)(list [3]);
			object attr = (list [4]);
			object data = (list [5]);
			object callbak = list [6];
			fire (attacker, target, orgPos, dir, attr, data, callbak);
		}
	}
}
