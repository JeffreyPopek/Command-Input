using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private int sceneToLoad;
    
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;
    public bool doorOpen = false;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool soundPlayed = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && doorOpen)
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
        else
        {
            _spriteRenderer.sprite = closedDoor;

        }
    }

    public void OpenDoor()
    {
        doorOpen = true;
    }

    
}
