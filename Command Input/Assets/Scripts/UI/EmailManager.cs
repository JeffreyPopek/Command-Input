using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class EmailManager : MonoBehaviour
{
    //public static EmailManager Instance { get; private set; }
    
    
    [SerializeField] private GameObject emailWindow;

    [SerializeField] private GameObject emailNotification;
    private bool isEmailTabOpen = false;

    private bool isEmailOpen = false;

    private bool emailSent = false;
    
    [SerializeField] private Email[] emails;

    [SerializeField] private int emailToShow;

    private void Start()
    {
        emailWindow.SetActive(false);

        if (!emailSent)
        {
            Invoke("MoveNotification", 2);
        }
    }

    public bool GetEmailActive()
    {
        return isEmailOpen;
    }
    
    public void EmailButtonPressed()
    {
        isEmailTabOpen = !isEmailTabOpen;
        
        emailWindow.SetActive(isEmailTabOpen);

        if (UIManager.Instance.GetNotesActive())
        {
            UIManager.Instance.NotesPanelToggle();
        }
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

    private void MoveNotification()
    {
        emailNotification.transform.LeanMoveLocal(new Vector2(530, -450), 1);
        FindObjectOfType<AudioManager>().Play("Notification");

        emailSent = true;

    }

}
