using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessSolutionChecker : MonoBehaviour
{
    // Start is called before the first frame update

    public PlacementIndicator B2, F3, B5, D5, G7, H8;

    public List<GameObject> gridPath; 
    public Material pathMat;

    [SerializeField] Animator door1;
    [SerializeField] Animator door2;





    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         if (B2.hasRook == true && F3.hasBishop == true && B5.hasKing == true && D5.hasKnight == true && G7.hasQueen == true && H8.hasPawn == true)
        {
            print("WORKED");
            door1.SetTrigger("open");
            door2.SetTrigger("open");
            FindObjectOfType<pathGuide>().solution = true;
            foreach (GameObject p in gridPath)
            { 
                p.GetComponent<MeshRenderer>().material = pathMat;
            }
        }

    }
}
