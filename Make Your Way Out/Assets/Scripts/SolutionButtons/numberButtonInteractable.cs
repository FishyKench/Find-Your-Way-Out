using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberButtonInteractable : interactable
{
    [SerializeField] private int changeAmount;
    [SerializeField] private string changeIndex;
    [SerializeField] private Material highlightMat;
    [SerializeField] private buttonManager bm;

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;

    private void Start()
    {

        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    //when player is looking at this object
    public override void OnFocus()
    {
        print("looking at " + gameObject.name);

        _meshRenderer.material = highlightMat;
    }

    //when player clicks the interact button (Default E) on this object
    public override void OnInteract()
    {
        print("interacted with " + gameObject.name);
        bm.changeAmount(changeIndex, changeAmount);
    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {
        print("stopped lokking at " + gameObject.name);

        _meshRenderer.material = _defaultMat;
    }
}
