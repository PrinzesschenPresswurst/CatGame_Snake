using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private float moveTimerInterval = 1f;
    private float _moveTimer;
    private  int _currentX;
    private int _currentY;
    private bool _stopMovement;
    private static PlayerInput.MoveDirection _direction;
    
    public static Tile CurrentTile { get; private set; }
    public static event Action PlayerMoved;
    public static event Action <PlayerInput.MoveDirection> PlayerAboutToMove;
    public static event Action PlayerCrashedInWall; 
    
    private void Start()
    {
        _stopMovement = false;
        GameGrid.GridHasBeenDrawn += OnGridHasBeenDrawn;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
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

    private void FixedUpdate()
    {
        if (_stopMovement) 
            return;
        
        RunMoveTimer();
        _direction = PlayerInput.GetDirection(this.gameObject);
        //CheckIfTreatIsUpcoming();
        PlayerAboutToMove?.Invoke(_direction);
        
        if (_moveTimer < moveTimerInterval)
            return;
        
        _moveTimer = 0;
        MovePlayer(_direction);
        StartCoroutine(TellBodyPartsToMove());
    }
    
    private void RunMoveTimer()
    {
        _moveTimer += Time.deltaTime;
    }

    IEnumerator TellBodyPartsToMove()
    {
       yield return new WaitForFixedUpdate();
       PlayerMoved?.Invoke();
    }
    
    private void MovePlayer(PlayerInput.MoveDirection direction)
    {
        if (CheckDeath(direction))
        {
            if (PlayerCrashedInWall != null)
                PlayerCrashedInWall.Invoke();
            return;
        }
        
        switch (direction)
        {
            case PlayerInput.MoveDirection.Up:
                _currentY++;
                break;
            case PlayerInput.MoveDirection.Down:
                _currentY--;
                break;
            case PlayerInput.MoveDirection.Left:
                _currentX--;
                break;
            case PlayerInput.MoveDirection.Right:
                _currentX++;
                break;
        }
        CurrentTile = GameGrid.GridArray[_currentX, _currentY];
        transform.position = CurrentTile.transform.position;
    }

    private bool CheckDeath(PlayerInput.MoveDirection direction)
    { 
        switch (direction) 
        { 
            case PlayerInput.MoveDirection.Up:
                if (CurrentTile.GridY == GameGrid.GridArray.GetLength(1) - 1)
                    return true;
                break;
            case PlayerInput.MoveDirection.Down:
                if (CurrentTile.GridY == 0)
                    return true;
                break;
            case PlayerInput.MoveDirection.Left:
                if (CurrentTile.GridX == 0)
                    return true;
                break;
            case PlayerInput.MoveDirection.Right:
                if (CurrentTile.GridX == GameGrid.GridArray.GetLength(0) - 1)
                    return true;
                break;
        }
        return false;
    }

    private void OnPlayerDied()
    {
        _stopMovement = true;
        GameGrid.GridHasBeenDrawn -= OnGridHasBeenDrawn;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }
    
}
