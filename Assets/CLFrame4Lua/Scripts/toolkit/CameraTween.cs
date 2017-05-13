using UnityEngine;
using System.Collections;

/// <summary>
/// Camera tween.摄像机移动
/// </summary>
public class CameraTween : MonoBehaviour {
	Camera ca;
	public float speed = 1;
	// Use this for initialization
	void Start () {
		ca = GetComponent<Camera>();
	}
	
	Vector2 tmppos;
	Vector2 tmpsize;
	// Update is called once per frame
	void Update () {
		if(isPlayNow) {
			float dt = Time.deltaTime * speed;
			offset += dt;
			tmppos += diffPos*dt;
			tmpsize += diffSize * dt;
			ca.rect = new Rect(tmppos.x, tmppos.y, tmpsize.x, tmpsize.y);
			if(offset >= 1) {
				isPlayNow = false;
				tmppos = oldpos + diffPos;
				tmpsize = oldsize + diffSize;
				ca.rect = new Rect(tmppos.x, tmppos.y, tmpsize.x, tmpsize.y);
			}
		}
	}
	
	Vector2 diffPos;
	Vector2 diffSize;
	float offset = 0;
	Vector2 oldpos;
	Vector2 oldsize;
	bool isPlayNow = false;
	
	public void play(Rect toRect, float speed) {
		if(ca == null) {
			ca = GetComponent<Camera>();
			if(ca == null){
				Debug.LogError("can not find camera, this script muct binding a camera");
				return;
			}
		}
		this.speed = speed;
		oldpos = new Vector2(ca.rect.x, ca.rect.y);
		oldsize = new Vector2(ca.rect.width, ca.rect.height);
		tmppos = oldpos;
		tmpsize = oldsize;
		
		diffPos = new Vector2(toRect.x, toRect.y) - oldpos;
		diffSize = new Vector2(toRect.width, toRect.height) - oldsize;
		offset = 0 ;
		isPlayNow = true;
	}
}
