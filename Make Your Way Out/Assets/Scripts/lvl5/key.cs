using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : interactable
{
    [SerializeField] DoorLocked door;
    [SerializeField] Material highlightMat;
    MeshRenderer _meshRenderer;
    Material _defaultMat;
    AudioSource sfx;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;
        sfx = GetComponent<AudioSource>();
    }
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        door.isLocked = false;
        sfx.PlayOneShot(sfx.clip);
        Destroy(this.gameObject, 0.15f);
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }
}
