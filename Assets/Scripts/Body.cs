using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject Parent { get; set; }
    private Tile _currentTile;
    private Tile _parentTile;
    private PlayerMovement _playerMovement;
    private Body _body;
    private bool _parentIsPlayer;
    
    private void Start()
    {
        PlayerMovement.PlayerMoves += MoveBody;
        
        _playerMovement = Parent.GetComponent<PlayerMovement>();
        _body = Parent.GetComponent<Body>();
        
        if (_playerMovement != null)
            _parentIsPlayer = true;
        
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
        if (_parentIsPlayer)
            _parentTile = PlayerMovement.CurrentTile;
        else
            _parentTile = _body._currentTile;
    }
}
