using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AchievementScriptableObjectList", menuName = "ScriptableObjects/Achievement/NewAchievementListScriptableObject")]
public class AchievementScriptableObjectList : ScriptableObject
{
    public BulletFiredAchievementScriptableObject bulletsFiredAchievementScriptableObject;
    public EnemiesKilledAchievementScriptableObject enemiesKilledAchievementScriptableObject;
}