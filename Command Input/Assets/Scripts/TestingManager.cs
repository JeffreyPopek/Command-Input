using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestingManager : MonoBehaviour
{
    private string thisScene;
    private int thisSceneNum;

    private void Awake()
    {
        thisScene = SceneManager.GetActiveScene().name;
        thisSceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(thisScene);
            Debug.Log("Load Scene");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(thisSceneNum + 1);
            Debug.Log("Load next scene");
        }
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(thisSceneNum - 1);
            Debug.Log("Load next scene");
        }

    }
}
