using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObjects/Achievement", order = 1)]
public class Achievement : ScriptableObject
{
    public string achievementName;
    public string achievementDescription;
    public int achievementValue;
}
