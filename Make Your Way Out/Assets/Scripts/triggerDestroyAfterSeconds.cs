using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float WaitTime = 3;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("destroyInTime", WaitTime);
        }
    }

    void destroyInTime()
    {
        Destroy(this.gameObject);
    }
}
