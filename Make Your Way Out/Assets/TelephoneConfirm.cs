using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TelephoneConfirm : interactable
{

    private Material _defaultMat;
    public Material highlightMat;
    private MeshRenderer _meshRenderer;


    public TelephoneSolution teleSolutionScrip;
    public TextMeshProUGUI text;

    public Clock clockScript;



    public int buttonPresses;

    public int cFirstHours;
    public int cSecondHours;
    public int cFirstMins;
    public int cSecondMins;

    public int iFinalHours;
    public int iFinalMins;

    public string sFirstHours;
    public string sSecondHours;
    public string sFirstMins;
    public string sSecondMins;

    public string sFinalHours;
    public string sFinalMins;



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
