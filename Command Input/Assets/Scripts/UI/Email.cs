using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Email", menuName = "Emails")]
public class Email : ScriptableObject
{
    public new string emailTitle;
    public string emailSender;
    public Sprite senderImage;
    public string emailText;
    public Sprite emailImage;

    public void Print()
    {
        Debug.Log(name);
    }



}
