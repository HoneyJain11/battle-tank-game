using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankGenericSingleton<T> : MonoBehaviour where T : PlayerTankGenericSingleton<T>
{
    private static T instance;
    public static T Instance { get { return instance; } }
    private void Awake()
    {
        if(instance == null)
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
