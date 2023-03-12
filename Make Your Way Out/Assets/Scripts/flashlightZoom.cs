using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightZoom : MonoBehaviour
{
    [SerializeField] Light spotlight;
    [SerializeField] float zoomedInValue;
    [SerializeField] float smooth;
    float originalSize;
    private void Start()
    {
        originalSize = spotlight.spotAngle;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(zoomIn());
        if (Input.GetKeyUp(KeyCode.Q))
            StartCoroutine(zoomOut());
    }

    IEnumerator zoomIn()
    {
        float time = 0;
        float duration = smooth;

        float startAngle = spotlight.spotAngle;

        while (time < duration)
        {
            spotlight.spotAngle = Mathf.Lerp(startAngle, zoomedInValue, time / duration);

            time += Time.deltaTime;
            yield return null;
        }

        spotlight.spotAngle = zoomedInValue;
    }
    IEnumerator zoomOut()
    {
        float time = 0;
        float duration = smooth;

        float startAngle = spotlight.spotAngle;

        while (time < duration)
        {
            spotlight.spotAngle = Mathf.Lerp(startAngle, originalSize, time / duration);

            time += Time.deltaTime;
            yield return null;
        }

        spotlight.spotAngle = originalSize;
    }

}