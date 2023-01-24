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

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;

        player = FindObjectOfType<PlayerMovementAdvanced>().gameObject;
        spawnpoint = GameObject.Find("PlayerSpawnPoint");
        fade = GameObject.Find("Fade").GetComponent<Animator>();

    }
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        if (rightDoor)
            openDoor();
        else
            wrongDoor();
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }

    private void openDoor()
    {
        GetComponent<Animator>().SetTrigger("openDoor");
        GetComponent<AudioSource>().Play();
    }

    private void wrongDoor()
    {
        player.transform.position = spawnpoint.transform.position;
        fade.SetTrigger("Fade");
    }
}
