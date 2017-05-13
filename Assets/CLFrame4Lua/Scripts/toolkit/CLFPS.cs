using UnityEngine;
using System.Collections;

public class CLFPS : MonoBehaviour
{
	public bool isPrintFps = true;
	public int baseFps = 30;
	public void OnGUI()
	{
		// call the method to draw the FPS label
		XGUI.xLabelFPS(2, isPrintFps);
	}
	
	public void FixedUpdate()
	{
		// increment the time that has passed with the fixedDeltaTime
		XGUI.timePassed++;
	}

	public float framesPerSecond {
		get {
			return XGUI.framesPerSecond;
		}
	}

	public float fpsRate {
		get {
			return baseFps/(framesPerSecond < 1.0f? 1.0f : framesPerSecond);
//			return framesPerSecond > 30 ? 0.5f : 1;
		}
	}
}

/// <summary>
/// Class for storing some stuffz we need
/// </summary>
public abstract class XGUIAbstract
{
	private static float? _fixedDeltaTime;
	
	/// <summary>
	/// interval at which the FixedUpdate method is called
	/// </summary>
	protected static float fixedDeltaTime {
		get {
			if (!_fixedDeltaTime.HasValue) {
				_fixedDeltaTime = Time.fixedDeltaTime;
			}
			return (float)_fixedDeltaTime;
		}
	}
	
	private static float _timePassed = 0;
	
	/// <summary>
	/// How much time has passed since last FPS display
	/// </summary>
	public static float timePassed {
		get { return _timePassed; }
		set { _timePassed = value == 0 ? 0 : _timePassed + fixedDeltaTime; }
	}
	
	/// <summary>
	/// Store the FPS of last update
	/// </summary>
	public static float framesPerSecond = 0;
	
	/// <summary>
	/// Store how many frames have passed since last FPS update
	/// </summary>
	protected static int framesPassed = 0;
	
}

public class XGUI : XGUIAbstract
{
	
	/// <summary>
	/// stores how many seconds needs to pass for FPS update
	/// </summary>
	private static float _interval;
	
	private XGUI()
	{
		
	}
	
	public static void xLabelFPS()
	{
		xLabelFPS(1, true);
	}
	
	public static void xLabelFPS(float interval, bool isPrintFps = true)
	{
		_interval = interval;
		string fps = XGUI.calculateFPS();
		if (isPrintFps) {
			GUI.Label(new Rect(10, 0, 100, 50), fps);
		}
	}
	
	
	
	/// <summary>
	/// Calculate the FPS
	/// </summary>
	/// <returns>String of FPS</returns>
	protected static string calculateFPS()
	{
		if (timePassed >= _interval) {
			float FPS = (Time.frameCount - framesPassed) / timePassed;
			framesPassed = Time.frameCount;
			framesPerSecond = FPS;
			timePassed = 0;
		}
		
		return framesPerSecond.ToString();
	}
}
