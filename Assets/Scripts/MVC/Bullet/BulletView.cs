using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;

    public void SetBulletController(BulletController controller)
    {
        bulletController = controller;
    }
    void Start()
    {
        Debug.Log("Bullet is Created"); 
    }

}
