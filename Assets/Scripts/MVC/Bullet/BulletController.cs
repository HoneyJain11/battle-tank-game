using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController
{
    public BulletView BulletView { get; set; }
    public BulletModel BulletModel { get; }
    public BulletService BulletService { get; }

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
    // to give damage when bullet collide 
    public void OnCollisionEnter(Collider other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if(damagable != null)
        {
            DoDamage(damagable, other);
        }
        PlayParticleEffects();
        PlayExplosionAudio();
        BulletView.DestroyBullet();

    }
    // to give damage when bullet collide with rigidbody
    private void DoDamage(IDamagable damagable, Collider other)
    {
        Rigidbody targetRb = other.GetComponent<Rigidbody>();
        if(targetRb)
        {
            damagable.TakeDamage(BulletModel.bulletDamage);
        }
    }
    // play particle effect after bullet collide with objects
    private void PlayParticleEffects()
    {
        ParticleSystem explosionParticles = BulletView.explosionParticles;
        explosionParticles.transform.parent = null;
        explosionParticles.Play();
        BulletView.DestroyParticleSystem(explosionParticles);
    }

    // play audio when bullet collide with object
    private void PlayExplosionAudio()
    {
        BulletView.explosionAudio.Play();
    }




}