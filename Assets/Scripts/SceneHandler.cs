using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Finish")
            LoadNextScene();

    }

    private void LoadNextScene()
    {
        if (SceneManager.GetActiveScene().buildIndex < 4)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
