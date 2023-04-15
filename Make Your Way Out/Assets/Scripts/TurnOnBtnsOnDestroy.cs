using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBtnsOnDestroy : MonoBehaviour
{
    [SerializeField]ChamberConfButton cBtn;

    private void OnDestroy()
    {
        cBtn.enabled = true;
    }
}
