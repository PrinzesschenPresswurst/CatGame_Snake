using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class AchievementTracker : MonoBehaviour
{
    [SerializeField] private GameObject achievementPop;
    [SerializeField] private TextMeshProUGUI achievementPoptext;
    public static EventHandler AchievementUnlocked;
    private void Start()
    {
        Treat.TreatWasCollected += OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied += OnPlayerDied;
        achievementPop.SetActive(false);
    }

    private void OnPlayerDied()
    {

        if (PlayerPrefs.GetInt(AchievementList.Achievement1.ToString()) == 0)
        {
            if (BodyHandler.BodyList.Count == 0)
            {
                PlayerPrefs.SetInt(AchievementList.Achievement1.ToString(), 1);
                AchievementUnlocked?.Invoke(sender:this, EventArgs.Empty);
                StartCoroutine(AchievementDisplay(AchievementList.Achievement1));
            }
        }
        
        Treat.TreatWasCollected -= OnTreatWasCollected;
        PlayerDeathHandler.PlayerDied -= OnPlayerDied;
    }

    private void OnTreatWasCollected(object sender, Treat.TreatWasCollectedEventArgs e)
    {
        string treatCountString = "treatCount";
        int treatCount = PlayerPrefs.GetInt(treatCountString);
        treatCount++;
        PlayerPrefs.SetInt(treatCountString, treatCount);
        
        if (PlayerPrefs.GetInt(AchievementList.Achievement2.ToString()) == 0)
        {
            if (treatCount == 10)
            {
                PlayerPrefs.SetInt(AchievementList.Achievement2.ToString(), 1);
                AchievementUnlocked?.Invoke(sender:this, EventArgs.Empty);
                StartCoroutine(AchievementDisplay(AchievementList.Achievement2));
            }
        }
    }

    IEnumerator AchievementDisplay(Achievement achievement)
    {
        achievementPoptext.text = "Achievement unlocked: " + achievement.achievementName;
        
        float blinkTime = 0.5f;
        achievementPop.SetActive(true);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(false);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(true);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(false);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(true);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(false);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(true);
        yield return new WaitForSeconds(blinkTime);
        achievementPop.SetActive(false);
    }
}
