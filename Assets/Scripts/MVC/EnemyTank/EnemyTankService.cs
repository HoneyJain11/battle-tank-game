using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{
    public EnemyTankView enemyTankView;
    public TankScriptableObjectList enemyList;
    public BulletScriptableObjectList bulletList;
    public EnemyTankController enemyTankController;
    public Transform[] points;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            enemyTankController = CreateEnemyTank();
            enemyTankController.SetEnemyHealthUI();
        }
        
    }

  
    private EnemyTankController CreateEnemyTank()
    {
        TankScriptableObject tankScriptableObject = enemyList.tanks[2];
        EnemyTankModel model = new EnemyTankModel(tankScriptableObject);
        EnemyTankController tank = new EnemyTankController(model, enemyTankView);
        return tank;
    }


}
