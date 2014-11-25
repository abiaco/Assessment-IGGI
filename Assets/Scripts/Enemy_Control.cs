﻿using UnityEngine;
using System.Collections;

public class Enemy_Control : MonoBehaviour
{
    public float speed;
    public int power;
    private float moveX, moveY;
    private Vector3 move;
    public int health;
    public GUIText healthText;
    public Player_Control player;
    // Use this for initialization
    void Start()
    {
        power = 10;
        health = 100;
        setHealthText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //rigidbody.AddForce(move * speed * Time.deltaTime);
    }
/*    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_Control player = (Player_Control)other.GetComponent("PlayerControl");
            health -= player.power;
            setHealthText();
        }
        if (other.gameObject.tag == "Trampoline")
        {
            rigidbody.velocity = move + new Vector3(0.0f, 10f, 0.0f);
        }
    }
*/
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_Control player = (Player_Control)other.collider.GetComponent("PlayerControl");
            player.health -= power;
            setHealthText();
            if (player.health < 1)
            {
                player.healthText.text = " ";
                player.gameObject.SetActive(false);
            }
        }
    }
    void setHealthText()
    {
        healthText.text = "Enemy Health: " + health.ToString();
    }
}