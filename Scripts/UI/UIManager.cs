using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Animator ui;
    public GameObject celownik;
    static public bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel") && !change)
        {
            change = true;
        }
        else if(Input.GetButtonDown("Cancel") && change)
        {
            change = false;
        }

        if(!change)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ui.SetBool("change", false);
            celownik.SetActive(true);
        }
        else if(change)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            ui.SetBool("change", true);
            celownik.SetActive(false);
        }
    }

    public void Resume()
    {
        change = false;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
