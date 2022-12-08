using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    // Start is called before the first frame update


    public static float rCounter = 4f;
    public static float total = 0f;
    public int value;


    public GameObject mainCube;
    void Start()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rCounter -= 1;
            total += value * Mathf.Pow(10, rCounter);
            print("total is : " + total);
            print("rCounter is : " + rCounter);


            if (rCounter == 0)
            {
                print("2nd if ");
                if (total == 4321)
                {
                    print("3rd if ");
                    Destroy(mainCube);
                }
                else
                {
                    print("else");
                    rCounter = 3;
                    total = 0;
                }
            }
        }
    }

}
