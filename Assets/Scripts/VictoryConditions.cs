using UnityEngine;
using System.Collections;

public enum VictoryType
{
    ArriveAtDestination = 1,
    CollectAllItems = 2,
    TouchLocationsInOrder = 3
}

public class VictoryConditions : MonoBehaviour {

    public VictoryType VictoryType = VictoryType.ArriveAtDestination;
    
    public GameObject Destination;
    
    public GameObject[] ItemsToCollect;
    
    public GameObject[] LocationsToTouch;
    
    public int TriggerRange = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(VictoryType == VictoryType.ArriveAtDestination)
        {
            if(Vector3.Distance(transform.position, Destination.transform.position) <= TriggerRange)
            {
                //Victory
                Debug.Log("You win.");
            }
        }
	}
}
