using UnityEngine;
using System.Collections;
using LuaInterface;

public class CameraZoom : MonoBehaviour
{
	public static CameraZoom self;
	public float speed = 1;
	public Camera camera;
	public Camera subCamera;
	
	float midFieldOfView = 60;
	float toFieldOfView = 60;
	bool isPlaying = false;
	float element = 1;
	object onFinsihCallback;
	bool needBack = false;
	float staySeconds = 0;
	bool isPlayBack = false;

	public CameraZoom()
	{
		self = this;
	}

	// Use this for initialization
	void Start()
	{
//		if (camera == null) {
//			camera = GetComponent<Camera>();
//			subCamera = GetComponentInChildren<Camera>();
//		}
		enabled = false;
	}

	float tmpField = 0;
	bool isFinished = false;
	// Update is called once per frame
	float toFiled = 0;
	void Update()
	{
		if (!isPlaying) {
			return;
		}
		tmpField = camera.fieldOfView;
		tmpField += element * Time.deltaTime * speed*50;
		toFiled = toFieldOfView;
		if (needBack && !isPlayBack) {
			toFiled = midFieldOfView;
		}
		if ((		element > 0 && tmpField - toFiled > 0) 
		    ||	(	element < 0 && tmpField - toFiled < 0)) {
			tmpField = toFiled;
			isFinished = true;
		}
		camera.fieldOfView = tmpField;
		if (subCamera != null) {
			subCamera.fieldOfView = tmpField;
		}
		if (isFinished) {
			if(needBack) {
				if(!isPlayBack) {
					isPlayBack = true;
					isPlaying = false;
					Invoke("playBack", staySeconds);
				} else {
					onFinish();
				}
			} else {
				onFinish();
			}
		}
	}

	void playBack() {
		zoom(toFieldOfView, speed, onFinsihCallback);
	}

	void onFinish()
	{
		isPlaying = false;
		enabled = false;
		if (onFinsihCallback != null) {
			if(onFinsihCallback.GetType() == typeof(Callback)) {
				((Callback)onFinsihCallback)(this);
			} else if(onFinsihCallback.GetType() == typeof(LuaFunction)) {
				((LuaFunction)onFinsihCallback).Call(this);
			}
		}
	}

	public void zoom(float zoomValue, float speed, object callback)
	{
		this.speed = speed;
		toFieldOfView = zoomValue;
		onFinsihCallback = callback;
		element = zoomValue - camera.fieldOfView > 0 ? 1 : (zoomValue - camera.fieldOfView == 0 ? 0 : -1);

		needBack = false;
		isFinished = false;
		enabled = true;
		isPlaying = true;
	}

	public void zoomFromTo(float mid, float to, float staySeconds, float speed, object callback)
	{
		midFieldOfView = mid;
		toFieldOfView = to;
		this.staySeconds = staySeconds;
		this.speed = speed;
		onFinsihCallback = callback;
		element = mid - camera.fieldOfView > 0 ? 1 : (mid - camera.fieldOfView == 0 ? 0 : -1);

		needBack = true;
		isFinished = false;
		isPlaying = true;
		enabled = true;
		isPlayBack = false;
	}
}
