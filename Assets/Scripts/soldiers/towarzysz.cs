using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class towarzysz : MonoBehaviour
{
    public bool towarzyszy = false;
    GameObject player;
    public NavMeshAgent agent;
    float odleglosc;
    public float dystans = 5f;
    public Animator anim;
    public Vector3 pl;
    public Vector3 pkt;
    public Vector3 wybrany;
    public bool zmien = false;
    public bool inSide = false;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update() 
    {
        pl = player.transform.position;

        if(!zmien)
        wybrany = pl;
        else
        wybrany = pkt;

        odleglosc = Vector3.Distance(wybrany, transform.position);

            if(towarzyszy && odleglosc >= dystans)
            {
                agent.SetDestination(wybrany);
                anim.SetBool("ruch", true);
                anim.SetBool("stay", false);
            }
            else if(towarzyszy && !anim.GetBool("strzelaj"))
            {
                anim.SetBool("ruch", false);
                anim.SetBool("stay", true);
            }
            else if(towarzyszy && anim.GetBool("strzelaj"))
            {
                anim.SetBool("ruch", false);
                anim.SetBool("stay", false);
                anim.SetBool("strzelaj", true);
            }
        }

        // private void OnTriggerEnter(Collider other) {
        //     if(other.name == "setShoot")
        //     {
        //         anim.SetBool("strzelaj", true);
        //     }
        // }

        // private void OnTriggerExit(Collider other) {
        //     if(other.name == "setShoot")
        //     {
        //         anim.SetBool("strzelaj", false);
        //     }
        // }
}
