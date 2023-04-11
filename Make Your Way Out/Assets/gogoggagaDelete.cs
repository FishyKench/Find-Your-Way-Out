using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gogoggagaDelete : interactable
{

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;

    public bool isOpen;
    public bool isInteractable;




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

    }
    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {

            if (isOpen == false && isInteractable == true)
            {
                StartCoroutine(canInteract());
                StartCoroutine(openDoor());
                isOpen = true;
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
            door2.transform.position = Vector3.Lerp(originalPos1, targetPos1, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(originalPos1, targetPos1, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(originalPos1, targetPos1, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        door1.transform.position = targetPos1;
        door2.transform.position = targetPos1;
        door3.transform.position = targetPos1;
        door4.transform.position = targetPos1;
        elapsedTime = 0;
        yield return new WaitForSeconds(2f);

        while (elapsedTime < waitTime)
        {
            door1.transform.position = Vector3.Lerp(door1.transform.position, targetPos1, (elapsedTime / waitTime));
            door2.transform.position = Vector3.Lerp(door1.transform.position, targetPos1, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(door1.transform.position, targetPos1, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(door1.transform.position, targetPos1, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        door1.transform.position = targetPos1;
        door2.transform.position = targetPos1;
        door3.transform.position = targetPos1;
        door4.transform.position = targetPos1;
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

        while (elapsedTime < waitTime)
        {
            door1.transform.position = Vector3.Lerp(door1.transform.position, originalPos1, (elapsedTime / waitTime));
            door2.transform.position = Vector3.Lerp(door1.transform.position, originalPos2, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(door1.transform.position, originalPos3, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(door1.transform.position, originalPos4, (elapsedTime / waitTime));
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
    }


}
