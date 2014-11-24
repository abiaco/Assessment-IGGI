using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

	public GameObject player;
    //public Camera camera;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	

	//Doesn't need to be LateUpdate here - you use LateUpdate if there's something
	//in Update that has to happen first.
	void Update () 
	{
		if (player != null)
			transform.position = player.transform.position + offset;
	}
}
