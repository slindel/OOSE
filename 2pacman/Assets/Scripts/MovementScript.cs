using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {
	int speed = 20;
	int gravity = -10;
	public int score1 =0;
	public int score2 =0;
	public int coinScore = 10;
	public int jointScore = 100;
	private CharacterController cc;
	public GUI_Stuff myGui;
	// Use this for initialization
	void Start () {
	cc=GetComponent<CharacterController>();
		myGui=GetComponent<GUI_Stuff>();
	}

	// Update is called once per frame
	void Update () {
		if(networkView.isMine && this.gameObject.name=="player(Clone)"){
		Vector3 movementCoords= new Vector3 (Input.GetAxis("Horizontal") * speed * Time.deltaTime, gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
		cc.Move (movementCoords);
		//cc.Move(Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, gravity * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime));
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ballPrefab(Clone)") {
			//Debug.Log("BALL COLLISION!");
			if(Network.isServer){
				myGui.score1 += coinScore;	
			}
			else myGui.score2+=coinScore;
			//Debug.Log (myGui.score1);
			Destroy(col.gameObject);
			
			
		} else if (col.gameObject.name == "bigballPrefab(Clone)") {
			//Debug.Log ("BIGBALL COLLISION!");
			if(Network.isServer){
				myGui.score1+= jointScore;	
			}
			else myGui.score2+= jointScore;
			Destroy(col.gameObject);
		}
	}
}
