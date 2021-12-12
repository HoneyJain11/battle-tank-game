using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public TankView tankView;
    //public TankScriptableObject[] tankConfigurations;
    public TankScriptableObjectList tankList;
    public BulletScriptableObjectList bulletList;
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        for(int i =0; i<3;i++)
        {
            CreateTank();
        }
    
    }

    private TankController CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[1];
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        return tank;
    }

}
