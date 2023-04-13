using System;
using System.Collections;
using System.Collections.Generic;
using GestureRecognizer;
using UnityEngine;
using TMPro;
using Quaternion = System.Numerics.Quaternion;

public class GridManager : MonoBehaviour
{
    private Dictionary<(int, int), GameObject> cells;
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

                cells[(3, 4)] = new GameObject();//TODO replace with player

                tile.gridManager = this;
                tile.gridCoords = new Vector2Int(x, y);
            }
        }
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
