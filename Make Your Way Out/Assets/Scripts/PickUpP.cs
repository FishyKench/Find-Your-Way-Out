using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpP : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("KeyBindings")]
    public KeyCode GrabKey = KeyCode.E;



    [SerializeField]
    private Transform playerCamT;
    [SerializeField]
    private float pickUpDistance;
    [SerializeField] private LayerMask pickUpLayerMask;

    [SerializeField]
    private Transform objectGrabT;



    private GrabScript grabScript;




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(GrabKey))
        {
            if (grabScript == null)
            {


                pickUpDistance = 2f;

                if (Physics.Raycast(playerCamT.position, playerCamT.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out grabScript))
                    {
                        grabScript.Grab(objectGrabT);
                    }
                }
            }

            else
            {
                grabScript.Drop();
                grabScript = null;

            }
        }
    }



    public Vector3 playerCamTGetter()
    {
        return playerCamT.transform.position;
    }
}
