using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public bool isAtWall = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("At a wall on: " + this.ToString());
            isAtWall = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        isAtWall = false;
    
        Debug.Log("Not at a wall on: " + this.ToString());
    
    }

    public bool GetIsAtWall()
    {
        return isAtWall;
    }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     if (other.gameObject.tag == "Wall")
    //     {
    //         isAtWall = false;
    //
    //         Debug.Log("Not at a wall on: " + this.ToString());
    //     }
    // }
    //
}
