using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : GenericSingleton<TankController>
{
    public Joystick joystick;
    public float MoveSpeed = 2f;

    public TankModel TankModel { get; }
    public TankView TankView { get; }

    private void FixedUpdate()
    {
        float XAxisMovement = joystick.Horizontal * MoveSpeed;
        float ZAxisMovement = joystick.Vertical * MoveSpeed;

        transform.position += new Vector3(XAxisMovement, 0, ZAxisMovement);
    }

    public TankController (TankModel tankModel,TankView tankPrefab)
    {
        TankModel = tankModel;
      
        TankView = GameObject.Instantiate<TankView>(tankPrefab);
        Debug.Log("Tank View Created");
    }
}
