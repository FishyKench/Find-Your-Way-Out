using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberDoors : interactable
{

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    
    public TextMeshProUGUI chemText1;
    public TextMeshProUGUI chemText2;
    public TextMeshProUGUI chemText3;
    public TextMeshProUGUI chemText4;


    public GameObject sphereVial;
    public GameObject squareVial;
    public GameObject cylinderVial;
    public GameObject triangleVial;






    public bool isOpen;
    public bool isInteractable;

    public int sequenceNo;




    private float elapsedTime;
    private float waitTime = 0.75f;

    public Vector3 originalPos1;
    public Vector3 targetPos1;

    public Vector3 originalPos2;
    public Vector3 targetPos2;

    public Vector3 originalPos3;
    public Vector3 targetPos3;

    public Vector3 originalPos4;
    public Vector3 targetPos4;


    public Vector3 firstChamberPos;
    public Vector3 secondChamberPos;
    public Vector3 thirdChamberPos;
    public Vector3 fourthChamberPos;



    private void Start()
    {
        originalPos1 = new Vector3(door1.transform.position.x, door1.transform.position.y, door1.transform.position.z);
        targetPos1 = new Vector3(door1.transform.position.x, -3f, door1.transform.position.z);

        originalPos2 = new Vector3(door2.transform.position.x, door2.transform.position.y, door2.transform.position.z);
        targetPos2 = new Vector3(door2.transform.position.x, -3f, door2.transform.position.z);

        originalPos3 = new Vector3(door3.transform.position.x, door3.transform.position.y, door3.transform.position.z);
        targetPos3 = new Vector3(door3.transform.position.x, -3f, door3.transform.position.z);

        originalPos4 = new Vector3(door4.transform.position.x, door4.transform.position.y, door4.transform.position.z);
        targetPos4 = new Vector3(door4.transform.position.x, -3f, door4.transform.position.z);

        isInteractable = true;

        firstChamberPos = new Vector3(-8.76f, -2.46f, -26.56f);
        secondChamberPos = new Vector3(-9.17f, -2.46f, -26.56f);
        thirdChamberPos = new Vector3(-9.59f, -2.46f, -26.56f);
        fourthChamberPos = new Vector3(-10.01f, -2.46f, -26.56f);
        sequenceNo = 0;
        



    }


    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {

        if (isOpen == false && isInteractable == true)
        {
            if (sequenceNo >= 8)
            {
                sequenceNo = 1;
            }
            sequenceNo++;
            switch (sequenceNo)
            {
                case 1:
                    chemText1.text = "Na";
                    chemText2.text = "Cl";
                    chemText3.text = "Fe";
                    chemText4.text = "H";

                    sphereVial.transform.position = firstChamberPos;
                    squareVial.transform.position = secondChamberPos;
                    cylinderVial.transform.position = thirdChamberPos;   //1234
                    triangleVial.transform.position = fourthChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;

                case 2:
                    chemText1.text = "Ca";
                    chemText2.text = "N";
                    chemText3.text = "He";
                    chemText4.text = "H";

                    sphereVial.transform.position = fourthChamberPos;
                    squareVial.transform.position = thirdChamberPos;
                    cylinderVial.transform.position = secondChamberPos; //4321
                    triangleVial.transform.position = firstChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 3:
                    chemText1.text = "Au";
                    chemText2.text = "Na";
                    chemText3.text = "Si";
                    chemText4.text = "K";

                    sphereVial.transform.position = firstChamberPos;
                    squareVial.transform.position = fourthChamberPos;
                    cylinderVial.transform.position = secondChamberPos;  //1423
                    triangleVial.transform.position = thirdChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 4:
                    chemText1.text = "Pt";
                    chemText2.text = "Fe";
                    chemText3.text = "H";
                    chemText4.text = "Si";

                    sphereVial.transform.position = secondChamberPos;
                    squareVial.transform.position = thirdChamberPos;
                    cylinderVial.transform.position = firstChamberPos;  //2314
                    triangleVial.transform.position = fourthChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 5:
                    chemText1.text = "Au";
                    chemText2.text = "Pt";
                    chemText3.text = "Si";
                    chemText4.text = "Fe";

                    sphereVial.transform.position = thirdChamberPos;
                    squareVial.transform.position = firstChamberPos;
                    cylinderVial.transform.position = secondChamberPos;  //3124
                    triangleVial.transform.position = fourthChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 6:
                    chemText1.text = "Cl";
                    chemText2.text = "H";
                    chemText3.text = "Pt";
                    chemText4.text = "Na";

                    sphereVial.transform.position = fourthChamberPos;
                    squareVial.transform.position = thirdChamberPos;
                    cylinderVial.transform.position = firstChamberPos;  //4312
                    triangleVial.transform.position = secondChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 7:
                    chemText1.text = "K";
                    chemText2.text = "H";
                    chemText3.text = "N";
                    chemText4.text = "He";

                    sphereVial.transform.position = secondChamberPos;
                    squareVial.transform.position = firstChamberPos;
                    cylinderVial.transform.position = thirdChamberPos;  //2134
                    triangleVial.transform.position = fourthChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;
                case 8:
                    chemText1.text = "Fe";
                    chemText2.text = "Li";
                    chemText3.text = "Na";
                    chemText4.text = "N";

                    sphereVial.transform.position = firstChamberPos;
                    squareVial.transform.position = secondChamberPos;
                    cylinderVial.transform.position = fourthChamberPos;  //1243
                    triangleVial.transform.position = thirdChamberPos;
                    StartCoroutine(canInteract());
                    StartCoroutine(openDoor());
                    isOpen = true;
                    break;

            }
        }
        else if (isInteractable == true && isOpen == true)
        {
            StartCoroutine(canInteract());
            StartCoroutine(closeDoor());
            isOpen = false;
        }



    }

    public override void OnLoseFocus()
    {

    }

    private IEnumerator canInteract()
    {
        isInteractable = false;
        yield return new WaitForSeconds(1.5f);
        isInteractable = true;
    }

    private IEnumerator openDoor()
    {




        while (elapsedTime < waitTime)
        {
            door1.transform.position = Vector3.Lerp(originalPos1, targetPos1, (elapsedTime / waitTime));
            door2.transform.position = Vector3.Lerp(originalPos2, targetPos2, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(originalPos3, targetPos3, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(originalPos4, targetPos4, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        door1.transform.position = targetPos1;
        door2.transform.position = targetPos2;
        door3.transform.position = targetPos3;
        door4.transform.position = targetPos4;
        elapsedTime = 0;

    }


    private IEnumerator closeDoor()
    {

        while (elapsedTime < waitTime)
        {
            door1.transform.position = Vector3.Lerp(targetPos1, originalPos1, (elapsedTime / waitTime));
            door2.transform.position = Vector3.Lerp(targetPos2, originalPos2, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(targetPos3, originalPos3, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(targetPos4, originalPos4, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        door1.transform.position = originalPos1;
        door2.transform.position = originalPos2;
        door3.transform.position = originalPos3;
        door4.transform.position = originalPos4;
        elapsedTime = 0;
        yield return new WaitForSeconds(2f);

    }


}

