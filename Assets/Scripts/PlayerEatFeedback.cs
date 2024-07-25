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
    
    private void Start()
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
        Dictionary<PlayerInput.MoveDirection, (int x, int y)> offsets =
            new Dictionary<PlayerInput.MoveDirection, (int x, int y)>()
            {
                { PlayerInput.MoveDirection.Up, (0, -1) }, 
                { PlayerInput.MoveDirection.Down, (0, +1) },
                { PlayerInput.MoveDirection.Left, (+1, 0) },
                { PlayerInput.MoveDirection.Right, (-1, 0) },
            };
        
        if (offsets.TryGetValue(direction, out var offset))
        {
            int spawnTileGridX = FoodSpawner._spawnTile.GridX + offset.x;
            int spawnTileGridY = FoodSpawner._spawnTile.GridY + offset.y;
            
            if ( PlayerMovement.CurrentTile.GridX == spawnTileGridX && PlayerMovement.CurrentTile.GridY == spawnTileGridY)
                PlayEatAnimation();
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
