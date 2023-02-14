using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGun : MonoBehaviour
{
    public GameObject bulletObject;
    public Transform bulletSpawn;
    public Bullet bullet_SC;

    public Camera cam;
    public GameObject[] UIZoom;
    bool canZoom;
    public bool zoomForGun;    
    [HideInInspector] public bool iszoom = false;

    float TimeReloadBullet = 0f;
    public ShopMenu bulletMenu;
    public int bulletMax;
    public float rebullettime = 1f;
    int bulletReal;
    [HideInInspector] public bool canshoot = true;
    
    Animator GunAnim;
    public TextMeshPro textBullet;

    public bool Gun4 = false;
    GameObject gun;

    AudioSource audioSource;
    public AudioClip soundShoot;
    public AudioClip soundZoom;
    public AudioClip soundReBullet;
    bool is1Shoot = false;
    float t1Shoot = 0;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        gun = gameObject.GetComponent<GameObject>();
        GunAnim = gameObject.GetComponent<Animator>();
        bulletReal = bulletMax;
        textBullet.color = new Color(204, 225, 0, 255);
    }
 
    void Update()
    {
        GunAnim.SetBool("Fire", false);
        GunAnim.SetBool("ReBullet", false);

        if (TimeReloadBullet > 0)
        {
            TimeReloadBullet -= Time.deltaTime;   
        }

        if (zoomForGun)
        {
            if (Input.GetMouseButton(0) && TimeReloadBullet <= 0 && canshoot && !Gun4) 
            {
                Fire();
                bulletReal -= 1;
                TimeReloadBullet = bullet_SC.reloadTime;
                GunAnim.SetBool("Fire", true);
                audioSource.PlayOneShot(soundShoot, 1f);
            }
            else if (Input.GetMouseButtonUp(0) && !Gun4)
            {
                audioSource.Stop();
            }
            else if (Input.GetMouseButton(0) && canshoot && Gun4)
            {
                Fire();
                bulletMenu.gun1();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && TimeReloadBullet <= 0 && canshoot) 
            {
                Fire();
                bulletReal -= 1;
                TimeReloadBullet = bullet_SC.reloadTime;
                GunAnim.SetBool("Fire", true);

                audioSource.PlayOneShot(soundShoot, 1f);
                is1Shoot = true;
            }
        }
        

        if (bulletReal <= 0)
        {
            textBullet.text = "bug";
            textBullet.color = new Color(225, 0, 0, 255);
            canZoom = false;
            cam.fieldOfView = 60;
            UIZoom[0].SetActive(false);
            canshoot = false;
        }
        else 
        {
            textBullet.text = bulletReal.ToString();
            canZoom = true;
        }

        _ZoomControl();
        _reBullet();
    }
 
    private void Fire()
    {
        float x = Screen.width / 2; //1/2 screen
        float y = Screen.height / 2;

        var ray = cam.ScreenPointToRay(new Vector3(x, y, 0)); //set ray camera
        GameObject projectile = Instantiate(bulletObject); //create bullets
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), bulletSpawn.parent.GetComponent<Collider>()); //spawm bullets
        projectile.transform.position = bulletSpawn.position; //set position bullet
        Vector3 rotation = projectile.transform.rotation.eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z); //set rotation bullets
        
        projectile.AddComponent<Rigidbody>(); // create rigid 
        projectile.GetComponent<Rigidbody>().useGravity = false; //un Gravity
        projectile.GetComponent<Rigidbody>().velocity = ray.direction * bullet_SC.SpeedBullet;// set speed bullet
    }

    void _ZoomControl()
    {
        if  (Input.GetMouseButtonDown(1) && canZoom && zoomForGun)
        {
            if (!iszoom) 
            {
                cam.fieldOfView = 20;
                UIZoom[0].SetActive(true);
                UIZoom[1].SetActive(false);
                iszoom = true;
                audioSource.PlayOneShot(soundZoom, 1f);
            }
            else
            {
                cam.fieldOfView = 60;
                UIZoom[0].SetActive(false);
                UIZoom[1].SetActive(true);
                iszoom = false;
            }
        }
    }

    float tt = 0f;
    bool enterR = false;
    void _reBullet()
    {
        if (tt > 0)
        {
            tt -= Time.deltaTime;
        } 
        else 
        {
            if (enterR)
            {
                Time.timeScale = 1f;
                audioSource.PlayOneShot(soundReBullet, 1f);
                int tbullet = bulletMax - bulletReal;
                if (bulletReal < bulletMax)
                {
                    if (bulletMenu.bulletInBalo >= tbullet) //full bullet
                    {
                        bulletReal += tbullet;
                        bulletMenu.bulletInBalo -= tbullet;
                    }
                    else
                    {
                        bulletReal += bulletMenu.bulletInBalo;
                    }
                }
                textBullet.color = new Color(204, 225, 0, 255);
                enterR = false;
                canshoot = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletMenu.bulletInBalo > 0)
        {
            GunAnim.SetBool("ReBullet", true);
            Time.timeScale = 0.3f;
            tt = rebullettime;
            enterR = true; 
        }
    }


    float tt2 = 5f;
    void _Gun4()
    {
        bool _Destroy = false;
        if (tt2 > 0)
        {
            tt2 -= Time.deltaTime;
            Debug.Log(tt2);
            _Destroy = true;
        }

        if (_Destroy)
        {
            gun.SetActive(false);
            tt2 = 5f;
            Debug.Log("yess");
            _Destroy = false;
        }
    }
}
