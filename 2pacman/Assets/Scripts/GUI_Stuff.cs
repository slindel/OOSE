using UnityEngine;
using System.Collections;

public class GUI_Stuff : MonoBehaviour {

	int scoreMax=6040;
	public Buttons button;
	public Color color;
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	public NetworkManager NetMgr;
	 GUIStyle pacTxt;
	 GUIStyle copTxt;
	public MazeGeneration Mze;
	//public MovementScript Movement;
	public int score1=0;
	public int score2=0;
	public bool end=false;


	void Start () {
		btnX =Screen.width* 0.05f;
		btnY =Screen.height* 0.80f;
		btnW =Screen.width* 0.15f;
		btnH =Screen.height* 0.15f;
		NetMgr=GetComponent<NetworkManager>();
		Mze=GetComponent<MazeGeneration>();
		button=GetComponent<Buttons>();
		//Movement=GetComponent<MovementScript>();
		//score1= Movement.score1;
		//score2= Movement.score2;
	//	GameObject player= GameObject.FindGameObjectWithTag("player");

	}

	void OnGUI(){

		/*if(!Network.isClient && !Network.isServer){
			if (GUI.Button(new Rect(btnX, btnY, btnW, btnH), "Start Server")){
				Debug.Log("Starting Server");
				NetMgr.startServer();
			}
			if (GUI.Button(new Rect(btnX* 1.2f + btnW, btnY, btnW, btnH), "Load Servers")){
				Debug.Log("Refreshing");
				NetMgr.refreshServers();
			}
			if(NetMgr.hostData!=null){
				for(int i=0; i<NetMgr.hostData.Length; i++){
					if(GUI.Button(new Rect(btnX*4.5f +btnW , btnY, btnW*1.5f, btnH* 0.5f),NetMgr.hostData[i].gameName))
						Network.Connect(NetMgr.hostData[i]);
				}
			}

		}*/
		if(score1+score2<scoreMax){

			GUI.Label (new Rect (10, 10, 100, 20), "2pac: " + score1);
			GUI.Label (new Rect (120, 10, 100, 20), "Cop: " + score2);
		}
		else if (score1>score2){
			pacTxt.fontSize = 36;
			pacTxt.normal.textColor = Color.blue;
			GUI.Label(new Rect(Screen.width/2,btnY, 100, 100), "Game over, 2Pac won");
				
			}
		}
		else {
			GUI.Label(new Rect(Screen.width/2,Screen.height/2, 100, 100), "Game over, The officer won");
		}
	}

	


}


