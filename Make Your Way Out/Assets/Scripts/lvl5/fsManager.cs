using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fsManager : MonoBehaviour
{

    public int psi = 18;
    [SerializeField] int goalPSI;

    [Space(15)]

    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI psiText;

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
            print("EZEZ");
        }

        //easteregg
        if(psi > 150)
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
