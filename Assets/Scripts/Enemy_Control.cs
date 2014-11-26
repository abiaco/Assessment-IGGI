using UnityEngine;
using System.Collections;

public class Enemy_Control : MonoBehaviour
{
    public float speed;
    public int power;
    private float moveX, moveY;
    private Vector3 move;
    public int health;
    public TextMesh healthText;
    public Player_Control player;
    public AudioClip punchSound;


    // Use this for initialization
    void Start()
    {
        power = 1;
        health = 5;
        setHealthText();

        player = GameObject.FindGameObjectWithTag("Player")

    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()

       
    {

        //Function following the player.
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }


     

        
    }


    void OnCollisionEnter(Collision other)

        //If enemy hits player...f
    {
        if (other.gameObject.tag == "Player")
        {
            
            audio.PlayOneShot(punchSound);
            player.health -= power;
            setHealthText();
            if (player.health < 1)
            {
                player.healthText.text = " ";
                player.gameObject.SetActive(false);
                Destroy(player);
            }
        }
    }
    void setHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }
}
