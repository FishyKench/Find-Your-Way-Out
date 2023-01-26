using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayJumpBarrier : MonoBehaviour
{
    hallwayPlatformManager hpm;
    private void Start()
    {
        hpm = FindObjectOfType<hallwayPlatformManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            hpm.makeThemFall();
    }
}
