using UnityEngine;
using System.Collections;

public class Collectables : MonoBehaviour {


	int score = 0;
	// Function: on collision with coin, adds five points to the score
	public void OnCollisionEnter( Collision other ) {
		if (other.gameObject.name == "coin") {
						score += 5;
						Destroy (other.gameObject);
						Debug.Log ("Mie");
						Debug.Log (score);

				} 
		// When colliding with a joint, 10 points... 
		if (other.gameObject.name == "joint") {
						score += 10;
						Destroy (other.gameObject);
						Debug.Log ("HUZZAH");
				}
		else
						Debug.Log ("FUCCCCK");
	}
	
}
