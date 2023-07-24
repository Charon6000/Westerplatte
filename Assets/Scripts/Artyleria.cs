using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artyleria : MonoBehaviour
{
    public GameObject kapitan;
    public GameObject Klik;
    public bool shooting = false;
    public bool once = false;
    public GameObject rocket;
    public GameObject point;
    public GameObject baltowski;

    void Update()
    {
        if(!once && shooting && transform.name != "Klik")
        {
            var rock = Instantiate(rocket, point.transform.position, point.transform.rotation);
            once = true;
        }
        else if(!once && shooting && transform.name == "Klik")
        {
            var rock = Instantiate(rocket, point.transform.position, point.transform.rotation);
            Megaphones.PlayNuke = false;
            Challengemanager.actualProg++;
            once = true;
            GameObject pref = Instantiate(Klik, kapitan.transform.position, kapitan.transform.rotation);
            pref.GetComponent<Kapitan>().kap = kapitan;
            pref.transform.SetParent(kapitan.transform);
            pref.transform.name = "KapitanKlik";
            baltowski.GetComponent<towarzysz>().pkt = transform.position;
            baltowski.GetComponent<towarzysz>().zmien = true;
        }
    }

    public void Zacznij()
    {
        if(!shooting)
        {
            shooting = true;
        }
    }
}
