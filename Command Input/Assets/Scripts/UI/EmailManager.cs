using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    [SerializeField] private GameObject emailWindow;
    private bool isEmailTabOpen = false;

    private void Start()
    {
        emailWindow.SetActive(false);
    }

    public void EmailButtonPressed()
    {
        isEmailTabOpen = !isEmailTabOpen;
        
        emailWindow.SetActive(isEmailTabOpen);
    }
    
    
    
}
