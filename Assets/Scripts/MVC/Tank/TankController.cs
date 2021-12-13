﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    public TankModel TankModel { get; }
    public TankView TankView { get; }
    private Joystick rightJoystick;
    private Joystick leftJoystick;
    private Rigidbody rbTank;
    private Camera camera;
    //private GameObject BulletEmitter;
    private BulletController bulletController;
   

    public TankController(TankModel tankModel, TankView tankPrefab)
    {
        TankModel = tankModel;

        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        rbTank = TankView.GetComponent<Rigidbody>();
    }

    public void SetCamera(Camera cameraSet)
    {
        camera = cameraSet;
        camera.transform.SetParent(TankView.Turret.transform);
    }

    public void SetJoystick(Joystick rtJoystick ,Joystick ltJoystick)
    {
        rightJoystick = rtJoystick;
        leftJoystick = ltJoystick;
    }

    public void UpdateShootBullet()
    {
       BulletService.Instance.CreateBullet(TankView.BulletEmitter);
       //BulletController.Instance.ShotBullet();
        
    }

    public void FixedUpdateTankController()
    {
        if (rbTank)
        {
            if (leftJoystick.Vertical != 0)
            {
                ForwardMovement();
            }
            if (leftJoystick.Horizontal != 0)
            {
                RotationMovement();
            }
        }

        if (true)
        {
            if (rightJoystick.Horizontal != 0)
            {
                TurretRotationMovement();
            }
        }

    }

    private void TurretRotationMovement()
    {
        Vector3 turrentrotation = Vector3.up * rightJoystick.Horizontal * TankModel.TurretRotationRate * Time.deltaTime;

        TankView.Turret.transform.Rotate(turrentrotation, Space.Self);
    }

    private void RotationMovement()
    {
        Quaternion rotation = rbTank.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * TankModel.RotationRate * Time.deltaTime);

        rbTank.MoveRotation(rotation);
    }

    private void ForwardMovement()
    {
        Vector3 moveforward = rbTank.transform.position + (leftJoystick.Vertical * rbTank.transform.forward * TankModel.Speed * Time.deltaTime);
        rbTank.MovePosition(moveforward);
    }
}
