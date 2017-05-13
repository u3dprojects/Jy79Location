using System;
using UnityEngine;
using LuaInterface;

public class AnimationProc : MonoBehaviour
{
	public object onFinish;
	public object callbackPara;			//回调数
	bool canFixedUpdate = false;
	public bool isLoop = false;
	public bool isDestroySelf;
	public float timeOut = 0;
//	public GameObject receiver;
//	public string functionName;
	long frameCounter = 0;
	long hideFrame = 0;
	[HideInInspector]
	public int id;
	Animation animation;
	void Start ()
	{
		animation = GetComponent<Animation> ();
	}
	
	void OnEnable ()
	{
		frameCounter = 0;
		if (timeOut > 0) {
			hideFrame = Mathf.FloorToInt(timeOut/Time.fixedDeltaTime);
		}
		if (animation != null) {
			animation.Play ();
		}
		canFixedUpdate = true;
	}
	
	float curtTime = 0;

	void FixedUpdate ()
	{
		if(!canFixedUpdate) return;
		frameCounter++;
		if (timeOut > 0) {
			if (isDestroySelf) {
//				if (animation != null && !animation.isPlaying || curtTime - hideTime > 0) {
				if (frameCounter - hideFrame >= 0) {
					Destroy (gameObject);
				}
			} else {
//				if (animation != null && !animation.isPlaying || curtTime - hideTime > 0) {
				if (frameCounter - hideFrame >= 0) {
//					gameObject.SetActiveRecursively (false);
					gameObject.SetActive(false);
					Send ();
				}
			}
		} else {
			if (isDestroySelf) {
				if (GetComponent<Animation>() != null && !GetComponent<Animation>().isPlaying) {
					Destroy (gameObject);
				}
			} else {
				if (GetComponent<Animation>() != null && !GetComponent<Animation>().isPlaying) {
//					gameObject.SetActiveRecursively (false);
					gameObject.SetActive(false);
					Send ();
				}
			}
		}
	}
	
	void Send ()
	{
		canFixedUpdate = false;
		if (onFinish != null) {
			if (onFinish.GetType () == typeof(Callback)) {
				((Callback)onFinish) (this);
			} else if (onFinish.GetType () == typeof(LuaFunction)) {
				((LuaFunction)onFinish).Call (this);
			}
		}
	}
	
}
