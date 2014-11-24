using UnityEngine;
using System.Collections;

public class Elliptical_Movement : MonoBehaviour {

	//public Transform target;
//	public float speed;
	//public float range;

	//public Rigidbody ;
	public float range;

	private float YY;
	//Transform.position.y = new Vector2 Originalposition;

	// Update is called once per frame
	void FixedUpdate () {
		YY = transform.position.y;
		rigidbody.AddForce(0, 150, 0);  //speed essentially
		if (range < YY) {  //if it goes too far
						
			rigidbody.AddForce(0,-250,0);  //it will return. Therefore the second force must always be negative
		    //print (transform.position.y);
		    }


		}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject);
			
		}
}


		//t
		//float step = speed * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, target.position, step);
		//ConfigurableJointMotion(
		//transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
}