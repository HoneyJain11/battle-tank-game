﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankModel
{
    public int Speed { get; }
    public float Health { get; }
    public TankType TankType { get; }
    public TankModel(TankScriptableObject tankScriptableObject)
    {
        TankType = tankScriptableObject.TankType;
        Speed = (int)tankScriptableObject.Speed;
        Health = tankScriptableObject.Health;

    }
    
    
}