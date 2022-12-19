using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonManager_RGBnDOOR : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI redDisplay;
    [SerializeField] TextMeshProUGUI greenDisplay;
    [SerializeField] TextMeshProUGUI blueDisplay;

    [Space(5)]

    public GameObject normalDoor;
    public GameObject brokenDoor;

    [HideInInspector] public int redNum;
    [HideInInspector] public int greenNum;
    [HideInInspector] public int blueNum;

    [Space(15)]

    [Header("Solution")]
    [SerializeField] int goalRed;
    [SerializeField] int goalGreen;
    [SerializeField] int goalBlue;

    private void Update()
    {
        redDisplay.text = redNum.ToString();
        greenDisplay.text = greenNum.ToString();
        blueDisplay.text = blueNum.ToString();

        if (redNum < 0)
            redNum = 0;

        if (greenNum < 0)
            greenNum = 0;

        if (blueNum < 0)
            blueNum = 0;
    }

    public void changeAmount(string index, int changeAmont)
    {
        switch (index)
        {
            case "red":
                redNum += changeAmont;
                break;

            case "blue":
                blueNum += changeAmont;
                break;

            case "green":
                greenNum += changeAmont;
                break;
        }
    }

    public void CheckSolution()
    {
        if (redNum == goalRed && greenNum == goalGreen && blueNum == goalBlue)
        {
            print("CACHANG DOOR OPEN");
            Destroy(normalDoor);
            Instantiate(brokenDoor, normalDoor.transform.position, Quaternion.identity);
        }
        else
        {
            print("NOPE TRY AGAIN");
        }
    }
}
