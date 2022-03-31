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

    private void Update() {
        if(numberofenemy >= maxenemy && once)
        {
            Challengemanager.actualProg++;
            GameObject pref = Instantiate(Klik, kapitan.transform.position, kapitan.transform.rotation);
            pref.GetComponent<Kapitan>().kap = kapitan;
            pref.transform.SetParent(kapitan.transform);
            pref.transform.name = "KapitanKlik";
            once = false;
        }
    }
}
