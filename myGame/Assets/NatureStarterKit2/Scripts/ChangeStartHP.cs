using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStartHP : MonoBehaviour
{

    /// <summary>
    /// слайдер стартовых hp
    /// </summary>
    public Slider _startHPSlider;

    /// <summary>
    /// текст для стартового хп
    /// </summary>
    public TextMeshProUGUI _textStartHP;

    // Use this for initialization
    void Start()
    {
        _textStartHP.text = SaveSettings._selectedStartHP.ToString();
        _startHPSlider.value = SaveSettings._selectedStartHP;
    }

    // Update is called once per frame
    void Update()
    {
        _startHPSlider.onValueChanged.AddListener(delegate { ChangeStartHPText(); });
    }

    /// <summary>
    /// изменить текст стартового хп
    /// </summary>
    public void ChangeStartHPText()
    {
        _textStartHP.text = _startHPSlider.value.ToString();
    }
}
