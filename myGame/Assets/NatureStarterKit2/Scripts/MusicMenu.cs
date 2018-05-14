using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicMenu : MonoBehaviour
{
    /// музыка в меню
    public AudioClip MenuMusic;

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<AudioSource>().clip = MenuMusic;
        gameObject.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<AudioSource>().volume = SaveSettings._selectedVolume;
    }
}
