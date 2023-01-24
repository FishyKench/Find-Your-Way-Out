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

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;

        player = FindObjectOfType<PlayerMovementAdvanced>().gameObject;
        spawnpoint = GameObject.Find("PlayerSpawnPoint");
        fade = GameObject.Find("Fade").GetComponent<Animator>();

        pivot = transform.parent.gameObject.transform;
        closedRotation = pivot.rotation;
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
        //GetComponent<Animator>().SetTrigger("openDoor");
        GetComponent<AudioSource>().Play();

        if (invertRotation == false)
        {
        pivot.rotation = Quaternion.Euler(0, 90, 0);
            print("nonvert");
        }
        else if(invertRotation == true)
        {
        pivot.rotation = Quaternion.Euler(0, -90, 0);
            print("INVERS");
        }
        yield return new WaitForSeconds(1f);
        pivot.rotation = closedRotation;

    }

    private void wrongDoor()
    {
        player.transform.position = spawnpoint.transform.position;
        fade.SetTrigger("Fade");
    }
}
