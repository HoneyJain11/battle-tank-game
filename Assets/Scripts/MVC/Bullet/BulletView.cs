using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public ParticleSystem explosionParticles;
    public AudioSource explosionAudio;
    public LayerMask tankMask;

    public void SetBulletController(BulletController controller)
    {
        bulletController = controller;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        bulletController.OnCollisionEnter(other);
    }
    // to destroy bullet particle effect 
    public void DestroyParticleSystem(ParticleSystem particles)
    {
        Destroy(particles.gameObject, particles.main.duration);
    }
    //to destroy bullet object
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
