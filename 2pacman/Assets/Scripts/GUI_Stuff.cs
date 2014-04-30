using UnityEngine;
using System.Collections;

public class GUI_Stuff : MonoBehaviour {

	int scoreMax=6040; //max possible score
	//some variables for positioning text
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	//initializing score
	public int score1=0;
	public int score2=0;
	public bool end=false; //to be used in buttons class


	void Start () {
		btnX =Screen.width* 0.05f;
		btnY =Screen.height* 0.80f;
		btnW =Screen.width* 0.15f;
		btnH =Screen.height* 0.15f;
	}
	//score text and game over text
	void OnGUI(){

		if(score1+score2<scoreMax){

			GUI.Label (new Rect (10, 10, 100, 20), "2pac: " + score1);
			GUI.Label (new Rect (120, 10, 100, 20), "Cop: " + score2);
		}
		else if (score1>score2){
			GUI.Label(new Rect(Screen.width/2,btnY, 100, 100), "Game over, 2Pac won");
			}
		else {
			GUI.Label(new Rect(Screen.width/2,Screen.height/2, 100, 100), "Game over, The officer won");
		}
	}
	
}


