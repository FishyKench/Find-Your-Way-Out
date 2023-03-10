using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : interactable
{


    private bool _isOff;

    private Quaternion _offPos;
    private Quaternion _onPos;

    private float elapsedTime;
    private float waitTime = 0.5f;

    void Start()
    {

        _offPos = Quaternion.Euler(315, 90, -90);
        _onPos = Quaternion.Euler(229, 90, -90);

        _isOff = true;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnFocus()
    {

    }

    public override void OnInteract()
    {
        StartCoroutine(rotateLever());
    }

    public override void OnLoseFocus()
    {

    }


    private IEnumerator rotateLever()
    {

        if(_isOff == true)
        {
            while (elapsedTime < waitTime)
            {
                    transform.rotation = Quaternion.Lerp(_offPos, _onPos, (elapsedTime / waitTime));
                    elapsedTime += Time.deltaTime;
                    // Yield here
                    yield return null;
                    _isOff = false;
            }
            elapsedTime = 0f;
        }

        else
        {
            while (elapsedTime < waitTime)
            {
                transform.rotation = Quaternion.Lerp(_onPos, _offPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                // Yield here
                yield return null;
                _isOff = true;
            }
            elapsedTime = 0f;
        }

        

    }


}