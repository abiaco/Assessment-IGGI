using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	

	public GameObject teleportPoint;

	void OnTriggerEnter(Collider other) {

        if (teleportPoint != null){
            other.gameObject.transform.position = teleportPoint.transform.position;
		}
}
}