﻿using System.Collections;
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
    /// уровень завершен ?
    /// </summary>
    public bool IsCongratulationsMenu = false;

    /// <summary>
    /// меню старта уровня
    /// </summary>
    public GameObject InfoLevel;

    /// <summary>
    /// меню поздравления
    /// </summary>
    public GameObject CongratulationsMenu;

    /// <summary>
    /// cтрельба
    /// </summary>
    public GameObject Spawn;

    /// <summary>
    /// оружие
    /// </summary>
    public GameObject Weapon;

    public Text TextTimer;
    public Text NumberLevel;
    public Text CongratulationsText;



    public float timer;

    /// <summary>
    /// текущий уровень
    /// </summary>
    public static int CurrentLevel = 1;

    /// <summary>
    /// кол-во врагов
    /// </summary>
    public static int CountEnemiesPrefab = 3;

    /// <summary>
    /// превфаб зомби
    /// </summary>
    public Rigidbody ZombiePrefab;

    /// <summary>
    /// объект зомби
    /// </summary>
    public GameObject ZombieObject;

    /// <summary>
    /// превфаб паук
    /// </summary>
    public Rigidbody SpiderPrefab;

    /// <summary>
    /// объект паук
    /// </summary>
    public GameObject SpiderObject;

    /// <summary>
    /// превфаб босса
    /// </summary>
    public Rigidbody BossPrefab;

    /// <summary>
    /// объект босс
    /// </summary>
    public GameObject BossObject;


    /// <summary>
    /// кол-во убитых врагов
    /// </summary>
    public static int CountDeadEnemies { get; set; }

    SaveSettings a = new SaveSettings();


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
                DisplayInfoLevel();
                StopGame();
            }
            else
            {
                TimerTextForGoGame();
            }
        }
        else
        {
            if (CountDeadEnemies == CountEnemiesPrefab && !IsCongratulationsMenu)
            {
                DisplayCongratulationsMenu();
                StopGame();
                IsCongratulationsMenu = true;
            }
            else if (IsCongratulationsMenu)
            {
                TimerText();
            }

            if (CurrentLevel == 3 && CountDeadEnemies == 1)
            {
                DisplayCongratulationsGame();
                StopGame();
                IsCongratulationsMenu = true;
            }
            
            if(HealthPlayer._health == 0)
            {
                DisplayDead();
                StopGame();
                IsCongratulationsMenu = true;
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
    /// показ панели начала уровня и заполнение текста
    /// </summary>
    public void DisplayInfoLevel()
    {
        InfoLevel.SetActive(true);
        NumberLevel.text = "Level " + CurrentLevel;
    }

    /// <summary>
    /// показ панели поздравления и заполнение текста
    /// </summary>
    public void DisplayCongratulationsMenu()
    {
        CongratulationsMenu.SetActive(true);
        CongratulationsText.text = "Congratulations!\n You have passed level " + CurrentLevel;
    }

    /// <summary>
    /// окно поздравления
    /// </summary>
    public void DisplayCongratulationsGame()
    {
        CongratulationsMenu.SetActive(true);
        CongratulationsText.text = "Congratulations, you have passed the game!!!";
    }

    /// <summary>
    /// окно смерти
    /// </summary>
    public void DisplayDead()
    {
        CongratulationsMenu.SetActive(true);
        CongratulationsText.text = "Congratulations, you DEAD!!!";
    }

    /// <summary>
    /// продолжить игру
    /// </summary>
    public void GoGame()
    {
        CreateEnemiesDependingLevel();
        GetComponent<FirstPersonController>().enabled = true;
        Spawn.GetComponent<ShootHelper>().enabled = true;
        Weapon.GetComponent<AudioSource>().enabled = true;
        GetComponent<AmmoPlayer>().enabled = true;
        Cursor.visible = false;
        Time.timeScale = 1f;

        IsLevelStart = false;
    }


    /// <summary>
    /// создание зомби
    /// </summary>
    public void CreateZombiePrefab()
    {
        int temp = 1;
        while (temp < CountEnemiesPrefab)
        {
            ZombieObject.SetActive(true);
            Rigidbody ZombieClone = Instantiate(ZombiePrefab, new Vector3(Random.Range(-13f, 20f), 1, Random.Range(0f, 39f)), Quaternion.Euler(0, 0, 0)) as Rigidbody;
            ZombieClone.velocity = new Vector3(0, 0, 1);
            temp++;
        }
    }

    public void CreateBossPrefab()
    {
        BossObject.SetActive(true);
    }

    /// <summary>
    /// создание пауков
    /// </summary>
    public void CreateSpiderPrefab()
    {
        int temp = 1;
        while (temp < CountEnemiesPrefab)
        {
            SpiderObject.SetActive(true);
            Rigidbody SpiderClone = Instantiate(SpiderPrefab, new Vector3(Random.Range(-13f, 20f), 1, Random.Range(0f, 39f)), Quaternion.Euler(0, 0, 0)) as Rigidbody;
            SpiderClone.velocity = new Vector3(0, 0, 1);
            temp++;
        }
    }

    /// <summary>
    /// по таймеру задается текст для окна и после него начинается | продолжается игра игра
    /// </summary>
    public void TimerTextForGoGame()
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
            InfoLevel.SetActive(false);
            timer = 10;
            GoGame();
        }
    }

    /// <summary>
    /// таймер для завершения показа окна
    /// </summary>
    public void TimerText()
    {
        if (timer > 0)
        {
            timer -= 0.05f;
        }
        if (timer < 0)
        {
            if (CurrentLevel == 3)
            {
                Application.Quit();
            }

            CountDeadEnemies = 0;
            CurrentLevel++;
            IsCongratulationsMenu = false;
            IsLevelStart = true;

            CongratulationsMenu.SetActive(false);
            timer = 10;
            IsStopGame = false;
        }
    }

    /// <summary>
    /// создать врагов в зависимости от уровня
    /// </summary>
    public void CreateEnemiesDependingLevel()
    {
        CountEnemiesPrefab *= SaveSettings._selectedComplexity;

        if (CurrentLevel == 1) CreateZombiePrefab();
        if (CurrentLevel == 2) CreateSpiderPrefab();
        if (CurrentLevel == 3)
        {
            CreateBossPrefab();
        }

    }
}
