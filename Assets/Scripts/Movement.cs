using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    static public int recoil = 0;
    public int hp = 30;
    [Header("Amunicja")]
    public Text[] ammoText;
    public Text[] MaxammoText;
    [HideInInspector] public int ammorew = 7;
    int ammoMaxrew = 7;
    [HideInInspector] public int ammoshot = 6;
    int ammoMaxshot = 6;
    [HideInInspector] public int ammokar = 30;
    int ammoMaxkar = 30;

    [Header("Napisy broni")]
    public Text[] karabin;
    public Text[] shotgun;
    public Text[] rewolwer;

    [Header("Movement")]
    public float speed;
    public float speeder;
    public bool kuca = false;
    private enum State {brak,lewo,prawo}
    State pochylenie;
    public float gravity = -9.81f;
    public float jumpspeed = 3f;
    //Rigidbody rb;
    CharacterController controller;
    bool festBoi;
    Vector3 velocity;
    bool chod = false;

    [Header("Camera")]
    public float cameraSpeed;
    float verticalRotation;
    float horizontalRotation;
    public GameObject camera;

    [Header("Animations")]
    public Animator rece;
    private enum Guns {brak, shotgun, rewolwer, karabin}
    Guns Bron;
    int scroll = 1;

    public Animator skip;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pochylenie = State.brak;
    }

    private void FixedUpdate()
    {
        if(!UIManager.change)
        CameraRotation();
    }

    private void Update()
    {
        DeadCheck();
        Move();
        Kucanie();
        //PochylSie();
        if(!UIManager.change)
        Shoot();
        
        ZmianaBroni();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(z != 0 || x != 0)
        {
            rece.SetBool("chod", true);

            if(!festBoi && DynamicCrossHair.spread <= 100)
            {
                DynamicCrossHair.spread += WeaponsShooting.chodspread;
            }
        }
        else
        {
            rece.SetBool("chod", false);
        }

        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Speed") && Input.GetKey(KeyCode.W))
        {
            festBoi = true;
            rece.SetBool("bieg", true);
            speed *= speeder;
        }
        else if(Input.GetButtonUp("Speed") && festBoi == true|| Input.GetKeyUp(KeyCode.W) && festBoi == true)
        {
            festBoi = false;
            rece.SetBool("bieg", false);
            speed /= speeder;
        }

        if(festBoi == true && DynamicCrossHair.spread <= 200)
        DynamicCrossHair.spread += WeaponsShooting.biegspread;

        controller.Move(move * speed * Time.deltaTime);
    }

    void Kucanie()
    {
        if(!Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.up) * 0.1f))
        {
            if(!Physics.Raycast(transform.position, Vector3.up))
            {
                if(Input.GetButtonDown("Kucanie") && !kuca)
                {
                    controller.height = 1;
                    controller.center = new Vector3(controller.center.x, -.5f, controller.center.z);
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - .5f, camera.transform.position.z);
                    kuca = true;

                    if(festBoi)
                    {
                        festBoi = false;
                        rece.SetBool("bieg", false);
                        speed /= speeder;
                    }
                }
                else if(Input.GetButtonDown("Kucanie") && kuca || Input.GetButtonDown("Speed") && kuca)
                {
                    controller.height = 2;
                    controller.center = new Vector3(controller.center.x, 0, controller.center.z);
                    camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y + .5f, camera.transform.position.z);
                    kuca = false;
                }
            }
        }
    }

    void CameraRotation()
    {
        cameraSpeed = PlayerPrefs.GetFloat("dpi") * 10;
        horizontalRotation += (Input.GetAxis("Mouse X") * cameraSpeed);
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, horizontalRotation, transform.localRotation.z);
        verticalRotation -= (Input.GetAxis("Mouse Y") * cameraSpeed);
        verticalRotation = Mathf.Clamp(verticalRotation, -90f + recoil, 60f + recoil);
        camera.transform.localRotation = Quaternion.Euler(verticalRotation - recoil, camera.transform.localRotation.y, camera.transform.localRotation.z);
    }

    void PochylSie()
    {
        if(Input.GetButtonDown("Prawo") && pochylenie != State.prawo)
        {
            pochylenie = State.prawo;
            
        }
        else if(Input.GetButtonDown("Prawo") && pochylenie == State.prawo)
        {
            pochylenie = State.brak;
        }

        if(Input.GetButtonDown("Lewo") && pochylenie != State.lewo)
        {
            pochylenie = State.lewo;
        }
        else if(Input.GetButtonDown("Lewo") && pochylenie == State.lewo)
        {
            pochylenie = State.brak;
        }

        switch(pochylenie)
        {
            case State.brak:
                camera.transform.localRotation = Quaternion.Euler(verticalRotation, camera.transform.localRotation.y, 0);
                break;

            case State.prawo:
                camera.transform.localRotation = Quaternion.Euler(verticalRotation, camera.transform.localRotation.y, -15);
                break;
            
            case State.lewo:
                camera.transform.localRotation = Quaternion.Euler(verticalRotation, camera.transform.localRotation.y, 15);
                break;
        }
    }

    void Shoot()
    {
            if(Bron == Guns.rewolwer && ammorew <= ammoMaxrew && Input.GetButtonDown("Reload") && !festBoi || Bron == Guns.rewolwer && ammorew <= 0 && Input.GetButtonDown("Shoot") && !festBoi)
            {
                StartCoroutine(Reload(1f));
            }
            else if(Bron == Guns.shotgun && ammoshot <= ammoMaxshot && Input.GetButtonDown("Reload") && !festBoi || Bron == Guns.shotgun && ammoshot <= 0 && Input.GetButtonDown("Shoot") && !festBoi)
            {
                StartCoroutine(Reload(2f));
            }
            else if(Bron == Guns.karabin && ammokar <= ammoMaxkar && Input.GetButtonDown("Reload") && !festBoi || Bron == Guns.karabin && ammokar <= 0 && Input.GetButtonDown("Shoot") && !festBoi)
            {
                StartCoroutine(Reload(3f));
            }

        if(Input.GetButtonDown("Shoot") && Bron == Guns.rewolwer || Input.GetButtonDown("Shoot") && Bron == Guns.shotgun)
        {
            if(festBoi)
            {
                festBoi = false;
                rece.SetBool("bieg", false);
                speed /= speeder;
            }

            // if(Bron == Guns.rewolwer)
            // ammorew--;
            // else
            // ammoshot--;
            if(Bron == Guns.rewolwer && ammorew > 0)
            rece.SetTrigger("Shoot");
            else if(Bron == Guns.shotgun && ammoshot > 0)
            rece.SetTrigger("Shoot");
        }
        else if(Input.GetButton("Shoot") && Bron == Guns.karabin)
        {
            if(festBoi)
            {
                festBoi = false;
                rece.SetBool("bieg", false);
                speed /= speeder;
            }

            if(Bron == Guns.karabin && ammokar > 0)
            rece.SetBool("ShootAuto", true);
            else
            rece.SetBool("ShootAuto", false);
        }
        else if(Input.GetButtonUp("Shoot") && Bron == Guns.karabin || Bron != Guns.karabin)
        {
            rece.SetBool("ShootAuto", false);
        }
    }

    void ZmianaBroni()
    {
        switch(Bron)
        {
            case Guns.shotgun:
            ammoText[0].text = ammoshot.ToString();
            ammoText[1].text = ammoshot.ToString();
            MaxammoText[0].text = "/ "+ammoMaxshot.ToString();
            MaxammoText[1].text = "/ "+ammoMaxshot.ToString();
            shotgun[0].fontSize = 100;
            shotgun[1].fontSize = 100;
            karabin[0].fontSize = 70;
            karabin[1].fontSize = 70;
            rewolwer[0].fontSize = 70;
            rewolwer[1].fontSize = 70;
            rece.SetInteger("bronie", 1);
            break;

            case Guns.karabin:
            if(ammokar >= 0)
            {
            ammoText[0].text = ammokar.ToString();
            ammoText[1].text = ammokar.ToString();
            }
            MaxammoText[0].text = "/"+ammoMaxkar.ToString();
            MaxammoText[1].text = "/"+ammoMaxkar.ToString();
            shotgun[0].fontSize = 70;
            shotgun[1].fontSize = 70;
            karabin[0].fontSize = 100;
            karabin[1].fontSize = 100;
            rewolwer[0].fontSize = 70;
            rewolwer[1].fontSize = 70;
            rece.SetInteger("bronie", 2);
            break;

            case Guns.rewolwer:
            ammoText[0].text = ammorew.ToString();
            ammoText[1].text = ammorew.ToString();
            MaxammoText[0].text = "/ "+ammoMaxrew.ToString();
            MaxammoText[1].text = "/ "+ammoMaxrew.ToString();
            shotgun[0].fontSize = 70;
            shotgun[1].fontSize = 70;
            karabin[0].fontSize = 70;
            karabin[1].fontSize = 70;
            rewolwer[0].fontSize = 100;
            rewolwer[1].fontSize = 100;
            rece.SetInteger("bronie", 3);
            break;

            default:
            rece.SetInteger("bronie", 0);
            break;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            scroll = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            scroll = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            scroll = 2;
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && !festBoi)
        {
            StartCoroutine(Skrol(-1));
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0 && !festBoi)
        {
            StartCoroutine(Skrol(+1));
        }

        if(scroll == 0)
        {
            Bron = Guns.karabin;
        }
        else if(scroll == 1)
        {
            Bron = Guns.shotgun;
        }
        else if(scroll == 2)
        {
            Bron = Guns.rewolwer;
        }
    }

    IEnumerator Skrol(int a)
    {
        rece.SetBool("change", true);
        scroll = scroll + a;
        
        if(scroll > 2)
        {
            scroll = 0;
        }
        else if(scroll < 0)
        {
            scroll = 2;
        }
        yield return new WaitForSeconds(.5f);
        rece.SetBool("change", false);
    }

    IEnumerator Reload(float t)
    {
        rece.SetBool("change", true);
        yield return new WaitForSeconds(t);

        if(Bron == Guns.rewolwer)
        {
            ammorew = ammoMaxrew;
        }
        else if(Bron == Guns.karabin)
        {
            ammokar = ammoMaxkar;
        }
        else if(Bron == Guns.shotgun)
        {
            ammoshot = ammoMaxshot;
        }
        rece.SetBool("change", false);
    }

    void DeadCheck()
    {
        if(hp <= 0){
            skip.SetTrigger("exit");
            Invoke("Die", 1f);
        }
    }

    void Die()
    {
        SceneManager.LoadScene(2);
    }
}
