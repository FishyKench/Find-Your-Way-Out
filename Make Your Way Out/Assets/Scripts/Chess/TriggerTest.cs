using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour

{
    public bool hasPiece;
    public bool hasEntered;
    [SerializeField]
    private GrabScript grabscipt;

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



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }




    private void OnTriggerStay(Collider other)
    {

        grabscipt = other.gameObject.GetComponent<GrabScript>();
        if (other.tag == "ChessPiece")
        {
            switch (other.GetComponent<ChessTypeChecker>().Type)
            {
                case "King":
                    _chessPiece = Instantiate(_chessKing, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
                case "Rook":
                    _chessPiece = Instantiate(_chessRook, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
                case "Bishop":
                    _chessPiece = Instantiate(_chessBishop, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
                case "Queen":
                    _chessPiece = Instantiate(_chessQueen, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
                case "Knight":
                    _chessPiece = Instantiate(_chessKnight, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
                case "Pawn":
                    _chessPiece = Instantiate(_chessPawn, this.transform.position, Quaternion.Euler(-90, 0, 0));
                    break;
            }


        }


        if (hasEntered == false)
        {

            if (other.tag == "ChessPiece" && hasPiece == false && grabscipt.IsGrabbed == false)
            {
                hasEntered = true;
                other.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                other.transform.rotation = Quaternion.Euler(-90, 0, 0);
                other.GetComponent<Rigidbody>().freezeRotation = true;
                print(hasEntered);
                other.transform.localPosition = this.gameObject.transform.position;
                other.GetComponent<Rigidbody>().freezeRotation = false;
                other.tag = "ChessPieceIn";
                hasPiece = true;

            }
        }



    }
    private void OnTriggerExit(Collider other)
    {
        hasPiece = false;
        hasEntered = false;
        if (other.tag == "ChessPieceIn")
        {
            
            other.tag = "ChessPiece";
        }
    }
}
