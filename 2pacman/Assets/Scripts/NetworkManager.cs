using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	float btnX;
	float btnY;
	float btnW;
	float btnH;
	string gameName = "LSRM_2pacman";
	bool refreshing = false;
	public HostData[] hostData;
	int length;
	public GameObject playerPrefab;
	public Transform spawnObject1;
	public Transform spawnObject2;
	Vector3 SpawningPos;



	void Start () {
		 btnX =Screen.width* 0.05f;
		 btnY =Screen.height* 0.80f;
		 btnW =Screen.width* 0.15f;
		 btnH =Screen.height* 0.15f;
	}

	public void startServer(){
		bool useNat = !Network.HavePublicAddress();
		Network.InitializeServer(2,2500, useNat);
		MasterServer.RegisterHost(gameName, "2pac-man server","Object oriented programing exam");
	}

	public void refreshServers(){
		MasterServer.RequestHostList(gameName);
		refreshing=true;
		}

	public void Update(){
		if(refreshing){
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData= MasterServer.PollHostList();
			}
		}
	}

	public void spawnPlayer(){
		//SpawningPos
		Network.Instantiate(playerPrefab, spawnObject1.position, Quaternion.identity, 0);

	}

	void OnServerInitialized() {
		Debug.Log("Server initialized and ready");
		spawnPlayer();
	}
	
	void OnConnectedToServer(){
		spawnPlayer();
	}

	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registration succeded");
		}
	}

	// this part is handling the gui
	/*void OnGUI(){
		//GUI.Label(new Rect(btnX*1.5f +btnW , btnY*1.2f, btnW*3, btnH* 0.5f),"hello world");
		if(!Network.isClient && !Network.isServer){
			if (GUI.Button(new Rect(btnX, btnY, btnW, btnH), "Start Server")){
				Debug.Log("Starting Server");
				startServer();
			}
			if (GUI.Button(new Rect(btnX* 1.2f + btnW, btnY, btnW, btnH), "Load Servers")){
				Debug.Log("Refreshing");
				refreshServers();
			}
			if(hostData != null){
				for(int i=0; i<hostData.Length; i++){
					if(GUI.Button(new Rect(btnX*4.5f +btnW , btnY, btnW*1.5f, btnH* 0.5f),hostData[i].gameName))
					Network.Connect(hostData[i]);
				}
			}
		}
	}*/
}