using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankGenericSingleton<T> : MonoBehaviour where T : EnemyTankGenericSingleton<T>
{
    private static T instance;
    public static T Instances { get { return instance; } }
    private void Awake()
    {
        if (instance == null)
        {
            instance = (T)this;
        }
        else
        {
            Debug.LogError("Creating a duplicate singleton");
            Destroy(this);
        }

    }
}
