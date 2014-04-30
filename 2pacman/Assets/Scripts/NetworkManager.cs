using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	string gameName = "LSRM_2pacman"; // the unique name to be found on the Unity Master Server
	bool refreshing = false; // a bool to control the client
	public HostData[] hostData; //Master server info stored in here
	MazeGeneration maze; // relation with mazeGeneration class



	void Start () {
		maze=GetComponent<MazeGeneration>();
	}
	//initializing the server, note that now it's possible for only 2 players to connect, but the game supports more than 2
	public void startServer(){
		bool useNat = !Network.HavePublicAddress();
		Network.InitializeServer(2,2500, useNat);
		MasterServer.RegisterHost(gameName, "2pac-man server","Object oriented programing exam");
	}
	//checking for server with the unique server name stored in gameName
	public void refreshServers(){
		MasterServer.RequestHostList(gameName);
		refreshing=true;
		}
	//when a server is found, store it`s info in hostData, to be accesed later
	public void Update(){
		if(refreshing){
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData= MasterServer.PollHostList();
			}
		}
	}
	//spanw a player as server and broadcast it`s color 
	void OnServerInitialized() {
		Vector3 copColor=new Vector3 (1,0,0);
		networkView.RPC("setColor", RPCMode.AllBuffered, copColor);
		maze.spawn2Pac();

	}
	//spawn as many clients as necessary
	void OnConnectedToServer(){
		maze.spawnCop();
	}
	//debugging stuff
	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registration succeded");
		}
	}
	
}