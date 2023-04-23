using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadTyler()
    {
        SceneManager.LoadScene(1);
    }
    
    public void LoadJake()
    {
        SceneManager.LoadScene(2);
    }
}
