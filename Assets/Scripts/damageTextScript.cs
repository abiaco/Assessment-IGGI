using UnityEngine;
using System.Collections;

public class damageTextScript : MonoBehaviour
{

    public int floatDistance;
    private int floatCounter;
    public Vector3 offset;

    // Use this for initialization
    void Start()
    {

        floatCounter = 0;


    }

    // Update is called once per frame
    void Update()
    {
        //Code for making the text float up
        if (floatCounter < floatDistance)
        {

            transform.position = transform.position + offset;
            floatCounter++;
        }
        else
        {

            Destroy(this.gameObject);

        }


    }

}
