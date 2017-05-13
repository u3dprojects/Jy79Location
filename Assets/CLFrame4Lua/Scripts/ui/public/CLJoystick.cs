using UnityEngine;
using System.Collections;
using LuaInterface;

/// <summary>
/// CL joystick.
/// </summary>
[RequireComponent(typeof(BoxCollider))]

public class CLJoystick : UIEventListener
{
	public Transform joystickUI;
	public float joystickMoveDis = 10;
	object onPressCallback;
	object onDragCallback;
	object onClickCallback;
	bool isCanMove = false;
	Vector2 orgPos = Vector2.zero;
	Vector2 dragDetla = Vector2.zero;
	Vector3 joystickUIPos = Vector3.zero;
//	GameObject empty = null;

	bool isFinishStart = false;
	void Start ()
	{
		if(isFinishStart) return;
		isFinishStart = true;
//		empty = new GameObject();
        if (joystickUI != null) {
            joystickUI.transform.parent.localScale = Vector3.one*0.95f;
            joystickUIPos = joystickUI.transform.parent.localPosition;
//			empty.transform.parent = joystickUI.transform.parent;
			orgPos = joystickUI.localPosition;
//			empty.transform.localPosition = joystickUI.localPosition;
		}
	}

	public void init (object onPress, object onClick, object onDrag)
	{
		onPressCallback = onPress;
		onDragCallback = onDrag;
		onClickCallback = onClick;
		Start();
		OnPress (false);
	}

//	RaycastHit lastHit;
	MyMainCamera mainCamera;

	void OnClick ()
	{

		mainCamera = SCfg.self.mainCamera.GetComponent<MyMainCamera> ();
		mainCamera.enabled = true;
		mainCamera.Update ();
		mainCamera.LateUpdate ();
//	#if UNITY_EDITOR
//		mainCamera.ProcessMouse();
//		#else
//		mainCamera.ProcessTouches();
//#endif
		if (MyMainCamera.lastHit.collider != null) {
		}

		if (onClickCallback != null) {
			if (typeof(Callback) == onClickCallback.GetType ()) {
				((Callback)onClickCallback) ();
			} else if (typeof(LuaFunction) == onClickCallback.GetType ()) {
				((LuaFunction)onClickCallback).Call ();
			}
		}
	}

	void OnPress (bool isPressed)
    {
        if (!isPressed) {
//            if(checkPressedJoy()) return;
			CancelInvoke ("doOnPress");
			if (isCanMove) {
				callOnPressCallback (isPressed);
			}
			isCanMove = false;
			dragDetla = Vector2.zero;
			if (joystickUI != null) {
				joystickUI.localPosition = orgPos;
				joyPosition = orgPos;
				joystickUI.transform.parent.localPosition = joystickUIPos;
				joystickUI.transform.parent.localScale = Vector3.one*0.95f;
			}
		} else {
			joyPosition = orgPos;
			if(joystickUI != null) {
				joystickUI.transform.parent.localScale = Vector3.one*1.1f;
			}
//			Invoke ("doOnPress", 0.2f);
			doOnPress();
		}
	}

	void callOnPressCallback (bool isPressed)
	{
		if (onPressCallback != null) {
			if (typeof(Callback) == onPressCallback.GetType ()) {
				((Callback)onPressCallback) (isPressed);
			} else if (typeof(LuaFunction) == onPressCallback.GetType ()) {
				((LuaFunction)onPressCallback).Call (isPressed);
			}
		}
	}

	void doOnPress ()
	{
		//		isCanMove = true;
		if (joystickUI != null) {
			joystickUI.transform.parent.position = UICamera.lastHit.point;
		}
		callOnPressCallback (true);
	}

	Vector3 joyPosition = Vector3.zero;
	void OnDrag (Vector2 delta)
	{
        isCanMove = true;
		joyPosition += new Vector3(delta.x, delta.y, 0);
		if (joystickUI != null) {
			if (joyPosition.magnitude > joystickMoveDis) {
				joystickUI.transform.localPosition = Vector3.ClampMagnitude (joyPosition, joystickMoveDis);
			} else {
				joystickUI.transform.localPosition = joyPosition;
			}
			dragDetla = new Vector2 ((joystickUI.transform.localPosition.x - orgPos.x) / joystickMoveDis, (joystickUI.transform.localPosition.y - orgPos.y) / joystickMoveDis);
		}
	}


//	void  OnDragOver (GameObject draggedObject) //is sent to a game object when another object is dragged over its area.
//	{
//		Debug.LogError("OnDragOver");
//		OnPress(false);
//	}
//	void  OnDragOut (GameObject draggedObject) //is sent to a game object when another object is dragged out of its area.
//	{
//		Debug.LogError("OnDragOut");
//		OnPress(false);
//	}
	void OnDragEnd ()// is sent to a dragged object when the drag event finishes.
	{
		OnPress(false);
	}

