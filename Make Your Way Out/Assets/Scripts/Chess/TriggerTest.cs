using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    public bool hasPiece;
    public bool hasEntered;
    public GameObject currentPiece; // stores the exact piece on this tile

    [SerializeField]
    private GrabScript grabscipt;
    public ChessTypeChecker chessTypeChecker; // reference to get the piece type

    private void OnTriggerStay(Collider other)
    {
        grabscipt = other.gameObject.GetComponent<GrabScript>();
        if (!hasEntered && !hasPiece)
        {
            if (other.CompareTag("ChessPiece") && !hasPiece && grabscipt.IsGrabbed == false)
            {
                hasEntered = true;
                hasPiece = true;
                currentPiece = other.gameObject; // track the piece

                other.GetComponent<Rigidbody>().velocity = Vector3.zero;
                other.transform.rotation = Quaternion.Euler(-90, 0, 0);
                other.GetComponent<Rigidbody>().freezeRotation = true;
                other.transform.position = transform.position;
                other.GetComponent<Rigidbody>().freezeRotation = false;

                other.tag = "ChessPieceIn";

                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentPiece) // oonly reset if the piece is the one placed
        {
            hasPiece = false;
            hasEntered = false;
            currentPiece = null;
            other.tag = "ChessPiece";
        }
    }
}
