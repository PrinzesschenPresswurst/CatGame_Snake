using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public static int Score { get; private set;}
    public static int HighScore { get; private set;}
    public static bool HighScoreWasBroken { get; private set;}
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
        Score = 0;
        HighScoreWasBroken = false;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = ""+ Score;
    }

    private void OnTreatWasCollected(object sender, EventArgs e)
    {
        Score++;
        UpdateScore();
    }

    private void OnPlayerDied()
    {
        CheckForHighScore();
        Treat.TreatWasCollected -= OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }

    private void CheckForHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScore < Score)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            HighScoreWasBroken = true;
            HighScore = Score;
        }
    }
}