using UnityEngine;
using System.Collections;

public class Destroy_Object : MonoBehaviour {

	public float Simple_TIME_LEFT;


	void OnCollisionEnter(Collision Liz){
		Debug.Log ("ENTRY COLLISION");
		if (Liz.gameObject.name == "Player") {
			Destroy(gameObject, Simple_TIME_LEFT);
		}
	}
}
