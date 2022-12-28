using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    public GameObject A1,A2,A3,A4,A5,A6,A7,A8;
    public GameObject triggerToChoose;
    
        






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print(1);
        }
    }
}
