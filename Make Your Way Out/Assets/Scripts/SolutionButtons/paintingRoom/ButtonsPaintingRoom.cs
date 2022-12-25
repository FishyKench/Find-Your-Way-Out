using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPaintingRoom : interactable
{
    [SerializeField] private int changeAmount;
    [SerializeField] private int changeIndex;
    [SerializeField] private Material highlightMat;
    [SerializeField] private ButtonManager_RGBnDOOR bm;
    [SerializeField] Transform targetPos;




    private Material _defaultMat;
    private MeshRenderer _meshRenderer;
    Vector3 originalPos;

    private void Start()
    {

        originalPos = transform.position;
        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    //when player is looking at this object
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    //when player clicks the interact button (Default E) on this object
    public override void OnInteract()
    {
        bm.changeAmount(changeIndex, changeAmount);
        StartCoroutine(interactAnim());
    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {

        _meshRenderer.material = _defaultMat;
    }

    IEnumerator interactAnim()
    {


        transform.position = Vector3.Lerp(transform.position, targetPos.position, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }
}
