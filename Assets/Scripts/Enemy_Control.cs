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


    // Use this for initialization
    void Start()
    {

        setHealthText();

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
            
            //Update OWN health
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
}
