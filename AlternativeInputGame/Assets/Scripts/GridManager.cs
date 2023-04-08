using System;
using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;
using TMPro;
using Quaternion = System.Numerics.Quaternion;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;

    [SerializeField] private GameObject gridManager;
    [SerializeField] private Transform cam;

    private void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), transform.rotation);
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.transform.parent = gridManager.transform;

                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
            }

            gridManager.transform.position = new Vector3(52.5f, -31f, 0f);
        }

        //cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
    // public event Action<GridTile> TileSelected;
    //
    // [Header("Grid Params")]
    // [SerializeField] private int numRows = 5;
    // [SerializeField] private int numColumns = 6;
    // [SerializeField] private float padding = 0.1f;
    //
    // [Header("Tile Prefab")]
    // [SerializeField] private GridTile tilePrefab;
    //
    // [Header("UI")] 
    // [SerializeField] private TextMeshProUGUI currentTileInfo;
    //
    //
    // // public Recognizer _Recognizer;
    // // private RecognitionResult _lastGesture;
    // // private RecognitionResult _result;
    //
    // private void Awake()
    // {
    //     InitGrid();
    // }
    //
    // public void InitGrid()
    // {
    //     for (int y = 0; y < numRows; y++)
    //     {
    //         for (int x = 0; x < numColumns; x++)
    //         {
    //             GridTile tile = Instantiate(tilePrefab, transform);
    //             Vector2 tilePos = new Vector2(x + (padding * x), y + (padding * y));
    //             tile.transform.localPosition = tilePos;
    //             tile.name = $"Tile_{x}_{y}";
    //
    //             tile.gridManager = this;
    //             tile.gridCoords = new Vector2Int(x, y);
    //         }
    //     }
    // }
    //
    // public void OnTileHoverEnter(GridTile gridTile)
    // {
    //     currentTileInfo.text = gridTile.gridCoords.ToString();
    // }
    //
    // public void OnTileHoverExit(GridTile gridTile)
    // {
    //     currentTileInfo.text = "----";
    // }
    //
    // public void OnTileSelected(GridTile gridTile)
    // {
    //     TileSelected.Invoke(gridTile);
    // }
}
