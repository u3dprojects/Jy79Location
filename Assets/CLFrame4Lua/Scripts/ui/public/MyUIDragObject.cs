//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2012 Tasharen Entertainment
//----------------------------------------------
using UnityEngine;
using System.Collections;

/// <summary>
/// Allows dragging of the specified target object by mouse or touch, optionally limiting it to be within the UIPanel's clipped rectangle.
/// </summary>

public delegate bool CanMoveDelaget(float scale,Vector3 toPos,Transform target);

[AddComponentMenu("NGUI/Interaction/My Drag Object")]
public class MyUIDragObject : MonoBehaviour
{ 
	public static MyUIDragObject self;
	public Callback onDragDelegate = null;
	public Callback onEndInertanceDelegate = null;
	public enum DragEffect
	{
		None,
		Momentum,
		MomentumAndSpring,
	}
	public MyMainCamera main3DCamera;

	/// <summary>
	/// Target object that will be dragged.
	/// </summary>

	public Transform target;
	public CLSmoothFollow scaleTarget;
	public bool canMove = true;
	public bool canRotation = true;
	public bool canScale = true;
	public bool canDoInertance = true;
	float scaleTargetHight = 0;

	/// <summary>
	/// Scale value applied to the drag delta. Set X or Y to 0 to disallow dragging in that direction.
	/// </summary>

	public Vector3 scale = Vector3.one;

	/// <summary>
	/// Effect the scroll wheel will have on the momentum.
	/// </summary>

	public float scrollWheelFactor = 0f;

	/// <summary>
	/// Whether the dragging will be restricted to be within the parent panel's bounds.
	/// </summary>

	public bool restrictWithinPanel = true;

	/// <summary>
	/// Effect to apply when dragging.
	/// </summary>

	public DragEffect dragEffect = DragEffect.MomentumAndSpring;

	/// <summary>
	/// How much momentum gets applied when the press is released after dragging.
	/// </summary>

	public float momentumAmount = 35f;
	Plane mPlane;
	Vector3 mLastPos;
	UIPanel mPanel;
	bool mPressed = false;
	Vector3 mMomentum = Vector3.zero;
	float mScroll = 0f;
	Bounds mBounds;
	public Rect mRect;
	public float rotationMini = 0;
	public float rotationMax = 0;
	public float scaleMini = 0;
	public float scaleMax = 0;
	public float scaleHeightMini = 0;
	public float scaleHeightMax = 0;
	public float miniOrthographicSize = 0;
	public float maxOrthographicSize = 0;
	int dragProcType = -1;//0:拖动 1:旋转 2:缩放

	public float scaleValue {
		get {
			return scaleTarget.height / 2.5f;
		}
	}

	/// <summary>
	/// Find the panel responsible for this object.
	/// </summary>

	public MyUIDragObject()
	{
		self = this;
	}

	void Awake()
	{
		if (scaleTarget != null) {
			scaleTargetHight = scaleTarget.distance;
		}
	}

	void FindPanel()
	{
		//mPanel = (target != null) ? UIPanel.Find(target.transform, false) : null;
		if (mPanel == null) {
			restrictWithinPanel = false;
		}
	}

	static Hashtable canProcClickPanels = new Hashtable();
	public static void setCanClickPanel(string pName) {
		canProcClickPanels[pName] = true;
	}
	public static void removeCanClickPanel(string pName) {
		canProcClickPanels[pName] = null;
	}
	/// <summary>
	/// Create a plane on which we will be performing the dragging.
	/// </summary>

