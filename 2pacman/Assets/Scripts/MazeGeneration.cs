using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MazeGeneration : MonoBehaviour {

	public Transform wallPrefab;
	public Transform ballPrefab;
	public Transform bigballPrefab;

	string[,] map;
	
	// Use this for initialization
	void Start () {

		map = new string[,] { {"X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X"}, 
			{"Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X"}, 
			{"X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "Y", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X"}, 
			{"X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X"}, 
			{"X", "X", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "X"}, 
			{"X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X"}, 
			{"X", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X"}, 
			{"X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X"}, 
			{"X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "Y", "X", "Y", "X", "X", "X", "X", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "X", "X", "Y", "X", "X", "X", "Y", "X"}, 
			{"X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y", "Y", "Y", "Y", "X", "Y", "Y", "Y", "Y"}, 
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
					GameObject cube = Instantiate(wallPrefab, v, Quaternion.identity) as GameObject;
					transform.parent = transform;
				}
			}
		}
	}
}