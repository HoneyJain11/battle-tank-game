using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankModel
{
    public int Speed { get; }
    public float Health { get; }
    public TankType TankType { get; }
    public Vector3 walkPoint { get; set; }
    //public float walkPointRange { get; set; }
    //public bool walkPointSet { get; set; }
    public EnemyTankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;
        //walkPointSet = false;
        //walkPointRange =;

    }
}
