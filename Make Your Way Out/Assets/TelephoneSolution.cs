using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneSolution : MonoBehaviour
{
    public int FirstHours = -1;
    public int SecondHours = -1;
    public int FirstMins = -1;
    public int SecondMins = -1;

    public int hehe;




    private void Update()
    {
        if (hehe == 1)
        {
            if (FirstHours == 0 && SecondHours == 7 && FirstMins == 3 && SecondMins == 0)
            {
                print(FirstHours + SecondHours + ":" + FirstMins + SecondMins);
                print("CORRECT!");
            }
            else
            {
                print(FirstHours + SecondHours + ":" + FirstMins + SecondMins);
                print("Wrong!");

                FirstHours = -1;
                SecondHours = -1;
                FirstMins = -1;
                SecondMins = -1;
            }
        }
    }



    public int getNum(int number)
    {
        if (FirstHours == -1)
        {
            FirstHours = number;
            return FirstHours;
        }

        else if (FirstHours != -1 && SecondHours == -1)
        {
            SecondHours = number;
            return SecondHours;
        }
        else if (FirstHours != -1 && SecondHours != -1 && FirstMins == -1)
        {
            FirstMins = number;
            return FirstMins;
        }
        else
        {
            SecondMins = number;
            return SecondMins;
        }
    }




}
