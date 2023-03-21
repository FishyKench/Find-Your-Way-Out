using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatformManager : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> platforms;
    [SerializeField] private List<Transform> spawnpoints;
    [SerializeField] private Transform playerSpawn;
    [SerializeField] private GameObject particleSpawner;
    [SerializeField] private AudioSource fallingSFX;
    [SerializeField] private AudioSource respawnSFX;
    private GameObject player;
    [SerializeField]
    private bool soundPlayed;
    private Animator fade;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovementAdvanced>().gameObject;
        fade = GameObject.Find("Fade").GetComponent<Animator>();
    }
    public void makeThemFall()
    {
        if(soundPlayed == false)
        {
            fallingSFX.PlayOneShot(fallingSFX.clip);
            soundPlayed = true;
            StartCoroutine(soundCoolDown());
        }
        

        particleSpawner.SetActive(true);
        foreach (Rigidbody i in platforms)
        {
            i.isKinematic = false;
        }
    }

    public void respawn()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            platforms[i].transform.position = spawnpoints[i].position;
            platforms[i].transform.rotation = spawnpoints[i].rotation;
        }
        foreach (Rigidbody platform in platforms)
        {
            platform.isKinematic = true;
            platform.GetComponent<hallwayPlatform>().shouldLight = false;
            platform.GetComponent<BoxCollider>().enabled = true;
            platform.GetComponent<hallwayPlatform>().lamp.SetActive(false);

        }
        particleSpawner.SetActive(false);
        player.transform.position = playerSpawn.position;
        respawnSFX.Play();
        fade.SetTrigger("Fade");

    }
    IEnumerator soundCoolDown()
    {
        if(soundPlayed == true)
        {
            yield return new WaitForSeconds(2);
            soundPlayed = false;
        }
        
    }
}
