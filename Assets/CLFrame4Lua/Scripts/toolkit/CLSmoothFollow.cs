using UnityEngine;

public class CLSmoothFollow : MonoBehaviour
{
	// The target we are following
	public Transform target;

	// The distance in the x-z plane to the target
	public float distance = 10.0f;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we 
	public float heightDamping = 2.0f;
	public float  rotationDamping = 3.0f;
	public bool  isCanRotate = true;
	public bool  isRole = false;
	float wantedRotationAngle = 0;
	float wantedHeight = 0;
	float currentRotationAngle = 0;
	float currentHeight = 0;
	Quaternion currentRotation;
	Vector3 pos = Vector3.zero;

	public void LateUpdate ()
	{
		// Early out if we don't have a target
		if (!target)
			return;
	
		// Calculate the current rotation angles
		wantedRotationAngle = target.eulerAngles.y;
		wantedHeight = target.position.y + height;
		
		currentRotationAngle = transform.eulerAngles.y;
		currentHeight = transform.position.y;
	
		if (Mathf.Abs (wantedRotationAngle - currentRotationAngle) < 160 || !isRole) {
			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		}

		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		if (isCanRotate) {
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;
		} else {
			var newPos = target.position;
			newPos.y -= distance;
			newPos.z -= distance;
			//newPos.x -= 5;
			transform.position = newPos;
		}

		// Set the height of the camera
		pos = transform.position;
		pos.y = currentHeight;
		transform.position = pos;
	
		// Always look at the target
		if (isCanRotate) {
			transform.LookAt (target);
		}
	}
}