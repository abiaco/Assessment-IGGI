using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

	public GameObject player;

	public GameObject teleportPoint;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.transform.position = new Vector3(2, 10 , -23);

		}
}
}