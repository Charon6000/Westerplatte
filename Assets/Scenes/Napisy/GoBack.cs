using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim.SetTrigger("exit");
        Invoke("Goback", 25f);
    }

    void Goback()
    {
        SceneManager.LoadScene(0);
    }
}
