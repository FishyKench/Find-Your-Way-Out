using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessInteractable : interactable
{
    [SerializeField]
    private GameObject _chessPiecePref; // the prefab
    private GameObject _chessPiece; // the refrence to the prefab to be able to destory it 
    [SerializeField]
    private bool _spawned;
    public PickUpP pickUpScript;

    public Transform thisObject;

    private void Start()
    {
        pickUpScript.GetComponent<PickUpP>();
    }


    //when player is looking at this object
    public override void OnFocus()
    {
        if (_spawned == false && pickUpScript.isHoldingObject == true)
        {
            _chessPiece = Instantiate(_chessPiecePref,this.transform.position,Quaternion.Euler(-90,0,0));
            _spawned = true;
        }
    }

    //when player clicks the interact button (Default E) on this object
    public override void OnInteract()
    {

    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {
        if(_spawned == true)
        {
           Destroy(_chessPiece);
            _spawned = false;
        }
    }


}
