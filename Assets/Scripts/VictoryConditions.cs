using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    
    private HashSet<GameObject> ItemsCollected;
    
    private bool Victory = false;
    
    public bool IsVictorious() { return Victory; }

	// Use this for initialization
	void Start () {
        Victory = false;
        ItemsCollected = new HashSet<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if(VictoryType == VictoryType.ArriveAtDestination && Destination != null)
        {
            if(Vector3.Distance(transform.position, Destination.transform.position) <= TriggerRange)
            {
                //Victory
                Debug.Log("You win by arriving at the destination.");
                Victory = true;
            }
        }
        
        if(VictoryType == VictoryType.CollectAllItems && ItemsToCollect.Length > 0)
        {
            foreach(GameObject go in ItemsToCollect)
            {
                if(Vector3.Distance(transform.position, go.transform.position) <= TriggerRange)
                {
                    ItemsCollected.Add(go);
                    go.SetActive(false);
                }
            }
            
            if(ItemsCollected.Count == ItemsToCollect.Length)
            {
                //Victory
                Debug.Log("You win by having collected all the items!");
                Victory = true;
            }
        }
        
        if(VictoryType == VictoryType.TouchLocationsInOrder && LocationsToTouch.Length > 0)
        {
            if(ItemsCollected.Count < LocationsToTouch.Length && Vector3.Distance(transform.position, LocationsToTouch[ItemsCollected.Count].transform.position) <= TriggerRange)
            {
                LocationsToTouch[ItemsCollected.Count].SetActive(false);
                ItemsCollected.Add(LocationsToTouch[ItemsCollected.Count]);
            }
            
            if(ItemsCollected.Count == LocationsToTouch.Length)
            {
                //Victory
                Debug.Log("You win by having touched all the locations in order!");
                Victory = true;
            }
        }
        
        if(Victory)
        {
            Application.LoadLevel("MainMenu");
        }
	}
}
