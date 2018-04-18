using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{

    public string DrawAnim = "draw";
    public string FireLeftAnim = "fire";
    public string ReloadAnim = "reload";

    public GameObject AnimationGO;
    /// звук выстрела
    public AudioClip ShootSound;

    /// звук перезарядки
    public AudioClip ReloadSound;

    private bool DrawWeapon = false;
    private bool reloading = false;
    private bool GameIsPaused = false;

    private int Ammo = 30;


    // Use this for initialization
    void Start()
    {
        WeaponDraw();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameIsPaused)
        {
            if (Input.GetButtonDown("Fire1") && reloading == false && DrawWeapon == false)
            {
                Fire();
                Ammo--;
                PlayShootSound();
            }
            if (Input.GetKeyDown("r") && reloading == false && DrawWeapon == false || Ammo == 0)
            {
                PlayReloadSound();
                Reloading();
                Ammo = 30;
            }

            if (Input.GetKeyDown("1") && reloading == false)
            {
                WeaponDraw();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !GameIsPaused)
        {
            InvertBool();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && GameIsPaused)
        {
            InvertBool();
            return;
        }
    }

    public void InvertBool()
    {
        if (GameIsPaused) GameIsPaused = false;
        else if (!GameIsPaused) GameIsPaused = true;
    }
    public void Fire()
    {
        AnimationGO.GetComponent<Animation>().CrossFadeQueued(FireLeftAnim, 0.08f, QueueMode.PlayNow);
    }

    public void WeaponDraw()
    {
        if (DrawWeapon)
            return;

        AnimationGO.GetComponent<Animation>().Play(DrawAnim);
        DrawWeapon = true;
       // WaitForSeconds(0.6f);
        DrawWeapon = false;
    }

    public void Reloading()
    {
        if (reloading) return;

        AnimationGO.GetComponent<Animation>().Play(ReloadAnim);
        reloading = true;
       // yield WaitForSeconds(2.0);
        reloading = false;
    }

    /// воспроизвести звук выстрела
    public void PlayShootSound()
    {
        gameObject.GetComponent<AudioSource>().clip = ShootSound;
        gameObject.GetComponent<AudioSource>().Play();
    }

    /// воспроизвести звук перезарядки
    public void PlayReloadSound()
    {
        gameObject.GetComponent<AudioSource>().clip = ReloadSound;
        gameObject.GetComponent<AudioSource>().Play();
    }

}
