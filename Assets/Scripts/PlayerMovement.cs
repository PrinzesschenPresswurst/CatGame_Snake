using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveTimerInterval = 1f;
    private float _moveTimer;
    private int _currentX;
    private int _currentY;
    private MoveDirection _direction;
    
    public Tile CurrentTile { get; private set; }
    public static event Action PlayerMoves;
    
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
        CurrentTile = GameGrid.GridArray[0, 0];
        transform.position = CurrentTile.transform.position;
    }

    private void Update()
    {
        RunMoveTimer();
        GetDirection();
        
        if (_moveTimer < moveTimerInterval)
            return;
        _moveTimer = 0;
        
        MovePlayer(_direction);
        
        if (PlayerMoves != null) //MoveBody
            PlayerMoves.Invoke();
    }
    
    private void RunMoveTimer()
    {
        _moveTimer += Time.deltaTime;
    }
    
    private void GetDirection()
    {
        //for keys
        _direction = GetMoveDirectionFromKeys();

        //for touch
        if (Input.touchCount > 0)
        {
            float angle = GetTouchAngle();
            _direction = GetDirectionFromTouch(angle);
        }
    }

    private float GetTouchAngle() 
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = new Vector2(touch.position.x, touch.position.y);
        Vector2 point = Camera.main.ScreenToWorldPoint (touchPos);
        Vector2 ownPos = transform.position;
        
        Vector2 touchDirection = point - ownPos;
        Vector2 rightVector = new Vector2(1, ownPos.y);
        return Vector2.SignedAngle(touchDirection, rightVector);
    }

    private MoveDirection GetDirectionFromTouch(float angle)
    {
        if (angle > -45 && angle < 45)
            return MoveDirection.Up;
            
        if (angle > -135 && angle < 45)
            return MoveDirection.Left;
        
        if (angle > 45 && angle < 135)
            return MoveDirection.Right;
        
        if (angle > 135 && angle < 180)
            return MoveDirection.Down;
        if (angle > -135 && angle < -180)
            return MoveDirection.Down;
        
        return _direction;
    }
    
    private MoveDirection GetMoveDirectionFromKeys()
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

    private void MovePlayer(MoveDirection direction)
    {
        switch (direction)
        {
            case MoveDirection.Up:
                if (CurrentTile.GridY < GameGrid.GridArray.GetLength(1) - 1)
                    _currentY++;
                break;
            case MoveDirection.Down:
                if (CurrentTile.GridY > 0)
                    _currentY--;
                break;
            case MoveDirection.Left:
                if (CurrentTile.GridX > 0)
                    _currentX--;
                break;
            case MoveDirection.Right:
                if (CurrentTile.GridX < GameGrid.GridArray.GetLength(0) - 1)
                    _currentX++;
                break;
        }
        
        CurrentTile = GameGrid.GridArray[_currentX, _currentY];
        transform.position = CurrentTile.transform.position;
    }
    
    
    private enum MoveDirection 
    {
        Left, 
        Right, 
        Up, 
        Down
    }
}
