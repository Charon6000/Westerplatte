using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    private void OnCollisionEnter(Collider other) {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<Movement>().hp--;
        }
    }
}
