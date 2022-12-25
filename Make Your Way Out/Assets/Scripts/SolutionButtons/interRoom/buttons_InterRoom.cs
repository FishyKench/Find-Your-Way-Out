using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttons_InterRoom : interactable
{

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;
    Vector3 originalPos;

    [SerializeField] private buttonManager_interRoom bm;
    [SerializeField] private Material highlightMat;

    [Space(10)]

    [SerializeField] private int id;


    private void Start()
    {

        originalPos = transform.position;
        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    //when player clicks the interact button (Default E) on this object
    public override void OnInteract()
    {
        bm.CheckID(id);
    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }

}
