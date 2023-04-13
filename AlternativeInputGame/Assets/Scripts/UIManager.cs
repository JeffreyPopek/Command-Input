using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    private int remainingMoves;
    
    //UI Text
    [SerializeField] private TextMeshProUGUI movesLeftText;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        movesLeftText.text = remainingMoves.ToString();

        remainingMoves = Player.Instance.remainingMoves;
    }

    private void Update()
    {
        remainingMoves = Player.Instance.remainingMoves;

        Debug.Log(remainingMoves);
        movesLeftText.text = remainingMoves.ToString();
    }
}
