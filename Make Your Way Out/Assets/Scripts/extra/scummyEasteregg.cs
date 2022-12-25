using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scummyEasteregg : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
