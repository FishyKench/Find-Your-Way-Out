using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class interactable : MonoBehaviour
{
    //DW about this script 
    //It's main use is that the interactable objects inheret these voids and shit
    public virtual void Awake()
    {
        gameObject.layer = 11;
    }

    public abstract void OnInteract();
    public abstract void OnFocus();
    public abstract void OnLoseFocus();
}
