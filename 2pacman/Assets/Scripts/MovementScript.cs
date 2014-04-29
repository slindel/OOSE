using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	int speed = 20;
	int gravity = -5;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
	cc=GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(networkView.isMine){
		Vector3 movementCoords= new Vector3 (Input.GetAxis("Horizontal") * speed * Time.deltaTime, gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		cc.Move (movementCoords);
		//cc.Move(Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
		}
	}
}
