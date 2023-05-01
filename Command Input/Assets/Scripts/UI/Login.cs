using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    private string username, password;

    private bool usernameEntered = false;
    private bool passwordEntered = false;

    public void ReadUsernameSInput(string s)
    {
        username = s;
        Debug.Log("username" + username);
        usernameEntered = true;

        CheckLoginLogic();
    }
    
    public void ReadPasswordInput(string s)
    {
        password = s;
        Debug.Log("password" + password);
        passwordEntered = true;

        CheckLoginLogic();
    }

    private void CheckLoginLogic()
    {
        if (usernameEntered && passwordEntered)
        {
            //load game if both fields are entered
            Debug.Log("loaded scnee");
            //SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("not enough");
        }
    }
}
