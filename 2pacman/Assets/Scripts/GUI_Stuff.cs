using UnityEngine;
using System.Collections;

public class GUI_Stuff : MonoBehaviour {
	public int coinScore = 10;
	public int jointScore = 100;
	private int score = 0;
	public Color color;
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	public NetworkManager NetMgr;

	string scoreText = "Score: ";


	void Start () {
		btnX =Screen.width* 0.05f;
		btnY =Screen.height* 0.80f;
		btnW =Screen.width* 0.15f;
		btnH =Screen.height* 0.15f;
		NetMgr=GetComponent<NetworkManager>();

	}
	void OnGUI(){

		if(!Network.isClient && !Network.isServer){
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
		}
		else
			GUI.Label (new Rect (10, 10, 100, 20), "Score: "+score);
	}

	void Update () {
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ballPrefab(Clone)") {
			//Debug.Log("BALL COLLISION!");
			score += coinScore;	
			Destroy(col.gameObject);

		} else if (col.gameObject.name == "bigballPrefab(Clone)") {
			//Debug.Log ("BIGBALL COLLISION!");
			score += jointScore;
			Destroy(col.gameObject);
		}
	}
}


