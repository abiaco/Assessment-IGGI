using UnityEngine;
using System.Collections;



public class Player_Control : MonoBehaviour {

	public float speed;
	public GUIText countText;
	private int count;
	private float Jump;
	private float Double_Jump;
	private bool first_jump_pressed;
	public float Jump_Height;

	void Start() {
				count = 0;
				setCountText();
		first_jump_pressed = false;

		}
	 //Update is called once per frame


	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
//		Jump = Input.GetKey ("space");

		if (Input.GetKeyDown ("space") && first_jump_pressed == false) {
						Debug.Log ("SPACE HAS BEEN PRESSED");
						rigidbody.AddForce(Vector3.up * Jump_Height);
			
		}



			//if (first_jump_pressed == true) {



		      //Replace_Vector3.up and it makes a dash !
		//}

	}


	void OnCollisionExit(Collision col) {

				Debug.Log ("COLLISION");
		if ((col.gameObject.name == "Ground") && first_jump_pressed == false) {
						first_jump_pressed = true;
//						if (first_jump_pressed = true) {
//								first_jump_pressed = false;
//						}
				}
		}
	void OnCollisionEnter(Collision lol){
		Debug.Log ("ENTRY COLLISION");
			if ((lol.gameObject.name == "Ground") && first_jump_pressed ==true) {
				first_jump_pressed=false;
			}
		}

	void OnTriggerEnter(Collider other) {
				if (other.gameObject.tag == "Pickup") {
						other.gameObject.SetActive (false);
						count++;
						setCountText ();
				}
		}
	void setCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