	void OnDoubleClick ()
	{

	}

	#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
	LuaFunction _lfonPressAttack;
	LuaFunction _lfonPressSkill;
	LuaFunction lfonPressAttack{
		get{
			if(_lfonPressAttack == null) {
				_lfonPressAttack = CLMain.self.lua.GetLuaFunction("CLLPBattle.onPressAttack");
			}
			return _lfonPressAttack;
		}
	}
	LuaFunction lfonPressSkill{
		get{
			if(_lfonPressSkill == null) {
				_lfonPressSkill = CLMain.self.lua.GetLuaFunction("CLLPBattle.playSkillByIndex");
			}
			return _lfonPressSkill;
		}
	}
	#endif
	void Update ()
	{
		if (isCanMove) {
			if (onDragCallback != null) {
				if (typeof(Callback) == onDragCallback.GetType ()) {
					((Callback)onDragCallback) (dragDetla);
				} else if (typeof(LuaFunction) == onDragCallback.GetType ()) {
					((LuaFunction)onDragCallback).Call (dragDetla);
				}
			}
		}
		
		#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX
		if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) {
			isCanMove = true;
			dragDetla =  new Vector2(1,1);
		} else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) {
			isCanMove = true;
			dragDetla =  new Vector2(-1,1);
		} else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)) {
			isCanMove = true;
			dragDetla =  new Vector2(0,1);
		} else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) {
			isCanMove = true;
			dragDetla =  new Vector2(1,-1);
		} else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) {
			isCanMove = true;
			dragDetla =  new Vector2(-1,-1);
		} else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
			isCanMove = true;
			dragDetla =  new Vector2(1,0);
		} else if(Input.GetKey(KeyCode.W)){
			isCanMove = true;
			dragDetla =  new Vector2(0,1);
		} else if(Input.GetKey(KeyCode.S)) {
			isCanMove = true;
			dragDetla = new Vector2(0,-1);
		} else if(Input.GetKey(KeyCode.A)) {
			isCanMove = true;
			dragDetla =  new Vector2(-1,0);
		} else if(Input.GetKey(KeyCode.D)) {
			isCanMove = true;
			dragDetla =  new Vector2(1,0);
		}

		if(Input.GetKeyUp(KeyCode.A) ||
		   Input.GetKeyUp(KeyCode.D) ||
		   Input.GetKeyUp(KeyCode.W) ||
		   Input.GetKeyUp(KeyCode.S)
		   ) {
			isCanMove = false;
			
			if (onPressCallback != null) {
				if (typeof(Callback) == onPressCallback.GetType()) {
					((Callback)onPressCallback)(false);
				} else if (typeof(LuaFunction) == onPressCallback.GetType()) {
					((LuaFunction)onPressCallback).Call(false);
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.J)) {
			if (lfonPressAttack != null) {
				lfonPressAttack.Call(null, true);
			}
		} else if(Input.GetKeyUp(KeyCode.J)) {
			if (lfonPressAttack != null) {
				lfonPressAttack.Call(null, false);
			}
		}
		if(Input.GetKeyUp(KeyCode.U)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(1);
		} else if(Input.GetKeyUp(KeyCode.I)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(2);
		} else if(Input.GetKeyUp(KeyCode.O)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(3);
		} else if(Input.GetKeyUp(KeyCode.P)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(4);
		} else if(Input.GetKeyUp(KeyCode.N)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(7);
		} else if(Input.GetKeyUp(KeyCode.M)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(8);
		} else if(Input.GetKeyUp(KeyCode.B)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(9);
		} else if(Input.GetKeyUp(KeyCode.H)) {
			if(lfonPressSkill != null)
				lfonPressSkill.Call(10);
		}

#endif
	}

}