	public void OnPress(bool pressed)
	{
		if (	CLPanelManager.topPanel != null && 
		    canProcClickPanels[CLPanelManager.topPanel.name] != null) {
			if (pressed && main3DCamera != null) {//add by chenbin
				main3DCamera.enabled = true;
				main3DCamera.Update();
				main3DCamera.LateUpdate();
			}
		}
	
		if (enabled && gameObject.activeSelf && target != null) {
			mPressed = pressed;

			if (pressed) {
				if (restrictWithinPanel && mPanel == null) {
					FindPanel();
				}

				// Calculate the bounds
				if (restrictWithinPanel) {
					mBounds = NGUIMath.CalculateRelativeWidgetBounds(mPanel.cachedTransform, target);
				}

				// Remove all momentum on press
				mMomentum = Vector3.zero;
				mScroll = 0f;

				// Disable the spring movement
				SpringPosition sp = target.GetComponent<SpringPosition>();
				if (sp != null) {
					sp.enabled = false;
				}

				// Remember the hit position
				mLastPos = UICamera.lastHit.point;
			
				// Create the plane to drag along
				Transform trans = UICamera.currentCamera.transform;
				mPlane = new Plane((mPanel != null ? mPanel.cachedTransform.rotation : trans.rotation) * Vector3.back, mLastPos);
			} else if (restrictWithinPanel && mPanel != null && mPanel.clipping != UIDrawCall.Clipping.None && dragEffect == DragEffect.MomentumAndSpring) {
				mPanel.ConstrainTargetToBounds(target, ref mBounds, false);
			}
		}
	
		///////////////////////////
		if (!pressed) {
			inertancePower = INERTANCE_POWER;
			if (canDoInertance) { 
				isDoInertance = true;
			}
			dragProcType = -1;
		} else {
			init();
		}
	}

	public void init()
	{
		inertanceDelta = Vector3.zero;
		isDoInertance = false;
		dragProcType = -1;
	}

	void OnDisable()
	{
		init();
	}

	void OnEnable() {
		init ();
	}

	/// <summary>
	/// Drag the object along the plane.
	/// </summary>

	public void OnDrag(Vector2 delta)
	{
		switch (dragProcType) {
			case 0:
				if (canMove) {
					doOnDragMove(delta, true);
				}
				break;
			case 1:
				if (canRotation) {
					procAngleView(delta);
				}
				break;
			case 2:
				if (canScale) {
					procScalerSoft(delta);
				}
				break;
			case 3:
				procDragAll();
				break;
			default:
				break;
		}
	}

	public void doOnDragMove(Vector2 delta, bool changePos)
	{
		if (enabled && gameObject.activeSelf && target != null) {
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;

			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float dist = 0f;

			if (mPlane.Raycast(ray, out dist)) {
				Vector3 currentPos = ray.GetPoint(dist);
				Vector3 offset = currentPos - mLastPos;
				mLastPos = currentPos;

				if (offset.x != 0f || offset.y != 0f) {
					offset = target.InverseTransformDirection(offset);
					offset.Scale(scale);
					offset = target.TransformDirection(offset);
				}

				// Adjust the momentum
				mMomentum = Vector3.Lerp(mMomentum, mMomentum + offset * (0.01f * momentumAmount), 0.67f);

				// We want to constrain the UI to be within bounds
				if (restrictWithinPanel) {
					// Adjust the position and bounds
					Vector3 localPos = target.localPosition;
				
					target.localPosition -= offset;
					mBounds.center = mBounds.center + (target.localPosition - localPos);

					// Constrain the UI to the bounds, and if done so, eliminate the momentum
					if (dragEffect != DragEffect.MomentumAndSpring && mPanel.clipping != UIDrawCall.Clipping.None &&
						mPanel.ConstrainTargetToBounds(target, ref mBounds, true)) {
						mMomentum = Vector3.zero;
						mScroll = 0f;
					}
				} else {
					// Adjust the position
					Vector3 off = new Vector3();
					if (changePos) {
						off.x += -((offset.x) * Mathf.Cos(target.rotation.eulerAngles.y * Mathf.PI / 180)
							+ (offset.y) * Mathf.Sin(target.rotation.eulerAngles.y * Mathf.PI / 180));// * Camera.main.orthographicSize;
						off.z += -((offset.y) * Mathf.Cos(target.rotation.eulerAngles.y * Mathf.PI / 180)
							- (offset.x) * Mathf.Sin(target.rotation.eulerAngles.y * Mathf.PI / 180));// * Camera.main.orthographicSize;
					} else {
						off = offset;
					}
					//Debug.Log("off======" + off.ToString());
					off = moveCameraLimit(off, changePos);
					off = off * scaleValue;
					if (off.x > 8 || off.x > 8) {
						inertanceDelta = Vector3.zero;
						return;
					}
					target.position += off;
				
					//Debug.Log("off new===" + off.ToString());
				
					if (!isDoInertance) {
						if (Mathf.Abs(off.x) > 0.1f || Mathf.Abs(off.y) > 0.1f || Mathf.Abs(off.z) > 0.1f) {
							inertanceDelta = off;
							ischangePos = changePos;
						} else {
							inertanceDelta = Vector3.zero;
						}
					}
					if (onDragDelegate != null) {
						onDragDelegate(delta);
					}
				}
			}
		}
	}

