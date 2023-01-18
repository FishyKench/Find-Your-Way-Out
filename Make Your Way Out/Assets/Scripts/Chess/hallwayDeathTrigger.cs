using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayDeathTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<hallwayPlatformManager>().respawn();
        }
    }
}
