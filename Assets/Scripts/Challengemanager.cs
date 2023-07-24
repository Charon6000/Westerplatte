using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Challengemanager : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public Animator anim;
    public class Challenge
    {
        public string nazwa;
        public int numer;

        public Challenge(int nr, string name)
        {
            nazwa = name;
            nazwa = name;
        }
    }

    List<Challenge> challenges;
    public Text chelltxt;
    static public int actualProg = 0;
    public GameObject[] points;

    private void Start() {
        challenges = new List<Challenge>();
        challenges.Add(new Challenge(0, "Udaj sie do Majora Henryka Sucharskiego"));
        challenges.Add(new Challenge(1, "Wlacz Działo"));
        challenges.Add(new Challenge(2, "Udaj sie do Majora"));
        challenges.Add(new Challenge(3, "Udaj sie do Kapitana Dabrowskiego"));
        challenges.Add(new Challenge(4, "Pokonaj nazistow"));
        challenges.Add(new Challenge(5, "Udaj sie do Majora"));
        challenges.Add(new Challenge(6, "Udaj sie do Kapitana na torach kolejowych"));
        challenges.Add(new Challenge(7, "Pokonaj nazistow na torach"));
        challenges.Add(new Challenge(8, "Udaj sie do Majora"));
        challenges.Add(new Challenge(9, "Idz spac"));
        challenges.Add(new Challenge(10, "Odepszyj natarcia wroga z lasu"));
        challenges.Add(new Challenge(11, "Wroc do Majora"));
        challenges.Add(new Challenge(12, "Dzieki za gre"));
    }

    private void Update()
    {
        for(int i = 0; i < challenges.Count -1; i++)
        {
            if(actualProg == i)
            {
            chelltxt.text = challenges[i].nazwa;
            }
            points[i].SetActive(false);
        }
        points[actualProg].SetActive(true);

        if(actualProg == 9)
        {
            anim.SetTrigger("exit");
            Invoke("Ex", 1f);
        }
    }

    void Ex()
    {
        SceneManager.LoadScene("Napisy");
    }
}
