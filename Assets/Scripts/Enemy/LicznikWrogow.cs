using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LicznikWrogow : MonoBehaviour
{
    public int numberofenemy = 0;
    public int maxenemy;
    public GameObject kapitan;
    public GameObject Klik;
    bool once = true;
    public GameObject[] zolnierze;

    private void Update() {
        if(numberofenemy >= maxenemy && once)
        {
            Challengemanager.actualProg++;
            GameObject pref = Instantiate(Klik, kapitan.transform.position, kapitan.transform.rotation);
            pref.GetComponent<Kapitan>().kap = kapitan;
            pref.transform.SetParent(kapitan.transform);
            pref.transform.name = "KapitanKlik";
            once = false;
            if(transform.name == "Wrogowie")
            {
                foreach(GameObject x in zolnierze)
                {
                x.GetComponent<towarzysz>().pkt = new Vector3(Random.Range(1016, 1030), 100, Random.Range(580, 605));
                x.GetComponent<towarzysz>().zmien = true;
                x.GetComponent<Animator>().SetBool("strzelaj", false);
                }
            }
        }
    }
}
