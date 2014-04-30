using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MazeGeneration : MonoBehaviour {

	public Texture pacTex;
	public Texture copTex;
	public Transform wallPrefab;
	public Transform ballPrefab;
	public Transform bigballPrefab;
	public GameObject pacPrefab;
	public GameObject copPrefab;
	public Transform spawnObject1;
	public Transform spawnObject2;
	Color pacColor;

	string[,] map;
	
	// Use this for initialization
	void Start () {

		map = new string[,] { {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X"}, 
			{"X", "P", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "X"}, 
			{"X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", ".", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", ".", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X"}, 
			{"X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", "X", "X"}, 
			{"X", ".", ".", ".", ".", ".", "X", "O", ".", ".", ".", ".", ".", ".", ".", ".", "X", "O", ".", ".", "X", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", "X", ".", "X", ".", "X", ".", ".", ".", "X"}, 
			{"X", ".", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X", "X", "X", "X", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", "O", ".", ".", ".", ".", "X"}, 
			{"X", ".", "X", ".", "X", "X", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", "X", "X", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", ".", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", ".", ".", ".", ".", "X", ".", "X", "X", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "X", ".", "X", ".", "O", ".", "X", ".", "X", ".", ".", ".", ".", ".", ".", ".", "X", ".", "X", ".", "X", ".", ".", ".", "X"}, 
			{"X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", ".", "X", ".", "X", ".", ".", ".", "X", ".", "X", ".", "X", "X", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X"}, 
			{"X", ".", ".", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", "X", ".", ".", ".", "X", ".", "X"}, 
			{"X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", ".", "X", "X", "X", "X", "X", "X", "X", ".", ".", ".", "X", "X", "X", "X", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", ".", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", "X", "X", "X", "X", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", "X", ".", "X", ".", "X", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", ".", ".", "X", ".", ".", ".", "X", ".", "X", ".", "X"}, 
			{"X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", "X"}, 
			{"X", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", "O", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X"}, 
			{"X", ".", "X", ".", "X", "X", "X", ".", "X", "X", "X", ".", "X", "X", "X", "X", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", ".", "X", "X", "X", ".", "X", "O", "X", "X", "X", "X", "X"}, 
			{"X", "O", ".", ".", "X", ".", ".", ".", ".", ".", "X", ".", "X", ".", ".", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X"}, 
			{"X", ".", "X", "X", "X", ".", "X", ".", "X", "X", "X", ".", "X", ".", "X", "X", "X", "X", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", "X", "X", ".", "X", "X", "X", ".", "X"}, 
			{"X", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", "X", "O", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "X", ".", ".", ".", ".", ".", ".", ".", "X", ".", ".", ".", "."}, 
			{"X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X"}, 
		};
		
		string wallChar = "X";
		string ballChar = ".";
		string bigballChar = "O";

		Vector3 v = new Vector3 ();
		v.y = 1.0f;
		
		for (int i = 0; i < map.GetLength(0); i++){
			v.z = (i * 2) - 1 - map.GetLength(0);
			for(int j = 0; j < map.GetLength(1); j++) {
				v.x = (j * 2)  - map.GetLength(1);
				if (map[i,j].Equals(wallChar)) {
					GameObject wall = Instantiate(wallPrefab, v, Quaternion.identity) as GameObject;
					transform.parent = transform;
				} else if(map[i,j].Equals(ballChar)){
					GameObject ball = Instantiate(ballPrefab, v, Quaternion.identity) as GameObject;
					transform.parent = transform;
				}else if(map[i,j].Equals(bigballChar)){
					GameObject bigball = Instantiate(bigballPrefab, v, Quaternion.identity) as GameObject;
					transform.parent = transform;
				}
			}
		}
	}
	[RPC]
	public void setColor(Vector3 newColor){
		//renderer.material.color(newColor.x, newColor.y, newColor.z, 1);
		pacColor=new Color (newColor.x, newColor.y, newColor.z, 1);
		Debug.Log ("color change");
	}


	public void spawn2Pac(){
		Debug.Log ("2pacspawned");
		pacPrefab = Network.Instantiate(pacPrefab, spawnObject1.position, Quaternion.identity, 0) as GameObject;
		pacPrefab.renderer.material.color= pacColor;
		Debug.Log ("player spawned");
		}
	public void spawnCop(){
		copPrefab = Network.Instantiate(copPrefab, spawnObject2.position, Quaternion.identity, 0) as GameObject;
		copPrefab.renderer.material.color= Color.blue;

		Debug.Log ("cop spawned");

	}

}