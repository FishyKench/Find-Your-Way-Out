using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerFromStart : MonoBehaviour
{
    public float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
