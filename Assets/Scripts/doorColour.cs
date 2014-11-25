using UnityEngine;
using System.Collections;

public class doorColour : MonoBehaviour {

	public Color colour;
	public int doorNumber;

	// Use this for initialization
	void Start () {

		this.gameObject.renderer.material.color = colour;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
