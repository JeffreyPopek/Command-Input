using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    //UI Text
    [SerializeField] private TextMeshProUGUI barrierActive;


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

        if (Player.Instance.redBarriersActive)
        {
            barrierActive.text = "Red";
        }
        else
        {
            barrierActive.text = "Blue";
        }

    }

    private void Update()
    {
        // remainingMoves = Player.Instance.remainingMoves;
        //
        // //Debug.Log(remainingMoves);
        // movesLeftText.text = remainingMoves.ToString();
        
        if (Player.Instance.redBarriersActive)
        {
            barrierActive.text = "Red";
        }
        else if(!Player.Instance.redBarriersActive)
        {
            barrierActive.text = "Blue";
        }
    }
}
