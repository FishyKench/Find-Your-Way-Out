using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementIndicator : MonoBehaviour
{
    public bool hasEntered;
    [SerializeField]
    private GrabScript grabscipt;
    [SerializeField]
    private TriggerTest triggerScript;

    [SerializeField]
    private GameObject _chessKing; // The King Prefab
    [SerializeField]
    private GameObject _chessRook; // The Rook Prefab
    [SerializeField]
    private GameObject _chessBishop; //The Bishop Prefab
    [SerializeField]
    private GameObject _chessQueen; // The Queen Prefab
    [SerializeField]
    private GameObject _chessKnight; // The Knight Prefab
    [SerializeField]
    private GameObject _chessPawn; // The Pawn Prefab

    private GameObject _chessPiece; // the refrence to the prefab to be able to destory it 

    public GameObject daPlayer;

    public bool hasKing;
    public bool hasRook;
    public bool hasBishop;
    public bool hasQueen;
    public bool hasKnight;
    public bool hasPawn;





    void Start()
    {
        
    }

    void Update()
    {
        if (triggerScript.hasPiece && triggerScript.currentPiece != null) // makes sure there is a piece
        {
            Destroy(_chessPiece);

            if (!hasEntered) // update once only.
            {
                hasEntered = true;

                ChessTypeChecker typeChecker = triggerScript.currentPiece.GetComponent<ChessTypeChecker>();
                if (typeChecker != null)
                {
                    ResetPieceFlags(); // reset all flags before setting the correct one

                    switch (typeChecker.Type)
                    {
                        case "King":
                            hasKing = true;
                            break;
                        case "Rook":
                            hasRook = true;
                            break;
                        case "Bishop":
                            hasBishop = true;
                            break;
                        case "Queen":
                            hasQueen = true;
                            break;
                        case "Knight":
                            hasKnight = true;
                            break;
                        case "Pawn":
                            hasPawn = true;
                            break;
                    }
                }
            }
        }
    }

    private void ResetPieceFlags()
    {
        hasKing = false;
        hasRook = false;
        hasBishop = false;
        hasQueen = false;
        hasKnight = false;
        hasPawn = false;
    }


    private void OnTriggerStay(Collider other)
    {
        if(hasEntered == false && triggerScript.GetComponent<TriggerTest>().hasPiece == false)
        {
            if(daPlayer.GetComponent<PickUpP>().isHoldingObject == true)
            {
                if(other.tag == "ChessPiece")
                {
                    switch (other.GetComponent<ChessTypeChecker>().Type)
                    {
                        case "King":
                            _chessPiece = Instantiate(_chessKing, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasKing = true;
                            break;
                        case "Rook":
                            _chessPiece = Instantiate(_chessRook, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasRook = true;
                            break;
                        case "Bishop":
                            _chessPiece = Instantiate(_chessBishop, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasBishop = true;
                            break;
                        case "Queen":
                            _chessPiece = Instantiate(_chessQueen, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasQueen = true;
                            break;
                        case "Knight":
                            _chessPiece = Instantiate(_chessKnight, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasKnight = true;
                            break;
                        case "Pawn":
                            _chessPiece = Instantiate(_chessPawn, this.transform.position, Quaternion.Euler(-90, 0, 0));
                            hasEntered = true;
                            hasPawn = true;
                            break;

                    }

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(_chessPiece);
        hasEntered = false;
        hasKing = false;
        hasRook = false;
        hasBishop = false;
        hasQueen= false;
        hasKnight = false;
        hasPawn = false;
        if (other.tag == "ChessPieceIn")
        {

            other.tag = "ChessPiece";
        }
    }


}
