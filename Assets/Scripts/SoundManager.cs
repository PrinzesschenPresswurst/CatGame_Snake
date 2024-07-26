using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   private static SoundManager _instance;

   [SerializeField] private AudioClip winSound;
   [SerializeField] private AudioClip loseSound;
   [SerializeField] private AudioClip eatSound;
   [SerializeField] private AudioClip crashSound;
   private AudioSource _audioSource;
   
   private void Awake()
   {
      if (_instance != null)
         Destroy(this.gameObject);
      
      if (_instance == null)
      {
         _instance = this;
         DontDestroyOnLoad(this.gameObject);
      }
   }

   private void Start()
   {
      _audioSource = GetComponent<AudioSource>();
      PlayerDeathHandler.PlayerDied += OnPlayerDied;
      Treat.TreatWasCollected += OnTreatWasCollected;
      GameOverPopup.EndPopupOpened += OnEndPopupOpened;
   }

   private void OnEndPopupOpened(object sender, EventArgs e)
   {
      if (ScoreKeeper.HighScoreWasBroken)
         _audioSource.PlayOneShot(winSound);
      else 
         _audioSource.PlayOneShot(loseSound);
   }

   private void OnPlayerDied()
   {
      _audioSource.PlayOneShot(crashSound);
   }

   private void OnTreatWasCollected(object sender, Treat.TreatWasCollectedEventArgs e)
   {
      _audioSource.PlayOneShot(eatSound);
   }
   
}
