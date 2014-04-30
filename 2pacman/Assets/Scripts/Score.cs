using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public MazeGeneration ScoreMaze;
	void Start () {
		ScoreMaze = GetComponent<MazeGeneration>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
