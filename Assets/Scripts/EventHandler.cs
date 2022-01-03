using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHandler : GenericSingleton<EventHandler>
{
    
    public event Action OnEnemyDeath;
    public event Action OnShotBullet;

    public void InvokeOnEnemyDeathEvent()
    {
        OnEnemyDeath?.Invoke();
    }

    public void InvokeOnShotBullet()
    {
        OnShotBullet?.Invoke();
    }
}
