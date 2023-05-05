using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    
    public bool buttonPressed = false;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            Debug.Log("Button pressed!");
            FindObjectOfType<AudioManager>().Play("ButtonPressed");
            buttonPressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Box")
        {
            Debug.Log("Button left!");
            FindObjectOfType<AudioManager>().Play("ButtonUnpressed");
            buttonPressed =  false;
        }
    }


}
