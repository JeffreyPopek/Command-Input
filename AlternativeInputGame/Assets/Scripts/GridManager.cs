using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    public event Action<GridTile> TileSelected;
    
    [Header("Grid Params")]
    [SerializeField] private int numRows = 5;
    [SerializeField] private int numColumns = 6;
    [SerializeField] private float padding = 0.1f;

    [Header("Tile Prefab")]
    [SerializeField] private GridTile tilePrefab;

    [Header("UI")] 
    [SerializeField] private TextMeshProUGUI currentTileInfo;


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
                GridTile tile = Instantiate(tilePrefab, transform);
                Vector2 tilePos = new Vector2(x + (padding * x), y + (padding * y));
                tile.transform.localPosition = tilePos;
                tile.name = $"Tile_{x}_{y}";

                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
            }
        }
    }

    public void OnTileHoverEnter(GridTile gridTile)
    {
        currentTileInfo.text = gridTile.gridCoords.ToString();
    }
    
    public void OnTileHoverExit(GridTile gridTile)
    {
        currentTileInfo.text = "----";
    }

    public void OnTileSelected(GridTile gridTile)
    {
        TileSelected.Invoke(gridTile);
    }
    
}
