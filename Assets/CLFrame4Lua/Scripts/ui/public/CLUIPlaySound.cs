using UnityEngine;
using System.Collections;

public class CLUIPlaySound : UIPlaySound {
	[HideInInspector]
	public string soundFileName = "Tap.wav";

	public bool isPlaySound = true;

	public string soundName = "Tap";

	public override void Play ()
	{
		if(isPlaySound)
			Toolkit.SoundEx.playSound(soundName, volume, 1);
	}
}
