using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
   public static bool PlayerIsDead { get; private set; }

   private void Start()
   {
      PlayerIsDead = false;
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
      PlayerIsDead = true;
   }
   
}
