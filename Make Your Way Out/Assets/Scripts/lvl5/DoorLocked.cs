using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLocked : interactable
{
    public bool isLocked = true;

    public  bool isOpened;

    [SerializeField] private Material highlightMat;
    [SerializeField] private AudioSource slam;
    [SerializeField] private AudioSource open;

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;

    [Header("Rotation stuff")]
    Quaternion closedRotation;
    private Transform pivot;
    [SerializeField] private bool invertRotation = false;

    [SerializeField]
    private Quaternion _targetRot;

    private float elapsedTime;
    private float waitTime = 0.75f;
    private Quaternion originalRotation;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;


        originalRotation = this.transform.rotation;




    }
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        if(isLocked == false && isOpened == false)
        {
            StartCoroutine(openDoor());
            isOpened = true;
        }
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }

    private IEnumerator openDoor()
    {


        open.PlayOneShot(open.clip);

        while (elapsedTime < waitTime)
        {
            transform.rotation = Quaternion.Lerp(originalRotation, _targetRot, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        transform.rotation = _targetRot;
        elapsedTime = 0;

    }
}
