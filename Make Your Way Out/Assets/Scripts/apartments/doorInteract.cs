using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : interactable
{
    [SerializeField] private Material highlightMat;
    [SerializeField] private bool rightDoor = false;

    GameObject player;
    GameObject spawnpoint;
    Animator fade;

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

        player = FindObjectOfType<PlayerMovementAdvanced>().gameObject;
        spawnpoint = GameObject.Find("PlayerSpawnPoint");
        fade = GameObject.Find("Fade").GetComponent<Animator>();


        originalRotation = this.transform.rotation;
        



    }
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        if (rightDoor)
            StartCoroutine(openDoor());
        else
            wrongDoor();
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }

    private IEnumerator openDoor()
    {
       


        while (elapsedTime < waitTime)
        { 
            transform.rotation = Quaternion.Lerp(originalRotation, _targetRot, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;

 
        }
        // Make sure we got there
        transform.rotation = _targetRot;
        yield return null;

    }

    private void wrongDoor()
    {
        player.transform.position = spawnpoint.transform.position;
        fade.SetTrigger("Fade");
    }
}
