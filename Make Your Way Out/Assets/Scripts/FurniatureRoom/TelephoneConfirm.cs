using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TelephoneConfirm : interactable
{
    [Header("Refrences")]
    private Material _defaultMat;
    public Material highlightMat;
    private MeshRenderer _meshRenderer;

    public GameObject normalDoor;
    public GameObject brokenDoor;


    [Header ("Script Refrences")]
    public Clock clockScript;
    public TelephoneSolution teleSolutionScrip;
    public TextMeshProUGUI text;

    
    [Header ("Declerations")]

    //saves the final hours inputed in form of integers
    public int iFinalHours;
    public int iFinalMins;

    //converts the inputed pressed buttons to strings
    public string sFirstHours;
    public string sSecondHours;
    public string sFirstMins;
    public string sSecondMins;
    public string sFinalHours;
    public string sFinalMins;

    public int buttonPresses;





    // Start is called before the first frame update
    void Start()
    {
        text = teleSolutionScrip.telephoneText;

        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        sFirstHours = teleSolutionScrip.FirstHours.ToString();
        sSecondHours = teleSolutionScrip.SecondHours.ToString();
        sFirstMins = teleSolutionScrip.FirstMins.ToString();
        sSecondMins = teleSolutionScrip.SecondMins.ToString();

        if (buttonPresses == 2)
        {
            sFinalHours = sFirstHours + sSecondHours;
            int.TryParse(sFinalHours, out iFinalHours);
            clockScript.PutHours(iFinalHours);

        }
        else if (buttonPresses == 4)
        {
            sFinalMins = sFirstMins + sSecondMins;
            int.TryParse(sFinalMins, out iFinalMins);
            clockScript.PutMins(iFinalMins);
        }

    }



    public override void OnInteract()
    {
        if (iFinalHours == 7 && iFinalMins == 30)
        {
            Destroy(normalDoor);
            Instantiate(brokenDoor,normalDoor.transform.position,Quaternion.identity);
        }

        else
        {
            teleSolutionScrip.FirstHours = -1;
            teleSolutionScrip.SecondHours = -1;
            teleSolutionScrip.FirstMins = -1;
            teleSolutionScrip.SecondMins = -1;

            buttonPresses = 0;

            sFirstHours = null;
            sSecondHours = null;
            sFirstMins = null;
            sSecondMins = null;
            sFinalHours = null;
            sFinalMins = null;
            clockScript.ResetClock();
            text.text = "-" + "-" + ":" + "-" + "-";
        }
    }

    public override void OnFocus()
    {
        _meshRenderer.material = highlightMat;
    }

    public override void OnLoseFocus()
    {
        _meshRenderer.material = _defaultMat;
    }


}
