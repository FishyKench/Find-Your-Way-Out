using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpers : MonoBehaviour
{
    //float maxDistance = 0;

    GrabScript grab;
    Camera cam;
    Rigidbody rb;

    
    [SerializeField] Vector3 localRot;
    [SerializeField]bool canMove = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<GrabScript>();
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        localRot = transform.rotation.eulerAngles;

        if (grab.IsGrabbed == true)
        {
            canMove = false;
            cam.GetComponent<PlayerCam>().enabled = false;
            FindObjectOfType<PlayerMovementAdvanced>().enabled = false;
            //switchtoOrtho();
            //calculateDistance();
        }
        else if(grab.IsGrabbed == false && canMove == false)
        {
            canMove = true;
            FindObjectOfType<PlayerMovementAdvanced>().enabled = true;
            cam.GetComponent<PlayerCam>().enabled = true;
        }
    }


}
