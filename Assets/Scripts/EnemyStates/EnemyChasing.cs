using UnityEngine;
using System.Collections;
using System;

public class EnemyChasing : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyTankView.activeState = StateType.chasing;
    }
    private void Update()
    {
        if (!enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange)
            enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
        else if (enemyTankView.playerInSightRange && enemyTankView.playerInAttackRange)
            enemyTankView.currentState.ChangeState(enemyTankView.attackingState);
        ChasePlayer();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void ChasePlayer()
    {
        
        if (!enemyTankView.tankPlayer)
        {
            enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);
            return;
        }
        enemyTankView.navMeshAgent.SetDestination(enemyTankView.tankPlayer.position);
        
        if (Mathf.Abs(Vector3.SignedAngle(enemyTankView.transform.forward, enemyTankView.Turret.transform.forward, Vector3.up)) > 1)
        {
            enemyTankView.Turret.transform.Rotate(GetRequiredTurretRotation(), Space.Self);
        }
    }

    // Returns desired rotation of enemy tank turret.
    private Vector3 GetRequiredTurretRotation()
    {
        Vector3 desiredRotation = new Vector3(0, 0, 0);

        float angle = Vector3.SignedAngle(enemyTankView.transform.forward, enemyTankView.Turret.transform.forward, Vector3.up);

        // Decides the direction of rotaion of turret. // Whether to rotate from left side or right side.
        if (angle < 0)
        {
            desiredRotation = Vector3.up * enemyTankView.turretRotationRate * Time.deltaTime;
        }
        else if (angle > 0)
        {
            desiredRotation = -Vector3.up * enemyTankView.turretRotationRate * Time.deltaTime;
        }

        return desiredRotation;
    }
}

