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
    public int maxHealth = 10;
    public float healthBarLength;
    public int healthBarWidth; 
    public int healthBarHeight; 
    public GUISkin healthBarSkin; 
    public Vector3 screenPosition;

    // Use this for initialization
    void Start()
    {
        power = 1;
        health = 10;
        setHealthText();
        healthBarLength = Screen.width / 16;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>();

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
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;

        AddjustCurrentHealth(0);
            

        
    }


    void OnCollisionEnter(Collision other)

        //If enemy hits player...f
    {
        if (other.gameObject.tag == "Player")
        {
            
            audio.PlayOneShot(punchSound);
            player.health -= power;
            AddjustCurrentHealth(-3);
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

    void OnGUI()
    {
        GUI.Label(new Rect(screenPosition.x - 36, screenPosition.y - 35, Screen.width / 16, 7), "Health");
        GUI.Box(new Rect(screenPosition.x - 36, screenPosition.y - 35, healthBarLength, 7), "Health");
    }

    public void AddjustCurrentHealth(int adj) {
     health += adj;
     if (health < 1)
     {
         healthBarLength = 0;
         active = false;
         Destroy(this);
     }
     healthBarLength = (Screen.width / 16 ) * (health / (float)maxHealth);
 }
}
