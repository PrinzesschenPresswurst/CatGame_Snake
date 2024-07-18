using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] private GameObject treat;
    public static Tile _spawnTile { get; set; }

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
        int randomX = Random.Range(0, GameGrid.GridArray.GetLength(0));
        int randomY = Random.Range(0, GameGrid.GridArray.GetLength(1));
        _spawnTile = GameGrid.GridArray[randomX, randomY];
    }
    
    private void SpawnTreat()
    {
        Instantiate(treat, _spawnTile.transform.position, quaternion.identity);
    }
}
