using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AchievementMenu : MonoBehaviour
{

    [SerializeField] private GameObject AchievementPrefab;
    [SerializeField] private GameObject AchievementPrefabParent;
    
    [SerializeField] private Sprite achievementCompleteSprite;
    [SerializeField] private Sprite achievementNotCompleteSprite;
    [SerializeField] private Color achievementCompleteColor;
    [SerializeField] private Color achievementNotCompleteColor;
    private GameObject _newAchievement;
    private int _offset;


    private void Start()
    {
        _offset = -2000;
        AddAchievement(AchievementList.Achievement1);
        AddAchievement(AchievementList.Achievement2);
    }

    private void AddAchievement(Achievement achievement)
    {
        _newAchievement = Instantiate(AchievementPrefab, Vector3.down, quaternion.identity);
        _newAchievement.transform.SetParent(AchievementPrefabParent.transform, false);
        RectTransform rectTransform = _newAchievement.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, _offset);
        DisplayAchievementInfo(achievement);
        _offset += -600;
    }

    private void DisplayAchievementInfo(Achievement achievement)
    {
        TextMeshProUGUI description = null;
        TextMeshProUGUI[] textMeshProComponents = _newAchievement.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI textMeshProComponent in textMeshProComponents)
        {
            if (textMeshProComponent.gameObject.name == "Header")
            {
                textMeshProComponent.text = achievement.achievementName;
            }
            if (textMeshProComponent.gameObject.name == "Description")
            {
                description = textMeshProComponent;
            }
        }
        
        Image image = null;
        Image[] images = _newAchievement.GetComponentsInChildren<Image>();
        foreach (var pic  in images)
        {
            if (pic.gameObject.name == "Image")
            {
                image = pic;
                break;
            }
        }
        
        int achievement1Complete = PlayerPrefs.GetInt(achievement.ToString());
        if (achievement1Complete == 0)
        {
            image.sprite = achievementNotCompleteSprite;
            description.text = "????";
            description.color = achievementNotCompleteColor;
        }

        else
        {
            image.sprite = achievementCompleteSprite;
            description.text = achievement.achievementDescription;
            description.color = achievementCompleteColor;
        }
    }
}
