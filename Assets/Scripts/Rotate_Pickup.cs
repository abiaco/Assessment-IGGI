using UnityEngine;
using System.Collections;

public class Rotate_Pickup : MonoBehaviour {

	public int ZSpinSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, ZSpinSpeed) * Time.deltaTime);
	}
}
