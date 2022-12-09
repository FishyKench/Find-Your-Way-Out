using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonManager : MonoBehaviour
{
    [HideInInspector] public int redNum;
    [HideInInspector] public int greenNum;
    [HideInInspector] public int blueNum;
    [HideInInspector] public int yellowNum;

    [Header("References")]
    [SerializeField] TextMeshProUGUI redDisplay;
    [SerializeField] TextMeshProUGUI greenDisplay;
    [SerializeField] TextMeshProUGUI blueDisplay;
    [SerializeField] TextMeshProUGUI yellowDisplay;

    [Space (15)]

    [Header("Solution")]
    [SerializeField] int goalRed;
    [SerializeField] int goalGreen;
    [SerializeField] int goalBlue;
    [SerializeField] int goalYellow;

    private void Update()
    {
        redDisplay.text = redNum.ToString();
        greenDisplay.text = greenNum.ToString();
        blueDisplay.text = blueNum.ToString();
        yellowDisplay.text = yellowNum.ToString();

        if (redNum < 0)
            redNum = 0;

        if (greenNum < 0)
            greenNum = 0;

        if (blueNum < 0)
            blueNum = 0;

        if (yellowNum < 0)
            yellowNum = 0;
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

            case "yellow":
                yellowNum += changeAmont;
                break;

        }
    }

    public void CheckSolution()
    {
        if(redNum == goalRed && greenNum == goalGreen && blueNum == goalBlue && yellowNum == goalYellow)
        {
            print("CACHANG DOOR OPEN");
        }
        else
        {
            print("NOPE TRY AGAIN");
        }
    }
}
