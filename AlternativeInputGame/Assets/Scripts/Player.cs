using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement
    private bool isMoving;
    private Vector3 originalPosition, targetPosition;
    private float timeToMove = 0.2f;
    
    //Accessing results data
    public GameObject exampleGesturePatternObject;
    private ExampleGestureHandler _exampleGestureHandler;
    
    
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private float moveSpeed = 5f;

    private string lastGestureID = "";
    private bool waitingForInput;

    private void Awake()
    {
        _exampleGestureHandler = exampleGesturePatternObject.GetComponent<ExampleGestureHandler>();
    }

    private void Update()
    {
        GetVariables();
        Debug.Log("Last Gesture: " + lastGestureID + "   wait for input: " + waitingForInput);

        if (!waitingForInput)
        {
            if (lastGestureID == "up")
            {
                Debug.Log("HE WENT UP YOOOOOOOOOOOOOOOOOOOO");
                StartCoroutine(MovePlayer(Vector3.up));
            }
            
            if (lastGestureID == "down")
            {
                Debug.Log("HE WENT DOWN YOOOOOOOOOOOOOOOOOOOO");
                StartCoroutine(MovePlayer(Vector3.down));
            }
            
            if (lastGestureID == "left")
            {
                Debug.Log("HE WENT LEFT YOOOOOOOOOOOOOOOOOOOO");
                StartCoroutine(MovePlayer(Vector3.left));
            }
            
            if (lastGestureID == "right")
            {
                Debug.Log("HE WENT RIGHT YOOOOOOOOOOOOOOOOOOOO");
                StartCoroutine(MovePlayer(Vector3.right));
            }
            _exampleGestureHandler.waitingForInput = true;

        }
        
        //movement
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.up));
        }
        
        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.down));
        }
        
        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.left));
        }
        
        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.right));
        }
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
