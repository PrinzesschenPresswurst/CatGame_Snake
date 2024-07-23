using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPopup : MonoBehaviour
{
    [SerializeField] private Canvas gameOverCanvas;
    
    private void Start()
    {
        gameOverCanvas.gameObject.SetActive(false);
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        gameOverCanvas.gameObject.SetActive(true);
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }
    
    public void PlayAgain()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
