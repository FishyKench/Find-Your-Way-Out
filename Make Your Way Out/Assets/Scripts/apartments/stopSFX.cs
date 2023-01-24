using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopSFX : MonoBehaviour
{
    [SerializeField] AudioSource sfx;
    [SerializeField] float fadeTime = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }

    }
    IEnumerator FadeOut()
    {
        float startVolume = sfx.volume;
        while (sfx.volume > 0)
        {
            sfx.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        sfx.Stop();
        sfx.volume = startVolume;
    }
}
