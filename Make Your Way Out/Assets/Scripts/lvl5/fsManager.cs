using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fsManager : MonoBehaviour
{

    public int psi = 18;
    [SerializeField] int goalPSI;

    public bool fsSolved;

    [Space(15)]

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI psiText;
    [SerializeField] TextMeshProUGUI solutionText;

    [SerializeField] AudioSource sfx;
    //easteregg
    [Space(30)]
    [SerializeField]GameObject jmpscr;

    private void Start()
    {
        psiText.text = psi.ToString();
        slider.value = psi;
    }

    public void changePSI(int changeAmount)
    {
        psi += changeAmount;

        psiText.text = psi.ToString();
        slider.value = psi;

        if(psi == goalPSI)
        {
            Color32 correctColor = new Color32(88, 255, 88, 65);
            solutionText.text = "sufficient";
            solutionText.color = correctColor;
            fsSolved = true;
            sfx.Play();
        }
        else
        {
            fsSolved = false;
            sfx.Stop();
        }

        //easteregg
        if(psi > 100)
        {
            StartCoroutine(jumpScare());
        }

    }

    IEnumerator jumpScare()
    {
        jmpscr.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(jmpscr);
    }
}
