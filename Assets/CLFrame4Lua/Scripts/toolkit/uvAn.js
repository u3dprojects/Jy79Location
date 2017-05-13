#pragma strict

var scrollSpeed = 5;
var countX : int = 4;
var countY : int = 4;

public var offsetX = 0.0;
public var offsetY = 0.0;
public var singleX = 0.0;
public var singleY = 0.0;
private var singleTexSize;
private var isInit  = false;
function Start() {
//    singleTexSize = Vector2(1.0/countX, 1.0/countY);
    //renderer.material.mainTextureScale = singleTexSize;
    GetComponent.<Renderer>().material.mainTextureScale = Vector2(singleX, singleY);
    isInit = true;
}
function Update ()
{
	if(!isInit) return;
    var frame = Mathf.Floor(Time.time*scrollSpeed);
    offsetX = frame/countX;
    offsetY = -(1.0/countY) -(frame - frame%countX) /countY / countX;
    GetComponent.<Renderer>().material.SetTextureOffset ("_MainTex", Vector2(offsetX, offsetY));
}
