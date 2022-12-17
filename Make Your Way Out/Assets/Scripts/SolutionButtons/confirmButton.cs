using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confirmButton : interactable
{
    [SerializeField] private Material highlightMat;
    [SerializeField]Transform targetPos;
    [SerializeField] private buttonManager bm;

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;
    Vector3 originalPos;


    private void Start()
    {
        originalPos = transform.position;
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
        StartCoroutine(interactAnim());
    }

    public override void OnLoseFocus()
    {
        print("stopped lokking at " + gameObject.name);

        _meshRenderer.material = _defaultMat;
    }

    IEnumerator interactAnim()
    {
        transform.position = Vector3.Lerp(transform.position,targetPos.position, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }
}
