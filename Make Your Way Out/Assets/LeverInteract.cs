using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteract : interactable
{


    public bool _isOff;
    [SerializeField]
    private Quaternion _offPos;
    [SerializeField]
    private Quaternion _onPos;

    private float elapsedTime;
    private float waitTime = 0.5f;

    private AudioSource sfx;

    void Start()
    {
        _isOff = true;
        sfx = GetComponent<AudioSource>();
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
        sfx.PlayOneShot(sfx.clip);
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
                    transform.localRotation = Quaternion.Lerp(_offPos, _onPos, (elapsedTime / waitTime));
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
                transform.localRotation = Quaternion.Lerp(_onPos, _offPos, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;
                // Yield here
                yield return null;
                _isOff = true;
            }
            elapsedTime = 0f;
        }

        

    }


}