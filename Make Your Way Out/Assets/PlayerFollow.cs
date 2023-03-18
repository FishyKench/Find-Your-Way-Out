
using UnityEngine;
using UnityEngine.AI;
public class PlayerFollow : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    private RaycastHit hit;

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

    private void Awake()
    {
        //player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);


            if (!playerInSightRange) Patroling();
            if (playerInSightRange) ChasePlayer();
        }
    }

    private void Patroling()
    {
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

        if (Physics.Raycast(walkPoint, -transform.up, out hit, 2, whatIsGround))
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

    }
    private void Destroyy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
