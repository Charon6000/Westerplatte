using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PodpalaczeAI : MonoBehaviour
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

    public int hp = 5;
    Animator anim;
    public GameObject flame;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        audio = GetComponent<AudioSource>();
    }
    private void Start() {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        else
        flame.SetActive(false);
    }

    public void Patroling()
    {
        anim.SetBool("dead", false);
        anim.SetBool("run", false);
        flame.SetActive(true);
    }

    public void ChasePlayer()
    {
        anim.SetBool("dead", false);
        anim.SetBool("run", true);
        agent.SetDestination(player.position);
        flame.SetActive(false);
    }

    public void AttackPlayer()
    {
        anim.SetBool("dead", false);
        anim.SetBool("run", false);
        agent.SetDestination(transform.position);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        flame.SetActive(true);
    }

    public void DeadCheck()
    {
        if(hp <= 0)
        {
            anim.SetBool("dead", true);
            anim.SetBool("run", false);
            GetComponent<BoxCollider>().enabled = false;
            if(!dead)
            licznik.GetComponent<LicznikWrogow>().numberofenemy++;
            min_point.SetActive(false);
            dead = true;
            flame.SetActive(false);
        }
    }
}
