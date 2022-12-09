using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberButtonInteractable : interactable
{
    [SerializeField] private float changeAmount;
    [SerializeField] private Material highlightMat;

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        //get the mesh renderer to change materials later
        _meshRenderer = GetComponent<MeshRenderer>();
        //save the default material to a variable
        _defaultMat = _meshRenderer.material;
    }

    //when player is looking at this object
    public override void OnFocus()
    {
        print("looking at " + gameObject.name);
        //change the material to the highlight one
        _meshRenderer.material = highlightMat;
    }

    //when player clicks the interact button (Default E) on this object
    public override void OnInteract()
    {
        print("interacted with " + gameObject.name);
    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {
        print("stopped lokking at " + gameObject.name);
        //Change the material to the default one
        _meshRenderer.material = _defaultMat;
    }
}
