using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject Parent { get; set; }
    private Tile _currentTile;
    private Tile _parentTile;
    
    private void Start()
    {
        PlayerMovement.PlayerMoves += MoveBody;
        GetParentTile();
    }

    private void MoveBody()
    {
        _currentTile = GameGrid.GridArray[_parentTile.GridX, _parentTile.GridY];
        transform.position = _currentTile.transform.position;
        GetParentTile();
    }

    private void GetParentTile()
    {
        if (Parent.GetComponent<PlayerMovement>() != null)
            _parentTile = Parent.GetComponent<PlayerMovement>().CurrentTile;
        else 
            _parentTile = Parent.GetComponent<Body>()._currentTile;
    }
}
