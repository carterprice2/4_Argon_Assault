﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    [SerializeField] int scorePerHit = 12;

    int score;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
    //this is public so any script/game object can call this method
	public void ScoreHit()
    {
        score = score + scorePerHit;
    }
}