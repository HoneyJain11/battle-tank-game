﻿using UnityEngine;

[CreateAssetMenu(fileName = "BulletScriptableObject", menuName = "ScriptableObjects/NewBulletScriptableObject")]
public class BulletScriptableObject : ScriptableObject
{
    public BulletType BulletType;
    public int Damage;
}


[CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletListScriptableObject")]
public class BulletScriptableObjectList : ScriptableObject
{
    public BulletScriptableObject[] bulletList;
}