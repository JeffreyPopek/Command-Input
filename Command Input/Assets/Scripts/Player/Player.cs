using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public LayerMask wallLayer;
    
    //RETRY FOR TESTING
    private Scene currentScene;


    [SerializeField] private float moveSpeed = 5f;

    public bool canMoveThroughRed = true;

    //remaining moves
    public int remainingMoves = 5;

    //movement
    private bool isMoving;
    private Vector3 originalPosition, targetPosition;
    private float timeToMove = 0.2f;
    
    //Accessing results data
    public GameObject exampleGesturePatternObject;
    private ExampleGestureHandler _exampleGestureHandler;
    
    private string lastGestureID = "";
    private bool waitingForInput;

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

        currentScene = SceneManager.GetActiveScene();
        
        
        _exampleGestureHandler = exampleGesturePatternObject.GetComponent<ExampleGestureHandler>();
    }

    private void Update()
    {
        GetVariables();
        
        //Debug.Log("Last Gesture: " + lastGestureID + "   wait for input: " + waitingForInput);

        CheckGestureIDLogic();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(4);
        }



    }

    private void CheckGestureIDLogic()
    {
        //raycast
        RaycastHit2D hit;
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.down) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left) * 1f, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.right) * 1f, Color.red);


        // if (hit)    
        // {
        //
        //     Debug.Log("Something hit");
        //     hit.transform.GetComponent<SpriteRenderer>().color = Color.red;
        // }
        // else
        // {
        //     Debug.Log("something not hit");
        // }

        if (!waitingForInput)
        {
            if (lastGestureID == "up")
            {
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 1f, wallLayer);
                if (!hit)
                {
                    StartCoroutine(MovePlayer(Vector3.up));
                }
                else
                {
                    Debug.Log("nah");
                }
            }
            
            if (lastGestureID == "down")
            {
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.down), 1f, wallLayer);

                if (!hit)
                {
                    StartCoroutine(MovePlayer(Vector3.down));
                }
                else
                {
                    Debug.Log("nah");
                }
            }
            
            if (lastGestureID == "left")
            {
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 1f, wallLayer);

                if (!hit)
                {
                    StartCoroutine(MovePlayer(Vector3.left));
                }
                else
                {
                    Debug.Log("nah");
                }
            }
            
            if (lastGestureID == "right")
            {
                hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1f, wallLayer);
                
                if (!hit)
                {
                    StartCoroutine(MovePlayer(Vector3.right));
                }
                else
                {
                    Debug.Log("nah");
                }
            }
            
            if (lastGestureID == "Circle")
            {
                canMoveThroughRed = !canMoveThroughRed;
                //Debug.Log(canMoveThroughRed);

                //return and enum, have a checker in update that does to worldmanager
            }
            
            _exampleGestureHandler.waitingForInput = true;
            remainingMoves--;
        }
    }

    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Box")
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    

    private void GetVariables()
    {
        lastGestureID =  _exampleGestureHandler.lastGestureID;
        
        waitingForInput = _exampleGestureHandler.waitingForInput;
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0f;

        originalPosition = transform.position;
        targetPosition = originalPosition + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        
        isMoving = false;
    }

}