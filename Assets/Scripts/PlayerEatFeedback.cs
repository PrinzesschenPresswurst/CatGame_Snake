using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerEatFeedback : MonoBehaviour
{
    [SerializeField] private ParticleSystem eatParticleSystem;
    private Animator _animator;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        PlayerMovement.PlayerAboutToMove += OnPlayerMoved;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
        Treat.TreatWasCollected += OnTreatWasCollected;
    }

    private void OnTreatWasCollected(object sender, Treat.TreatWasCollectedEventArgs e)
    {
        Instantiate(eatParticleSystem, e.TreatPosition, quaternion.identity);
    }

    private void OnPlayerMoved(PlayerInput.MoveDirection direction)
    {
        
        if (direction == PlayerInput.MoveDirection.Up) 
        {
            if (PlayerMovement.CurrentTile.GridX == FoodSpawner._spawnTile.GridX && PlayerMovement.CurrentTile.GridY == FoodSpawner._spawnTile.GridY -1)
            {
                PlayEatAnimation();
            }
        }
        if (direction == PlayerInput.MoveDirection.Down) 
        {
            if (PlayerMovement.CurrentTile.GridX == FoodSpawner._spawnTile.GridX && PlayerMovement.CurrentTile.GridY == FoodSpawner._spawnTile.GridY +1)
            {
                PlayEatAnimation();
            }
        }
        if (direction == PlayerInput.MoveDirection.Left) 
        {
            if (PlayerMovement.CurrentTile.GridX == FoodSpawner._spawnTile.GridX +1 && PlayerMovement.CurrentTile.GridY == FoodSpawner._spawnTile.GridY)
            {
                PlayEatAnimation();
            }
        }
        if (direction == PlayerInput.MoveDirection.Right) 
        {
            if (PlayerMovement.CurrentTile.GridX == FoodSpawner._spawnTile.GridX -1 && PlayerMovement.CurrentTile.GridY == FoodSpawner._spawnTile.GridY)
            {
                PlayEatAnimation();
            }
        }
    }

    private void PlayEatAnimation()
    {
        _animator.SetBool("isEating", true);
        StartCoroutine(StopEating());
    }

    IEnumerator StopEating()
    {
        yield return new WaitForSeconds(0.5f);
        _animator.SetBool("isEating", false);
    }
    

    private void OnPlayerDied()
    {
        PlayerMovement.PlayerAboutToMove -= OnPlayerMoved;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
        Treat.TreatWasCollected -= OnTreatWasCollected;
    }
    
}
