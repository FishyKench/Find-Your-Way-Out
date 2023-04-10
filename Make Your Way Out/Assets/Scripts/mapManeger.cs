using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapManeger : MonoBehaviour
{
    // Start is called before the first frame update


    public levermanager LeverScript;
    public fsManager fsScript;
    public RotationSolutionChecker knobScript;
    void Start()
    {
        LeverScript = LeverScript.GetComponent<levermanager>();
        fsScript = fsScript.GetComponent<fsManager>();
        knobScript = knobScript.GetComponent<RotationSolutionChecker>();


    }

    // Update is called once per frame
    void Update()
    {
        if(LeverScript.leverSolved == true && fsScript.fsSolved == true && knobScript.knobSolved == true)
        {
            print("momo");
        }
        else
        {

        }
        
    }
}
