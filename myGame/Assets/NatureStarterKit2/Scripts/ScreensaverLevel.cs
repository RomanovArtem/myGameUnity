using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ScreensaverLevel : MonoBehaviour
{
    /// <summary>
    /// начало игры ?
    /// </summary>
    public bool IsLevelStart = true;

    /// <summary>
    /// игра уже была остановлена ?
    /// </summary>
    public bool IsStopGame = false;

    /// <summary>
    /// меню паузы
    /// </summary>
    public GameObject SplashScreen;

    /// <summary>
    /// cтрельба
    /// </summary>
    public GameObject Spawn;

    /// <summary>
    /// оружие
    /// </summary>
    public GameObject Weapon;

    public Text TextTimer;

    public float timer;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsLevelStart)
        {
            if (!IsStopGame)
            {
                StopGame();
            }
            else
            {
                if (timer > 0)
                {
                    if (timer <= 10 && timer >= 7) TextTimer.text = "READY";
                    if (timer < 7 && timer >= 4) TextTimer.text = "STUDY";
                    if (timer < 4 && timer >= 1) TextTimer.text = "GO";

                    timer -= 0.05f;
                }
                if (timer < 0)
                {
                    GoGame();
                }
            }
        }
    }


    /// <summary>
    /// имитация паузы
    /// </summary>
    void StopGame()
    {
        GetComponent<FirstPersonController>().enabled = false;
        Spawn.GetComponent<ShootHelper>().enabled = false;
        Weapon.GetComponent<AudioSource>().enabled = false;
        GetComponent<AmmoPlayer>().enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0f;

        IsStopGame = true;

    }

    /// <summary>
    /// продолжить игру
    /// </summary>
    public void GoGame()
    {
        SplashScreen.SetActive(false);
        GetComponent<FirstPersonController>().enabled = true;
        Spawn.GetComponent<ShootHelper>().enabled = true;
        Weapon.GetComponent<AudioSource>().enabled = true;
        GetComponent<AmmoPlayer>().enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1f;

        IsLevelStart = false;
    }
}
