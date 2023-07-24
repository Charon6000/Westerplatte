using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public GameObject min_point;
    public AudioSource audio;
    public GameObject licznik;
    bool dead = false;
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 walkPoint;
    bool walkPointSet = true;
    public float walkPointRange;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public float timebetweenAttack;
    public bool alreadyAttacked;
    public int hp = 5;
    Animator anim;
    public GameObject pocisk;
    public float bulletspeed;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }
    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        DeadCheck();
        if(!dead) 
        {
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if(!playerInAttackRange && !playerInSightRange)
            Patroling();
            if(playerInSightRange && !playerInAttackRange)
            ChasePlayer();
            else if(playerInSightRange && playerInAttackRange)
            AttackPlayer();
        }
    }

    public void Patroling()
    {
        // if(!walkPointSet)
        // SearchWalkPoint();

        // if(walkPointSet)
        // agent.SetDestination(walkPoint);

        // Vector3 distanceToWalkPoint = transform.position - walkPoint;

        // if(distanceToWalkPoint.magnitude < 1f)
        // walkPointSet = false;
        anim.SetBool("firing", false);
        anim.SetBool("dead", false);
        anim.SetBool("bieg", false);
    }

    // void SearchWalkPoint()
    // {
    //     float randomZ = Random.Range(-walkPointRange, walkPointRange);
    //     float randomX = Random.Range(-walkPointRange, walkPointRange);

    //     walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
    //     if(Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
    //     walkPointSet = true;
    // }
    public void ChasePlayer()
    {
        anim.SetBool("firing", false);
        anim.SetBool("dead", false);
        anim.SetBool("bieg", true);
        agent.SetDestination(player.position);
    }
    public void AttackPlayer()
    {
        anim.SetBool("firing", true);
        anim.SetBool("dead", false);
        anim.SetBool("bieg", false);
        agent.SetDestination(transform.position);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));

        if(!alreadyAttacked)
        {
            Instantiate(pocisk, new Vector3(transform.position.x, transform.position.y + 1f,transform.position.z), transform.rotation);
            audio.Play();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttackTimer), timebetweenAttack);
        }
    }

    void ResetAttackTimer()
    {
        alreadyAttacked = false;
    }

    public void DeadCheck()
    {
        if(hp <= 0)
        {
            anim.SetBool("firing", false);
            anim.SetBool("dead", true);
            anim.SetBool("bieg", false);
            GetComponent<BoxCollider>().enabled = false;
            if(!dead)
            licznik.GetComponent<LicznikWrogow>().numberofenemy++;
            agent.SetDestination(transform.position);
            min_point.SetActive(false);
            dead = true;
        }
    }
}
