using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabScript : MonoBehaviour
{


    [SerializeField]
    private Transform playerCamTransform;
    private Rigidbody objectRB;
    private Transform objectGrabPointTransfrom;
    private float lerpSpeed = 9f;

    public GameObject camHolder;
    public GameObject playerHolder;

    public PlayerMovementAdvanced playerMovement;
    public PlayerCam camerMove;
    public RotateObj rotateObj;

    public GameObject player;

    public bool isFrozen;





    private void Start()
    {
        playerMovement = playerHolder.GetComponent<PlayerMovementAdvanced>();
        camerMove = camHolder.GetComponent<PlayerCam>();
        rotateObj = GetComponent<RotateObj>();
        objectRB.GetComponent<Rigidbody>();
        //objectRB.isKinematic = true;

    }


    private void FixedUpdate()
    {
        if (objectGrabPointTransfrom != null)
        {

            Vector3 newPos = Vector3.Lerp(transform.position, objectGrabPointTransfrom.transform.position, Time.deltaTime * lerpSpeed);
            objectRB.MovePosition(newPos);
            FreezeRotateOnRightClick();
        }

    }



    private void Awake()
    {
        objectRB = GetComponent<Rigidbody>();
    }



    public void Grab(Transform objectGrabPoint)
    {
        this.objectGrabPointTransfrom = objectGrabPoint;
        objectRB.useGravity = false;
    }

    public void Drop()
    {
        objectRB.isKinematic = false;
        objectRB.AddForce(playerCamTransform.forward * 9f, ForceMode.Impulse);
        this.objectGrabPointTransfrom = null;
        objectRB.useGravity = true;

        camerMove.enabled = true;
        playerMovement.enabled = true;
        rotateObj.enabled = false;
    }


    public void FreezeRotateOnRightClick()
    {
        if (objectGrabPointTransfrom != null)
        {
            isFrozen = true;
           
            objectRB.velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.Mouse1))
            {
                print("ur mom");
                camerMove.enabled = false;
                playerMovement.enabled = false;
                rotateObj.enabled = true;
                objectRB.velocity = Vector3.zero;
                objectRB.angularVelocity = Vector3.zero;

            }
            else
            {
                print("ur mom");
                camerMove.enabled = true;
                playerMovement.enabled = true;
                rotateObj.enabled = false;
            }


        }
    }



}
