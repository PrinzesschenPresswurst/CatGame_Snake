using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Body : MonoBehaviour
{
    public Tile CurrentTile { get; private set; }
    private GameObject _parent;
    private Tile _parentTile;
    [CanBeNull] private PlayerMovement _playerMovement;
    [CanBeNull] private Body _body;
    private bool _parentIsPlayer;

    private void Awake()
    {
        _parent = BodyHandler._lastBody;
    }

    private void Start()
    {
        PlayerMovement.PlayerMoves += MoveBody;
        _playerMovement = _parent.GetComponent<PlayerMovement>();
        _body = _parent.GetComponent<Body>();

        CheckIfThisIsFirstBody();
        GetParentTile();
    }

    private void CheckIfThisIsFirstBody()
    {
        if (_playerMovement != null)
            _parentIsPlayer = true;
    }
    
    private void GetParentTile()
    {
        if (_parentIsPlayer)
            _parentTile = PlayerMovement.CurrentTile;
        else
            _parentTile = _body.CurrentTile;
    }

    private void MoveBody()
    {
        CurrentTile = GameGrid.GridArray[_parentTile.GridX, _parentTile.GridY];
        transform.position = CurrentTile.transform.position;
        GetParentTile();
    }
}
