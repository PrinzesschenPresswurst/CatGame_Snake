using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int _score;
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
        _score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = ""+ _score;
    }

    private void OnTreatWasCollected()
    {
        _score++;
        UpdateScore();
    }

    private void OnPlayerDied()
    {
        Treat.TreatWasCollected -= OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }
    
}