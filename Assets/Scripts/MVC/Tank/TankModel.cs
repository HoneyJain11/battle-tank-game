using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public int Speed { get; }
    public float Health { get; set; }
    public TankType TankType { get; }
    public float RotationRate { get; }
    public float TurretRotationRate;
    public int BulletCount { get; set; }
    public int EnemiesKilledCount { get; set; }
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        RotationRate = tankScriptableObject.RotationRate;
        TurretRotationRate = tankScriptableObject.TurretRotationRate;
        BulletCount = tankScriptableObject.BulletCount;
        EnemiesKilledCount = tankScriptableObject.EnemiesKilledCount;
    }
    
    
}
    