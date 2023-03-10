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


    private void Start()
    {
        _from = Quaternion.Euler(currentRot, 0, 0);
        _to = Quaternion.Euler(_nextRot, 0, 0);
        
    }
    private void Update()
    {
        
        
    }
    public override void OnFocus()
    {
     

    }

    public override void OnInteract()
    {
        this.transform.rotation = Quaternion.Slerp(_from, _to, 1f);

        if(currentRot > 360)
        {
            currentRot = 0f;
            _nextRot = 45f;
        }

        currentRot = _nextRot;
        _nextRot = _nextRot + 45;
        _from = Quaternion.Euler(currentRot, 0, 0);
        _to = Quaternion.Euler(_nextRot, 0, 0);

    }

    public override void OnLoseFocus()
    {
        
    }
}
