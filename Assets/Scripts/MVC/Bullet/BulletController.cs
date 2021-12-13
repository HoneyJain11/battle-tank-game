using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletView BulletView { get; set; }
    public BulletModel BulletModel { get; }
    public BulletService BulletService { get; }
    public TankView TankView { get; }
    public BulletController(BulletModel bulletModel, BulletView bulletPrefab)
    {
        BulletModel = bulletModel;
        BulletView = GameObject.Instantiate<BulletView>(bulletPrefab);

    }
    public void ShotBullet()
    {
            
       BulletView = GameObject.Instantiate(BulletView, TankView.BulletEmitter.transform.position, TankView.BulletEmitter.transform.rotation);
       BulletView.transform.Rotate(Vector3.left * 90);
       Rigidbody rb;
       rb = BulletView.GetComponent<Rigidbody>();
       rb.AddForce(BulletView.transform.forward * BulletModel.bulletSpeed);
       BulletView.Destroy(BulletView, 5.0f);
    
    }
}