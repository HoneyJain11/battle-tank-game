using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public TankView tankView;
    //public TankScriptableObject[] tankConfigurations;
    public TankScriptableObjectList tankList;
    public BulletScriptableObjectList bulletList;
    public Joystick RightJoystick;
    public Joystick LeftJoystick;
    private TankController tankController;
    private void Start()
    {
        StartGame();
        tankController.SetJoystick(RightJoystick, LeftJoystick);
    }
    public void StartGame()
    {
        tankController = CreateTank();
        

    }
    private void Update()
    {
        tankController.FixedUpdateTankController();
    }

    private TankController CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[1];
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        tank.TankView.SetTankControllerReference(tank);
        return tank;
    }

}
