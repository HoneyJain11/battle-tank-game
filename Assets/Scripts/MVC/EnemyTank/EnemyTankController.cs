using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyTankController
{
    public EnemyTankModel TankModel { get; }
    public EnemyTankView TankView { get; }
    float byDefaultEnemyHealth;

    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<EnemyTankView>(tankPrefab);
        TankView.enemyTankController = this;
    }

    //to Checking Enemy Range Attack or Chaisng 
    public void EnemyTankRange()
    {
        if (TankView != null)
        {
            TankView.playerInSightRange = Physics.CheckSphere(TankView.transform.position, TankView.sightRange, TankView.playerTank);
            TankView.playerInAttackRange = Physics.CheckSphere(TankView.transform.position, TankView.attackrange, TankView.playerTank);
        }
    }
    //to set enemy tank health bar
    public void SetEnemyHealthUI()
    {
        TankView.healthSlider.value = TankModel.Health;
        TankView.healthFillImage.color = Color.Lerp(TankView.minHealthColour, TankView.maxHealthColour, TankModel.Health / byDefaultEnemyHealth);
    }
    //to take damage on enemy
    public void TakeDamage(int damage)
    {
        byDefaultEnemyHealth = TankModel.Health;
        TankModel.Health -= damage;
        SetEnemyHealthUI();
        if (TankModel.Health <= 0f && !TankView.isEnemyTankLive)
        {
            OnEnemyDeath();
            EventHandler.Instance.InvokeOnEnemyDeathEvent();
        }
    }
    //calling particle effect and to destroy objects
    public void OnEnemyDeath()
    {
        TankView.isEnemyTankLive = true;
        TankView.explosionParticles.transform.position = TankView.transform.position;
        TankView.explosionParticles.gameObject.SetActive(true);
        TankView.explosionParticles.Play();
        TankView.explosionSound.Play();
        TankView.DestroyEnemyTank();
    }

}
