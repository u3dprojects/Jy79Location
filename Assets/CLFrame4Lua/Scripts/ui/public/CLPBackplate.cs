using UnityEngine;
using System.Collections;

//档板
public class CLPBackplate : CLPanelLua
{
	public static CLPBackplate self;
//	public UITexture textureBg;
//	public Camera camera;
	public CLPBackplate ()
	{
		self = this;
	}

	public override void show() {
		base.show();
//		NGUITools.SetActive(textureBg.gameObject, false);
//		textureBg.mainTexture = null;
//		textureBg.width = Screen.width;
//		textureBg.height = Screen.height;
//		isDoLateUpdate = true;
	}

	bool isDoLateUpdate = false;
	Texture2D tex;
//	void OnRenderObject()  {
//		if (!isDoLateUpdate) {
//			return;
//		}
//		StartCoroutine(getCapture());
//	}
//	Rect rect = new Rect(0,0,Screen.width,Screen.height);
//	IEnumerator getCapture() {
//		yield return new WaitForEndOfFrame();
//		if (tex == null) {
//			tex = new Texture2D( Screen.width, Screen.height);
//		}
//		tex.ReadPixels(rect,0,0);
//		tex.Apply();
//		textureBg.mainTexture = tex;
//		isDoLateUpdate = false;
//	}

	public void proc (CLPanelBase clpanel)
	{
		if (clpanel == null
			) {
			hide ();
			return;
		}
		if (clpanel.isNeedBackplate) {
			show ();
			this.panel.depth = clpanel.panel.depth - 1;
			Vector3 pos = transform.localPosition;
			this.panel.renderQueue = UIPanel.RenderQueue.StartAt;
			// 设置startingRenderQueue是为了可以在ui中使用粒子效果，注意在粒子中要绑定CLUIParticle角本
			this.panel.startingRenderQueue = CLPanelManager.Const_RenderQueue + this.panel.depth;
			pos.z = -180;
			transform.localPosition = pos;
		} else {
			hide ();
		}
	}

}
