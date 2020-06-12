﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] SFX;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int sfxNumber)
    {
     // SFX[sfxNumber].Stop();
        SFX[sfxNumber].Play();
    }

    public void StopSFX(int sfxNumber)
    {
        SFX[sfxNumber].Stop();
    }
}
