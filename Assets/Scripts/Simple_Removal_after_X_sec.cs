using UnityEngine;
using System.Collections;

public class Simple_Removal_after_X_sec : MonoBehaviour {

	public float Simple_TIME_LEFT;


	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			Destroy(other.gameObject,Simple_TIME_LEFT);
			//It killed it dead.
		}
	}

}
