using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {
	

	public GameObject teleportPoint;
    public AudioClip teleportSound;

	void OnTriggerEnter(Collider other) {
        audio.PlayOneShot(teleportSound);
		//if (teleportPoint != null && other.gameObject.tag == "Player")
        if (teleportPoint != null){
            other.gameObject.transform.position = teleportPoint.transform.position;
		}
}
}