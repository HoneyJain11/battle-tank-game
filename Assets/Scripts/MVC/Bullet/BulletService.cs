using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
    public BulletView bulletView;
    public BulletScriptableObjectList bulletList;
    private BulletController bulletController;
  
    
    public void CreateBullet(GameObject bulletEmitter)
    {
        BulletScriptableObject bulletScriptableObject = bulletList.bulletList[0];
        BulletModel bModel = new BulletModel(bulletScriptableObject);
        BulletController bullet = new BulletController(bModel, bulletView, bulletEmitter);
        bullet.BulletView.SetBulletController(bullet);
        
    }
}
