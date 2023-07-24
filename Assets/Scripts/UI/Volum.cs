using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.UI;

public class Volum : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.name == "vol")
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("volume");
        else if(transform.name == "dpi")
        GetComponent<Slider>().value = PlayerPrefs.GetFloat("dpi");
        else
        GetComponent<Slider>().value = player.GetComponent<Movement>().hp;
    }

    public void Volume()
    {
        float x = this.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("volume", x);
    }

    public void DPI()
    {
        float x = this.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("dpi", x);
    }

    private void Update() 
    {
        if(transform.name == "Hp")
        GetComponent<Slider>().value = player.GetComponent<Movement>().hp;

        if(transform.name == "audio")
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("volume");
    }
}
