using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOnRotati : interactable
{
    // Start is called before the first frame update


    public GameObject crosshair;

    public override void OnInteract()
    {

    }
    public override void OnFocus()
    {
        crosshair.transform.localScale = new Vector3(.1f, .1f, .1f);
    }
    public override void OnLoseFocus()
    {
        crosshair.transform.localScale = new Vector3(.05f, .05f, .05f);
    }
}
