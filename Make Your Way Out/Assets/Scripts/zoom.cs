using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{

    public Camera cam;
    Coroutine zoomCoroutine;

    [SerializeField] private float zoomedOutFov = 80;
    [SerializeField] private float zoomedInFov = 40;
    [SerializeField] private float zoomDuration = .5f;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Stop old coroutine
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);

            //Start new coroutine and zoom within 1 second
            zoomCoroutine = StartCoroutine(lerpFieldOfView(cam, zoomedInFov, zoomDuration));
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            //Stop old coroutine
            if (zoomCoroutine != null)
                StopCoroutine(zoomCoroutine);

            //Start new coroutine and zoom within 1 second
            zoomCoroutine = StartCoroutine(lerpFieldOfView(cam, zoomedOutFov, zoomDuration));
        }

    }


    IEnumerator lerpFieldOfView(Camera targetCamera, float toFOV, float duration)
    {
        float counter = 0;

        float fromFOV = targetCamera.fieldOfView;

        while (counter < duration)
        {
            counter += Time.deltaTime;

            float fOVTime = counter / duration;
            Debug.Log(fOVTime);

            //Change FOV
            targetCamera.fieldOfView = Mathf.Lerp(fromFOV, toFOV, fOVTime);
            //Wait for a frame
            yield return null;
        }
    }
}
