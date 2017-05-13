using UnityEngine;
using System.Collections;

public class MyLookAt : MonoBehaviour
{
	public Transform target;
	public Vector3 offset = Vector3.zero;
	
	// Update is called once per frame
	Vector3 an = Vector3.zero;
	void Update ()
	{
		if (target == null) {
			
			if (Camera.main != null) {
				transform.rotation = Camera.main.transform.rotation;
				an = transform.localEulerAngles;
				an += offset;
				transform.localEulerAngles = an;
			}
		} else {
			transform.rotation = target.rotation;
			an = transform.localEulerAngles;
			an += offset;
			transform.localEulerAngles = an;
		}
	}
}
