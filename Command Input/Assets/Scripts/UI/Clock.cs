using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    private const float IN_GAME_TIME = 15f;
    
    [SerializeField] private TextMeshProUGUI timerText;

    public static float timer = 540.0f;

    private string actualTime;
    
    private void Update()
    {
        timer += Time.deltaTime / IN_GAME_TIME;
        DisplayTime();
    }

    private void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        timerText.text = string.Format("{00 : 00}:{01 : 00}", minutes, seconds);

        actualTime = timerText.text;
        Debug.Log(timerText.text);
    }

    public string GetTime()
    {
        Debug.Log("actual time" + actualTime);
        return actualTime;
    }
}
