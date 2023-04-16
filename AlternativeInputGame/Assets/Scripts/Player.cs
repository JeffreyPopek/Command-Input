using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    //RETRY FOR TESTING
    private Scene currentScene;

    //[SerializeField] private GridManager _gridManager;

    [SerializeField] private float moveSpeed = 5f;

    public bool canMoveThroughRed = true;

    private bool atWallUp, atWallDown, atWallLeft, atWallRight;

    [SerializeField] private Detector upDetector, downDetector, leftDetector, rightDetector;

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


    // private void OnEnable()
    // {
    //     _gridManager.TileSelected += OnTileSelected;
    // }
    //
    // private void OnDisable()
    // {
    //     _gridManager.TileSelected -= OnTileSelected;
    // }
    //
    // private void OnTileSelected(Tile obj)
    // {
    //      StopAllCoroutines();
    //      StartCoroutine(Co_MoveTo(obj.transform.position));
    // }
    //
    // private IEnumerator Co_MoveTo(Vector3 targetPos)
    // {
    //     while (Vector3.Distance(transform.position, targetPos) > 0.01f)
    //     {
    //         transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    //         yield return null;
    //     }
    //
    //     transform.position = targetPos;
    // }

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

    private void WallLogic()
    {
        atWallUp = upDetector.GetIsAtWall();
        atWallDown = downDetector.GetIsAtWall();
        atWallLeft = leftDetector.GetIsAtWall();
        atWallRight = rightDetector.GetIsAtWall();

    }
    
    private void Update()
    {
        GetVariables();
        WallLogic();
        
        Debug.Log(atWallUp + " " + atWallDown + " " + atWallLeft + " " + atWallRight);
        Debug.Log("Last Gesture: " + lastGestureID + "   wait for input: " + waitingForInput);

        CheckGestureIDLogic();

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene.name);
        }
        
    }

    private void CheckGestureIDLogic()
    {
        if (!waitingForInput)
        {
            if (lastGestureID == "up" && !atWallUp)
            {
                StartCoroutine(MovePlayer(Vector3.up));
            }
            
            if (lastGestureID == "down" && !atWallDown)
            {
                StartCoroutine(MovePlayer(Vector3.down));
            }
            
            if (lastGestureID == "left" && !atWallLeft)
            {
                StartCoroutine(MovePlayer(Vector3.left));
            }
            
            if (lastGestureID == "right" && !atWallRight)
            {
                StartCoroutine(MovePlayer(Vector3.right));
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
