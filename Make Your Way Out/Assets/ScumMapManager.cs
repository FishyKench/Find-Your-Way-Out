using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScumMapManager : MonoBehaviour
{
    [SerializeField]
    private fsManager fsM;
    [SerializeField]
    private levermanager leverM;
    public GameObject normalDoor;
    public GameObject brokenDoor;
    private bool broke;
    // Start is called before the first frame update
    void Start()
    {
        fsM = fsM.GetComponent<fsManager>();
        leverM = leverM.GetComponent<levermanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (broke == false && leverM.leverSolved == true && fsM.fsSolved == true)
        {
            broke = true;
            Instantiate(brokenDoor, normalDoor.transform.position, Quaternion.identity);
            Destroy(normalDoor);
        }

    }
}
