using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {


    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

	// Use this for initialization
	void Start () {
        AddNonTriggerBoxCollider();
        
	}

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
        
    }

    private void OnParticleCollision(GameObject other)
    {
        GameObject FX = Instantiate(deathFX, transform.position, Quaternion.identity);
        FX.transform.parent = parent;
        Destroy(gameObject);
    }
   
}
