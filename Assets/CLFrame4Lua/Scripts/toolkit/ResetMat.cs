using UnityEngine;
using System.Collections;

public class ResetMat : MonoBehaviour {
	public bool isRunOnlyEditerMode = false;
//	public Shader defaultShader;

	// Use this for initialization
	void Start () {
		if(!isRunOnlyEditerMode || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.WindowsEditor) {
			resetMat ();
		}
	}

	public void resetMat() {
		Utl.setBodyMatEdit(transform);
	}
	
}
