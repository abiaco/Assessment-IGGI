﻿using UnityEngine;
using System.Collections;

public class faceCamera_damageText : MonoBehaviour
{

    public Camera mainCamera;
    

    // Use this for initialization
    void Start()
    {

        //Finds main camera and stores it as a variable for reuse.
        //This allows us to simply drop more enemies in the world without having to reassign variables every time.
        mainCamera = Camera.main;

    }


    void Update()
    {

        //This code ensures the text mesh is always facing the camera.
        //Makes object look in same direction as camera's forward axis.
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
            mainCamera.transform.rotation * Vector3.up);




    }
}
