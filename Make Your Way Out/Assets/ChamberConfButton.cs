using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChamberConfButton : interactable
{

    public ChamberDoors chamberDoorsScript;
    private float elapsedTime;
    private float waitTime = 3f;
    public GameObject theSuspect;

    [SerializeField]
    private Vector3 orignalScale;
    [SerializeField]
    private Vector3 bigScale;


    private void Start()
    {
        orignalScale = theSuspect.transform.localScale;
        bigScale = new Vector3(27.154f, 27.154f, 27.154f);



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

    }

}