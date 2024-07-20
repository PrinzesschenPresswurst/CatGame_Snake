using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject treat;
    private static Tile _spawnTile;

    private void Start()
    {
        GameGrid.GridHasBeenDrawn += OnGridHasBeenDrawn;
        Treat.TreatWasCollected += OnTreatWasCollected;
    }

    private void OnGridHasBeenDrawn()
    {
        PickTreatPosition();
        SpawnTreat();
    }

    private void OnTreatWasCollected()
    {
        PickTreatPosition();
        SpawnTreat();
    }

    private void PickTreatPosition()
    {
        do
        {
            int randomX = Random.Range(0, GameGrid.GridArray.GetLength(0));
            int randomY = Random.Range(0, GameGrid.GridArray.GetLength(1));
            _spawnTile = GameGrid.GridArray[randomX, randomY];
            
        } while (CheckIfPositionIsOccupied());
       
    }

    private bool CheckIfPositionIsOccupied()
    {
        if (BodyHandler.BodyList != null)
        {
            foreach (var body in BodyHandler.BodyList)
            {
                if (_spawnTile == body.CurrentTile)
                    return true;
            }
        }
        
        return false;
    }
    
    private void SpawnTreat()
    {
        Instantiate(treat, _spawnTile.transform.position, quaternion.identity);
    }
}
