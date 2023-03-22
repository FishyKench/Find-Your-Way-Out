using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RotationSolutionChecker : MonoBehaviour
{
    //public TextMeshProUGUI solutionText;

    public GameObject g1;
    public GameObject g2;
    public GameObject g3;

    public float firstRotation;
    public float secondRotation;
    public float thirdRotation;

    public bool knobSolved;

    [SerializeField] private AudioSource sfx;
    private bool sfxPlayed;
    //private void Start()
    //{
    //    sfx = GetComponent<AudioSource>();
    //}




    void Update()
    {
        firstRotation = g1.GetComponent<knobRotateInteract>().currentRot;
        secondRotation = g2.GetComponent<knobRotateInteract>().currentRot;
        thirdRotation = g3.GetComponent<knobRotateInteract>().currentRot;




        if (firstRotation == 90 && secondRotation == 225 && thirdRotation == 135)
        {
            Color32 correctColor = new Color32(88, 255, 88, 65);
            //solutionText.text = "Unlocked";
            //solutionText.color = correctColor;
            knobSolved = true;
            if (sfxPlayed == false)
            {
                sfx.PlayOneShot(sfx.clip);
                sfxPlayed = true;
            }
        }
        else
        {
            knobSolved = false;
            sfxPlayed = false;
        }

    }
}
