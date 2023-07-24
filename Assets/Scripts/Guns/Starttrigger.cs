using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starttrigger : MonoBehaviour
{
    public GameObject napis;
    public Camera camera;
    RaycastHit hit;
    Ray ray;
    Vector3 randSSpread;
    public float odleglosc = 10f;
    void Update()
    {
        randSSpread = new Vector3(Screen.width/2, Screen.height/2, 0);
        ray = camera.ScreenPointToRay(randSSpread);

        if(Physics.Raycast(ray, out hit, odleglosc))
        {
            if(hit.transform.name == "Klik" && Input.GetButtonDown("Click"))
            {
                hit.transform.GetComponent<Artyleria>().Zacznij();
                Destroy(hit.transform.gameObject,0.5f);
            }
            else if(hit.transform.name == "KapitanKlik" && Input.GetButtonDown("Click"))
            {
                hit.transform.GetComponent<Kapitan>().Zacznij();

                Destroy(hit.transform.gameObject,0.5f);
            }
            

            if(hit.transform.CompareTag("Click"))
            {
                napis.SetActive(true);
            }
            else
            {
                napis.SetActive(false);
            }
        }
        else
        {
            napis.SetActive(false);
        }
    }
}
