using UnityEngine;
using System.Collections;

public class Camera_Control : MonoBehaviour {

	//public GameObject player;
    public Camera camera;
	public Vector3 offset;

	// Use this for initialization
	void Start () {
		//offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		camera.transform.position = transform.position + offset;
	}
}
