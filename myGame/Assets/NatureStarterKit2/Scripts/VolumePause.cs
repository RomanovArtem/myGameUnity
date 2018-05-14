using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumePause : MonoBehaviour
{
    /// <summary>
    /// слайдер громкости
    /// </summary>
    public Slider _volumeSlider;

    // Use this for initialization
    void Start()
    {
        _volumeSlider.value = SaveSettings._selectedVolume;
    }

    // Update is called once per frame
    void Update()
    {
        SaveSettings._selectedVolume = _volumeSlider.value;
    }
}
