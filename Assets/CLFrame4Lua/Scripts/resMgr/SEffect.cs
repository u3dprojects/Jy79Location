using UnityEngine;
using System.Collections;
using LuaInterface;

[RequireComponent(typeof(AnimationProc))]
public class SEffect : MonoBehaviour
{
	AnimationProc _animationProc;

	public AnimationProc animationProc {
		get {
			if (_animationProc == null) {
				_animationProc = GetComponent<AnimationProc>();
			}
			return _animationProc;
		}
	}

	Transform _tr;

	public Transform transform {
		get {
			if (_tr == null) {
				_tr = gameObject.transform;
			}
			return _tr;
		}
	}

	public string effectName = "";
	public object willFinishCallback = null;
	public object willFinishCallbackPara;			//回调数
	public object finishCallback = null;
	public object finishCallbackPara;			//回调数
	public bool returnAuto = true;
	public float willFinishTime = 0;

	/// <summary>
	/// Plaies the delay.延迟播放特效
	/// </summary>
	/// <returns>The delay.</returns>
	/// <param name="name">Name.</param>
	/// <param name="pos">Position.</param>
	/// <param name="parent">Parent.</param>
	/// <param name="willFinishTime">Will finish time.</param>
	/// <param name="willFinishCallback">Will finish callback.</param>
	/// <param name="willFinishCallbackPara">Will finish callback para.</param>
	/// <param name="finishCallback">Finish callback.</param>
	/// <param name="finishCallbackPara">Finish callback para.</param>
	/// <param name="delaySec">Delay sec.</param>
	/// <param name="returnAuto">If set to <c>true</c> return auto.</param>
	public static SEffect playDelay(string name, Vector3 pos, Transform parent, float willFinishTime,
	                                object willFinishCallback, object willFinishCallbackPara, 
	                                object finishCallback, object finishCallbackPara, float delaySec, bool returnAuto = true)
	{
		if (string.IsNullOrEmpty(name)) {
			return null;
		}
        
        if(!SEffectPool.havePrefab (name)) {
            ArrayList list = new ArrayList();
            list.Add(name);
            list.Add(pos);
            list.Add(parent);
            list.Add(willFinishTime);
            list.Add(willFinishCallback);
            list.Add(willFinishCallbackPara);
            list.Add(finishCallback);
            list.Add(finishCallbackPara);
            list.Add(delaySec);
            list.Add(returnAuto);
            SEffectPool.setPrefab (name, (Callback)onFinishSetPrefab2, list);
            return null;
        }

        SEffect effect = SEffectPool.borrowEffect(name);
		if (effect == null) {
			return null;
		}
		NGUITools.SetActive(effect.gameObject, false);
		effect.effectName = name;
		CLMain.self.StartCoroutine(effect.playDelay(pos, parent, willFinishTime,
		                      willFinishCallback, willFinishCallbackPara, 
		                      finishCallback, finishCallbackPara, delaySec, returnAuto));
		return effect; 
	}

	public IEnumerator playDelay(Vector3 pos, Transform parent, float willFinishTime,
	                             object willFinishCallback, object willFinishCallbackPara, 
	                             object finishCallback, object finishCallbackPara, float delaySec, bool returnAuto)
	{
		yield return new WaitForSeconds(delaySec);
		show(pos, parent, willFinishTime, willFinishCallback, willFinishCallbackPara,
		      finishCallback, finishCallbackPara, returnAuto);
	}

	public static SEffect play(string name, Vector3 pos, Transform parent, float willFinishTime,
		object willFinishCallback, object willFinishCallbackPara, 
		object finishCallback, object finishCallbackPara, bool returnAuto = true)
	{
		try{
		if (string.IsNullOrEmpty(name)) {
			return null;
		}
        if(!SEffectPool.havePrefab (name)) {
                ArrayList list = new ArrayList();
                list.Add(name);
                list.Add(pos);
                list.Add(parent);
                list.Add(willFinishTime);
                list.Add(willFinishCallback);
                list.Add(willFinishCallbackPara);
                list.Add(finishCallback);
                list.Add(finishCallbackPara);
                list.Add(returnAuto);
                SEffectPool.setPrefab (name, (Callback)onFinishSetPrefab, list);
            return null;
        }

		SEffect effect = SEffectPool.borrowEffect(name);
		if (effect == null) {
			return null;
		}
		effect.effectName = name;
		effect.show(pos, parent, willFinishTime, willFinishCallback, willFinishCallbackPara,
			finishCallback, finishCallbackPara, returnAuto);
		return effect;
		} catch(System.Exception e) {
			Debug.LogError(e);
			return null;
		}
	}
    public static void onFinishSetPrefab(params object[] args) {
        SEffect effect = (SEffect)(args[0]);
        if(effect != null) {
            ArrayList list = (ArrayList)(args[1]);
            string name = list[0].ToString();
            Vector3 pos = (Vector3)(list[1]);
            Transform parent = (Transform)(list[2]);
            float willFinishTime = (float)(list[3]);
            object willFinishCallback = list[4];
            object willFinishCallbackPara = list[5];
            object finishCallback = list[6];
            object finishCallbackPara = list[7];
            bool returnAuto =(bool)(list[8]);
            play(name, pos, parent, willFinishTime,
                 willFinishCallback, willFinishCallbackPara, 
                 finishCallback, finishCallbackPara, returnAuto);
        }
        
    }
    public static void onFinishSetPrefab2(params object[] args) {
        SEffect effect = (SEffect)(args[0]);
        if(effect != null) {
            ArrayList list = (ArrayList)(args[1]);
            string name = list[0].ToString();
            Vector3 pos = (Vector3)(list[1]);
            Transform parent = (Transform)(list[2]);
            float willFinishTime = (float)(list[3]);
            object willFinishCallback = list[4];
            object willFinishCallbackPara = list[5];
            object finishCallback = list[6];
            object finishCallbackPara = list[7];
            float delaySec = (float)(list[8]);
            bool returnAuto =(bool)(list[9]);
            playDelay(name, pos, parent, willFinishTime,
                 willFinishCallback, willFinishCallbackPara, 
                 finishCallback, finishCallbackPara, delaySec, returnAuto);
        }
        
    }
    
