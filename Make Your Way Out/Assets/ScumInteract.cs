using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScumInteract : interactable
{

    public GameObject endScreenImg;
    void Start()
    {
        //_isOff = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        StartCoroutine(EndScreen());
    }

    public override void OnLoseFocus()
    {

    }

    IEnumerator EndScreen()
    {
        endScreenImg.SetActive(true);
        Application.Quit(0);
    }
}
