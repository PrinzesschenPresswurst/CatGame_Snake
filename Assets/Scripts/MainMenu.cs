using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas tutorialCanvas;
    [SerializeField] private Canvas menuCanvas;
    private int _tutorialInt;
    
    private void Start()
    {
        tutorialCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
        Debug.Log("int: "+ _tutorialInt);
    }
    
    public void PressPlayButton()
    {
        _tutorialInt = PlayerPrefs.GetInt("HasSeenTutorial");
        
        if (_tutorialInt == 0)
        {
            tutorialCanvas.gameObject.SetActive(true);
            menuCanvas.gameObject.SetActive(false);
        }

        else
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene +1);
        }
    }

    public void PressDontShowTutorialAgain()
    {
        PlayerPrefs.SetInt("HasSeenTutorial", 1);
    }

    public void PressGotItButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene +1);
    }
    
    public void PressMenuButton()
    {
        Debug.Log("Menu button pressed");
        PlayerPrefs.DeleteAll();
    }
}
