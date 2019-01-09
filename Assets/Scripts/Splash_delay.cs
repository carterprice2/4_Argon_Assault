using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Splash_delay : MonoBehaviour {

    // Use this for initialization
    //private void Awake()
    //{
    //    DontDestroyOnLoad(GameObject);
    //}

    void Start ()
    {
        Invoke("LoadFirstScene", 2f);
	}
	
	// Update is called once per frame
	void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
	}
}
