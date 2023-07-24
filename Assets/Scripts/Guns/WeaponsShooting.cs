using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsShooting : MonoBehaviour
{
    public GameObject Player;
    public GameObject shoteffect;
    public Transform karabinpoint;
    public Transform shotgunpoint;
    public Transform rewolwerpoint;
    public GameObject bullet_hole;
    RaycastHit hit;
    Ray ray;
    public Camera camera;
    public GameObject cam;

    [Header("CrosshairSpread")]
    int shotspead = 100;
    int rewspead = 50;
    int karspead = 60;
    static public int chodspread = 4;
    static public int biegspread = 7;

    [Header("ShootingSpread")]
    Vector3 randSSpread;
    Vector2 offset;

    [Header("Sounds")]
        public AudioClip rewShot;
        public AudioClip shotShot;
        public AudioClip karShot;
        AudioSource audio;

    private void Start() 
    {
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate() 
    {
        offset = Random.insideUnitCircle * DynamicCrossHair.spread;
        randSSpread = new Vector3(Screen.width/2 + offset.x, Screen.height/2, 0 + offset.y);
        ray = camera.ScreenPointToRay(randSSpread);
    }

    public void Rewolwer()
    {
        Player.GetComponent<Movement>().ammorew--;
        GameObject a = Instantiate(shoteffect, rewolwerpoint.position, rewolwerpoint.rotation);
        a.transform.SetParent(this.transform);
        audio.PlayOneShot(rewShot);

        if(Physics.Raycast(ray, out hit))
        {
           Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
           Movement.recoil += 4;

           if(hit.transform.tag == "Enemy")
            {
                if(hit.transform.name[0] == 'N')
                hit.transform.GetComponent<AIEnemy>().hp-=2;
                else
                hit.transform.GetComponent<PodpalaczeAI>().hp-=2;
            }
        }

        if(DynamicCrossHair.spread <= 135)
           DynamicCrossHair.spread += rewspead;
    }

    public void Karabin()
    {
        Player.GetComponent<Movement>().ammokar--;
        GameObject a = Instantiate(shoteffect, shotgunpoint.position, shotgunpoint.rotation);
        a.transform.SetParent(this.transform);
        audio.PlayOneShot(karShot);
        if(Physics.Raycast(ray, out hit))
        {
            Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Movement.recoil += 2;

            if(hit.transform.tag == "Enemy")
            {
                if(hit.transform.name[0] == 'N')
                hit.transform.GetComponent<AIEnemy>().hp--;
                else
                hit.transform.GetComponent<PodpalaczeAI>().hp--;
            }
        }
        if(DynamicCrossHair.spread <= 135)
            DynamicCrossHair.spread += karspead;
    }

    public void Shotgun()
    {
        Player.GetComponent<Movement>().ammoshot--;
        GameObject a = Instantiate(shoteffect, karabinpoint.position, Quaternion.identity);
        a.transform.SetParent(this.transform);
        audio.PlayOneShot(shotShot);
        if(Physics.Raycast(ray, out hit))
        {
            Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            Movement.recoil += 5;

            if(hit.transform.tag == "Enemy")
            {
                if(hit.transform.name[0] == 'N')
                hit.transform.GetComponent<AIEnemy>().hp-=3;
                else
                hit.transform.GetComponent<PodpalaczeAI>().hp-=3;
            }
        }
        
        if(DynamicCrossHair.spread <= 200)
            DynamicCrossHair.spread += shotspead;
    }
}
