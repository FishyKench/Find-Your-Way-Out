using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatformManager : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> platforms;
    [SerializeField] private List<Transform> spawnpoints;
    [SerializeField] private Transform playerSpawn;
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovementAdvanced>().gameObject;
    }
    public void makeThemFall()
    {
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

        player.transform.position = playerSpawn.position;

    }
}
