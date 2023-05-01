using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    //public static EmailManager Instance { get; private set; }

    [SerializeField] private GameObject emailWindow;

    [SerializeField] private GameObject emailNotification;
    private bool isEmailTabOpen = false;

    private bool isEmailOpen = false;

    [SerializeField] private Email[] emails;

    [SerializeField] private int emailToShow;

    private void Start()
    {
        emailWindow.SetActive(false);

        StartMoving();
    }

    public void EmailButtonPressed()
    {
        isEmailTabOpen = !isEmailTabOpen;
        
        emailWindow.SetActive(isEmailTabOpen);
    }

    public Email GetEmail()
    {
        return emails[emailToShow];
    }

    public void OpenEmailFromNotification()
    {
        isEmailTabOpen = true;
        
        emailWindow.SetActive(isEmailTabOpen);
        
        emailNotification.SetActive(false);
    }
    
    public void StartMoving()
    {
        StartCoroutine(WaitForTime());

        emailNotification.transform.LeanMoveLocal(new Vector2(530, -450), 1);
        
        //FindObjectOfType<AudioManager>().Play("Notification");
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(3);
    }


}
