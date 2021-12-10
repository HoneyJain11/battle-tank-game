using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel :MonoBehaviour
{
    public int Speed { get; }
    public float Health { get; }
    public TankModel(int speed ,float health)
    {
        Speed = speed;
        Health = health;
    }
    
}
