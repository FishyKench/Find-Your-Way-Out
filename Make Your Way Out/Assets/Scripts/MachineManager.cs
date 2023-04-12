using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineManager : MonoBehaviour
{

    public string solutionString, correctString;
    public bool machineNotRunning = true;

    [SerializeField]
    private int _id;


    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    void Start()
    {
        light1.SetActive(false);
        light2.SetActive(false);
        light3.SetActive(false);
        light4.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (solutionString.Length == 7)
        {
            if (string.Compare(solutionString, correctString) == 0)
            {
                if(_id == 2)
                {
                    light1.SetActive(true);
                    light2.SetActive(true);
                    light3.SetActive(true);
                    light4.SetActive(true);

                }
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
