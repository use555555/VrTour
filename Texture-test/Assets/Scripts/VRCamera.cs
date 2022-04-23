using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class VRCamera : MonoBehaviour
{ 
    // sensitivity of mouse
    private float rotateSpeed = 600.0f;
    //tourmanager
    private TourManager tourManager;
    public Camera vrCamera;
    void Start()
    {
        tourManager = GetComponent<TourManager>();
    }

	// Update is called once per frame
	void Update () 
    {
    }
    public void ResetCamera()
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            vrCamera.transform.localPosition = new Vector3(0, 0, 0);
        }

    public void CanvasCamera()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        vrCamera.transform.localPosition = new Vector3(10, 10, 0);
    }
}