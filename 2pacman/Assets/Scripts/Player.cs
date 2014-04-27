using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	private Vector3 moveDirection = new Vector3(0,0,0);
	private Vector3 forward = new Vector3(0,0,0);
	private Vector3 right = new Vector3(0,0,0);
	
	public int score;
	public float velocity = 10.0f;
	public float gravity = 100.0f;
	public float rotation_speed = 10.0f;

	private CharacterController controller = new CharacterController();
	public SphereCollider _collider = new SphereCollider();

	
	void Start () {
		gameObject.AddComponent("CharacterController");
		gameObject.AddComponent("SphereCollider");
		controller = gameObject.GetComponent<CharacterController>();
		_collider = gameObject.GetComponent<SphereCollider>();

	}
	
	// Update is called once per frame
	void Update () {
		Move_Translate();
		Move_Rotate();


	}

	public void Move_Translate(){
		Vector3 movement = new Vector3(0, 0, Input.GetAxis("Vertical"));
		
		movement = transform.TransformDirection(movement);
		movement*= velocity;
		if(!controller.isGrounded)
			movement.y -=gravity*Time.deltaTime;
		
		controller.Move (movement*Time.deltaTime);
		
	}
	
	public void Move_Rotate(){

		forward = transform.forward;
		right.x = forward.z;
		right.y = 0;
		right.z = -forward.x;
		
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		Vector3 targetDirection = horizontalInput*right + forward;
		moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 200*Mathf.Deg2Rad*Time.deltaTime, 1000);
		gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(targetDirection),rotation_speed*Time.deltaTime);

		
	}


}
