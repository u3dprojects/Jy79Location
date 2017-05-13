using UnityEngine;
using System.Collections;

[AddComponentMenu("NGUI/Tween/Tween Sprite Fill")]

public class MyTweenSpriteFill : UITweener {

	[Range(0f,1f)]
	public float from;
	[Range(0f,1f)]
	public float to;


	UISprite mSprite;

	public float value
	{
		get
		{
			return mSprite.fillAmount;
		}
		set
		{
			mSprite.fillAmount = value;
		}
	}

	void Awake () { mSprite = GetComponent<UISprite>(); }

	protected override void OnUpdate (float factor, bool isFinished) { value = from * (1f - factor) + to * factor; }

	static public MyTweenSpriteFill Begin (GameObject go, float duration, float amount)
	{
		MyTweenSpriteFill comp = UITweener.Begin<MyTweenSpriteFill>(go, duration);
		comp.from = comp.value;
		comp.to = amount;
		
		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value; }
	
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value; }
	
	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; }
	
	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; }
}
