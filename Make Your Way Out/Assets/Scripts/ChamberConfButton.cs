using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChamberConfButton : interactable
{

    private float elapsedTime;
    private float waitTime = 3f;
    //for ending visuals
    public GameObject theSuspect;

    public List<Light> lights;
    public MeshRenderer lamp1;
    public MeshRenderer lamp2;
    public Material lampRed;
    CameraShake camShake;
    [Header("ending")]
    public GameObject turnOffMesh;
    public GameObject Cage;
    public GameObject Wall;
    public GameObject explosionParticles;
    public GameObject glassParticles;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioSource explosionSfx;
    [SerializeField] AudioSource glassBreakSfx;
    [SerializeField] AudioSource rumbleSfx;
    [SerializeField] AudioSource doorSfx;
    [SerializeField] AudioSource doorLongSfx;


    [SerializeField]
    private Vector3 orignalScale;
    [SerializeField]
    private Vector3 bigScale;


    public VilesChange btn1;
    public VilesChange btn2;
    public VilesChange btn3;
    public VilesChange btn4;

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;


    public Vector3 origianlPos1;
    public Vector3 origianlPos2;
    public Vector3 origianlPos3;
    public Vector3 origianlPos4;


    public Vector3 targetlPos1;
    public Vector3 targetlPos2;
    public Vector3 targetlPos3;
    public Vector3 targetlPos4;

    public bool isCorrect;

    public bool doorisDone;


    private void Start()
    {
        orignalScale = theSuspect.transform.localScale;
        bigScale = new Vector3(9f, 9f, 9f);
        camShake = FindObjectOfType<CameraShake>();
        sfx = GetComponent<AudioSource>();



        origianlPos1 = door1.transform.position;
        origianlPos2 = door2.transform.position;
        origianlPos3 = door3.transform.position;
        origianlPos4 = door4.transform.position;

        isCorrect = false;
        doorisDone = true;



    }
    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {

        if (btn1.isCorrect == true && btn2.isCorrect == true && btn3.isCorrect == true && btn4.isCorrect == true)
        {
            isCorrect = true;
            if (doorisDone == true)
            {
                StartCoroutine(doorAnim());
            }
        }
        else
        {
            if (doorisDone == true)
            {
                StartCoroutine(doorAnim());
            }
        }
    }

    public override void OnLoseFocus()
    {

    }


    private IEnumerator makeBig()
    {
        rumbleSfx.Play();
        glassParticles.SetActive(true);
        glassBreakSfx.PlayOneShot(glassBreakSfx.clip);
        Destroy(Cage);
        camShake.StartCoroutine(camShake.Shake(0.3f, 0.1f));


        while (elapsedTime < waitTime)
        {
            theSuspect.transform.localScale = Vector3.Lerp(orignalScale, bigScale, (elapsedTime / waitTime));

            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        theSuspect.transform.localScale = bigScale;
        elapsedTime = 0;
        StartCoroutine(destoryRoute());
    }
    IEnumerator destoryRoute()
    {
        lamp1.materials[0] = lampRed;
        lamp2.materials[0] = lampRed;
        foreach (Light l in lights)
        {
            l.color = Color.red;
            l.range = 10;
            l.intensity = 0.1f;
        }
        yield return new WaitForSeconds(0.2f);
        camShake.StartCoroutine(camShake.Shake(1f, 0.5f));
        Destroy(theSuspect);
        Destroy(turnOffMesh);
        explosionParticles.SetActive(true);
        explosionSfx.PlayOneShot(explosionSfx.clip);
        Destroy(Wall);
        rumbleSfx.Stop();
        this.transform.position = new Vector3(23423423, 45356345, 34543);

    }

    IEnumerator doorAnim()
    {
        
        doorisDone = false;
        doorLongSfx.PlayOneShot(doorLongSfx.clip);
        while (elapsedTime < waitTime)
        {
            

            door1.transform.position = Vector3.Lerp(origianlPos1, targetlPos1, (elapsedTime / waitTime));
            door2.transform.position = Vector3.Lerp(origianlPos2, targetlPos2, (elapsedTime / waitTime));
            door3.transform.position = Vector3.Lerp(origianlPos3, targetlPos3, (elapsedTime / waitTime));
            door4.transform.position = Vector3.Lerp(origianlPos4, targetlPos4, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            // Yield here
            yield return null;


        }
        // Make sure we got there
        door1.transform.position = targetlPos1;
        door2.transform.position = targetlPos2;
        door3.transform.position = targetlPos3;
        door4.transform.position = targetlPos4;
        elapsedTime = 0;

        yield return new WaitForSeconds(1f);
        if (isCorrect == true)
        {
            StartCoroutine(makeBig());
            doorisDone = true;
        }
        else
        {
            doorSfx.PlayOneShot(doorSfx.clip);
            while (elapsedTime < waitTime)
            {
                

                door1.transform.position = Vector3.Lerp(door1.transform.position, origianlPos1, (elapsedTime / waitTime));
                door2.transform.position = Vector3.Lerp(door2.transform.position, origianlPos1, (elapsedTime / waitTime));
                door3.transform.position = Vector3.Lerp(door3.transform.position, origianlPos1, (elapsedTime / waitTime));
                door4.transform.position = Vector3.Lerp(door4.transform.position, origianlPos1, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                // Yield here
                yield return null;


            }
            // Make sure we got there
            door1.transform.position = origianlPos1;
            door2.transform.position = origianlPos2;
            door3.transform.position = origianlPos3;
            door4.transform.position = origianlPos4;
            elapsedTime = 0;
            doorisDone = true;
        }


    }



}