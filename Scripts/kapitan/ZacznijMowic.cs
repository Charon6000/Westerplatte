using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZacznijMowic : MonoBehaviour
{
    public GameObject audio;
    public GameObject player;
    public Animator anim;
    public Text[] Dialtxt;

    public string[] zero;
    public string[] dwa;
    public string[] trzy;
    public string[] piec;
    public string[] szesc;
    public string[] osiem;

    private void Start() 
    {
        anim = GetComponent<Animator>();
    }

    public void czekaj()
    {
        switch (Challengemanager.actualProg)
        {
            case 0:
            StartCoroutine(pierwszyS());
            break;

            case 2:
            StartCoroutine(dwaS());
            break;

            case 3:
            StartCoroutine(trzyS());
            break;

            case 5:
            StartCoroutine(piecS());
            break;

            case 6:
            StartCoroutine(szescS());
            break;

            case 8:
            StartCoroutine(osiemS());
            break;

            default:
            Dialtxt[0].text = " ";
            Dialtxt[1].text = " ";
            break;
        }
    }

    public IEnumerator pierwszyS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = zero[0];
        Dialtxt[1].text = zero[0];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = zero[1];
        Dialtxt[1].text = zero[1];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }

    public IEnumerator dwaS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = dwa[0];
        Dialtxt[1].text = dwa[0];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = dwa[1];
        Dialtxt[1].text = dwa[1];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }

    public IEnumerator trzyS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = trzy[0];
        Dialtxt[1].text = trzy[0];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = trzy[1];
        Dialtxt[1].text = trzy[1];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }

    public IEnumerator piecS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = piec[0];
        Dialtxt[1].text = piec[0];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = piec[1];
        Dialtxt[1].text = piec[1];
        yield return new WaitForSeconds(7f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }

    public IEnumerator szescS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = szesc[0];
        Dialtxt[1].text = szesc[0];
        yield return new WaitForSeconds(5f);
        player.GetComponent<Movement>().hp = 30;
        Dialtxt[0].text = szesc[1];
        Dialtxt[1].text = szesc[1];
        yield return new WaitForSeconds(3f);
        Dialtxt[0].text = szesc[2];
        Dialtxt[1].text = szesc[2];
        yield return new WaitForSeconds(9f);
        Dialtxt[0].text = szesc[3];
        Dialtxt[1].text = szesc[3];
        yield return new WaitForSeconds(9f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }

    public IEnumerator osiemS()
    {
        audio.GetComponent<AudioSource>().volume /= 2;
        anim.SetBool("mow", true);
        Dialtxt[0].text = osiem[0];
        Dialtxt[1].text = osiem[0];
        yield return new WaitForSeconds(9f);
        Dialtxt[0].text = osiem[1];
        Dialtxt[1].text = osiem[1];
        yield return new WaitForSeconds(9f);
        Dialtxt[0].text = " ";
        Dialtxt[1].text = " ";
        anim.SetBool("mow", false);
        Challengemanager.actualProg++;
        audio.GetComponent<AudioSource>().volume *= 2;
    }
}
