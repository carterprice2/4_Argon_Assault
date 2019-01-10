using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        //print(numMusicPlayers);
        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        
    }
}
