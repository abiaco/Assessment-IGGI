using UnityEngine;
using System.Collections;

public class MainMenuLevelSelect : MonoBehaviour {

    public string LevelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
    
    void OnMouseDown() {
        if(LevelToLoad.Length > 0)
        {
            Application.LoadLevel(LevelToLoad);
        }
    }
}
