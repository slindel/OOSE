using UnityEngine;
using System.Collections;

public class GUI_Stuff : MonoBehaviour {
	public int coinScore = 10;
	public int jointScore = 100;
	private int score = 0;
	public Color color;

	string scoreText = "Score: ";
	

	void Start () {

	}
	void OnGUI(){
			GUI.Label (new Rect (10, 10, 100, 20), "Score: "+score);
	}

	void Update () {

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ballPrefab(Clone)") {
			Debug.Log("BALL COLLISION!");

			score += coinScore;	
			Destroy(col.gameObject);

		} else if (col.gameObject.name == "bigballPrefab(Clone)") {
			Debug.Log ("BIGBALL COLLISION!");

			score += jointScore;
			Destroy(col.gameObject);
		}
	}
}


