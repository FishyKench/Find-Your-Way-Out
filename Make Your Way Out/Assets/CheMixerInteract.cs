using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheMixerInteract : interactable
{

    Vector3 originalPos;
    Vector3 targetPos;
    public int btnID;



    public ChemMixBtnManager ChemMixScript;
    public TMP_Text firstElement;
    public TMP_Text secondElement;
    public TMP_Text thirdElement;
    public TMP_Text fourthElement;

    public override void OnFocus()
    {
        originalPos = this.transform.position;
    }

    public override void OnInteract()
    {

        ChemMixScript.btnPos++;
        if (ChemMixScript.btnPos >= 5)
            ChemMixScript.btnPos = 1;
        switch (btnID)
        {
            case 1:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Na";
                        break;
                    case 2:
                        secondElement.text = "Na";
                        break;
                    case 3:
                        thirdElement.text = "Na";
                        break;
                    case 4:
                        fourthElement.text = "Na";
                        break;
                }

                break;
            case 2:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Cl";
                        break;
                    case 2:
                        secondElement.text = "Cl";
                        break;
                    case 3:
                        thirdElement.text = "Cl";
                        break;
                    case 4:
                        fourthElement.text = "Cl";
                        break;
                }

                break;
            case 3:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Fe";
                        break;
                    case 2:
                        secondElement.text = "Fe";
                        break;
                    case 3:
                        thirdElement.text = "Fe";
                        break;
                    case 4:
                        fourthElement.text = "Fe";
                        break;
                }
                break;
            case 4:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "H";
                        break;
                    case 2:
                        secondElement.text = "H";
                        break;
                    case 3:
                        thirdElement.text = "H";
                        break;
                    case 4:
                        fourthElement.text = "H";
                        break;
                }
                break;
            case 5:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Li";
                        break;
                    case 2:
                        secondElement.text = "Li";
                        break;
                    case 3:
                        thirdElement.text = "Li";
                        break;
                    case 4:
                        fourthElement.text = "Li";
                        break;
                }
                break;
            case 6:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "K";
                        break;
                    case 2:
                        secondElement.text = "K";
                        break;
                    case 3:
                        thirdElement.text = "K";
                        break;
                    case 4:
                        fourthElement.text = "K";
                        break;
                }

                break;
            case 7:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Ca";
                        break;
                    case 2:
                        secondElement.text = "Ca";
                        break;
                    case 3:
                        thirdElement.text = "Ca";
                        break;
                    case 4:
                        fourthElement.text = "Ca";
                        break;
                }
                break;
            case 8:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Si";
                        break;
                    case 2:
                        secondElement.text = "Si";
                        break;
                    case 3:
                        thirdElement.text = "Si";
                        break;
                    case 4:
                        fourthElement.text = "Si";
                        break;
                }
                break;
            case 9:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "N";
                        break;
                    case 2:
                        secondElement.text = "N";
                        break;
                    case 3:
                        thirdElement.text = "N";
                        break;
                    case 4:
                        fourthElement.text = "N";
                        break;
                }
                break;
            case 10:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "He";
                        break;
                    case 2:
                        secondElement.text = "He";
                        break;
                    case 3:
                        thirdElement.text = "He";
                        break;
                    case 4:
                        fourthElement.text = "He";
                        break;
                }
                break;
            case 11:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Pt";
                        break;
                    case 2:
                        secondElement.text = "Pt";
                        break;
                    case 3:
                        thirdElement.text = "Pt";
                        break;
                    case 4:
                        fourthElement.text = "Pt";
                        break;
                }
                break;
            case 12:
                switch (ChemMixScript.btnPos)
                {
                    case 1:
                        firstElement.text = "Au";
                        break;
                    case 2:
                        secondElement.text = "Au";
                        break;
                    case 3:
                        thirdElement.text = "Au";
                        break;
                    case 4:
                        fourthElement.text = "Au";
                        break;
                }
                break;

        }

    }

    public override void OnLoseFocus()
    {

    }

    IEnumerator interactAnim()
    {
        //transform.position = Vector3.Lerp(transform.position, targetPos.position, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }
}
