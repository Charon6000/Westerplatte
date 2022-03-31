using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float bulletspeed = 10f;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.transform.tag == "Player")
        {
            other.GetComponent<Movement>().hp--;
            Destroy(this.gameObject);
        }
    }

    private void Start() 
    {
        Destroy(this.gameObject, 3f);
    }

    private void Update() 
    {
        transform.Translate(0,0,bulletspeed*Time.deltaTime);
    }
}
