using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //ok to included here as long as this is only script that loads screens

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] public GameObject DeathFX;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        gameObject.SendMessage("OnPlayerDeath", true);
        DeathFX.SetActive(true);
        Invoke("ReloadLevel", levelLoadDelay);
    }

    private void ReloadLevel() //string referenced
    {
        SceneManager.LoadScene(1);
    }
}
