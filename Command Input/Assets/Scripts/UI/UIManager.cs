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

    //[SerializeField] private EmailManager _emailManager;

    //[SerializeField] private GameObject barriertextGameObject;
    
    [SerializeField] private GameObject notesPanel;
    private bool notesActive = false;



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

        // if (!isBarrierLevel)
        // {
        //     barriertextGameObject.SetActive(false);
        // }

        notesPanel.SetActive(notesActive);
    }

    private void Update()
    {
        movesRemaining.text = Player.Instance.GetRemainingMoves().ToString();

        if (Player.Instance.redBarriersActive)
        {
            barrierActive.text = "Red";
        }
        else if(!Player.Instance.redBarriersActive)
        {
            barrierActive.text = "Blue";
        }  
        

    }

    public void NotesPanelToggle()
    {
        notesActive = !notesActive;
        notesPanel.SetActive(notesActive);
        
        // if (_emailManager.GetEmailActive())
        // {
        //     _emailManager.EmailButtonPressed();
        // }

    }

    public bool GetNotesActive()
    {
        return notesActive;
    }
}
