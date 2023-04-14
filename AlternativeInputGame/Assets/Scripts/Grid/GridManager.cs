using System;
using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;
using TMPro;
using Quaternion = System.Numerics.Quaternion;

public class GridManager : MonoBehaviour
{
    
    public static GridManager Instance { get; private set; }

    public bool switchingBarrier = false;
    //private Dictionary<(int, int), GameObject> cells;
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject doorPrefab;
    [SerializeField] private GameObject playerPrefab;



    [Header("Objects on Grid")] [SerializeField]
    private int temp1, temp2;
    
    public event Action<Tile> TileSelected;

    [Header("Grid Params")] [SerializeField]
    private int numRows = 5;

    [SerializeField] private int numColumns = 6;
    [SerializeField] private float padding = 0.1f;

    [Header("Tile Prefab")] [SerializeField]
    private Tile tilePrefab;

    [Header("UI")] [SerializeField] private TextMeshProUGUI currentTileInfo;
    

    private void Awake()
    {
        InitGrid();
    }

    public void InitGrid()
    {
        for (int y = 0; y < numRows; y++)
        {
            for (int x = 0; x < numColumns; x++)
            {
                Tile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding * x), y + (padding * y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{x}_{y}";

                // if (x == 1 && y == 1)
                // {
                //     GameObject player = Instantiate(playerPrefab, transform);
                //     player.transform.localPosition = tilePos;
                // }
                
                if (x == temp1 && y == temp2)
                {
                    GameObject box = Instantiate(boxPrefab, transform);
                    box.transform.localPosition = tilePos;
                }
                
                if (x == 2 && y == 3)
                {
                    GameObject button = Instantiate(buttonPrefab, transform);
                    button.transform.localPosition = tilePos;
                }
                
                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
            }
        }
    }

    private void Update()
    {
        Debug.Log(switchingBarrier);
    }

    public void OnTileHoverEnter(Tile gridTile)
    {
        currentTileInfo.text = gridTile.gridCoords.ToString();
    }

    public void OnTileHoverExit(Tile gridTile)
    {
        currentTileInfo.text = "----";
    }

    public void OnTileSelected(Tile gridTile)
    {
        TileSelected.Invoke(gridTile);
    }

}
