using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankGenericSingleton : GenericSingleton<EnemyTankGenericSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }

}
