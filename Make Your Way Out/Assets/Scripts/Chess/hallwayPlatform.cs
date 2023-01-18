using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatform : MonoBehaviour
{
    
    [SerializeField]private bool correctPlatform;
    public GameObject lamp;
    public bool shouldLight;

    private void Start()
    {
        lamp = GetComponentInChildren<Light>().gameObject;
        lamp.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (correctPlatform == true && collision.gameObject.CompareTag("Player"))
        {
            shouldLight = true;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            FindObjectOfType<hallwayPlatformManager>().makeThemFall();
        }
        if (shouldLight)
            lamp.SetActive(true);
    }
}
