using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
            }
            _exampleGestureHandler.waitingForInput = true;

        }
    }

    private void GetVariables()
    {
        lastGestureID =  _exampleGestureHandler.lastGestureID;
        
        waitingForInput = _exampleGestureHandler.waitingForInput;
    }

    private void GetGestureID()
    {
    }

    private void OnEnable()
    {
        _gridManager.TileSelected += OnTileSelected;
    }

    private void OnDisable()
    {
        _gridManager.TileSelected -= OnTileSelected;
    }

    private void OnTileSelected(GridTile obj)
    {
        StopAllCoroutines();
        StartCoroutine(Co_MoveTo(obj.transform.position));
    }

    private IEnumerator Co_MoveTo(Vector2 targetPosition)
    {
        //set target pos to tile pos when moving based on drawn input
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPosition;
    }
}
