using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour,IDamagable
{
    public GameObject Turret;
    public GameObject BulletEmitter;
    public Slider healthSlider;
    public Image healthFillImage;
    public Color maxHealthColour = Color.green;
    public Color minHealthColour = Color.red;
    public GameObject explosionPrefab;
    public bool isTankLive = false;
    public AudioSource explosionSound;
    public ParticleSystem explosionParticles;
    [HideInInspector]
    public TankController tankController;
    

    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }
 

    private void FixedUpdate()
    {
        tankController.MovementController();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            tankController.ShootBullet();
        }
    }

    public void SetTankControllerReference(TankController controller)
     {
         tankController = controller;
     }
    // to destroy tank player
    public void DestroyTank()
    {
        Destroy(gameObject);
    }
    // to destroy all gameobjects in game after palyer death
    public void DestroyGround(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    // take damage on playertank
    public void TakeDamage(int damage)
    {
        tankController.TakeDamage(damage);
    }
}