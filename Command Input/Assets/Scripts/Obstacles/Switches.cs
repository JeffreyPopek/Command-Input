using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switches : MonoBehaviour
{
    [SerializeField] private bool isRed;
    private bool canSwitch = true;

    private void Awake()
    {
        if (this.CompareTag("Red Barrier"))
        {
            isRed = true;
        }
        else
        {
            isRed = false;
        }
        
    }

    private void Update()
    {
        
        // if (Player.Instance.canMoveThroughRed == true)
        // {
        //     if (!isRed)
        //     {
        //         this.tag = "Wall";
        //     }
        //     else
        //     {
        //         this.tag = "Red Barrier";
        //     }
        // }
        //
        // if (Player.Instance.canMoveThroughRed == false)
        // {
        //     if (isRed)
        //     {
        //         this.tag = "Wall";
        //     }
        //     else
        //     {
        //         this.tag = "Blue Barrier";
        //     }
        // }
    }

    public bool GetIsRed()
    {
        return isRed;
    }

    public bool GetCanSwitch()
    {
        return canSwitch;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        canSwitch = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        canSwitch = true;
    }
}
