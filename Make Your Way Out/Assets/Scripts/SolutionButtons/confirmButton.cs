using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmButton : interactable
{
    [SerializeField] private Material highlightMat;
    private Material _defaultMat;
    private MeshRenderer _meshRenderer;

    [SerializeField] private buttonManager bm;

    private void Start()
    {

        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;

    }
    public override void OnFocus()
    {
        print("looking at " + gameObject.name);

        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        bm.CheckSolution();
    }

    public override void OnLoseFocus()
    {
        print("stopped lokking at " + gameObject.name);

        _meshRenderer.material = _defaultMat;
    }
}
