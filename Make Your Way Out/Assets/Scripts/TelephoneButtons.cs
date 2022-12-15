using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneButtons : interactable
{
    public TelephoneSolution teleScript;
    public TelephoneConfirm teleConfirmScript;


    private Material _defaultMat;
    public Material highlightMat;
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private int num;



    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
        
    }


    public override void OnInteract()
    {

        teleScript.getNum(num);
        teleScript.changeText();
       teleConfirmScript.buttonPresses++;
    }


    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }





}
