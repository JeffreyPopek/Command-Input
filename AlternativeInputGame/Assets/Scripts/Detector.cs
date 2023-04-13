using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    // public void CheckForWallsLogic(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Wall")
    //     {
    //         Debug.Log("At a wall on: " + this.ToString());
    //         //return false;
    //     }
    //     
    //     Debug.Log("Not at a wall on: " + this.ToString());
    //
    //
    //     //return true;
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("At a wall on: " + this.ToString());
            //return false;
        }
        
        Debug.Log("Not at a wall on: " + this.ToString());
    
    
        //return true;
        
    }
}
