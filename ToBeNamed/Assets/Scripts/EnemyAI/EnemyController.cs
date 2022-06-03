using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator enemyAnimation;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    bool isWalking;
    //Attacking
    public float timeBetweenAttack;
    bool alreadyAttacked;

    //State
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
            enemyAnimation.SetBool("isWalking", true);
            enemyAnimation.SetBool("isRunning", false);
            enemyAnimation.SetBool("isAttacking", false);
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
            enemyAnimation.SetBool("isWalking", false);
            enemyAnimation.SetBool("isRunning", true);
            enemyAnimation.SetBool("isAttacking", false);
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
            enemyAnimation.SetBool("isWalking", false);
            enemyAnimation.SetBool("isRunning", true);
            enemyAnimation.SetBool("isAttacking", true);
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //walkPoint Reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);


        if (!alreadyAttacked)
        {
            //Attack Code Here
            //^^

            alreadyAttacked = true;
           
            Invoke(nameof(ResetAttack), timeBetweenAttack);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
