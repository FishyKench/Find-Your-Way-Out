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

    public GameObject PlayerCam;
    public GameObject playerHolder;

    public PlayerMovementAdvanced playerMovement;
    public PlayerCam camerMove;
    public RotateObj rotateObj;

    public PickUpP pickUpPlayer;

    public GameObject player;

    public bool isFrozen;

    public bool IsGrabbed;

    public float throwForce;

    private LayerMask originalLayer;





    private void Start()
    {
        playerMovement = playerHolder.GetComponent<PlayerMovementAdvanced>();
        camerMove = PlayerCam.GetComponent<PlayerCam>();
        rotateObj = GetComponent<RotateObj>();
        objectRB.GetComponent<Rigidbody>();

        throwForce = 9f;

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
        IsGrabbed = true;
        this.objectGrabPointTransfrom = objectGrabPoint;
        objectRB.useGravity = false;
        objectRB.gameObject.transform.SetParent(playerCamTransform);
    }

    public void Drop()
    {
        IsGrabbed = false;
        objectRB.gameObject.transform.SetParent(null);
        if (pickUpPlayer.itWasntGrab == true)
        {
            this.gameObject.layer = 10;

            objectRB.isKinematic = false;
            objectRB.AddForce(playerCamTransform.forward * throwForce, ForceMode.Impulse);
            this.objectGrabPointTransfrom = null;
            objectRB.useGravity = true;

            camerMove.enabled = true;
            playerMovement.enabled = true;
            rotateObj.enabled = false;
            player.tag = "Player";
            

        }
        else if (pickUpPlayer.itwasSCUM == true)
        {
            this.gameObject.layer = 13;

            objectRB.isKinematic = false;
            objectRB.AddForce(playerCamTransform.forward * throwForce, ForceMode.Impulse);
            this.objectGrabPointTransfrom = null;
            objectRB.useGravity = true;

            camerMove.enabled = true;
            playerMovement.enabled = true;
            rotateObj.enabled = false;
            
        }

        else
        {
            this.gameObject.layer = 8;
            objectRB.isKinematic = false;
            objectRB.AddForce(playerCamTransform.forward * throwForce, ForceMode.Impulse);
            this.objectGrabPointTransfrom = null;
            objectRB.useGravity = true;

            camerMove.enabled = true;
            playerMovement.enabled = true;
            rotateObj.enabled = false;
            
        }
    }


    public void FreezeRotateOnRightClick()
    {
        if (objectGrabPointTransfrom != null)
        {
            isFrozen = true;
           
            objectRB.velocity = Vector3.zero;
            if (Input.GetKey(KeyCode.Mouse1))
            {
                camerMove.enabled = false;
                playerMovement.enabled = false;
                rotateObj.enabled = true;
                objectRB.velocity = Vector3.zero;
                objectRB.angularVelocity = Vector3.zero;
            objectRB.gameObject.transform.SetParent(null);

            }
            else
            {
                camerMove.enabled = true;
                playerMovement.enabled = true;
                rotateObj.enabled = false;
                objectRB.gameObject.transform.SetParent(playerCamTransform);
            }


        }
    }



}
