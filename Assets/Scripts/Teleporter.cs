using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	//public GameObject player;

	public GameObject teleportPoint;

	void OnTriggerEnter(Collider other) {
		//if (teleportPoint != null && other.gameObject.tag == "Player")
        if (teleportPoint != null)
		{
			//other.gameObject.transform.position = new Vector3(2, 10 , -23);
            other.gameObject.transform.position = teleportPoint.transform.position;
		}
}
}