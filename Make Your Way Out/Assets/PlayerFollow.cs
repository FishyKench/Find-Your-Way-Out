using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerFollow : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //States
    public bool isDead;
    public float sightRange;
    public bool playerInSightRange;

    [SerializeField] AudioSource rumble;
    bool rumblePlayed = false;



    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 9;
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);


            if (!playerInSightRange) Patroling();
            if (playerInSightRange) checkIfPlayerBehindWall();
            //if (playerInSightRange) ChasePlayer();
        }
    }

    void checkIfPlayerBehindWall()
    {
        if (playerInSightRange)
        {
            Physics.Raycast(transform.position, -(transform.position - player.transform.position), out RaycastHit checkwallHit);
            Debug.DrawLine(transform.position, checkwallHit.point, Color.red);

            //print(checkwallHit.transform.gameObject.name);
            if (checkwallHit.transform.gameObject.CompareTag("Player"))
            {
                ChasePlayer();
                agent.speed = 11;
            }
            else
            {
                Patroling();
                agent.speed = 9;
            }


        }
    }
    private void Patroling()
    {
        rumble.Stop();
        rumblePlayed = false;

        if (isDead) return;

        if (!walkPointSet) SearchWalkPoint();

        //Calculate direction and walk to Point
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);

        }

        //Calculates DistanceToWalkPoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, out RaycastHit hit, 2, whatIsGround))
        {
            if (hit.transform.gameObject.name == "hall2Floor")
            {
                walkPointSet = true;
                //print(hit.transform.gameObject.name);
            }
        }
    }
    private void ChasePlayer()
    {
        if (isDead) return;

        agent.SetDestination(player.position);

        if (rumblePlayed == false)
        {
            rumble.Play();
            rumblePlayed = true;
        }

    }
    private void Destroyy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
        //Gizmos.DrawLine(wallchecker.position, player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            
            Scene Scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(Scene.name);

   
        }
    }

}
