using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatform : MonoBehaviour
{
    private GameObject lamp;
    
    [SerializeField]private bool correctPlatform;
    [SerializeField]private bool shouldLight;

    private void Start()
    {
        lamp = GetComponentInChildren<Light>().gameObject;
        lamp.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(correctPlatform == true && collision.gameObject.CompareTag("Player"))
        {
            shouldLight = true;
        }
        else
        {
            FindObjectOfType<hallwayPlatformManager>().makeThemFall();
        }
        if (shouldLight)
            lamp.SetActive(true);
    }
}
