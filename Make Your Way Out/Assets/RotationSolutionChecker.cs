using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSolutionChecker : MonoBehaviour
{
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public GameObject mainDisplay1;
    public GameObject mainDisplay2;
    public GameObject mainDisplay3;

    public float firstRotation;
    public float secondRotation;
    public float thirdRotation;

    public MeshRenderer cube1;
    public MeshRenderer cube2;
    public MeshRenderer cube3;


    private MeshRenderer _meshRenderer;
    [SerializeField] 
    private Material correctMat;

    [SerializeField]
    private Material defaultMat;


    // Start is called before the first frame update
    void Start()
    {
        cube1 = mainDisplay1.GetComponent<MeshRenderer>();
        cube2 = mainDisplay2.GetComponent<MeshRenderer>();
        cube3 = mainDisplay3.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        firstRotation = g1.GetComponent<knobRotateInteract>().currentRot;
        secondRotation = g2.GetComponent<knobRotateInteract>().currentRot;
        thirdRotation = g3.GetComponent<knobRotateInteract>().currentRot;


        if (firstRotation == 90)
        {
            cube1.material = correctMat;
        }
        else
        {
            cube1.material = defaultMat;
        }

        if(secondRotation == 225)
        {
            cube2.material = correctMat;
        }
        else
        {
            cube2.material = defaultMat;
        }

        if (thirdRotation == 135)
        {
            cube3.material = correctMat;
        }
        else
        {
            cube3.material = defaultMat;
        }





        if (firstRotation == 90 && secondRotation == 225 && thirdRotation == 135)
        {
            print("MOMO!");
        }

    }
}