	public void DoInertance(Vector3 delta)
	{
		Vector3 off = new Vector3();
		off = delta;
		off = moveCameraLimit(off, ischangePos);
		target.localPosition += off;
		if (onDragDelegate != null) {
			onDragDelegate(new Vector2(delta.x, delta.y));
		}
	}

	bool isDoInertance = false;
	const int INERTANCE_POWER = 1;
	float inertancePower = INERTANCE_POWER;
	Vector3 inertanceDelta = Vector3.zero;
	float speed = 0.5f;
	public float rotateSpeed = 10;
	public float scaleSpeed = 0.1f;
	bool ischangePos = false;

	void Update()
	{
		//计算帧率
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval) {
			fps = (float)(frames / (timeNow - lastInterval));
//			float ms = 1000.0f / Mathf.Max (fps, 0.00001f);
			frames = 0;
			lastInterval = timeNow;
		}
	
		if (isDoInertance) {
			if (inertancePower <= 0.0001f) {
				isDoInertance = false;
				if (onEndInertanceDelegate != null) { 
					onEndInertanceDelegate(null);
				}
			}
		
			DoInertance(inertanceDelta * (inertancePower / INERTANCE_POWER) * scaleValue * speed);
			inertancePower -= 0.05f;
		}
	
		//处理旋转或缩放
		screenTouch();
	}

	public CanMoveDelaget canMoveDelegate;		//处理能否拖动的判断
	Vector3 moveCameraLimit(Vector3 movetoPosition, bool changePos)
	{
		Vector3 ret = movetoPosition;
	
		if (canMoveDelegate != null && 
			!canMoveDelegate(scaleTarget.distance, movetoPosition, target)) {
			return Vector3.zero;
		}
	
		Rect rect = mRect;
//		rect.x = - ((mRect.x) * Mathf.Sin (target.rotation.eulerAngles.y * Mathf.PI / 180)
//		           + (mRect.y) * Mathf.Cos (target.rotation.eulerAngles.y * Mathf.PI / 180));
//		rect.y = -((mRect.y) * Mathf.Sin (target.rotation.eulerAngles.y * Mathf.PI / 180)
//		            - (mRect.x) * Mathf.Cos(target.rotation.eulerAngles.y * Mathf.PI / 180)) ;
//		rect.width = -((mRect.width) * Mathf.Sin (target.rotation.eulerAngles.y * Mathf.PI / 180)
//		            + (mRect.height) * Mathf.Cos (target.rotation.eulerAngles.y * Mathf.PI / 180)) ; 
//		rect.height = -((mRect.height) * Mathf.Sin (target.rotation.eulerAngles.y * Mathf.PI / 180)
//		            -(mRect.width) * Mathf.Cos (target.rotation.eulerAngles.y * Mathf.PI / 180));
//		Debug.Log("rect.ToString()===" + mRect.ToString());	
//		Debug.Log("rect.ToString()===" + rect.ToString());	
	
		if (rect.width == 0 && rect.height == 0) {
			return ret;
		}
		
		Vector3 newPos = target.localPosition;
		if (changePos) {
			Vector2 tmpPos = new Vector2(target.localPosition.x + movetoPosition.x, target.localPosition.z + movetoPosition.z);
			if (tmpPos.x > rect.x + rect.width) {
				newPos.x = rect.x + rect.width;
				ret.x = 0;
				target.position = newPos;
			} else if (tmpPos.x < rect.x) {
				newPos.x = rect.x;
				ret.x = 0;
				target.position = newPos;
			}
			if (tmpPos.y > rect.y + rect.height) {
				newPos.z = rect.y + rect.height;
				ret.z = 0;
				target.position = newPos;
			} else if (tmpPos.y < rect.y) {
				newPos.z = rect.y;
				ret.z = 0;
				target.position = newPos;
			}
		} else {
			Vector2 tmpPos = new Vector2(target.localPosition.x + movetoPosition.x, target.localPosition.y + movetoPosition.y);
			if (tmpPos.x > rect.x + rect.width) {
				newPos.x = rect.x + rect.width;
				ret.x = 0;
				target.position = newPos;
			} else if (tmpPos.x < rect.x) {
				newPos.x = rect.x;
				ret.x = 0;
				target.position = newPos;
			}
			if (tmpPos.y > rect.y + rect.height) {
				newPos.y = rect.y + rect.height;
				ret.y = 0;
				target.position = newPos;
			} else if (tmpPos.y < rect.y) {
				newPos.y = rect.y;
				ret.y = 0;
				target.position = newPos;
			}
		}
		return ret;
	}


	/// <summary>
	/// Apply the dragging momentum.
	/// </summary>

	void LateUpdate()
	{
		float delta = RealTime.deltaTime;
//				float delta = UpdateRealTimeDelta ();
		if (target == null) {
			return;
		}

		if (mPressed) {
			// Disable the spring movement
			SpringPosition sp = target.GetComponent<SpringPosition>();
			if (sp != null) {
				sp.enabled = false;
			}
			mScroll = 0f;
		} else {
			mMomentum += scale * (-mScroll * 0.05f);
			mScroll = NGUIMath.SpringLerp(mScroll, 0f, 20f, delta);

			if (mMomentum.magnitude > 0.0001f) {
				// Apply the momentum
				if (mPanel == null) {
					FindPanel();
				}
				if (mPanel != null) {
					target.localPosition += NGUIMath.SpringDampen(ref mMomentum, 9f, delta);

					if (restrictWithinPanel && mPanel.clipping != UIDrawCall.Clipping.None) {
						mBounds = NGUIMath.CalculateRelativeWidgetBounds(mPanel.cachedTransform, target);
					
						if (!mPanel.ConstrainTargetToBounds(target, ref mBounds, dragEffect == DragEffect.None)) {
							SpringPosition sp = target.GetComponent<SpringPosition>();
							if (sp != null) {
								sp.enabled = false;
							}
						}
					}
				}
			} else {
				mScroll = 0f;
			}
		}
	}

	/// <summary>
	/// If the object should support the scroll wheel, do it.
	/// </summary>

	void OnScroll(float delta)
	{
		if (enabled && gameObject.activeSelf) {
			if (Mathf.Sign(mScroll) != Mathf.Sign(delta)) {
				mScroll = 0f;
			}
			mScroll += delta * scrollWheelFactor;
		}
	}

	//=======================================================
	//=======================================================
	//**************** 通过处理旋转和缩放******************************************
	//=======================================================
	//=======================================================
	bool isCameraMoved = false;
	bool isCameraRotation = false;
	bool isCameraZoom = false;
	Vector2 beginpos = Vector2.zero;
	Vector2 endpos = Vector2.zero;
	Vector2 totalDelta1 = Vector2.zero;
	Vector2 totalDelta2 = Vector2.zero;
	long distanceTime = 0;
	const long CONST_DISTANCETIME = 5000000;
	long StationaryTime = 0;
	float oldTowFingersDis = -1;
	bool isFirstInOneTouch = true;

	void screenTouch()
	{
		if (Application.platform == RuntimePlatform.Android ||
			Application.platform == RuntimePlatform.IPhonePlayer) {
			//两个手指滑动
			if (Input.touchCount == 2) {
				isFirstInOneTouch = true;
				if (Input.touches [0].phase == TouchPhase.Moved) {
					totalDelta1 += Input.touches [0].deltaPosition;
				}
				if (Input.touches [1].phase == TouchPhase.Moved) {
					totalDelta2 += Input.touches [1].deltaPosition;
				}
				if (Input.touches [0].phase == TouchPhase.Stationary) {
					totalDelta1 = Vector2.zero;
				}
				if (Input.touches [1].phase == TouchPhase.Stationary) {
					totalDelta2 = Vector2.zero;
				}
				//===============
				if (Input.touches [0].phase == TouchPhase.Began ||
					Input.touches [1].phase == TouchPhase.Began) {
					isCameraZoom = true;
					dragProcType = -1;
					oldTowFingersDis = -1;
					totalDelta1 = Vector2.zero; 
					totalDelta2 = Vector2.zero;
				} else if ((Input.touches [0].phase == TouchPhase.Stationary 
					&& isTouchMoved(totalDelta2)) ||
					(isTouchMoved(totalDelta1)
					&& Input.touches [1].phase == TouchPhase.Stationary)) {
//									dragProcType = 1;		//旋转
					procDragAll();
				} else if (isTouchMoved(totalDelta1) &&
					isTouchMoved(totalDelta2)) {
//									dragProcType = 2;		//放大缩小处理
					procDragAll();
				} else if (Input.touches [0].phase == TouchPhase.Ended ||
					Input.touches [1].phase == TouchPhase.Ended) {
					init();
					totalDelta1 = Vector2.zero;
					totalDelta2 = Vector2.zero;
					dragProcType = -1;
					isCameraRotation = false;
					StationaryTime = System.DateTime.Now.AddSeconds(0.5f).ToFileTime();
					isFirstInOneTouch = true;
				}
			}
		//一个手指
		else if (Input.touchCount == 1) {
				if (isFirstInOneTouch) {
					isCameraZoom = false;
					isCameraMoved = false;
					//初始化视角转动参Number
					StationaryTime = System.DateTime.Now.AddSeconds(0.5f).ToFileTime();
					isCameraRotation = false;
					isFirstInOneTouch = false;
					return;
				}
				if (isCameraZoom) {
					isCameraZoom = false;
					isCameraMoved = false;
					//初始化视角转动参Number
					StationaryTime = System.DateTime.Now.AddSeconds(0.5f).ToFileTime();
					isCameraRotation = false;
				}
				endpos = new Vector2(target.position.x, target.position.z);
				if (Input.touches [0].phase == TouchPhase.Stationary) {
					totalDelta1 = Vector2.zero;
					if (canRotation) {
//						if(!isCameraMoved && !isCameraRotation && System.DateTime.Now.ToFileTime() - StationaryTime > 0 ) {
//							isCameraRotation = true;
//							dragProcType = 1;
//							//TODO:显示一个图标，表示已经选中了点
//						}
					} else {
						isCameraRotation = false;
						dragProcType = -1;
					}
				} else if (Input.touches [0].phase == TouchPhase.Began) {
					totalDelta1 = Vector2.zero;
					isCameraMoved = false;
					//初始化视角转动参Number
					StationaryTime = System.DateTime.Now.AddSeconds(0.5f).ToFileTime();
					isCameraRotation = false;
				} else if (Input.touches [0].phase == TouchPhase.Ended) {
					isCameraMoved = false;
					isCameraRotation = false;
					isCameraZoom = false;
					totalDelta1 = Vector2.zero;
					dragProcType = -1;
				}
			//滑动
			 else if (Input.touches [0].phase == TouchPhase.Moved) {
					totalDelta1 += Input.touches [0].deltaPosition;
					if (isTouchMoved(totalDelta1)) {
						if (isCameraRotation) {
							dragProcType = 1;
						} else {
							isCameraMoved = true;
							dragProcType = 0;
						}
					}
				}
			}
		} else {
			float v = Input.GetAxis("Mouse ScrollWheel");
			if (Mathf.Abs(v) > 0.01f) {
				dragProcType = 2;
				OnDrag(new Vector2(v * Screen.width, 0));
			}
			//视角转动处理
			if (Input.GetMouseButtonDown(1)) {
				dragProcType = 1;
			} else if (Input.GetMouseButtonDown(0)) {
				dragProcType = 0;
			}
		}
	}

	void Start()
	{
		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
	}

	const float touchClickThreshold = 5f;
	public float maxFps = 120f;
	float updateInterval = 1.0f;
	double lastInterval; // Last interval end time
	float frames = 0; // Frames over current interval
	float fps = 0;
	/// <summary>
	/// Ises the touch moved.是否触控在移动
	/// </summary>
	/// <returns>
	/// The touch moved.
	/// </returns>
	/// <param name='totalDelta'>
	/// If set to <c>true</c> total delta.
	/// </param>
	bool isTouchMoved(Vector2 totalDelta)
	{
		float threshold = Mathf.Max(touchClickThreshold, Screen.height * 0.005f);
		threshold *= (fps / maxFps);
		if (totalDelta.magnitude > threshold) {
			return true;
		}
		return false;
	}
	
	void procDragAll()
	{
		if (Input.touchCount != 2) {
			dragProcType = -1;
			return;
		}
		
		Vector2 pos1 = Input.touches [0].position;
		Vector2 pos2 = Input.touches [1].position;
		
		Vector2 delta1 = Input.touches [0].deltaPosition;
		Vector2 delta2 = Input.touches [1].deltaPosition;
		if (Input.touches [1].position.x < Input.touches [0].position.x) {
			Vector2 tmp = delta1;
			delta1 = delta2;
			delta2 = tmp;
		}
		
		delta1 = Mathf.Abs(delta1.x) > Mathf.Abs(delta1.y) ? new Vector2(delta1.x, 0) : new Vector2(0, delta1.y);
		delta2 = Mathf.Abs(delta2.x) > Mathf.Abs(delta2.y) ? new Vector2(delta2.x, 0) : new Vector2(0, delta2.y);
		if (
			(delta1.x < 0 && delta2.x < 0) ||
			(delta1.x > 0 && delta2.x > 0) ||
			(delta1.y < 0 && delta2.y < 0) ||
			(delta1.y > 0 && delta2.y > 0)
			) {		//两个手指向同一方向移动
//			doOnDragMove (delta2, true);
			dragProcType = -1;
		} else if (
//			(delta1.x < 0 && delta2.x > 0) ||
//			(delta1.x > 0 && delta2.x < 0) ||
					(
						(Mathf.Abs(pos1.y - pos2.y) < 200 &&
			((delta1.x < 0 && delta2.x > 0) ||
			(delta1.x > 0 && delta2.x < 0)) 
							)
					) ||
			(
						(Mathf.Abs(pos1.x - pos2.x) < 200 &&
			((delta1.y < 0 && delta2.y > 0) ||
			(delta1.y > 0 && delta2.y < 0)) 
							)
					)
				) {	//缩放
//			procScalerSoft(delta2);
			dragProcType = 2;
		} else {
			if (
				(delta1.y <= 0 && delta2.y > 0) ||
				(delta1.y < 0 && delta2.y >= 0)) {
				float y1 = Mathf.Abs(delta1.y);
				float y2 = Mathf.Abs(delta2.y);
				Vector2 delta = y1 > y2 ? new Vector2(0, y1) : new Vector2(0, y2);
				procAngleView(delta);
				dragProcType = -1;
			} else if (
				(delta1.y >= 0 && delta2.y < 0) ||
				(delta1.y > 0 && delta2.y <= 0)) {
				float y1 = Mathf.Abs(delta1.y);
				float y2 = Mathf.Abs(delta2.y);
				Vector2 delta = y1 > y2 ? new Vector2(0, -y1) : new Vector2(0, -y2);
				procAngleView(delta);
				//			dragProcType = 1;
				dragProcType = -1;
			}
			
			if (
				(delta1.x <= 0 && delta2.x > 0) ||
				(delta1.x < 0 && delta2.x >= 0)) {
				float x1 = Mathf.Abs(delta1.x);
				float x2 = Mathf.Abs(delta2.x);
				Vector2 delta = x1 > x2 ? new Vector2(0, -x1) : new Vector2(0, -x2);
				procAngleView(delta);
				dragProcType = -1;
			} else if (
				(delta1.x >= 0 && delta2.x < 0) ||
				(delta1.x > 0 && delta2.x <= 0)) {
				float x1 = Mathf.Abs(delta1.x);
				float x2 = Mathf.Abs(delta2.x);
				Vector2 delta = x1 > x2 ? new Vector2(0, x1) : new Vector2(0, x2);
				procAngleView(delta);
				//			dragProcType = 1;
				dragProcType = -1;
			}
		}
	}

	//视角处理
	void procAngleView(Vector2 delta)
	{
		if (!canRotation) {
			return;
		}
		float offset = Mathf.Abs(delta.x) > Mathf.Abs(delta.y) ? delta.x : delta.y;
		target.Rotate(Vector3.up, rotateSpeed * Time.deltaTime * offset);
		Vector3 ea = target.localEulerAngles;
		if (rotationMax != 0 && rotationMini != 0) {
			if (ea.y >= rotationMax) {
				ea.y = rotationMax;
				target.localEulerAngles = ea;
			}
			if (ea.y <= rotationMini) {
				ea.y = rotationMini;
				target.localEulerAngles = ea;
			}
		}
	}

	void procScalerSoft(Vector2 delta)
	{
		if (!canScale) {
			return;
		}
		float offset = 0;
		if (Input.touchCount == 2) {
			float dis = Vector2.Distance(Input.touches [0].position, Input.touches [1].position);
			if (oldTowFingersDis == -1) {
				oldTowFingersDis = dis;
				return;
			}
			offset = (dis - oldTowFingersDis);
			oldTowFingersDis = dis;
		} else {
			offset = Mathf.Abs(delta.y) > Mathf.Abs(delta.x) ? delta.y : delta.x;
		}
		procScaler(offset);
	}

	void procScaler(float delta, bool isCamera)
	{
		if (!canScale) {
			return;
		}
		Camera ca = target.GetComponent<Camera>();
	
		if (ca != null) {
			float tmpSize = ca.orthographicSize + delta * Time.deltaTime * scaleSpeed;
			if (tmpSize > scaleMax) {
				ca.orthographicSize = scaleMax;
			} else if (tmpSize < scaleMini) {
				ca.orthographicSize = scaleMini;
			} else {
				ca.orthographicSize = tmpSize;
			}
		}
	}

	public AnimationCurve scaleCurve;

	public void procScaler(float delta)
	{
		if (!canScale) {
			return;
		}
		if (scaleTarget == null) {
			return;
		}
		//Debug.Log("delta======================" + delta);
		float offset = Time.deltaTime * delta * 5;
		scaleTarget.distance -= offset;
		scaleTarget.height -= offset;
		if (scaleMax != 0 && scaleMini != 0) {
			if (scaleTarget.distance >= scaleMax) {
				scaleTarget.distance = scaleMax;
			} else if (scaleTarget.distance <= scaleMini) {
				scaleTarget.distance = scaleMini;
			} 
		} 
		if (scaleHeightMax != 0 && scaleHeightMini != 0) {
			if (scaleTarget.height >= scaleHeightMax) {
				scaleTarget.height = scaleHeightMax;
			} else if (scaleTarget.height <= scaleHeightMini) {
				scaleTarget.height = scaleHeightMini;
			} 
		}
//			float scale = scaleCurve.Evaluate (scaleTarget.distance / 5.0f);
//			if(HUDRoot.go != null) {
//				HUDRoot.go.transform.localScale = new Vector3 (scale, scale, scale);
//			}
	}

