using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PSIHandler : interactable
{
    [SerializeField] private int changeAmount;
    [SerializeField] private Material highlightMat;
    [SerializeField] Transform targetPos;
    [SerializeField] private  int displayNum;




    private Material _defaultMat;
    private MeshRenderer _meshRenderer;
    Vector3 originalPos;

    [SerializeField] TextMeshProUGUI buttonDisplay;


    private void Start()
    {

        originalPos = transform.position;
        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    private void Update()
    {
        buttonDisplay.text = displayNum.ToString();
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
        StartCoroutine(interactAnim());

        displayNum = displayNum + changeAmount;



    }

    //when player stops looking at this object
    public override void OnLoseFocus()
    {
        print("stopped lokking at " + gameObject.name);

        _meshRenderer.material = _defaultMat;
    }

    IEnumerator interactAnim()
    {


        transform.position = Vector3.Lerp(transform.position, targetPos.position, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }
}
