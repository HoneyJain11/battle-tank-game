using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletModel
{
    public int bulletDamage { get; }
    public int bulletSpeed { get; }
    
    public BulletModel (BulletScriptableObject bulletScriptableObject)
    {
        bulletDamage = bulletScriptableObject.BulletDamage;
        bulletSpeed = bulletScriptableObject.BulletSpeed;
    }
}
                