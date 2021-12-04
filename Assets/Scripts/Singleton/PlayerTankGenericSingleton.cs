using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankGenericSingleton : GenericSingleton <PlayerTankGenericSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }

}
