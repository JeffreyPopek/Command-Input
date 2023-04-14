using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager Instance { get; private set; }

    [SerializeField] private GameObject door;
    [SerializeField] private Button[] buttonList;

    private bool allButtonsActivated = false;

    
    private void Awake()
    {
        door.SetActive(false);
    }
    
    private void Update()
    {
        foreach (Button element in buttonList)
        {
            if (!element.buttonPressed)
            {
                allButtonsActivated = false;       

                DoorLogic();
                return;
            }

            allButtonsActivated = true;
        }

        DoorLogic();
    }

    private void DoorLogic()
    {
        if(!allButtonsActivated)
        {
            door.SetActive(false);
        }

        if (allButtonsActivated)
        {
            door.SetActive(true);
        }
    }

    
    
}
