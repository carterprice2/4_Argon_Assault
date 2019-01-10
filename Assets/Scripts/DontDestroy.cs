﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Object.DontDestroyOnLoad example.
//
// This script example manages the playing audio. The GameObject with the
// "music" tag is the BackgroundMusic GameObject. The AudioSource has the
// audio attached to the AudioClip.

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        print(numMusicPlayers);

        DontDestroyOnLoad(this.gameObject);
    }
}
