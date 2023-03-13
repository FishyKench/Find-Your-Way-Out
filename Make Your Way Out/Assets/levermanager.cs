using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levermanager : MonoBehaviour

   
{


    public LeverInteract correctLever1;
    public LeverInteract correctLever2;
    public LeverInteract correctLever3;
    public LeverInteract wrongLever1;
    public LeverInteract wrongLever2;
    public LeverInteract wrongLever3;
    public LeverInteract wrongLever4;

    // Start is called before the first frame update
    void Start()
    {
        correctLever1 = correctLever1.GetComponent<LeverInteract>();
        correctLever2 = correctLever2.GetComponent<LeverInteract>();
        correctLever3 = correctLever3.GetComponent<LeverInteract>();
        wrongLever1 = wrongLever1.GetComponent<LeverInteract>();
        wrongLever2 = wrongLever2.GetComponent<LeverInteract>();
        wrongLever3 = wrongLever3.GetComponent<LeverInteract>();
        wrongLever4 = wrongLever4.GetComponent<LeverInteract>();

    }

    // Update is called once per frame
    void Update()
    {
        if(wrongLever1._isOff == true && wrongLever2._isOff == true && wrongLever3._isOff == true && wrongLever4._isOff == true )
        {
            {
                if(correctLever1._isOff == false && correctLever2._isOff == false && correctLever3._isOff == false)
                {
                    print("gj nigga");
                }
            }

        }
    }
}
