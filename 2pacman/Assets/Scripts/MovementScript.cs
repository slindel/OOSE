using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	int speed = 20; //player speed, change this for a faster/slower pace
	int gravity = -10; //gravity poiting down
	//initial scores for p1 and 2, and values for collectibles
	public int score1 =0; 
	public int score2 =0;
	public int coinScore = 10;
	public int jointScore = 100;

	private CharacterController cc;// character controller for the player
	public GUI_Stuff myGui; // connection to the gui_stuff class in order to pass the score values


	void Start () {
	cc=GetComponent<CharacterController>();
		myGui=GetComponent<GUI_Stuff>();
	}
	//move the player, and only the player in respect to the gravity, and the speed set before
	void Update () {
		if(networkView.isMine && this.gameObject.name=="player(Clone)"){
		Vector3 movementCoords= new Vector3 (Input.GetAxis("Horizontal") * speed * Time.deltaTime, gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		cc.Move (movementCoords);
		}
	}
	//handles colision between player and small collectibles
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ballPrefab(Clone)") {
			//Debug.Log("BALL COLLISION!");
			if(Network.isServer){
				myGui.score1 += coinScore;	}
			else myGui.score2+=coinScore;
			//Debug.Log (myGui.score1);
			Destroy(col.gameObject);
			
			//handles colision between player and big collectibles
		} else if (col.gameObject.name == "bigballPrefab(Clone)") {
			//Debug.Log ("BIGBALL COLLISION!");
			if(Network.isServer){
				myGui.score1+= jointScore;	}
			else myGui.score2+= jointScore;
			Destroy(col.gameObject);
		}
	}
}
