using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementList : MonoBehaviour
{
    private static AchievementList _instance;
    [SerializeField] private Achievement AchievementHelper1;
    public static Achievement Achievement1 { get; private set; }
    [SerializeField] private Achievement AchievementHelper2;
    public static Achievement Achievement2 { get; private set; }
    
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
        Achievement1 = AchievementHelper1;
        Achievement2 = AchievementHelper2;
    }
}
