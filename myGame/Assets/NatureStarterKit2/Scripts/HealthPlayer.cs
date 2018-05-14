using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
{
    /// <summary>
    /// здоровье персонажа
    /// </summary>
    public float _health;
    /// <summary>
    /// слайдер 
    /// </summary>
    public Slider _slider;

    /// <summary>
    /// кол-во здоровья строкой
    /// </summary>
    public Text _amountHealth;
    // Use this for initialization
    void Start()
    {
        _health = SaveSettings._selectedStartHP;
        _slider.maxValue = _health;
    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0)
        {
            _health = 0;
        }
        _slider.value = _health;
        _amountHealth.text = "Health " + _health;

    }
}
