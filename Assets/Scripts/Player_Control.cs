using UnityEngine;
using System.Collections;



public class Player_Control : MonoBehaviour
{

    public float speed;
    public GUIText countText;
    private int count;
    private float Jump;
    private float Double_Jump;
    private bool first_jump_pressed;
    public float Jump_Height;
    public int health;
    public GUIText healthText;
    public float MoveSpeed = 10;
    public float RotateSpeed = 40;

    void Start()
    {
        count = 0;
        health = 10;
        setCountText();
        setHealthText();
        first_jump_pressed = false;

    }

    void FixedUpdate()
    {

        //Controls the player using standard input (WASD/Arrows) and spacebar.
        


        //If spacebar is pressed and player can jump (first_jump_pressed=false), then jump
        if (Input.GetKeyDown("space") && first_jump_pressed == false)
        {
            Debug.Log("SPACE HAS BEEN PRESSED");
            rigidbody.AddForce(Vector3.up * Jump_Height);
        }

    }

    void Update()
    {
        //Displays how much health is left
        float MoveForward = Input.GetAxis("Vertical") * MoveSpeed;
        float MoveRotate = Input.GetAxis("Horizontal") * RotateSpeed;
        transform.Translate(Vector3.forward * MoveForward);
        transform.Rotate(Vector3.up * MoveRotate);
        setHealthText();
    }

    void OnCollisionExit(Collision col)
    {

        //Whenever the player hits ANY collision, there's a debug statement.
        //Debug.Log ("COLLISION");

        //When the player leaves the ground, this stops them jumping in mid-air
        //---Except it doesn't! There seems to be a bug in this sometimes - particularly near walls.
        if ((col.gameObject.name == "Ground") && first_jump_pressed == false)
        {
            first_jump_pressed = true;
        }
    }

    //When player hits pickup, disables it.
    //NOTE: Why aren't we destroying it?
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
    }

    void OnCollisionEnter(Collision lol)
    {

        Debug.Log("ENTRY COLLISION");
        //Resets first_jump_pressed so player can jump again.
        /*
         * Do we need the first_jump_pressed condition? Shouldn't we always be resetting
        //the 'allow jump' variable when player hits the ground?
         */
        if ((lol.gameObject.name == "Ground") && first_jump_pressed == true)
        {
            first_jump_pressed = false;
        }
    }

    void setCountText()
    {
        //Updates Count in GUI to reflect pickup
        countText.text = "Count: " + count.ToString();
    }

    void setHealthText()
    {
        //Updates Health in GUI to reflect changes.
        healthText.text = "Health: " + health.ToString();
    }
}