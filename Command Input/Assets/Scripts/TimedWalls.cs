using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimedWalls : MonoBehaviour
{
    [SerializeField] private int movesRemaining;

    //[SerializeField] private Sprite[] spriteList;

    private LayerMask wallLayer = 3;

   // private SpriteRenderer spriteRenderer;


    private void Awake()
    {
       // spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movesRemaining--;
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
}
