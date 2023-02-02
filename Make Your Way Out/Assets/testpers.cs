using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpers : MonoBehaviour
{
    float maxDistance = 0;

    GrabScript grab;
    Camera cam;
    Rigidbody rb;

    [Header("Visual Veriables")]
    [SerializeField] List<MeshRenderer> renderers;
    [Space(10)]

    [Header("Lerp Variables")]
    [SerializeField] float overTime = 0.5f;
    [Space(10)]

    [Header("Camera Variables")]
    [SerializeField] float orthoSize;
    [Space(10)]

    [Header("Rotation Variables")]
    [SerializeField] Vector3 goalRotMin;
    [SerializeField] Vector3 goalRotMax;
    [SerializeField] Vector3 goalRot;
    [SerializeField] Vector3 localRot;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        grab = GetComponent<GrabScript>();
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        localRot = transform.rotation.eulerAngles;

        if (grab.IsGrabbed == true)
        {
            switchtoOrtho();
            //calculateDistance();
        }
        else
        {
            cam.orthographic = false;
        }

        if (transform.eulerAngles.x > goalRotMin.x && transform.eulerAngles.y > goalRotMin.y && transform.eulerAngles.z > goalRotMin.z
        && transform.eulerAngles.x < goalRotMax.x && transform.eulerAngles.y < goalRotMax.y && transform.eulerAngles.z < goalRotMax.z)
        {
            StartCoroutine(lerpToGoal());
            grab.Drop();
            rb.isKinematic = true;
            rb.freezeRotation = true;
        }
    }

    void switchtoOrtho()
    {
        cam.orthographic = true;
        cam.orthographicSize = orthoSize;
        cam.GetComponent<PlayerCam>().enabled = false;
    }

    IEnumerator lerpToGoal()
    {
        float startTime = Time.time;
        while (Time.time < startTime + overTime)
        {
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.eulerAngles), Quaternion.Euler(goalRot), (Time.time - startTime) / overTime);
            yield return null;
        }
        transform.eulerAngles = goalRot;
    }

    void calculateDistance()
    {
        float distance = Vector3.Distance(transform.eulerAngles, goalRot);

        foreach (MeshRenderer mr in renderers)
        {
            mr.material.color = Color.Lerp(Color.green, Color.red, Mathf.InverseLerp(0, 507, distance));
        }
        print(Mathf.InverseLerp(0, 507, distance));
        //if(distance > maxDistance)
        //{
        //    maxDistance = distance;
        //    print("New Max = " + maxDistance);
        //}

    }
}
