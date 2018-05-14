using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSettings : MonoBehaviour
{
    /// <summary>
    /// кнопка сложности легко
    /// </summary>
    public Button _easyButton;

    /// <summary>
    /// кнопка сложности средне
    /// </summary>
    public Button _mediumButton;

    /// <summary>
    /// кнопка сложности тяжело
    /// </summary>
    public Button _hardButton;

    /// <summary>
    /// слайдер громкости
    /// </summary>
    public Slider _volumeSlider;

    /// <summary>
    /// слайдер стартовых hp
    /// </summary>
    public Slider _startHPSlider;

    /// <summary>
    /// бесконечные патроны
    /// </summary>
    public Toggle _infiniteAmmo;

    /// <summary>
    /// выбранная сложность: 1-easy, 2-medium,3-hard
    /// </summary>
    public static int _selectedComplexity = 1;

    /// <summary>
    /// выбранная громкость: по умолчанию 0.5f;
    /// </summary>
    public static float _selectedVolume = 0.5f;

    /// <summary>
    /// выбранные стартовые хп: по умолчанию 100f;
    /// </summary>
    public static float _selectedStartHP = 100f;

    /// <summary>
    /// чекбокс бесконечные патроны
    /// </summary>
    public static bool _selectedInfiniteAmmo = false;

    // Use this for initialization
    void Start()
    {
        _volumeSlider.value = _selectedVolume;
        _startHPSlider.value = _selectedStartHP;
    }

    // Update is called once per frame
    void Update()
    {

        _easyButton.onClick.AddListener(() => ChangeComplexity(1));

        _mediumButton.onClick.AddListener(() => ChangeComplexity(2));

        _hardButton.onClick.AddListener(() => ChangeComplexity(3));

        _volumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(_volumeSlider.value); });

        _startHPSlider.onValueChanged.AddListener(delegate { ChangeStartHP(_startHPSlider.value); });

        _infiniteAmmo.onValueChanged.AddListener(delegate { ChangeInfiniteAmmo(_infiniteAmmo.isOn); });

    }

    /// <summary>
    /// изменить уровень сложности
    /// </summary>
    /// <param name="complexity"></param>
    public void ChangeComplexity(int complexity)
    {
        _selectedComplexity = complexity;
    }

    /// <summary>
    /// изменить уровень громкости
    /// </summary>
    /// <param name="volume"></param>
    public void ChangeVolume(float volume)
    {
        _selectedVolume = volume;
    }

    /// <summary>
    /// установить или откобчить бесконечные патроны
    /// </summary>
    /// <param name="value"></param>
    public void ChangeInfiniteAmmo(bool value)
    {
        _selectedInfiniteAmmo = value;
    }

    public void ChangeStartHP(float startHP)
    {
        _selectedStartHP = startHP;
    }
}
