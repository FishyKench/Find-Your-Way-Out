using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    // Start is called before the first frame update
    public float senX;
    public float senY;
    public GrabScript cube;
    public Rigidbody rb;
    private Quaternion defualtRotation;
    private Transform cam;


    void Start()
    {
        cube = GetComponent<GrabScript>();
        rb = GetComponent<Rigidbody>();

        defualtRotation = gameObject.transform.rotation;
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && cube.IsGrabbed == true)
        {
            gameObject.transform.rotation = defualtRotation;
        }
    }

    void FixedUpdate()
    {
        
        if (cube.isFrozen == true)
        {

            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;
            // transform.Rotate(Vector3.down, mouseX, Space.World);
            //transform.Rotate(Vector3.right, mouseY, Space.World);
            transform.RotateAroundLocal(cam.up, -Mathf.Deg2Rad * mouseX);
            transform.RotateAroundLocal(cam.right,Mathf.Deg2Rad * mouseY);
        }
    }
}
