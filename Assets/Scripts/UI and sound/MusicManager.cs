﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip menuBGM;
    public AudioClip gameBGM;

    AudioSource audioSource;
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = menuBGM;
        audioSource.PlayDelayed(0.5f);
    }

    public void SetVol(float volume)
    {
        audioSource.volume = volume;
    }
    public void PlayGameBGM()
    {
        audioSource.Stop();
        audioSource.clip = gameBGM;
        audioSource.loop = true;
        audioSource.PlayDelayed(0.5f);
    }
    public void PlayMenuMusic()
    {
        audioSource.Stop();
        audioSource.clip = menuBGM;
        audioSource.loop = true;
        audioSource.PlayDelayed(0.5f);
    }
}
