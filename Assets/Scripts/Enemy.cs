﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hits = 10;

    ScoreBoard scoreBoard;
    

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
        
	}

    private void AddNonTriggerBoxCollider()
    {
        addBoxCollder();
        scoreBoard = FindObjectOfType<ScoreBoard>();

    }

    private void addBoxCollder()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        //TODO consider hit FX
        hits--;
        if (hits <= 1)
        {
            KillEnemy();
        }
        scoreBoard.ScoreHit(scorePerHit);
    }

    private void KillEnemy()
    {
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = parent;
        Destroy(gameObject);
    }
}
