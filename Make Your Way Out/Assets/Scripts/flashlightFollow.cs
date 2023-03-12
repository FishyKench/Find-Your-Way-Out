using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightFollow : MonoBehaviour
{
    [Header("Rotation")]
    [SerializeField] float snapbackSpeed;
    [SerializeField] float snapbackDelay;
    [Space(15)]

    [Header("Sway")]
    [SerializeField] float swayMultiplier;
    [SerializeField] float smooth;
    [Space(15)]

    [SerializeField] Transform flPosition;

    private void FixedUpdate()
    {
        transform.position = flPosition.position;
    }
    private void Update()
    {


        sway();                          //make visual sway with movement for a better visual
        StartCoroutine(rotate());        //make it lag behind a lil bit for spooky
    }


    IEnumerator rotate()
    {
        yield return new WaitForSeconds(snapbackDelay);

        float time = 0;
        float duration = snapbackSpeed;

        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Slerp(startValue, flPosition.rotation, time / duration);

            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = flPosition.rotation;
    }
    void sway()
    {
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * swayMultiplier;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayMultiplier;

        //calculate target rotation
        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        //rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
    }
}