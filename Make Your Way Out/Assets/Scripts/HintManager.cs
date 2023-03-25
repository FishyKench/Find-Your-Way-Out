using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hintText1;
    [SerializeField] TextMeshProUGUI hintText2;
    [SerializeField] TextMeshProUGUI hintText3;
    [SerializeField] TMP_FontAsset uiFont;

    public void RevealHint(int id)
    {
        switch (id)
        {
            case 1:
                hintText1.font = uiFont;
                hintText1.color = Color.white;
                break;
            case 2:
                hintText2.font = uiFont;
                hintText2.color = Color.white;
                break;
            case 3:
                hintText3.font = uiFont;
                hintText3.color = Color.white;
                break;
        }
    }
}
