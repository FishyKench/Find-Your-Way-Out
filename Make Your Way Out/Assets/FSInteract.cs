using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSInteract : interactable
{
    // Start is called before the first frame update


    [SerializeField] Transform targetPos;

    public ParticleSystem PS;

    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
        
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
        StartCoroutine(interactAnim());
        StartCoroutine(smokeAnim());
    }

    public override void OnLoseFocus()
    {

    }



    IEnumerator interactAnim()
    {


        transform.position = Vector3.Lerp(transform.position, targetPos.position, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }

    IEnumerator smokeAnim()
    {
        PS.Play();
        yield return new WaitForSeconds(.3f);
        PS.Stop();
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }

}
