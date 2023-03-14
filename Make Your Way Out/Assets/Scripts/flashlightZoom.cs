using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightZoom : MonoBehaviour
{
    [SerializeField] Light spotlight;
    [SerializeField] float zoomedInValue;
    [SerializeField] float zoomedInIntensity;
    [SerializeField] float zoomedInRange;
    [SerializeField] float smooth;
    float originalSize;
    float originalintensity;
    float originalRange;
    private void Start()
    {
        originalSize = spotlight.spotAngle;
        originalintensity = spotlight.intensity;
        originalRange = spotlight.range;
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
        float startIntensity = spotlight.intensity;
        float startRange = spotlight.range;

        while (time < duration)
        {
            spotlight.spotAngle = Mathf.Lerp(startAngle, zoomedInValue, time / duration);
            spotlight.intensity = Mathf.Lerp(startIntensity, zoomedInIntensity, time / duration);
            spotlight.range = Mathf.Lerp(startRange, zoomedInRange, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        spotlight.spotAngle = zoomedInValue;
        spotlight.intensity = zoomedInIntensity;
        spotlight.range = zoomedInRange;
    }
    IEnumerator zoomOut()
    {
        float time = 0;
        float duration = smooth;

        float startAngle = spotlight.spotAngle;
        float startIntensity = spotlight.intensity;
        float startRange = spotlight.range;

        while (time < duration)
        {
            spotlight.spotAngle = Mathf.Lerp(startAngle, originalSize, time / duration);
            spotlight.intensity = Mathf.Lerp(startIntensity, originalintensity, time / duration);
            spotlight.range = Mathf.Lerp(startRange, originalRange, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        spotlight.spotAngle = originalSize;
        spotlight.intensity = originalintensity;
        spotlight.range = originalRange;
    }

}