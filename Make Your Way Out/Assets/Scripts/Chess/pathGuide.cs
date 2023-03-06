using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathGuide : MonoBehaviour
{
    [SerializeField] Transform pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8, pos9, pos10;
    [SerializeField] float speed;
    [SerializeField] Transform startPos;
    public bool solution = false;

    Vector3 nextPos;
    private void Start()
    {
        nextPos = startPos.position;
    }
    private void Update()
    {
        if(solution == true)
        {

        if (transform.position == pos1.position)
        {
            nextPos = pos2.position;
        }
        if (transform.position == pos2.position) 
            nextPos = pos3.position;
        if (transform.position == pos3.position)
            nextPos = pos4.position;
        if (transform.position == pos4.position)
            nextPos = pos5.position;
        if (transform.position == pos5.position)
            nextPos = pos6.position;
        if (transform.position == pos6.position)
            nextPos = pos7.position;
        if (transform.position == pos7.position)
            nextPos = pos8.position;
        if (transform.position == pos8.position)
            nextPos = pos9.position;
        if (transform.position == pos9.position)
            nextPos = pos10.position;
        if (transform.position == pos10.position)
        {
            GetComponent<TrailRenderer>().Clear();
            transform.position = pos1.position;
            GetComponent<TrailRenderer>().Clear();
            nextPos = pos2.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position,pos2.position);
        Gizmos.DrawLine(pos2.position,pos3.position);
        Gizmos.DrawLine(pos3.position,pos4.position);
        Gizmos.DrawLine(pos4.position,pos5.position);
        Gizmos.DrawLine(pos5.position,pos6.position);
        Gizmos.DrawLine(pos6.position,pos7.position);
        Gizmos.DrawLine(pos7.position,pos8.position);
        Gizmos.DrawLine(pos8.position,pos9.position);
        Gizmos.DrawLine(pos9.position,pos10.position);
    }
}
