using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Animator Anti;

    public Transform player;

    public Transform AttackPoint;
   // public GameObject AttackSpot;

    public float AttackRange = 2f;

    public float damageTimeout = 1.2f;
    private bool canTakeDamage = true;

    public LayerMask WhatIsGround, WhatIsPlayer;
    //Patroling
    public Vector3 walkPoint;
    public Vector3 hitrange;
    bool walkPointSet;
    public float walkPointRange;

    //Attack
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
       // AttackSpot.SetActive(false);

    }
    private void Update()
    {
        //Checks for player in sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);
        //attackRange = player.position - hitrange;

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange)
        {
            agent.SetDestination(player.position);
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            //transform.rotation *= Quaternion.Euler(0, 90, 0);
            Anti.SetTrigger("Attack");
            StartCoroutine(Attacking());
            agent.stoppingDistance = 3;
        }
        else if(!playerInAttackRange) Anti.SetBool("Attackfalse", true);
        if (Anti.GetBool("Dead?"))
        {
            Anti.ResetTrigger("Search");
            Anti.ResetTrigger("Chase");
            Anti.ResetTrigger("Attack");
            Anti.ResetTrigger("Hurt");
            this.enabled = false;
        }
    }
        private void Patroling()
        {
            Anti.SetTrigger("Search");
        if (!walkPointSet) SearchWalkPoint();

            if (walkPointSet)
                agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //WalkPoint Reached
            if (distanceToWalkPoint.magnitude < 1f)
                walkPointSet = false;
        }
        private void SearchWalkPoint()
        {
            //Calculate Random point in range
            float randomZ = Random.Range(-walkPointRange, walkPointRange);
            float randomX = Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            if (Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround))
                walkPointSet = true;
        }
    private void Attack()
    { 
        Collider[] hitPlayer = Physics.OverlapSphere(AttackPoint.position, AttackRange, WhatIsPlayer);
    
            foreach (Collider player in hitPlayer)
               {
                  //  if (Anti.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
                   // {
                        //StartCoroutine(Attacking());
                        Health.health -= 1;
                //}
              //  }
        }
         
        //Makes Enemy not move
        agent.SetDestination(transform.position);
        //Update();
        void Update()
        {

            transform.LookAt(2 * transform.position - player.position);
        }
    }
    private void ChasePlayer()
    {
        Anti.SetTrigger("Chase");
        agent.SetDestination(player.position);
    }

        private void OnDrawGizmos()
        {
            if (AttackPoint == null)
                return;
            Gizmos.DrawSphere(AttackPoint.position, AttackRange);
        }
        private IEnumerator damageTimer()
        {
            canTakeDamage = false;
            yield return new WaitForSeconds(damageTimeout);
            canTakeDamage = true;
        }
    private IEnumerator Attacking()
    {
        yield return new WaitForSeconds(1.2f);
        Anti.ResetTrigger("Attack");
        Debug.Log("Player Hit!");

    }
}

