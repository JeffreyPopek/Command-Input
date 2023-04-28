using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class TimedWalls : MonoBehaviour
{
    [SerializeField] private int movesRemaining;
    private bool isTimerStarted = false;
    private int playerCurrentMoves;
    private int playerPastMoves;
    private bool checkedMoves = false;


    //[SerializeField] private Sprite[] spriteList;

    private LayerMask wallLayer = 3;

   // private SpriteRenderer spriteRenderer;

   private void Awake()
    {

       // spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!checkedMoves)
        {
            checkMoves();
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            movesRemaining--;
        }

        if (isTimerStarted)
        {
            Debug.Log("checking timer");
            playerCurrentMoves = Player.Instance.remainingMoves;
            
            Debug.Log("Current moves: " + playerCurrentMoves + "Past Moves: " + playerPastMoves);
            if (playerCurrentMoves == playerPastMoves - 1)
            {
                movesRemaining--;
                checkMoves();

            }
        }
        
        CheckMovesLogic();
    }

    private void CheckMovesLogic()
    {
        if (movesRemaining == 0)
        {
            gameObject.layer = wallLayer;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTimerStarted = true;
        checkMoves();
        Debug.Log("trigger");
    }

    // private void checkTimer()
    // {
    //
    // }

    private void checkMoves()
    {
        Debug.Log("Checked Moves in function");
        playerPastMoves = Player.Instance.remainingMoves;
        checkedMoves = true;
    }
}
