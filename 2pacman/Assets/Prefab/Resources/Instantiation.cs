using UnityEngine;
using System.Collections;

public class Instantiation : MonoBehaviour {

	//private Vector3 pos = Vector3.zero; //where the object will be place when instantiated
	//private Quaternion rot = Quaternion.identity; //quaternion.identity basically means 'no rotation'

	private GameObject player;
	private Camera cam;
	private GameObject cam_obj;


	void Start () {

		//place a player in the scene, set position and color
		player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		player.transform.position = new Vector3 (0,0,0);
		player.renderer.material = new Material(Shader.Find("Diffuse"));
		player.renderer.material.color = new Color(1,0,0);
		player.AddComponent("Player");


		gameObject.AddComponent("Camera");
		cam = gameObject.GetComponent<Camera>();
		gameObject.AddComponent("CameraFollow");
		cam.rect = new Rect(0, 0, 1,0.5f);

		cam.GetComponent<CameraFollow>().target = player.transform;

	}

}
