using UnityEngine;
using System.Collections;



public class Player_Control : MonoBehaviour {

	public float speed;
	public GUIText countText;
	private int count;
    public int health;
    public GUIText healthText;

	void Start() {
				count = 0;
                health = 10;
				setCountText();
                setHealthText();
		}
	 //Update is called once per frame

	void FixedUpdate() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}

    void Update()
    {
        setHealthText();
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

    void setHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
