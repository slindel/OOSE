using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public NetworkManager netw;
	public GUI_Stuff Gstuff;
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	bool server;
	bool client;
	GUIStyle pacTxt;


	void Start () {


		btnX =Screen.width* 0.05f;
		btnY =Screen.height* 0.80f;
		btnW =Screen.width* 0.15f;
		btnH =Screen.height* 0.15f;
		netw=GetComponent<NetworkManager>();
		Gstuff=GetComponent<GUI_Stuff>();
	}
	



	void OnGUI(){

	if(!Network.isClient && !Network.isServer){
		if (GUI.Button(new Rect(btnX, btnY, btnW, btnH), "Start Server")){
			Debug.Log("Starting Server");
				netw.startServer();

		}
		if (GUI.Button(new Rect(btnX* 1.2f + btnW, btnY, btnW, btnH), "Load Servers")){
			Debug.Log("Refreshing");
				netw.refreshServers();
		}
			if(netw.hostData!=null){
				for(int i=0; i<netw.hostData.Length; i++){
				if(GUI.Button(new Rect(btnX*4.5f +btnW , btnY, btnW*1.5f, btnH* 0.5f),netw.hostData[i].gameName))
						Network.Connect(netw.hostData[i]);
			}
		}
		
	}



	}

	public void finish()
	{

		if(Gstuff.end==true){
			Debug.Log("made it to function");
			if(Gstuff.score1>Gstuff.score2){
				pacTxt.fontSize = 36;
				pacTxt.normal.textColor = Color.blue;
				GUI.Label(new Rect(Screen.width/2,btnY, 100, 100), "Game over, 2Pac won");
				if(GUI.Button(new Rect(btnX, btnY, btnW, btnH), "Restart")){
					Application.LoadLevel("scene2");
					Debug.Log ("it will execute more");
					//Mze.spawn2Pac();
					//Mze.spawnCop();
				}
			}
			else {
				GUI.Label(new Rect(Screen.width/2,Screen.height/2, 100, 100), "Game over, The officer won");
			}
		}

	}
}