    public static SEffect play(string name, Vector3 pos, object finishCallback, object finishCallbackPara)
	{
		return play(name, pos, null, 0, null, null, finishCallback, finishCallbackPara, true);
	}

	public static SEffect play(string name, Vector3 pos, Transform parent)
	{
		return play(name, pos, parent, 0, null, null, null, null, true);
	}
	
	public static SEffect play(string name, Vector3 pos)
	{
		return play(name, pos, null, 0, null, null, null, null, true);
	}
	public void show(
		Vector3 pos, Transform parent, float willFinishTime,
		object willFinishCallback, object willFinishCallbackPara, 
		object finishCallback, object finishCallbackPara, bool returnAuto = true)
	{
		this.willFinishTime = willFinishTime;
		transform.parent = parent;
		transform.position = pos;
		transform.localScale = Vector3.one;
		transform.localEulerAngles = Vector3.zero;
		this.willFinishCallback = willFinishCallback;
		this.willFinishCallbackPara = willFinishCallbackPara;
		this.finishCallback = finishCallback;
		this.finishCallbackPara = finishCallbackPara;
		animationProc.callbackPara = finishCallbackPara;
		this.returnAuto = returnAuto;
		Callback cb = onFinish;
		animationProc.onFinish = cb;
		NGUITools.SetActive(gameObject, true);
		if (willFinishTime > 0.00001f) {
			Invoke("doWillfinishCallback", willFinishTime);
		}
	}
	
	void doWillfinishCallback()
	{
		if (willFinishCallback != null) {
			if (willFinishCallback.GetType() == typeof(Callback)) {
				((Callback)willFinishCallback)(this);
			} else if (willFinishCallback.GetType() == typeof(LuaFunction)) {
				((LuaFunction)willFinishCallback) .Call(this);
			}
		}
	}

	public void onFinish(params object[] obj)
	{
		if (returnAuto || obj == null) {
			SEffectPool.returnEffect(effectName, this);
			NGUITools.SetActive(gameObject, false);
			if(returnAuto) {
				transform.parent = null;
			}
		}
		if (finishCallback != null) {
			if (finishCallback.GetType() == typeof(Callback)) {
				((Callback)finishCallback)(this);
			} else if (finishCallback.GetType() == typeof(LuaFunction)) {
				((LuaFunction)finishCallback) .Call(this);
			}
		}
	}
	
	public void Start()
	{
#if UNITY_EDITOR
		//因为是通过assetebundle加载的，在真机上不需要处理，只有在pc上需要重设置shader
		Utl.setBodyMatEdit(transform);
#endif
	}

	ParticleSystem[] _particleSys;

	public ParticleSystem[] particleSys {
		get {
			if (_particleSys == null) {
				_particleSys = gameObject.GetComponentsInChildren<ParticleSystem>();
			}
			return _particleSys;
		}
	}
	
	Animator[] _animators;

	public Animator[] animators {
		get {
			if (_animators == null) {
				_animators = gameObject.GetComponentsInChildren<Animator>();
			}
			return _animators;
		}
	}
	
	Animation[] _animations;

	public Animator[] animations {
		get {
			if (_animations == null) {
				_animations = gameObject.GetComponentsInChildren<Animation>();
			}
			return _animators;
		}
	}
//	Hashtable particlesTimes = new Hashtable();
	public void pause()
	{
		if (particleSys != null && particleSys.Length > 0) {
			for (int i = 0; i < particleSys.Length - 1; i++) {
				particleSys [i].Pause();
//				particlesTimes[particleSys[i].GetInstanceID()] = particleSys[i].time;
			}
		}
		
		if (animations != null && animations.Length > 0) {
			for (int i = 0; i < animations.Length - 1; i++) {
				animations [i].enabled = false;
			}
		}
		
		if (animators != null && animators.Length > 0) {
			for (int i = 0; i < animators.Length - 1; i++) {
				animators [i].enabled = false;
			}
		}
	}

	public void regain()
	{
		if (particleSys != null && particleSys.Length > 0) {
			for (int i = 0; i < particleSys.Length - 1; i++) {
//				particleSys[i].time = (float)(particlesTimes[particleSys[i].GetInstanceID()]);
//				particleSys[i].Simulate((float)(particlesTimes[particleSys[i].GetInstanceID()]));
				particleSys [i].Play();
			}
		}
		
		if (animations != null && animations.Length > 0) {
			for (int i = 0; i < animations.Length - 1; i++) {
				animations [i].enabled = true;
			}
		}
		
		if (animators != null && animators.Length > 0) {
			for (int i = 0; i < animators.Length - 1; i++) {
				animators [i].enabled = true;
			}
		}
	}

    public void playSC(Vector3 pos, Transform parent, float willFinishTime,
                                 object willFinishCallback, object willFinishCallbackPara,
                                 object finishCallback, object finishCallbackPara, float delaySec, bool returnAuto)
    {
        StartCoroutine(playDelay(pos, parent, willFinishTime, willFinishCallback, willFinishCallbackPara, finishCallback, finishCallbackPara, delaySec, returnAuto));
    }
}
