using UnityEngine;
using System.Collections;

public class CLLaser : CLBullet
{
	Transform _target;
	LineRenderer[] _lrs;
	
	public LineRenderer[] lrs {
		get {
			if (_lrs == null) {
				_lrs = GetComponentsInChildren<LineRenderer> ();
			}
			return _lrs;
		}
	}
	
	// Use this for initializationthis._target
	void Start ()
	{
		for(int i=0; i < lrs.Length; i++) {
			lrs[i].SetPosition (0, transform.position);
		}
	}
	
	bool isStop = true;
	int count = 0;
	// Update is called once per frame
	void LateUpdate ()
	{
		if (isStop || _target == null ||(target != null && target.isDead)) {
			isStop = true;
			NGUITools.SetActive (gameObject, false);
			return;
		}
		
		count = lrs.Length;
		for(int i=0; i < count; i++) {
			lrs[i].SetPosition (0, transform.position);
			lrs[i].SetPosition (1, _target.position + Vector3.up*0.3f);
		}
		if(!isCalledCallback && finishCallback != null) {
			isCalledCallback = true;
			if(finishCallback.GetType() == typeof(LuaInterface.LuaFunction)) {
				((LuaInterface.LuaFunction)finishCallback).Call(this);
			} else if(finishCallback.GetType() == typeof(Callback)) {
				((Callback)finishCallback)(this);
			}
		}
	}
	
	object finishCallback = null;
	bool isCalledCallback = false;
	public void fire (Transform _target, object callback)
	{
		
		isCalledCallback = false;
		this.finishCallback = callback;
		this._target = _target;
		target = _target.GetComponentInParent<SUnit>();
		isStop = false;
		NGUITools.SetActive (gameObject, true);
	}
	
	public void stop() {
		isStop = true;
	}
}
