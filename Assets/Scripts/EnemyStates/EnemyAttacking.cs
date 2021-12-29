using UnityEngine;
using System.Collections;
using System;

public class EnemyAttacking : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyTankView.activeState = StateType.Attacking;
    }
    private void Update()
    {
        if (!enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange)
         enemyTankView.currentState.ChangeState(enemyTankView.patrollingState);

        else if (enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange)
         enemyTankView.currentState.ChangeState(enemyTankView.chasingState);
        AttackPlayer();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    private async void AttackPlayer()
    {
        enemyTankView.navMeshAgent.SetDestination(enemyTankView.transform.position);
        Vector3 forward = enemyTankView.Turret.transform.TransformDirection(Vector3.forward);
        Vector3 desiredRotation = new Vector3(0, 0, 0);

        if (!Physics.Raycast(enemyTankView.transform.position, forward, enemyTankView.attackrange, enemyTankView.playerTank))
        {
            Vector3 targetDirection = enemyTankView.tankPlayer.position - enemyTankView.Turret.transform.position;
            float angle = Vector3.SignedAngle(targetDirection, enemyTankView.Turret.transform.forward, Vector3.up);

            if (angle < 0)
            {
                desiredRotation = Vector3.up * enemyTankView.turretRotationRate * Time.deltaTime;
            }
            else if (angle > 0)
            {
                desiredRotation = -Vector3.up * enemyTankView.turretRotationRate * Time.deltaTime;
            }

            enemyTankView.Turret.transform.Rotate(desiredRotation, Space.Self);
        }
        else if (!enemyTankView.isAttacked)
        {
            enemyTankView.isAttacked = true;
            ShotEnemyBullet();
            await new WaitForSeconds(enemyTankView.fireTime);
            ResetAttack();
        }

    }

    private void ShotEnemyBullet()
    {
        BulletService.Instance.CreateBullet(enemyTankView.BulletEmitter);
    }

    private void ResetAttack()
    {
        enemyTankView.isAttacked = false;
    }
}
