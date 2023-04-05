using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private float moveSpeed = 5f;

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
