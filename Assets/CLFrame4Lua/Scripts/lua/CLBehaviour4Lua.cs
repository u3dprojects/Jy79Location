using UnityEngine;
using System.Collections;
using LuaInterface;
using System.IO;
using System.Collections.Generic;

//把mobobehaviour的处理都转到lua层
public class CLBehaviour4Lua : CLBaseLua
{
	public override void setLua ()
	{
		base.setLua();
		initGetLuaFunc();
	}

	// 把lua方法存在起来
	public virtual void initGetLuaFunc() {
		if (luaTable != null) {
			flStart = getLuaFunction ("Start");
			flUpdate = getLuaFunction ("Update");
			flLateUpdate = getLuaFunction ("LateUpdate");
			flFixedUpdate = getLuaFunction ("FixedUpdate");
			flAwake = getLuaFunction ("Awake");
//			flReset = getLuaFunction ("Reset");
			flOnTriggerEnter = getLuaFunction ("OnTriggerEnter");
			flOnTriggerExit = getLuaFunction ("OnTriggerExit");
			flOnTriggerStay = getLuaFunction ("OnTriggerStay");
			flOnCollisionEnter = getLuaFunction ("OnCollisionEnter");
			flOnCollisionExit = getLuaFunction ("OnCollisionExit");
			flOnApplicationPause = getLuaFunction ("OnApplicationPause");
			flOnApplicationFocus = getLuaFunction ("OnApplicationFocus");
			flOnBecameInvisible = getLuaFunction ("OnBecameInvisible");
			flOnBecameVisible = getLuaFunction ("OnBecameVisible");
			flOnControllerColliderHit = getLuaFunction ("OnControllerColliderHit");
			flOnDestroy = getLuaFunction ("OnDestroy");
			flOnDisable = getLuaFunction ("OnDisable");
			flOnEnable = getLuaFunction ("OnEnable");
			flOnWillRenderObject = getLuaFunction ("OnWillRenderObject");
			flOnPreRender = getLuaFunction ("OnPreRender");
			flOnPostRender = getLuaFunction ("OnPostRender");
			flOnClick = getLuaFunction ("OnClick");
			flOnPress = getLuaFunction ("OnPress");
			flOnDrag = getLuaFunction ("OnDrag");
			flUIEventDelegate = getLuaFunction ("uiEventDelegate");
			flclean = getLuaFunction("clean");
		}
	}

	public LuaFunction flclean = null;
	public virtual void clean ()
	{
		if (flclean != null) {
			flclean.Call ();
		}
		cancelInvoke4Lua ("");
		canFixedInvoke = false;
		cancelFixedInvoke4Lua (null);
		CancelInvoke();
		StopAllCoroutines();
	}
	
	public LuaFunction flStart = null;
	public LuaFunction flUpdate = null;
	public LuaFunction flLateUpdate = null;
	public LuaFunction flFixedUpdate = null;
	public LuaFunction flAwake = null;
	// Use this for initialization
	public  virtual void Start ()
	{
		if (flStart != null) {
			flStart.Call (gameObject);
		}
	}

	public  virtual void Awake ()
	{
		if (flAwake != null) {
			flAwake.Call (gameObject);
		}
	}
	
	// Update is called once per frame
	public  virtual void Update ()
	{
		if (flUpdate != null) {
			flUpdate.Call (gameObject);
		}
	}

	public  virtual void LateUpdate ()
	{
		if (flLateUpdate != null) {
			flLateUpdate.Call (gameObject);
		}
	}
	
	public override void FixedUpdate ()
	{
		base.FixedUpdate ();
		if (flFixedUpdate != null) {
			flFixedUpdate.Call (gameObject);
		}
	}
	
//	public LuaFunction flReset = null;
//
//	public virtual void Reset ()
//	{
//		isPause = false;
//		if (flReset != null) {
//			flReset.Call (gameObject);
//		}
//	}
	
	public LuaFunction flOnTriggerEnter = null;

	public virtual  void OnTriggerEnter (Collider other)
	{
		if (flOnTriggerEnter != null) {
			flOnTriggerEnter.Call (other);
		}
	}
	
	public LuaFunction flOnTriggerExit = null;

