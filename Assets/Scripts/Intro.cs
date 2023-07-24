using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Animator anim;
    public int scenenumber;
    public Text[] timer;

    public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Ex", 148f);
        Invoke("Next", 149f);
        time = 149f;
    }

    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Ex();
            Invoke("Next", 1f);
        }

        time-=Time.deltaTime;
        timer[0].text = Mathf.Round(time).ToString();
        timer[1].text = Mathf.Round(time).ToString();
    }

    void Next()
    {
        SceneManager.LoadScene(scenenumber);
    }

    void Ex(){
        anim.SetTrigger("exit");
    }
}
