using UnityEngine;
using System.Collections;


//private bool Right_click_Pressed;

//although in theory a pause button can be made by reducing Time.timeScale to 0
// it is not that simple since certain unfinished player actions will still happen 

public class Time_Delay : MonoBehaviour {
	
	void Update() {
		if (Input.GetKeyDown("q")) {   //&& Right_click_Pressed == false)
			if (Time.timeScale == 1.0F) //realtime = 1
				Time.timeScale = 0.3F;  // the lower it is the slower time moves
				else
				Time.timeScale = 1.0F;
				Time.fixedDeltaTime = 0.02F * Time.timeScale;
			}
	}
}
