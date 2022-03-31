using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kapitan : MonoBehaviour
{
    public GameObject kap;

    public void Zacznij()
    {
        kap.GetComponent<ZacznijMowic>().czekaj();
    }
}
