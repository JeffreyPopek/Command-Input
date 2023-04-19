using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadSceneButtons()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadSceneSwitches()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadSceneJackson()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LoadSceneTyler()
    {
        SceneManager.LoadScene(3);
    }
}
