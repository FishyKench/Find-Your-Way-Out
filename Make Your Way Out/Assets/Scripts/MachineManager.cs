using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineManager : MonoBehaviour
{

    public string solutionString, correctString = "CBABCAC";

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (solutionString.Length == 7)
        {
            if (string.Compare(solutionString, correctString) == 0)
            {
                //win??
                print("momo");

            }
            else
            {
                solutionString = "";
            }
        }
    }
}
