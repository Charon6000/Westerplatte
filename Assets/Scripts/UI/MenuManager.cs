using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator anim;
    public GameObject Option;
    public GameObject Games;
    public GameObject Welcome;
    public GameObject how;

    void Start()
    {
        Games.SetActive(false);
        Option.SetActive(false);
        Welcome.SetActive(true);
        how.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Play()
    {
        Games.SetActive(true);
        Option.SetActive(false);
        Welcome.SetActive(false);
        how.SetActive(false);
    }

    public void NewGame()
    {
        Games.SetActive(false);
        Option.SetActive(false);
        Welcome.SetActive(false);
        how.SetActive(true);
    }

    public void Options()
    {
        Games.SetActive(false);
        Option.SetActive(true);
        Welcome.SetActive(false);
        how.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void first()
    {
        anim.SetTrigger("exit");
        Invoke("Ex", 1f);
    }

    void Ex()
    {
        SceneManager.LoadScene(1);
    }

    public void second()
    {
        SceneManager.LoadScene(1);
    }

    public void third()
    {
        SceneManager.LoadScene(1);
    }

    public void fourth()
    {
        SceneManager.LoadScene(1);
    }

    public void fifth()
    {
        SceneManager.LoadScene(1);
    }

    public void sixth()
    {
        SceneManager.LoadScene(1);
    }

    public void seventh()
    {
        SceneManager.LoadScene(1);
    }
}
