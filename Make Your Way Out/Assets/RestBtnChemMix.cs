using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestBtnChemMix : interactable
{

    public ChemMixBtnManager chemSctipt;
    public TMP_Text txt1;
    public TMP_Text txt2;
    public TMP_Text txt3;
    public TMP_Text txt4;

    Vector3 originalPos;
    [SerializeField]
    Vector3 targetPos;

    AudioSource sfx;

    private void Start()
    {
        originalPos = this.transform.position;
        sfx = GetComponent<AudioSource>();
    }
    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        sfx.PlayOneShot(sfx.clip);
        StartCoroutine(interactAnim());

        chemSctipt.btnPos = 0;
        txt1.text = "";
        txt2.text = "";
        txt3.text = "";
        txt4.text = "";
    }

    public override void OnLoseFocus()
    {

    }

    IEnumerator interactAnim()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }
}
