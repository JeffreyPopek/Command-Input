using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private bool isBarrierLevel;
    
    //UI Text
    [SerializeField] private TextMeshProUGUI barrierActive;
    
    [SerializeField] private TextMeshProUGUI movesRemaining;



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
        
        movesRemaining.text = Player.Instance.GetRemainingMoves().ToString();

    }

    private void Update()
    {
        // remainingMoves = Player.Instance.remainingMoves;
        //
        // //Debug.Log(remainingMoves);
        // movesLeftText.text = remainingMoves.ToString();
        
        movesRemaining.text = Player.Instance.GetRemainingMoves().ToString();

        if (isBarrierLevel)
        {
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
}
