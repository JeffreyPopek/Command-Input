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

        if (Player.Instance.canMoveThroughRed)
        {
            movesLeftText.text = "Red";
        }
        else
        {
            movesLeftText.text = "Blue";
        }

        remainingMoves = Player.Instance.remainingMoves;
    }

    private void Update()
    {
        // remainingMoves = Player.Instance.remainingMoves;
        //
        // //Debug.Log(remainingMoves);
        // movesLeftText.text = remainingMoves.ToString();
        
        if (Player.Instance.canMoveThroughRed)
        {
            movesLeftText.text = "Red";
        }
        else if(!Player.Instance.canMoveThroughRed)
        {
            movesLeftText.text = "Blue";
        }
    }
}
