using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //remaining moves
    [SerializeField] private int remainingMoves = 5;
    
    //UI
    [SerializeField] private TextMeshProUGUI movesLeftText;
    //new tutorial
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform movePoint;
    
    
    //physics
    [SerializeField] private Rigidbody2D _rigidbody2D;
    
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
        _exampleGestureHandler = exampleGesturePatternObject.GetComponent<ExampleGestureHandler>();

        movePoint.parent = null;
    }

    private void Update()
    {

        movesLeftText.text = remainingMoves.ToString();
        
        GetVariables();
        Debug.Log("Last Gesture: " + lastGestureID + "   wait for input: " + waitingForInput);

        
        //FOR IN CLASS TESTING
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            remainingMoves = 5;
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
        //^^^^^^^^^^^^^^^^^
        //FOR IN CLASS TESTING

        
        if (!waitingForInput && remainingMoves != 0)
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
            remainingMoves--;

        }

        // transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        //
        // if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        // {
        //     if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        //     {
        //         movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        //     }
        //
        //     if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
        //     {
        //         movePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        //     }
        // }
       
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
