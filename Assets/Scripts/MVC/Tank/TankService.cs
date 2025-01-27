﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    public Camera Camera;
    public TankView tankView;
    public TankScriptableObjectList tankList;
    public BulletScriptableObjectList bulletList;
    public Joystick RightJoystick;
    public Joystick LeftJoystick;
    public TankController tankController;
    
   
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        tankController = CreateTank();
        tankController.SetJoystick(RightJoystick, LeftJoystick);
        tankController.SetCamera(Camera);
        tankController.SetHealthUI();
        tankController.SubscribeEvent();
    }

    public TankController CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[1];
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        tank.TankView.SetTankControllerReference(tank);
        return tank;
    }

}
