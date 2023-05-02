using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    
    [SerializeField] private Sprite openDoor;
    public bool doorOpen = false;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!doorOpen)
        {
            return;
        }
        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("LOADING SCENE");
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    private void Update()
    {
        if (doorOpen)
        {
            _spriteRenderer.sprite = openDoor;
        }
    }
}
