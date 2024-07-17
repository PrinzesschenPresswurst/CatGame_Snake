using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveTimerInterval = 1f;
    private float _moveTimer;
    private Tile _currentTile;
    private int _currentX;
    private int _currentY;
    private MoveDirection _direction;
    
    private void Start()
    {
        GameGrid.GridHasBeenDrawn += OnGridHasBeenDrawn;
        _direction = MoveDirection.Up;
    }
    
    private void OnGridHasBeenDrawn()
    {
        SetStartPos();
    }

    private void SetStartPos()
    {
        _currentTile = GameGrid.GridArray[0, 0];
        transform.position = _currentTile.transform.position;
    }

    private void Update()
    {
        _direction = GetMoveDirection();
        Move(_direction);
    }
    
    private MoveDirection GetMoveDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            return MoveDirection.Up;
            
        else if (Input.GetKey(KeyCode.DownArrow))
            return MoveDirection.Down;
        
        else if (Input.GetKey(KeyCode.LeftArrow))
            return MoveDirection.Left;
        
        else if (Input.GetKey(KeyCode.RightArrow))
            return MoveDirection.Right;
        return _direction;
    }

    private void Move(MoveDirection direction)
    {
        _moveTimer += Time.deltaTime;
        if (_moveTimer < moveTimerInterval)
            return;
        _moveTimer = 0;
        
        switch (direction)
        {
            case MoveDirection.Up:
                if (_currentTile.GridY < GameGrid.GridArray.GetLength(1) - 1)
                    _currentY++;
                break;
            case MoveDirection.Down:
                if (_currentTile.GridY > 0)
                    _currentY--;
                break;
            case MoveDirection.Left:
                if (_currentTile.GridX > 0)
                    _currentX--;
                break;
            case MoveDirection.Right:
                if (_currentTile.GridX < GameGrid.GridArray.GetLength(0) - 1)
                    _currentX++;
                break;
        }
        
        _currentTile = GameGrid.GridArray[_currentX, _currentY];
        transform.position = _currentTile.transform.position;
    }
    
    enum MoveDirection 
    {
        Left, 
        Right, 
        Up, 
        Down
    }
}
