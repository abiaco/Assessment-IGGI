using UnityEngine;
using System.Collections;

public class SwitchColour : MonoBehaviour {

	public Color colour;
	public GameObject linkedDoor;

	// Use this for initialization
	void Start () {

		this.gameObject.renderer.material.color = colour;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Player") {
			Destroy (linkedDoor);
			//For now, I'm leaving the switch in there, just for kicks! (TC)
			//Destroy (this.gameObject);
		}

	}

}
