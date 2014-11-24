using UnityEngine;
using System.Collections;

public class Floor_is_Lava : MonoBehaviour {

public float Total_Time = 5.0f;
	// Use this for initialization
	//OnTriggerEnter(Collider other)
	//if (other.gameObject.tag == "Player")

public float TIME_LEFT;
private bool experiment = true;
private Player_Control player;
	


	void OnTriggerExit(Collider other) {
		if (other.gameObject.tag == "Player") 
		{
			experiment =false;//TIME_LEFT = 100000000; //-1 will not do 
		}
	}

	void OnTriggerStay(Collider other) {
		if ((other.gameObject.tag == "Player") && experiment)
		{
			Destroy(other.gameObject,TIME_LEFT);
			
		}
	}

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_Control player = (Player_Control)other.collider.GetComponent("Player_Control");
            player.health -= player.health / 3;
            if (player.health < 1)
            {
                player.healthText.text = " ";
                player.gameObject.SetActive(false);
                Destroy(player);
            }
        }
    }
}
//	void Update() {
//
//				Total_Time -= Time.deltaTime;
//				if(Total_Time < 0)
//			{
//					Destroy(gameObject.tag == "Player");
//				
//			}
//			}
//}
//
//	//void onTriggerExit(Collider other){
//	//	{if (other.gameObject.tag == "Player")
//	//		{Total_Time= 20f;}		