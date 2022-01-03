using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementSystem : GenericSingleton<AchievementSystem>
{
    [SerializeField] private AchievementScriptableObjectList achievementList;
    [SerializeField] private GameObject AchievementPanel;
    [SerializeField] private TextMeshProUGUI AchievementName;
    [SerializeField] private TextMeshProUGUI AchievementInfo;
    private int currentBulletFiredLevel;
    private int currentEnemiesKilledLevel;
    private void Start()
    {
        currentBulletFiredLevel = 0;
        currentEnemiesKilledLevel = 0;
       
    }

    public void EnemyDeathCount(int enemyKilledCount)
    {
        for (int i = 0; i < achievementList.enemiesKilledAchievementScriptableObject.achievements.Length; i++)
        {
            if (i != currentEnemiesKilledLevel) continue;

            if (achievementList.enemiesKilledAchievementScriptableObject.achievements[i].requirement == enemyKilledCount)
            {
                UnlockAchievement(achievementList.enemiesKilledAchievementScriptableObject.achievements[i].name, achievementList.enemiesKilledAchievementScriptableObject.achievements[i].info);
                currentEnemiesKilledLevel = i + 1;
            }
            break;
        }
    }

    public void BulletsFiredCount(int bulletCount)
    {
        for (int i = 0; i < achievementList.bulletsFiredAchievementScriptableObject.achievements.Length; i++)
        {
            if (i != currentBulletFiredLevel) continue;
        
            if (achievementList.bulletsFiredAchievementScriptableObject.achievements[i].requirement == bulletCount)
            {
                UnlockAchievement(achievementList.bulletsFiredAchievementScriptableObject.achievements[i].name, achievementList.bulletsFiredAchievementScriptableObject.achievements[i].info);
                currentBulletFiredLevel = i + 1;
            }
            break;
        }
    }

    private async void UnlockAchievement(string name, string info)
    {
        this.AchievementName.text = name;
        this.AchievementInfo.text = info;
        AchievementPanel.gameObject.SetActive(true);
        await new WaitForSeconds(5);
        AchievementPanel.gameObject.SetActive(false);
    }

   
}
