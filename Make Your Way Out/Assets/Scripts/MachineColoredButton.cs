using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MachineColoredButton : interactable
{
    [SerializeField]
    private int _buttonID;

    public MachineManager machineM;
    public PasswordInteract passInter;
    [SerializeField]
    Vector3 originalPos;
    [SerializeField]
    Vector3 targetPos;

    public GameObject RedBlob, BlueBlob,GreenBlob;

    public TMP_Text textIndicator;




    void Start()
    {
        originalPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        
        if(machineM.solutionString.Length < 7 && machineM.machineNotRunning == true)
        { 
            switch (_buttonID)
            {
                case 1:
                    passInter.lilScreenText.text = "";
                    StartCoroutine(interactAnim());
                    machineM.solutionString = machineM.solutionString + "R"; //A
                    StartCoroutine(DisplayColors());

                    textIndicator.text += "R";
                    break;
                case 2:
                    passInter.lilScreenText.text = "";
                    StartCoroutine(interactAnim());
                    machineM.solutionString = machineM.solutionString + "B"; //B
                    StartCoroutine(DisplayColors());
                    textIndicator.text += "B";
                    break;
                case 3:
                    passInter.lilScreenText.text = "";
                    StartCoroutine(interactAnim());
                    machineM.solutionString = machineM.solutionString + "G"; //C
                    StartCoroutine(DisplayColors());
                    textIndicator.text += "G";
                    break;
            }
        }
    }

    public override void OnLoseFocus()
    {

    }

    IEnumerator DisplayColors()
    {
        switch (_buttonID)
        {
            case 1:
                RedBlob.SetActive(true);
                yield return new WaitForSeconds(.5f);
                RedBlob.SetActive(false);
                break;
            case 2:
                BlueBlob.SetActive(true);
                yield return new WaitForSeconds(.5f);
                BlueBlob.SetActive(false);
                break;
            case 3:
                GreenBlob.SetActive(true);
                yield return new WaitForSeconds(.5f);
                GreenBlob.SetActive(false);
                break;
        }
    }


    IEnumerator interactAnim()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }


}