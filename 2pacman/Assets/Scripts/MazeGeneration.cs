using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MazeGeneration : MonoBehaviour {
	
	//Used to apply textures in real-time
	public Texture pacTex;
	public Texture copTex;
	//Transforms used for positioning the maze from array to 3D world
	public Transform wallPrefab;
	public Transform ballPrefab;
	public Transform bigballPrefab;
	//Player prefabs
	public GameObject pacPrefab;
	public GameObject copPrefab;
	//A spawning point for each player
	public Transform spawnObject1;
	public Transform spawnObject2;
	//Structure used to pass color to the pacPrefab
	Color pacColor;
	
	
	//The two-dimensional array of strings used for the maze generation
	string[,] map;
	
	// Use this for initialization
	void Start () {
		
		//The entire array initialized with unique strings representing gameobjects
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
		
		//Initialized strings used to define game objects by strings
		string wallChar = "X";
		string ballChar = ".";
		string bigballChar = "O";
		
		//3D vector used to store 3D positions
		Vector3 v = new Vector3 ();
		//Y-dimension is initially assigned to 1 to fit the horizontal level of the maze
		v.y = 1.0f;
		
		//For loops that goes through each element of the array and assigns X and Z values in accordance to the index numbers
		for (int i = 0; i < map.GetLength(0); i++){
			v.z = (i * 2) - 1 - map.GetLength(0);
			for(int j = 0; j < map.GetLength(1); j++) {
				v.x = (j * 2)  - map.GetLength(1);
				
				//After the array is run through, game objects are spawned/instantiated at each position based on the corresponding strings initialized previously (Prefab, position, and rotation)
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
	//Remote procedure call to receive the color broadcasted in the network class
	[RPC]
	public void setColor(Vector3 newColor){
		//renderer.material.color(newColor.x, newColor.y, newColor.z, 1);
		pacColor=new Color (newColor.x, newColor.y, newColor.z, 1);
		Debug.Log ("color change");
	}
	
	//Method used for spawning 2Pac (instantiated through network)
	public void spawn2Pac(){
		Debug.Log ("2pacspawned");
		pacPrefab = Network.Instantiate(pacPrefab, spawnObject1.position, Quaternion.identity, 0) as GameObject;
		pacPrefab.renderer.material.color= pacColor;
		Debug.Log ("player spawned");
	}
	//Method used for spawning 2Pac (instantiated through network)
	public void spawnCop(){
		copPrefab = Network.Instantiate(copPrefab, spawnObject2.position, Quaternion.identity, 0) as GameObject;
		copPrefab.renderer.material.color= Color.blue;
		Debug.Log ("cop spawned");
	}
}