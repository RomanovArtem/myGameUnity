using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class AmmoPlayer : MonoBehaviour
{
    /// <summary>
    /// общее количество патронов
    /// </summary>
    public int AmmoCount = 150;

    /// <summary>
    /// количество патронов в магазине
    /// </summary>
    public int NumberBulletsInStore = 30;
    /// <summary>
    /// кол-во патронов строкой
    /// </summary>
    public Text _amountAmmo = null;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Reloading();
        if (NumberBulletsInStore < 0) NumberBulletsInStore = 0;
        if (AmmoCount < 0) AmmoCount    = 0;
        _amountAmmo.text = NumberBulletsInStore + " / " + AmmoCount;
    }

    /// <summary>
    /// перезарядка
    /// </summary>
    public void Reloading()
    {
        if (NumberBulletsInStore == 0 && AmmoCount > 0 || Input.GetKeyDown(KeyCode.R))
        {

            // устанавливаем метод обратного вызова
            TimerCallback timerCallback = new TimerCallback(CountingAmmo);
            // создаем таймер
            Timer timer = new Timer(timerCallback, null, 2000, 0);
        }
    }

    /// <summary>
    /// подсчет боеприпасов
    /// </summary>
    public void CountingAmmo(object obj)
    {
        var temp = 30 - NumberBulletsInStore;

        if (AmmoCount - temp >= 0)
        {
            NumberBulletsInStore += temp;
            AmmoCount -= temp;
        }

        else if (AmmoCount - temp < 0)
        {
            NumberBulletsInStore += AmmoCount;
            AmmoCount = 0;
        }
    }
}
