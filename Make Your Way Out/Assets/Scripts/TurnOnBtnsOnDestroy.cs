using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBtnsOnDestroy : MonoBehaviour
{
    [SerializeField]ChamberConfButton cBtn;
    [SerializeField]ChamberDoors dBtn;

    private void OnDestroy()
    {
        cBtn.enabled = true;
        dBtn.enabled = true;
    }
}
