using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI resultText;
    
    
    private void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        gameOverCanvas.gameObject.SetActive(true);
        SetPopUpInfo();
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }

    private void SetPopUpInfo()
    {
        scoreText.text = "Score: " + ScoreKeeper.Score.ToString();
        highScoreText.text = "HighScore: " + ScoreKeeper.HighScore.ToString();
        if (ScoreKeeper.HighScoreWasBroken)
            resultText.text = "You broke the HighScore!";
    }
    
    public void PlayAgain()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
