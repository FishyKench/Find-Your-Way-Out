using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneConfirm : interactable
{

    private Material _defaultMat;
    public Material highlightMat;
    private MeshRenderer _meshRenderer;


    public TelephoneSolution teleSolutionScrip;

    public int cFirstHours;
    public int cSecondHours;
    public int cFirstMins;
    public int cSecondMins;



    // Start is called before the first frame update
    void Start()
    {

        _meshRenderer = GetComponent<MeshRenderer>();

        _defaultMat = _meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        cFirstHours =  teleSolutionScrip.FirstHours;
        cSecondHours = teleSolutionScrip.SecondHours;
        cFirstMins = teleSolutionScrip.FirstMins;
        cSecondMins = teleSolutionScrip.SecondMins;

    }



    public override void OnInteract()
    {
            if (cFirstHours == 0 && cSecondHours == 7 && cFirstMins == 3 && cSecondMins == 0)
            {
                print(cFirstHours + cSecondHours + ":" + cFirstMins + cSecondMins);
                print("CORRECT!");
            }
            else if (cFirstHours != -1 && cSecondHours != -1 && cFirstMins != -1 && cSecondMins != -1)
            {
                print(cFirstHours + cSecondHours + ":" + cFirstMins + cSecondMins);
                print("Wrong!");

            teleSolutionScrip.FirstHours = -1;
            teleSolutionScrip.SecondHours = -1;
            teleSolutionScrip.FirstMins = -1;
            teleSolutionScrip.SecondMins = -1;
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
