using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatform : MonoBehaviour
{
    private AudioSource sfx;
    float pitch;

    [SerializeField]private bool correctPlatform;
    public GameObject lamp;
    public bool shouldLight;

    private void Start()
    {
        lamp = GetComponentInChildren<Light>().gameObject;
        lamp.SetActive(false);

        sfx = GetComponent<AudioSource>();
        pitch = Random.Range(1, 1.5f);
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
        {
            lamp.SetActive(true);
            sfx.pitch = pitch;
            sfx.PlayOneShot(sfx.clip);
        }
    }
}
