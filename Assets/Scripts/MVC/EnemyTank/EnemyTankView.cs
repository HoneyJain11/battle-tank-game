using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour, IDamagable
{
    public GameObject Turret;
    public GameObject BulletEmitter;
    public float turretRotationRate;
    public float fireTime;
    public Slider healthSlider;
    public Image healthFillImage;
    public Color maxHealthColour = Color.green;
    public Color minHealthColour = Color.red;
    public GameObject explosionPrefab;
    public bool isEnemyTankLive = false;
    public AudioSource explosionSound;
    public ParticleSystem explosionParticles;
    public LayerMask groundMask, playerTank;
    public NavMeshAgent navMeshAgent;
    public Vector3 walkPoint;
    public float walkPointRange;
    public bool walkPointSet;
    public float sightRange;
    public float attackrange;
    public bool playerInSightRange;
    public bool playerInAttackRange;
    public Transform tankPlayer;
    public bool isAttacked;
    public EnemyTankController enemyTankController;
    [HideInInspector]
    public EnemyStates currentState;
    public StateType activeState;
    [SerializeField] private StateType baseState;
    public EnemyPatrolling patrollingState;
    public EnemyChasing chasingState;
    public EnemyAttacking attackingState;


    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
        UpdateAwake();
        

    }
    void Start()
    {
        StartState();

    }
    public void DestroyEnemyTank()
    {
     
        Destroy(gameObject);
    }

    public void DestroyGameObjects()
    {
        DestroyPlayer();
    }

    private async void DestroyPlayer()
    {
        await new WaitForSeconds(2f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<TankView>().tankController.OnDeath();

    }

    public void UpdateAwake()
    {
        tankPlayer = TankService.Instance.tankView.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        enemyTankController.TakeDamage(damage);
    }

   

    private void StartState()
    {
        switch (baseState)
        {
            case StateType.patrolling:
                {
                    currentState = patrollingState;
                    break;
                }
            case StateType.Attacking:
                {
                    currentState = attackingState;
                    break;
                }
            case StateType.chasing:
                {
                    currentState = chasingState;
                    break;
                }
            default:
                {
                    currentState = null;
                    break;
                }
        }
        currentState.OnEnterState();
    }

}
