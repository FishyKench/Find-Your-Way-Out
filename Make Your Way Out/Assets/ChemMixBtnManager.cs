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

    public int btnPos;


    void Start()
    {

    }

    // Update is called once per frame //Au Pt Si Fe
    void Update()
    {
        if(firstText.text == "Au" && secondText.text == "Pt" && thirdText.text == "Si" && fourthText.text == "Fe")
        {
            print("momo");
        }
        
    }
}