	public virtual  void OnTriggerExit (Collider other)
	{
		if (flOnTriggerExit != null) {
			flOnTriggerExit.Call (other);
		}
	}
	
	public LuaFunction flOnTriggerStay = null;

	public virtual  void OnTriggerStay (Collider other)
	{
		if (flOnTriggerStay != null) {
			flOnTriggerStay.Call (other);
		}
	}
	
	public LuaFunction flOnCollisionEnter = null;

	public virtual  void OnCollisionEnter (Collision collision)
	{
		if (flOnCollisionEnter != null) {
			flOnCollisionEnter.Call (collision);
		}
	}
	
	public LuaFunction flOnCollisionExit = null;

	public virtual  void OnCollisionExit (Collision collisionInfo)
	{
		if (flOnCollisionExit != null) {
			flOnCollisionExit.Call (collisionInfo);
		}
	}
	
	public LuaFunction flOnApplicationPause = null;

	public virtual  void OnApplicationPause (bool pauseStatus)
	{
		if (flOnApplicationPause != null) {
			flOnApplicationPause.Call (pauseStatus);
		}
	}
	
	public LuaFunction flOnApplicationFocus = null;

	public virtual  void OnApplicationFocus (bool focusStatus)
	{
		if (flOnApplicationFocus != null) {
			flOnApplicationFocus.Call (focusStatus);
		}
	}
	
	public LuaFunction flOnBecameInvisible = null;

	public virtual  void OnBecameInvisible ()
	{
		if (flOnBecameInvisible != null) {
			flOnBecameInvisible.Call (gameObject);
		}
	}
	
	public LuaFunction flOnBecameVisible = null;

	public virtual  void OnBecameVisible ()
	{
		if (flOnBecameVisible != null) {
			flOnBecameVisible.Call (gameObject);
		}
	}
	
	public LuaFunction flOnControllerColliderHit = null;

	public virtual  void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (flOnControllerColliderHit != null) {
			flOnControllerColliderHit.Call (hit);
		}
	}
	
	public LuaFunction flOnDestroy = null;

	public override  void OnDestroy ()
	{
		if (flOnDestroy != null) {
			flOnDestroy.Call (gameObject);
		}
		base.OnDestroy ();
	}
	
	public LuaFunction flOnDisable = null;

	public virtual  void OnDisable ()
	{
		if (flOnDisable != null) {
			flOnDisable.Call (gameObject);
		}
	}
	
	public LuaFunction flOnEnable = null;

	public virtual  void OnEnable ()
	{
		if (flOnEnable != null) {
			flOnEnable.Call (gameObject);
		}
	}
	
	public LuaFunction flOnWillRenderObject = null;

	public virtual  void OnWillRenderObject ()
	{
		if (flOnWillRenderObject != null) {
			flOnWillRenderObject.Call (gameObject);
		}
	}
	
	public LuaFunction flOnPreRender = null;

	public virtual  void OnPreRender ()
	{
		if (flOnPreRender != null) {
			flOnPreRender.Call (gameObject);
		}
	}

	public LuaFunction flOnPostRender = null;

	public virtual  void OnPostRender ()
	{
		if (flOnPostRender != null) {
			flOnPostRender.Call (gameObject);
		}
	}
	
	public LuaFunction flOnClick = null;

	public virtual  void OnClick ()
	{
		if (flOnClick != null) {
			flOnClick.Call (gameObject);
		}
	}
	
	public LuaFunction flOnPress = null;

	public virtual  void OnPress (bool isPressed)
	{
		if (flOnPress != null) {
			flOnPress.Call (gameObject, isPressed);
		}
	}
	
	public LuaFunction flOnDrag = null;

	public virtual  void OnDrag (Vector2 delta)
	{
		if (flOnDrag != null) {
			flOnDrag.Call (gameObject, delta);
		}
	}

	public LuaFunction flUIEventDelegate = null;
	/// <summary>
	/// User interfaces the event delegate. 
	/// </summary>
	/// <param name="go">Go.</param>
	public virtual  void uiEventDelegate (GameObject go)
	{
		if (flUIEventDelegate != null) {
			flUIEventDelegate.Call (go);
		}
	}

}
