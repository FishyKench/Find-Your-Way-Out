using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasswordInteract : interactable
{
    [SerializeField]
    private int buttonNo;

    public TMP_Text lilScreenText;

    public bool textIsCorrect;

    public GameObject firstImg;
    public GameObject secondImg;
    public GameObject thridImg;

    [SerializeField]
    Vector3 originalPos;
    [SerializeField]
    Vector3 targetPos;




    public MachineManager machineM;

    public MachineColoredButton coloredButtons;


    void Start()
    {
        originalPos = transform.localPosition;
        machineM.machineNotRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (lilScreenText.text == "Z32X")
        {
            textIsCorrect = true;
        }

        if (lilScreenText.text.Length == 4)
        {
            if (textIsCorrect == true)
            {
                if (machineM.machineNotRunning == true)
                {
                    StartCoroutine(SlideShow());
                    lilScreenText.text = "";
                }

            }
            else
            {
                lilScreenText.text = "";
            }
        }


    }

    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {


        switch (buttonNo)
        {
            case 1:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "X";
                }

                break;
            case 2:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "Y";
                }
                break;
            case 3:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "Z";
                }
                break;
            case 4:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "1";
                }
                break;
            case 5:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "2";
                }
                break;
            case 6:
                if (lilScreenText.text.Length <= 4)
                {
                    StartCoroutine(interactAnim());
                    coloredButtons.textIndicator.text = "";
                    lilScreenText.text = lilScreenText.text + "3";
                }
                break;
        }



    }

    public override void OnLoseFocus()
    {

    }


    IEnumerator SlideShow()
    {
        machineM.machineNotRunning = false;
        machineM.solutionString = "";
        textIsCorrect = false; // making the text false again

        firstImg.SetActive(true);
        yield return new WaitForSeconds(1f);  // 1st img is displayed.. 
        firstImg.SetActive(false);
        secondImg.SetActive(true);

        yield return new WaitForSeconds(1f); // 2nd img is displayed.. 
        secondImg.SetActive(false);
        thridImg.SetActive(true);

        yield return new WaitForSeconds(1f); // 3rd img is displayed... 
        secondImg.SetActive(false);
        thridImg.SetActive(true);


        yield return new WaitForSeconds(1f); // 2nd img is displayed... (again)
        thridImg.SetActive(false);
        secondImg.SetActive(true);

        yield return new WaitForSeconds(1f); // 1st img is displayed... (again)
        secondImg.SetActive(false);
        firstImg.SetActive(true);


        yield return new WaitForSeconds(1f); // 3rd img is displayed... (again)
        firstImg.SetActive(false);
        thridImg.SetActive(true);


        yield return new WaitForSeconds(1f); // 1st img is displayed... (again)
        thridImg.SetActive(false);
        firstImg.SetActive(true);


        yield return new WaitForSeconds(1f);  //screen is off
        firstImg.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        machineM.machineNotRunning = true;

    }


    IEnumerator interactAnim()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, 10);
        yield return new WaitForSeconds(.3f);
        transform.position = Vector3.Lerp(transform.position, originalPos, 10);
    }

}
