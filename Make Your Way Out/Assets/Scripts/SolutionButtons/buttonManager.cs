using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonManager : MonoBehaviour
{
    public int redNum;
    public int greenNum;
    public int blueNum;
    public int yellowNum;

    [SerializeField] TextMeshProUGUI redDisplay;
    [SerializeField] TextMeshProUGUI greenDisplay;
    [SerializeField] TextMeshProUGUI blueDisplay;
    [SerializeField] TextMeshProUGUI yellowDisplay;

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
}
