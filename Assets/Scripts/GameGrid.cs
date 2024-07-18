using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    [SerializeField] private GameObject tile;
    private static float _tileSize;
    private static float _gridWidth;
    private static float _gridHeight;
    private static readonly float BufferForUi = 5f;
    
    public static Tile[,] GridArray { get; private set; }
    public static event Action GridHasBeenDrawn;
    
    private void Start()
    {
        _tileSize = 1f;
        _gridWidth = ScreenSettingsHandler.ScreenWidth / _tileSize;
        _gridHeight = ScreenSettingsHandler.ScreenHeight / _tileSize -BufferForUi;
        GridArray = new Tile[(int)_gridWidth, (int)_gridHeight];
         
        DrawGrid();
    }

    private void DrawGrid()
    {
        float widthLeftOver = (ScreenSettingsHandler.ScreenWidth % _tileSize) /2; // not full tile that's overlapping
        float xStartPos = _tileSize / 2 + widthLeftOver;
        float yStartPos = _tileSize / 2;
                                                                                                                    
        Vector2 tilePos = new Vector2(xStartPos, yStartPos);
         
        for (int x = 0; x < GridArray.GetLength(0); x++)
        {
            for (int y = 0; y < GridArray.GetLength(1); y++)
            {
                GameObject newTile =  Instantiate(tile, tilePos, quaternion.identity);
                newTile.GetComponentInChildren<TextMeshPro>().text = x + "/" + y;
                newTile.name = "Tile: " + x + "/" +y;
                Tile tileComponent = newTile.GetComponent<Tile>();
                tileComponent.GridX = x;
                tileComponent.GridY = y;
                
                GridArray[x, y] = tileComponent;
                
                tilePos.y += _tileSize;
            }
            tilePos.y = yStartPos;
            tilePos.x += _tileSize;
        }
        
        if (GridHasBeenDrawn != null)
            GridHasBeenDrawn.Invoke();
    }
}
