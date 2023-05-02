using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmailDisplay : MonoBehaviour
{
    [SerializeField] private EmailManager emailManager;
    [SerializeField] private Clock clock;
    private Email email;
    
    
    [SerializeField] private TextMeshProUGUI EmailTitle;
    [SerializeField] private Image SenderImage;
    [SerializeField] private TextMeshProUGUI SenderName;
    [SerializeField] private TextMeshProUGUI YourName;
    [SerializeField] private TextMeshProUGUI EmailText;

    [SerializeField] private TextMeshProUGUI TimeSent;
    //SerializeField] private Image EmailImage;

    private bool setTime = false;

    private void Start()
    {
        email = emailManager.GetEmail();

        EmailTitle.text = email.emailTitle;
        SenderImage.sprite = email.senderImage;
        SenderName.text = email.emailSender;
        YourName.text = Login.playerUsername;
        EmailText.text = email.emailText;
        

        //EmailImage.sprite = email.emailImage;
    }

    private void Update()
    {
        if (!setTime)
        {
            TimeSent.text = clock.GetTime();
            setTime = true;
        }

    }
}
