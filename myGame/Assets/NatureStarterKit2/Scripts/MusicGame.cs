using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicGame : MonoBehaviour
{
    /// музыка в игре
    public AudioClip Music1;

    public AudioClip Music2;

    public AudioClip Music3;

    public AudioClip Music4;


    // Use this for initialization
    void Start()
    {
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            PlayMusic();
        }
        gameObject.GetComponent<AudioSource>().volume = SaveSettings._selectedVolume;
    }

    /// <summary>
    /// проигрывать музыку
    /// </summary>
    public void PlayMusic()
    {
        System.Random rnd = new System.Random();
        var value = rnd.Next(1, 4);

        if (value == 1)
        {
            gameObject.GetComponent<AudioSource>().clip = Music1;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (value == 2)
        {
            gameObject.GetComponent<AudioSource>().clip = Music2;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (value == 3)
        {
            gameObject.GetComponent<AudioSource>().clip = Music3;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (value == 4)
        {
            gameObject.GetComponent<AudioSource>().clip = Music4;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
