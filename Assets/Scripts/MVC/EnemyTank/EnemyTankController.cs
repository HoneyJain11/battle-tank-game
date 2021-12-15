using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankController
{
    public EnemyTankModel TankModel { get; }
    public EnemyTankView TankView { get; }
    //public EnemyTankService EnemyTankService { get; set; }
     int current =0;

    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<EnemyTankView>(tankPrefab);
    }

    public void UpdateEnemyTankPatrolling()
    {
        //Debug.Log(EnemyTankService.Instance.points[current].transform.position);
        if (TankView.transform.position != EnemyTankService.Instance.points[current].transform.position)
        {
            TankView.transform.position = Vector3.MoveTowards(TankView.transform.position, EnemyTankService.Instance.points[current].transform.position, TankModel.Speed * Time.deltaTime); ;
        }
        else
            current = (current + 1) % EnemyTankService.Instance.points.Length;

    }



}