//	void procScalerSoft(Vector2 delta) {
//		float offset = delta.y;
//		procScaler(offset);
//	}
//	
//	void procScaler(float delta) {
//		if(scaleTarget == null) return;
//		//Debug.Log("delta======================" + delta);
//		Camera ca = scaleTarget.camera;
//		if(ca != null && ca.orthographic) {
//			float offset = Time.deltaTime*delta*5;
//			ca.orthographicSize += offset;
//			if(miniOrthographicSize !=0 && maxOrthographicSize != 0) {
//				if(ca.orthographicSize > maxOrthographicSize) {
//					ca.orthographicSize = maxOrthographicSize;
//				} else if(ca.orthographicSize < miniOrthographicSize) {
//					ca.orthographicSize = miniOrthographicSize;
//				}
//			}
//		} else {
//			float offset = Time.deltaTime*delta*5;
//			scaleTarget.distance -= offset;
//			scaleTarget.height -= offset;
//			if(scaleMax != 0  && scaleMini != 0) {
//				if(scaleTarget.distance >= scaleMax) {
//					scaleTarget.distance = scaleMax;
//				} else if(scaleTarget.distance <= scaleMini){
//					scaleTarget.distance = scaleMini;
//				} 
//			} 
//			if(scaleHeightMax != 0  && scaleHeightMini != 0) {
//				if(scaleTarget.height >= scaleHeightMax) {
//					scaleTarget.height = scaleHeightMax;
//				} else if(scaleTarget.height <= scaleHeightMini){
//					scaleTarget.height = scaleHeightMini;
//				} 
//			}
//		}
//	}
}