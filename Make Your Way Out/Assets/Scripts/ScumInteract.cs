using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScumInteract : interactable
{

    public GameObject endScreenImg;
    private Animator fade;
    void Start()
    {
        //_isOff = true;
        fade = GameObject.Find("Fade").GetComponent<Animator>();
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
        yield return new WaitForSeconds(3f);
        fade.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        print("QUIT");
        SceneManager.LoadScene("MainMenu");
    }
}
