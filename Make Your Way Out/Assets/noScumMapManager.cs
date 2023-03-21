using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noScumMapManager : MonoBehaviour
{


    public RotationSolutionChecker CheckSolution;
    public bool broke;
    public GameObject normalDoor;
    public GameObject brokenDoor;





    // Start is called before the first frame update
    void Start()
    {
        CheckSolution = CheckSolution.GetComponent<RotationSolutionChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(broke == false && CheckSolution.knobSolved == true)
        {
            broke = true;
            Instantiate(brokenDoor, normalDoor.transform.position, Quaternion.identity);
            Destroy(normalDoor);
        }
        
    }
}
