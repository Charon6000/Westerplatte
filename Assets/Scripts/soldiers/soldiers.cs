using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldiers : MonoBehaviour
{
    int exercise;
    Animator anim;
    public float dystans = 50f;
    float odleglosc;
    public GameObject[] kryj;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        exercise = Random.Range(0,3);
        anim.SetFloat("exercise", exercise);
    }

    void Update()
    {
        Znikanie();
    }

    void Znikanie()
    {
        odleglosc = Vector3.Distance(GameObject.FindWithTag("Player").transform.position, transform.position);

        if(odleglosc < dystans && kryj.Length != 0)
        {
            foreach (GameObject item in kryj)
                item.SetActive(true);
        }
        else if(kryj.Length != 0)
        {
            foreach (GameObject item in kryj)
                item.SetActive(false);
        }
    }
}
