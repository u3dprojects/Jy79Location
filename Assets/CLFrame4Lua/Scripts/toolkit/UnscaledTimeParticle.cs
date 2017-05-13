using UnityEngine;
using System.Collections;

public class UnscaledTimeParticle : MonoBehaviour {
	ParticleSystem[] particleSystems;
	public bool ignoreTimeScale = true;
	// Use this for initialization
	void Start () {
		particleSystems = GetComponentsInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!ignoreTimeScale)
			return;
		if (Time.timeScale < 0.01f)
		{
			if(particleSystems != null) {
				for(int i=0; i < particleSystems.Length; i++) {
					particleSystems[i].Simulate(Time.unscaledDeltaTime, true, false);
				}
			}
		}
	}
}
