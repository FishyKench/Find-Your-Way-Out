using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class destoryTest : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform thisObject;
    public int numOfChild,i;

    void Start()
    {
        try
        {
            StartCoroutine(waitForDoor());
        }

        catch(Exception e)
        {
            print("HEHE FK UR ERROR");
        }
        numOfChild = thisObject.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitForDoor()
    {
        yield return new WaitForSeconds(2);
        for (i = numOfChild - 1; i >=1; i--)
        {
            DestroyImmediate(thisObject.GetChild(i).gameObject);
            Destroy(this.gameObject);
        }
    }
}
