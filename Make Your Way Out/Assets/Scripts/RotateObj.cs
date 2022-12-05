using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    // Start is called before the first frame update

    public float senX;
    public float senY;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        transform.Rotate(Vector3.up, mouseX, Space.World);
        transform.Rotate(Vector3.left, -mouseY, Space.World);
    }
}
