using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager_interRoom : MonoBehaviour
{
    [SerializeField] private int index = 1;
    [SerializeField] private int correctIndex = 1;
    [SerializeField] private List<GameObject> lights;

    public GameObject normalDoor;
    public GameObject brokenDoor;
    public void CheckID(int ID)
    {
        print("id gotten :" + ID);
        if (ID == correctIndex)
        {
            index++;
            correctIndex++;
        }
        if(ID != correctIndex)
        {
            index++;
            correctIndex = 1;

            if (index >= 9 && correctIndex <= 9)
            {
                foreach (GameObject light in lights)
                {
                    light.SetActive(false);
                }
                index = 1;
                correctIndex = 1;
            }
        }

        if (correctIndex >= 9)
        {
            print("CACHANG DOOR OPEN");
            Destroy(normalDoor);
            Instantiate(brokenDoor, normalDoor.transform.position, Quaternion.identity);
        }

        print("index: "+ index);
        print("correct index: "+ correctIndex);
    }
}
