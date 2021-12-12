using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{
    public EnemyTankView enemyTankView;
    public TankScriptableObjectList enemyList;
    public BulletScriptableObjectList bulletList;

    private void Start()
    {
        CreateEnemyTank();
    }
  

    private EnemyTankController CreateEnemyTank()
    {
        TankScriptableObject tankScriptableObject = enemyList.tanks[1];
        EnemyTankModel model = new EnemyTankModel(tankScriptableObject);
        EnemyTankController tank = new EnemyTankController(model, enemyTankView);
        return tank;
    }
}
