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
    public GameObject gameUi;

    [SerializeField]
    private Transform playerCamT;
    [SerializeField]
    private float pickUpDistance;
    [SerializeField] private LayerMask pickUpLayerMask;

    [SerializeField]
    public Transform objectGrabT;

    [SerializeField]
    private RotateObj rotateScript;
    private GrabScript grabScript;

    public GameObject player;

    public bool itWasntGrab;
    public bool itwasSCUM;

    public bool isHoldingObject;



    void Start()
    {
        player.layer = 6;

        gameUi = GameObject.Find("inGamePanel");
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
                        isHoldingObject = true; // bool set to true when we successfully pick up an object

                        if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "King") // checks if knight is held
                        {
                            player.tag = "PlayerHoldingKing";
                        }
                        else if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "Rook")
                        {
                            player.tag = "PlayerHoldingRook";
                        }
                        else if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "King")
                        {
                            player.tag = "PlayerHoldingBishop";
                        }
                        else if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "Queen")
                        {
                            player.tag = "PlayerHoldingQueen";
                        }
                        else if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "Knight")
                        {
                            player.tag = "PlayerHoldingKnight";
                        }
                        else if (raycastHit.transform.gameObject.layer != 8 && raycastHit.transform.gameObject.GetComponent<ChessTypeChecker>().Type == "Pawn")
                        {
                            player.tag = "PlayerHoldingPawn";
                        }

                        //checks if the picked items is NOT scum nor a Grab
                        else if (raycastHit.transform.gameObject.layer != 8)
                        {
                            itWasntGrab = true;
                            raycastHit.transform.gameObject.layer = 8;
                        }
                        grabUi.SetActive(true);
                        gameUi.SetActive(false);
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
                gameUi.SetActive(true);
                isHoldingObject = false;
            }
        }
    }
}
