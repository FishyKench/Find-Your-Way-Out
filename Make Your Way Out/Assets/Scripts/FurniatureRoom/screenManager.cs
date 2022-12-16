using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenManager : MonoBehaviour
{
    public List<GameObject> screens;

    private void Start()
    {
        for (int i = 1; i < screens.Count; i++)
        {
            screens[i].SetActive(false);
        }
    }
}
