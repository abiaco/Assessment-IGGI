using UnityEngine;
using System.Collections;
public class Elliptical_Movement : MonoBehaviour {
	public float range;
	private float YY;


	public float positive_force_Y;
	public float negative_force_Y;

	// Update is called once per frame
	void FixedUpdate () {
		YY = transform.position.y;
		rigidbody.AddForce(0,positive_force_Y, 0); //speed essentially
		if (range < YY) { //if it goes too far
			rigidbody.AddForce(0,negative_force_Y,0);
			//it will return. Therefore the second force must always be negative
			//print (transform.position.y);
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy"){
			Destroy(other.gameObject);
		}
	}
}