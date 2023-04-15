using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VilesChange : interactable
{
    // Start is called before the first frame update


    public TextMeshProUGUI chemText;

    public GameObject sphereVial;
    public GameObject squareVial;
    public GameObject cylinderVial;
    public GameObject triangleVial;

    public ChamberConfButton chamberScript;

    public int seqNo;
    public int btnID;
    public bool isCorrect;

    public GameObject confirmLight;
    public bool isOpen;


    private float elapsedTime;
    private float waitTime = 0.75f;



    private void Start()
    {
        sphereVial.SetActive(false);
        squareVial.SetActive(false);
        cylinderVial.SetActive(false);
        triangleVial.SetActive(true);
        seqNo = 1;

        isCorrect = false;
    }

    private void Update()
    {
        if(seqNo > 4)
        {
            seqNo = 1;
        }
    }

    public override void OnInteract()
    {
        if(chamberScript.doorisDone == true)
        {
            switch (btnID)
            {

                case 1:
                    switch (seqNo)
                    {
                        case 1:

                            sphereVial.SetActive(false);
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(true);  //4th  is active
                            isCorrect = true;
                            seqNo++;
                            chemText.text = "Au";
                            break;
                        case 2:
                            sphereVial.SetActive(false);  // 3rd  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(true);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "Na";
                            break;
                        case 3:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(true);   //2nd is active 
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            chemText.text = "Cl";
                            seqNo++;

                            isCorrect = false;
                            break;
                        case 4:
                            sphereVial.SetActive(true);   //1st  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "H";
                            break;
                    }
                    break;
                case 2:
                    switch (seqNo)
                    {
                        case 1:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(true);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);  //2nd  is active
                            isCorrect = false;
                            seqNo++;
                            chemText.text = "Ca";
                            break;
                        case 2:
                            sphereVial.SetActive(false);  // 4th  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(true);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "Si";
                            break;
                        case 3:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(false);   //3rd is active 
                            cylinderVial.SetActive(true);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "He";
                            break;
                        case 4:
                            sphereVial.SetActive(true);   //1st  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = true;
                            chemText.text = "Pt";
                            break;
                    }
                    break;
                case 3:
                    switch (seqNo)
                    {
                        case 1:
                            sphereVial.SetActive(true);  // 1st  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "N";

                            break;
                        case 2:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(true);
                            triangleVial.SetActive(false);  //3rd  is active
                            isCorrect = true;
                            chemText.text = "Si";
                            seqNo++;



                            break;
                        case 3:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(true);   //2nd is active 
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "Fe";
                            break;
                        case 4:
                            sphereVial.SetActive(false);   //4th  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(true);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "K";
                            break;
                    }
                    break;
                case 4:
                    switch (seqNo)
                    {
                        case 1:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(true);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);  //2nd  is active
                            seqNo++;
                            isCorrect = true;
                            chemText.text = "Fe";
                            break;
                        case 2:
                            sphereVial.SetActive(false);  // 3rd  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(true);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "Li";
                            break;
                        case 3:
                            sphereVial.SetActive(false);
                            squareVial.SetActive(false);   //4ht is active 
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(true);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "Cl";
                            break;
                        case 4:
                            sphereVial.SetActive(true);   //1st  is active
                            squareVial.SetActive(false);
                            cylinderVial.SetActive(false);
                            triangleVial.SetActive(false);
                            seqNo++;
                            isCorrect = false;
                            chemText.text = "He";
                            break;
                    }
                    break;

            }
        }
        

    }
    public override void OnFocus()
    {

    }
    public override void OnLoseFocus()
    {

    }
}
