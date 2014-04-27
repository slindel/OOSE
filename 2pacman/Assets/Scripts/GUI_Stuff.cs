using UnityEngine;
using System.Collections;

public class GUI_Stuff : MonoBehaviour {
	GUIText scoreDisplay;
	int coinScore;
	int jointScore;
	private int score = 0;

	void Update () {
				scoreDisplay.text = "Score: " + score;
		}
	void OnCollisionEnter (Collision  other) {
		if (other.gameObject.name == "coin") {
						score += coinScore;
				} else if (other.gameObject.name == "joint") {
						score += jointScore; 
				}
		Destroy (other.gameObject);
	
}

}

