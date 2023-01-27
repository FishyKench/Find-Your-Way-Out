using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSceneLoader : interactable
{
    private Material _defaultMat;
    private MeshRenderer _meshRenderer;

    [SerializeField] private AudioSource vent;
    [SerializeField] private Material highlightMat;

    [SerializeField] private string SceneToGoTo;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _defaultMat = _meshRenderer.material;
    }
    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnInteract()
    {
        SceneManager.LoadScene(SceneToGoTo);
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }
}
