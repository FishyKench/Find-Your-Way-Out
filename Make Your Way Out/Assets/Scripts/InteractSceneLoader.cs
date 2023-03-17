using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractSceneLoader : interactable
{

    [SerializeField] private string SceneToGoTo;
    [SerializeField] private float waitToLoad;

    [Space(20)]
    [SerializeField] private AudioSource audio;
    [SerializeField] private Material highlightMat;

    private Material _defaultMat;
    private MeshRenderer _meshRenderer;


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
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("FadeIn");

        if (audio != null)
        {
            audio.Play();
            Invoke("loadScene", waitToLoad);
        }
        else
        {
            loadScene();
        }


    }

    public void loadScene()
    {
        SceneManager.LoadScene(SceneToGoTo);
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }
}
