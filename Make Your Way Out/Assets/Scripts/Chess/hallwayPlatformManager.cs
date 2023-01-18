using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hallwayPlatformManager : MonoBehaviour
{
   [SerializeField] private List<Rigidbody> platforms;

    public void makeThemFall()
    {
        foreach (Rigidbody i in platforms)
        {
            i.isKinematic = false;
        }
    }
}
