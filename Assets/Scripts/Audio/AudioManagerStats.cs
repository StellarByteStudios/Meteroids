using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AudioManagerStats
{
    //[Range(0, 200)]
    public int masterVolume;
    //[Range(0, 100)]
    public int musicVolume;
    //[Range(0, 100)]
    public int soundeffectsVolume;

    public AudioManagerStats()
    {
        masterVolume = 50;
        musicVolume = 100;
        soundeffectsVolume = 75;
    }
}
