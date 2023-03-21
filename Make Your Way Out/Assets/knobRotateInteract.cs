using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knobRotateInteract : interactable
{
    // Start is called before the first frame update
    [SerializeField]
    private Quaternion _from;
    [SerializeField]
    private Quaternion _to;

    public float currentRot = 0;
    public float _nextRot = 45f;


    private float elapsedTime;
    private float waitTime = 0.5f;


    [SerializeField] GameObject jmpscr;
    [SerializeField] private int _jumpScareCounter;
    private bool hasJumped;



    private void Start()
    {
        _from = Quaternion.Euler(currentRot, 0, 0);
        _to = Quaternion.Euler(_nextRot, 0, 0);
        
    }
    private void Update()
    {
        if (_jumpScareCounter == 3 && hasJumped == false)
        {
            StartCoroutine(jumpScare());
            hasJumped = true;
        }
        
    }
    public override void OnFocus()
    {
     

    }

    public override void OnInteract()
    {
        StartCoroutine(rotateObj());

        


    }



    private IEnumerator rotateObj()
    {

        while (elapsedTime < waitTime)
        {
            transform.rotation = Quaternion.Lerp(_from, _to, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;




            // Yield here
            yield return null;



        }
        elapsedTime = 0f;

        if (_nextRot > 360)
        {
            _jumpScareCounter +=1;
            currentRot = 0f;
            _nextRot = 45f;
        }

        currentRot = _nextRot;
        _nextRot = _nextRot + 45;
        _from = Quaternion.Euler(currentRot, 0, 0);
        _to = Quaternion.Euler(_nextRot, 0, 0);
        print("this is current: " + currentRot + " " + "this is next: " + _nextRot);

    }

    IEnumerator jumpScare()
    {
        jmpscr.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Destroy(jmpscr);
    }







    public override void OnLoseFocus()
    {
        
    }
}
