using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public GameObject Turret;
    public GameObject BulletEmitter;

    private TankController tankController;

    void Start()
    {
        Debug.Log("TankView Createtd");

    }

    public void SetTankControllerReference(TankController controller)
     {
            tankController = controller;
     }
   
}