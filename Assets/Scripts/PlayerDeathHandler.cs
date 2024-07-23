using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
   public static event Action PlayerDied ;

   private void Start()
   {
      PlayerMovement.PlayerCrashedInWall += OnPlayerCrashedInWall;
      PlayerCollisionHandler.PlayerCrashedInBody += OnPlayerCrashedInBody;
   }

   private void OnPlayerCrashedInBody()
   {
      SetPlayerDead();
   }
   private void OnPlayerCrashedInWall()
   {
      SetPlayerDead();
   }

   private void SetPlayerDead()
   {
      PlayerDied?.Invoke();
   }
   
}
