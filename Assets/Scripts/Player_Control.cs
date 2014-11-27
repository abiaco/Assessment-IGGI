﻿﻿using UnityEngine;
using System.Collections;
using System;



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
    public AudioClip jumpSound;
    public int power;
    public Enemy_Control enemyHealth;
    public GameObject damageTextReport;
    public Vector3 DamageOffset;
    


    void Start()
    {
        Caching.CleanCache();       
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
            first_jump_pressed = true;
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


        //When the player leaves the ground, this stops them jumping in mid-air
        //---Except it doesn't! There seems to be a bug in this sometimes - particularly near walls.
        if ((col.gameObject.name == "Ground") && first_jump_pressed == false)
        {
            audio.PlayOneShot(jumpSound);
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
        
        //Debug.Log("ENTRY COLLISION");
        //Resets first_jump_pressed so player can jump again.
        /*
         * Do we need the first_jump_pressed condition? Shouldn't we always be resetting
        //the 'allow jump' variable when player hits the ground?
         */
        if ((lol.gameObject.name == "Ground") && first_jump_pressed == true)
        {
            first_jump_pressed = false;
        }

        if (lol.gameObject.tag == "Enemy")
        {
            DamageText("");
            //Reduces Enemy health
            enemyHealth = lol.gameObject.GetComponent<Enemy_Control>();
            //enemyHealth.health -= power;
            enemyHealth.AddjustCurrentHealth(-power);
            enemyHealth.setHealthText();
            
            //Gives a damage readout
            enemyHealth.DamageText(power.ToString());

            //Kill enemy if their health is 0
            if (enemyHealth.health == 0) {

                Debug.Log("Enemy should die!");

                Destroy(lol.gameObject);

            }
        }
    }

    void setCountText()
    {
        if (countText != null)
        //Updates Count in GUI to reflect pickup
            countText.text = "Count: " + count.ToString();
    }

    void setHealthText()
    {
        if (healthText != null)
        //Updates Health in GUI to reflect changes.
            healthText.text = "Health: " + health.ToString();
    }

	void OnDestroy ()
    {
        VictoryConditions vc = GetComponent<VictoryConditions>();
        if(vc!=null)
        {
            if(vc.IsVictorious())
                return;
        }
		Debug.Log ("have been disabled");
		Application.LoadLevel(Application.loadedLevelName);
	}

    public void DamageText(String dmg)
    {
        Instantiate(damageTextReport, transform.position + DamageOffset, Quaternion.identity);
        TextMesh damage = damageTextReport.GetComponent<TextMesh>();
        damage.text = dmg.ToString();
    }
}