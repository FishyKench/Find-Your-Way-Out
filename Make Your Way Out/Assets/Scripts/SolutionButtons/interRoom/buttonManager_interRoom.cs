using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonManager_interRoom : MonoBehaviour
{
    [SerializeField] private int index = 1;
    [SerializeField] private List<GameObject> lights;

    public GameObject normalDoor;
    public GameObject brokenDoor;
    public void CheckID(int ID)
    {

        if (ID == index)
        {
            index++;
            print(index);
            lights[ID-=1].SetActive(true);
        }
        else
        {
            index = 1;
            print(index);

            foreach ( GameObject light in lights)
            {
                light.SetActive(false);
            }
        }

        if(index == 9)
        {
            print("CACHANG DOOR OPEN");
            Destroy(normalDoor);
            Instantiate(brokenDoor, normalDoor.transform.position, Quaternion.identity);
        }
    }
}
