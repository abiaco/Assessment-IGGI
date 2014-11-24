using UnityEngine;
using System.Collections;

public class Floor_is_Lava : MonoBehaviour {

//public float Total_Time = 5.0f;
	// Use this for initialization
	//OnTriggerEnter(Collider other)
	//if (other.gameObject.tag == "Player")

public float TIME_LEFT;

	private bool experiment = true;
	


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