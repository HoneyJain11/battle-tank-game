﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletView BulletView { get; set; }
    public BulletModel BulletModel { get; }
    public BulletService BulletService { get; }
    public TankView TankView { get; }
    public BulletController(BulletModel bulletModel, BulletView bulletPrefab, GameObject bulletEmitter)
    {
        BulletModel = bulletModel;
        BulletView = GameObject.Instantiate<BulletView>(bulletPrefab, bulletEmitter.transform.position , bulletEmitter.transform.rotation);
        ShotBullet();
        
    }
    public void ShotBullet()
    {
       Debug.Log("Shot Function call");
       Rigidbody rb;
       rb = BulletView.GetComponent<Rigidbody>();
       rb.AddForce(BulletView.transform.forward * BulletModel.bulletSpeed);
   
    }

    public void OnCollisionEnter(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(BulletView.transform.position, BulletModel.explosionRadius, BulletView.tankMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody targetRb = colliders[i].GetComponent<Rigidbody>();
            if (!targetRb)
                continue;
            targetRb.AddExplosionForce(BulletModel.bulletSpeed, BulletView.transform.position, BulletModel.explosionRadius);
            EnemyTankView targetEenemy = targetRb.GetComponent<EnemyTankView>();
            if (!targetEenemy)
                continue;
            float damage = CalculateDamage(targetRb.position);
            Debug.Log("Connect with Enemytank");
           
        }
        PlayParticleEffects();
        PlayExplosionAudio();
        BulletView.DestroyBullet();

    }

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - BulletView.transform.position;

        float explosionDistance = explosionToTarget.magnitude;
        float relativeDistance = (BulletModel.explosionRadius - explosionDistance) / BulletModel.explosionRadius;

        float damage = relativeDistance * BulletModel.bulletDamage;
        damage = Mathf.Max(0f, damage);

        return damage;
    }


    private void PlayParticleEffects()
    {
        ParticleSystem explosionParticles = BulletView.explosionParticles;
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        BulletView.DestroyParticleSystem(explosionParticles);
    }


    private void PlayExplosionAudio()
    {
        BulletView.explosionAudio.Play();
    }




}