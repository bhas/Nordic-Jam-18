﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource Source;
    public AudioSource Trunk;
    public AudioClip WreckingSound;
    public AudioClip Explosion;
    public AudioClip TargetSound;

    private static SoundController _instance;
    public static SoundController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SoundController();

            return _instance;
        }
    }

    //Awake is always called before any Start functions
    void Awake()
    {
        if (_instance == null)
            _instance = this;
        else if (_instance != this)
            Destroy(gameObject);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void PlaySound(AudioClip clip)
    {
        Source.PlayOneShot(clip);
    }

    public void TrunkPitch(float pitch)
    {
        Trunk.pitch = pitch;
    }
}
