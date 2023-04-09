using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HintManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hintText1;
    [SerializeField] TextMeshProUGUI hintText2;
    [SerializeField] TextMeshProUGUI hintText3;
    [SerializeField] TMP_FontAsset uiFont;

    [Space(15)]

    [Header("Timer")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float time;
    [SerializeField] Image counter1;
    [SerializeField] Image counter2;
    [SerializeField] Image counter3;
    float hint1Time = 600;
    float hint2Time = 1200;
    float hint3Time = 1800;

    TimerFromStart timer;

    private void Start()
    {
        timer = FindObjectOfType<TimerFromStart>();
    }
    private void Update()
    {
        time = timer.timer;

        counter1.fillAmount = time/hint1Time;
        counter2.fillAmount = time/hint2Time;
        counter3.fillAmount = time/hint3Time;
    }

    public void RevealHint(int id)
    {
        switch (id)
        {
            case 1:
                if (time >= hint1Time)
                {
                    hintText1.font = uiFont;
                    hintText1.color = Color.white;
                }
                break;
            case 2:
                if (time >= hint2Time)
                {
                    hintText2.font = uiFont;
                    hintText2.color = Color.white;
                }
                break;
            case 3:
                if (time >= hint3Time)
                {
                    hintText3.font = uiFont;
                    hintText3.color = Color.white;
                }
                break;
        }
    }
}
