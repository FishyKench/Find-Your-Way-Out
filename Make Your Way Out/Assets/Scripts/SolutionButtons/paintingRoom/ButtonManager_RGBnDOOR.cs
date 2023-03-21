using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonManager_RGBnDOOR : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Image oneDisplay;
    [SerializeField] Image twoDisplay;
    [SerializeField] Image threeDisplay;
    [SerializeField] Image fourDisplay;
    [SerializeField] Image fiveDisplay;
    [SerializeField] Image sixDisplay;
    [SerializeField] Image sevenDisplay;
    [SerializeField] Image eightDisplay;

    [SerializeField] Sprite red;
    [SerializeField] Sprite blue;
    [SerializeField] Sprite green;

    [SerializeField] AudioSource btnClick;
    [SerializeField] AudioSource confirmClick;

    [Space(5)]

    public GameObject normalDoor;
    public GameObject brokenDoor;

    [HideInInspector] public int one = 1;
    [HideInInspector] public int two = 1;
    [HideInInspector] public int three = 1;
    [HideInInspector] public int four = 1;
    [HideInInspector] public int five = 1;
    [HideInInspector] public int six = 1;
    [HideInInspector] public int seven = 1;
    [HideInInspector] public int eight = 1;

    [Space(15)]

    [Header("Solution")]
    [SerializeField] int goalOne;
    [SerializeField] int goalTwo;
    [SerializeField] int goalThree;
    [SerializeField] int goalFour;
    [SerializeField] int goalFive;
    [SerializeField] int goalSix;
    [SerializeField] int goalSeven;
    [SerializeField] int goalEight;


    private void Update()
    {
        

        //clamp min
        if (one < 1)
            one = 1;

        if (two < 1)
            two = 1;

        if (three < 1)
            three = 1;
        
        if (four < 1)
            four = 1;

        if (five < 1)
            five = 1;

        if (six < 1)
            six = 1;

        if (seven < 1)
            seven = 1;

        if (eight < 1)
            eight = 1;

        //clamp max
        if (one > 3)
            one = 3;

        if (two > 3)
            two = 3;

        if (three > 3)
            three = 3;

        if (four > 3)
            four = 3;

        if (six > 3)
            six = 3;

        if (seven > 3)
            seven = 3;

        if (eight > 3)
            eight = 3;
    }

    public void changeAmount(int index, int changeAmont)
    {
        btnClick.PlayOneShot(btnClick.clip);

        switch (index)
        {
            case 1:
                one += changeAmont;
                break;

            case 2:
                two += changeAmont;
                break;

            case 3:
                three += changeAmont;
                break;

            case 4:
                four += changeAmont;
                break;

            case 5:
                five += changeAmont;
                break;

            case 6:
                six += changeAmont;
                break;

            case 7:
                seven += changeAmont;
                break;

            case 8:
                eight += changeAmont;
                break;
        }

        switch (one)
        {
            case 1:
                oneDisplay.sprite = red;
                break;
            case 2:
                oneDisplay.sprite = green;
                break;
            case 3:
                oneDisplay.sprite = blue;
                break;
        }
        switch (two)
        {
            case 1:
                twoDisplay.sprite = red;
                break;
            case 2:
                twoDisplay.sprite = green;
                break;
            case 3:
                twoDisplay.sprite = blue;
                break;
        }
        switch (three)
        {
            case 1:
                threeDisplay.sprite = red;
                break;
            case 2:
                threeDisplay.sprite = green;
                break;
            case 3:
                threeDisplay.sprite = blue;
                break;
        }
        switch (four)
        {
            case 1:
                fourDisplay.sprite = red;
                break;
            case 2:
                fourDisplay.sprite = green;
                break;
            case 3:
                fourDisplay.sprite = blue;
                break;
        }
        switch (five)
        {
            case 1:
                fiveDisplay.sprite = red;
                break;
            case 2:
                fiveDisplay.sprite = green;
                break;
            case 3:
                fiveDisplay.sprite = blue;
                break;
        }
        switch (six)
        {
            case 1:
                sixDisplay.sprite = red;
                break;
            case 2:
                sixDisplay.sprite = green;
                break;
            case 3:
                sixDisplay.sprite = blue;
                break;
        }
        switch (seven)
        {
            case 1:
                sevenDisplay.sprite = red;
                break;
            case 2:
                sevenDisplay.sprite = green;
                break;
            case 3:
                sevenDisplay.sprite = blue;
                break;
        }
        switch (eight)
        {
            case 1:
                eightDisplay.sprite = red;
                break;
            case 2:
                eightDisplay.sprite = green;
                break;
            case 3:
                eightDisplay.sprite = blue;
                break;
        }

    }

    public void CheckSolution()
    {
        confirmClick.Play();

        if (one == goalOne && two == goalTwo && three == goalThree && four == goalFour && five == goalFive && six == goalSix && seven == goalSeven && eight == goalEight)
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
