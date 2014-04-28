using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector3 start_pos = new Vector3(0,15,0); //where the object will be placed when created
	public int color_r = 1;
	public int color_g = 0;
	public int color_b = 0;
	public Rect game_screen = new Rect(0,0,1,0.5f);

	//private Quaternion rot = Quaternion.identity; //quaternion.identity basically means 'no rotation'

	private GameObject player;
	private Camera cam;

	void Start () {

		//place a player in the scene, set position and color
		player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		player.AddComponent<Rigidbody> ();
		player.transform.position = start_pos;
		player.renderer.material = new Material(Shader.Find("Diffuse"));
		player.renderer.material.color = new Color(color_r,color_g,color_b) ;
		player.AddComponent("Player_controller");

		/*
		gameObject.AddComponent("Camera");
		cam = gameObject.GetComponent<Camera>();
		gameObject.AddComponent("CameraFollow");
		cam.rect = game_screen;

		cam.GetComponent<CameraFollow>().target = player.transform;
		*/
	}

}
