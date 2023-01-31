using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpers : MonoBehaviour
{
    GrabScript grab;
    [SerializeField] float orthoSize;
    private void Start()
    {
        grab = GetComponent<GrabScript>();
    }

    private void Update()
    {
        if(grab.IsGrabbed == true)
        {
            FindObjectOfType<Camera>().orthographic = true;
            FindObjectOfType<Camera>().orthographicSize = orthoSize;
            FindObjectOfType<Camera>().GetComponent<PlayerCam>().enabled = false;
        }
        else
        {
            FindObjectOfType<Camera>().orthographic = false;
        }
    }
}
