using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmailDisplay : MonoBehaviour
{
    public Email email;
    
    [SerializeField] private TextMeshProUGUI EmailTitle;
    [SerializeField] private Image SenderImage;
    [SerializeField] private TextMeshProUGUI SenderName;
    [SerializeField] private TextMeshProUGUI EmailText;
    [SerializeField] private Image EmailImage;

    


    void Start()
    {
        EmailTitle.text = email.emailTitle;
        SenderImage.sprite = email.senderImage;
        SenderName.text = email.emailSender;
        EmailText.text = email.emailText;
        EmailImage.sprite = email.emailImage;
    }


}
