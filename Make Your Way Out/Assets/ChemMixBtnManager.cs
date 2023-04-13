using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChemMixBtnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text firstText;
    public TMP_Text secondText;
    public TMP_Text thirdText;
    public TMP_Text fourthText;

    public Animator doorL;
    public Animator doorR;

    public int btnPos;

    AudioSource sfx;
    bool sfxplayed = false;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame //Au Pt Si Fe
    void Update()
    {
        if (firstText.text == "Au" && secondText.text == "Pt" && thirdText.text == "Si" && fourthText.text == "Fe")
        {
            playsfx();
            doorL.SetTrigger("open");
            doorR.SetTrigger("open");
        }

    }
    void playsfx()
    {
        if (sfxplayed == false)
        {
            sfx.PlayOneShot(sfx.clip);
            sfxplayed = true;
        }
    }
}
