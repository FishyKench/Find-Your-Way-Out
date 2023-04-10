using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobHintRandom : MonoBehaviour
{
    [Header("The First Clue")]
    private bool firstPos;
    public Vector3 firstVector;
    public Quaternion firstRotation;



    private bool secondPos;
    public Vector3 secondPosVector;
    public Quaternion secondPosRotation;


    private bool thirdPos;
    public  Vector3 thirdPosVector;
    public  Quaternion thirdPosRotation;
    private int randomNum;

    void Start()
    {
        randomNum = Random.Range(1, 4);
        
        switch (randomNum)
        {
            case 1:
                {
                    firstPos = true;
                    transform.localPosition = firstVector;
                    transform.localRotation = firstRotation;
                    break;
                }
            case 2:
                {
                    secondPos = true;
                    transform.localPosition = secondPosVector;
                    transform.localRotation = secondPosRotation;
                    break;
                }
            case 3:
                {
                    thirdPos = true;
                    transform.localPosition = thirdPosVector;
                    transform.localRotation = thirdPosRotation;
                    break;
                }
        }




    }
}
