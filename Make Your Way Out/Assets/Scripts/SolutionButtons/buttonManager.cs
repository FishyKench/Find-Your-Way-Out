using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonManager : MonoBehaviour
{
    [HideInInspector] public int redNum;
    [HideInInspector] public int greenNum;
    [HideInInspector] public int blueNum;
    [HideInInspector] public int yellowNum;

    [SerializeField]
    private List <GameObject> screens;
    [SerializeField]
    private List<MeshRenderer> screensToBeBroken;
    [SerializeField]
    private List<Material> brokenMaterials;
    [SerializeField]
    private List<GameObject> itemsToDelete;

    public GameObject brokenScreen;
    public GameObject brokenScreen1;
    public GameObject brokenScreen2;


    [Header("References")]
    [SerializeField] TextMeshProUGUI redDisplay;
    [SerializeField] TextMeshProUGUI greenDisplay;
    [SerializeField] TextMeshProUGUI blueDisplay;
    [SerializeField] TextMeshProUGUI yellowDisplay;
    [SerializeField] AudioSource btnClick;
    [SerializeField] AudioSource confirmClick;
    

    [Space (15)]

    [Header("Solution")]
    [SerializeField] int goalRed;
    [SerializeField] int goalGreen;
    [SerializeField] int goalBlue;
    [SerializeField] int goalYellow;

    [Space(15)]
    [Header("Clocks")]
    [SerializeField] List<Clock> clocks;
    [Space(5)]
    [SerializeField] List<int> hours;
    [SerializeField] List<int> minutes;
    [SerializeField] List<AudioSource> clockSFXs;
    [SerializeField] List<GameObject> clockLights;

    public Vector3 offSet;

    private void Start()
    {
        foreach (Clock c in clocks)
        {
            c.hour = 0;
            c.minutes = 0;
            c.seconds = 0;
            
        }
        foreach (AudioSource sfx in clockSFXs)
        {
            sfx.Stop();
        }
        foreach (GameObject g in clockLights)
        {
            g.SetActive(false);
        }
    }

    private void Update()
    {
        redDisplay.text = redNum.ToString();
        greenDisplay.text = greenNum.ToString();
        blueDisplay.text = blueNum.ToString();
        yellowDisplay.text = yellowNum.ToString();

        if (redNum < 0)
            redNum = 0;

        if (greenNum < 0)
            greenNum = 0;

        if (blueNum < 0)
            blueNum = 0;

        if (yellowNum < 0)
            yellowNum = 0;
    }

    public void changeAmount(string index, int changeAmont)
    {
        btnClick.PlayOneShot(btnClick.clip);
        switch (index)
        {
            case "red":
                redNum += changeAmont;
                break;

            case "blue":
                blueNum += changeAmont;
                break;

            case "green":
                greenNum += changeAmont;
                break;

            case "yellow":
                yellowNum += changeAmont;
                break;

        }
    }

    public void CheckSolution()
    {
        confirmClick.PlayOneShot(confirmClick.clip);

        if(redNum == goalRed && greenNum == goalGreen && blueNum == goalBlue && yellowNum == goalYellow)
        {
            print("CACHANG DOOR OPEN");
            foreach ( GameObject i in screens)
            {
                Destroy(i);
                brokenScreen.SetActive(true);
                brokenScreen1.SetActive(true);
                brokenScreen2.SetActive(true);
                brokenScreen.GetComponent<Rigidbody>().AddForce(new Vector3(0,1,1),ForceMode.Impulse);
                brokenScreen1.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
                brokenScreen2.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 1), ForceMode.Impulse);
            }

            foreach (GameObject i in itemsToDelete)
            {
                Destroy(i);
            }

            for(int i = 0; i <= screensToBeBroken.Count-1; i++)
            {
                print("I I I I II  I I ");
                screensToBeBroken[i].material = brokenMaterials[i];

               if(screensToBeBroken[i].TryGetComponent(out AudioSource screenAudio))
                {
                    screenAudio.Stop();
                }
            }

            for (int i = 0; i < clocks.Count; i++)
            {
                clocks[i].hour = hours[i];
                clocks[i].minutes = minutes[i];
                clocks[i].moveOnlySeconds = true;
            }
            foreach (AudioSource sfx in clockSFXs)
            {
                sfx.Play();
            }
            foreach (GameObject g in clockLights)
            {
                g.SetActive(true);
            }

            GameObject confirmBTN = FindObjectOfType<confirmButton>().gameObject;
            confirmBTN.GetComponent<MeshCollider>().enabled = false;

            
        }
        else
        {
            print("NOPE TRY AGAIN");
        }
    }
}
