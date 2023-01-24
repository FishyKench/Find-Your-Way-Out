using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;
    float time;
    bool shouldPlay = false;

    float timeElapsed;

    private void Start()
    {
        time = Random.Range(0f, 2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(waitToPlay());
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(waitToStop());
            time = Random.Range(0f, 2.5f);
        }
    }

    IEnumerator waitToPlay()
    {
        yield return new WaitForSeconds(time);
        sfx.Play();
    }

    IEnumerator waitToStop()
    {
        yield return new WaitForSeconds(0.2f);
        sfx.Stop();
    }
}
