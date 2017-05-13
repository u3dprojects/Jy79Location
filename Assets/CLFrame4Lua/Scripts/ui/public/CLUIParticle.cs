using UnityEngine;
using System.Collections;

/// <summary>
/// CLUI particle.在ui中使用粒子时，需要绑定该脚本，主要功能是设置粒子的renderQueue,使粒子可以在两个页面之间显示，而不总是显示在最顶层
/// </summary>
public class CLUIParticle : MonoBehaviour
{
	public UIPanel _panel;
	public int depth = 1;
	public int currRenderQueue = 0;
	Renderer[] _renders;
	Renderer[] renders {
		get {
			if(_renders == null) {
				_renders = GetComponentsInChildren<Renderer>();
			}
			return _renders;
		}
	}
	public UIPanel panel {
		get {
			if (_panel == null) {
				_panel = GetComponentInParent<UIPanel>();
			}
			return _panel;
		}
	}
	// Use this for initialization
	public void Start()
	{
		#if UNITY_EDITOR
		//因为是通过assetebundle加载的，在真机上不需要处理，只有在pc上需要重设置shader
		Utl.setBodyMatEdit(transform);
		#endif
	}

	// Update is called once per frame
	void LateUpdate()
	{
		setRenderQueue();
	}

	[ContextMenu("setRenderQueue")]
	void setRenderQueue()
	{
		Material mat = null;
		currRenderQueue = panel != null ? panel.startingRenderQueue + depth : depth;
		for(int i=0; i < renders.Length; i++) {
			mat = renders[i].material;
			if(mat != null) {
				Debug.Log("mat.renderQueue==" + mat.renderQueue);
				mat.renderQueue =  currRenderQueue;
			}
		}
	}
}
