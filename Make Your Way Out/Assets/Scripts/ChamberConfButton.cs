using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChamberConfButton : interactable
{

    public ChamberDoors chamberDoorsScript;
    private float elapsedTime;
    private float waitTime = 3f;
    public GameObject theSuspect;
    public GameObject Cage;
    public GameObject Wall;
    public GameObject explosionParticles;
    public GameObject glassParticles;
    public List<Light> lights;
    CameraShake camShake;

    [SerializeField]
    private Vector3 orignalScale;
    [SerializeField]
    private Vector3 bigScale;


    private void Start()
    {
        orignalScale = theSuspect.transform.localScale;
        bigScale = new Vector3(9f, 9f, 9f);
        camShake = FindObjectOfType<CameraShake>();


    }
    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        if (chamberDoorsScript.sequenceNo == 5 && chamberDoorsScript.isOpen == false)
        {
            StartCoroutine(makeBig());
        }

    }

    public override void OnLoseFocus()
    {

    }


    private IEnumerator makeBig()
    {
        glassParticles.SetActive(true);
        Destroy(Cage);
        camShake.StartCoroutine(camShake.Shake(0.3f, 0.1f));
       

        while (elapsedTime < waitTime)
        {
            theSuspect.transform.localScale = Vector3.Lerp(orignalScale, bigScale, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        theSuspect.transform.localScale = bigScale;
        elapsedTime = 0;
       StartCoroutine(destoryRoute());
    }
    IEnumerator destoryRoute()
    {
        foreach (Light l in lights)
        {
            l.color = Color.red;
            l.range = 10;
            l.intensity = 0.1f;
        }
        yield return new WaitForSeconds(0.2f);
        camShake.StartCoroutine(camShake.Shake(1f, 0.5f));
        Destroy(theSuspect);
        explosionParticles.SetActive(true);
        Destroy(Wall);
    }

}