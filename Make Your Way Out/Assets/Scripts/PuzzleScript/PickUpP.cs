using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpP : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("KeyBindings")]
    public KeyCode GrabKey = KeyCode.E;

    [Header("UI")]
    public GameObject grabUi;

    [SerializeField]
    private Transform playerCamT;
    [SerializeField]
    private float pickUpDistance;
    [SerializeField] private LayerMask pickUpLayerMask;

    [SerializeField]
    private Transform objectGrabT;

    [SerializeField]
    private RotateObj rotateScript;
    private GrabScript grabScript;

    public GameObject player;

    public bool itWasntGrab;
    public bool itwasSCUM;



    void Start()
    {
        player.layer = 6;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GrabKey))
        {
            if (grabScript == null)
            {
                pickUpDistance = 3f;
                if (Physics.Raycast(playerCamT.position, playerCamT.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out grabScript))
                    {

                        //checks if the picked up item is SCUM
                        if (raycastHit.transform.gameObject.layer == 13)
                        {
                            itwasSCUM = true;
                            raycastHit.transform.gameObject.layer = 8;
                        }


                        //checks if the picked items is NOT scum nor a Grab
                        else if (raycastHit.transform.gameObject.layer != 13 && raycastHit.transform.gameObject.layer != 8)
                        {
                            itWasntGrab = true;
                            raycastHit.transform.gameObject.layer = 8;
                        }
                        grabUi.SetActive(true);
                        player.layer = 7;
                        grabScript.Grab(objectGrabT);
                    }
                }
            }

            else
            {
                player.layer = 6;
                grabScript.Drop();
                grabScript = null;
                grabUi.SetActive(false);
            }
        }
    }

}
