using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour

{
    public bool hasPiece;
    public bool hasEntered;
    private GrabScript grabscipt;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "ChessPieceIn")
        {
            hasPiece = false;
            hasEntered = false;
            other.tag = "ChessPiece";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        grabscipt = other.gameObject.GetComponent<GrabScript>();
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
                StartCoroutine(UnFreeze());
                other.GetComponent<Rigidbody>().freezeRotation = false;
                other.tag = "ChessPieceIn";
                hasPiece = true;

            }
        }


    }
    IEnumerator UnFreeze()
    {
        yield return new WaitForSeconds(2);
        //other.GetComponent<Rigidbody>().freezeRotation = false;

    }
}
