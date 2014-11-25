using UnityEngine;
using System.Collections;

public class TeleporterColour : MonoBehaviour {

	public Color colour;

	// Use this for initialization
	void Start () {

		this.gameObject.renderer.material.color = colour;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
