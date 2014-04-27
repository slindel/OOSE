using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {


	int score = 0;
	// Function: 
	public void OnCollisionEnter( Collision other ) {
		if (other.gameObject.name == "coin") {
						score += 5;
						Destroy (other.gameObject);
						Debug.Log ("Mie");
						Debug.Log (score);

				} 
		if (other.gameObject.name == "joint") {
						score += 10;
						Destroy (other.gameObject);
						Debug.Log ("HUZZAH");
				}
		else
						Debug.Log ("FUCCCCK");
	}
	
}
