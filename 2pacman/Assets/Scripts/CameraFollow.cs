using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float distance = 10.0f;
	public float height = 5.0f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;

	void LateUpdate(){
	if(!target)
		return;

		//find the target's current angles and position
		float wantedRotationAngle = target.eulerAngles.y;
		float wantedHeight = target.position.y + height;

		//find the camera's current angles and position
		float currentRotationAngle = transform.eulerAngles.y;
		float currentHeight = transform.position.y;

		//damping the camera motion to avoid stiff movement - it will take a little time for the camera to catch up 
		//(this is done using the lerop(), as it linearly interpolates the two given points, i.e. creates a smooth transition from one point to another)

		//damp the rotation about the y-axis
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping*Time.deltaTime);
		//damp the height
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping);

		//convert angle into rotation of the camera
		Quaternion currentRotation = Quaternion.Euler(0,currentRotationAngle, 0);

		//position of camera on x-z plane to be at a distance behind target
		transform.position = target.position;
		transform.position -= currentRotation*Vector3.forward*distance;

		//temp vector of position because stupid c# won't let me modify struct fields on properties directly
		Vector3 tmp_position = transform.position;
		tmp_position.y = currentHeight;

		//height of the camera
		transform.position = tmp_position;

		//look at the target
		transform.LookAt(target);
	
	}
}
