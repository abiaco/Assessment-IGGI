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
    public GameObject damageTextReport;
    public Vector3 playerDamageOffset;
    public int maxHealth = 10;
    public float healthBarLength;
    public int healthBarWidth; 
    public int healthBarHeight; 
    public GUISkin healthBarSkin; 
    public Vector3 screenPosition;


    // Use this for initialization
    void Start()
    {
        
        
        setHealthText();
        healthBarLength = Screen.width / 16;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Control>();

    }



    void Update()

       
    {

        //Function following the player.
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.transform.position, speed * Time.deltaTime);
        }

        // adjusting health bar position.
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;

        
    }


    void OnCollisionEnter(Collision other)

        //If enemy hits player...
    {
        if (other.gameObject.tag == "Player")
        {
            //Play combat sounds
            audio.PlayOneShot(punchSound);
            
            //Hurt player
            player.health -= power;

            setHealthText();

            //Get player to display damage readout
            Instantiate(damageTextReport, other.transform.position + playerDamageOffset, Quaternion.identity);
            TextMesh damage = damageTextReport.GetComponent<TextMesh>();
            damage.text = power.ToString();


            //Surely this should be on the player?! (TC)
            if (player.health < 1)
            {
                player.healthText.text = " ";
                player.gameObject.SetActive(false);
                Destroy(player);
            }
        }
    }

    //Sets health for enemyHealth text
    public void  setHealthText()
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
     }
     healthBarLength = (Screen.width / 16 ) * (health / (float)maxHealth);
 }
}
