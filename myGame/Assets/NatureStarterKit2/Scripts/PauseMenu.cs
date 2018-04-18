using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class PauseMenu : MonoBehaviour
{

    /// <summary>
    /// поставлена ли игра на паузу ?
    /// </summary>
    public static bool GameIsPaused = false;

    /// <summary>
    /// меню паузы
    /// </summary>
    public GameObject PauseMenuUI;

    /// <summary>
    /// cтрельба
    /// </summary>
    public GameObject Spawn;

    /// <summary>
    /// оружие
    /// </summary>
    public GameObject Weapon;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// продолжить игру
    /// </summary>
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Spawn.GetComponent<ShootHelper>().enabled = true;
        Weapon.GetComponent<AudioSource>().enabled = true;
        Weapon.GetComponent<WeaponScript>().enabled = true;
        GetComponent<AmmoPlayer>().enabled = true;
        Cursor.visible = false;
        GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    /// <summary>
    /// поставить на паузу
    /// </summary>
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        GetComponent<FirstPersonController>().enabled = false;
        Spawn.GetComponent<ShootHelper>().enabled = false;
        Weapon.GetComponent<AudioSource>().enabled = false;
        Weapon.GetComponent<WeaponScript>().enabled = false;
        GetComponent<AmmoPlayer>().enabled = false;
        Cursor.visible = true;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    /// <summary>
    /// выйти из игры
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
