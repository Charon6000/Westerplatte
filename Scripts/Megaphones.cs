using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaphones : MonoBehaviour
{
    static public bool PlayNuke = true;
    private void Start() {
        PlayNuke = true;
    }

    private void Update() 
    {
        if(!PlayNuke)
        GetComponent<AudioSource>().Stop();
    }
}
