using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class EnemyPatrolling : EnemyStates
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyTankView.activeState = StateType.patrolling;
    }
    private void Update()
    {
        if (enemyTankView.playerInSightRange && !enemyTankView.playerInAttackRange)
            enemyTankView.currentState.ChangeState(enemyTankView.chasingState);
        else if (enemyTankView.playerInSightRange && enemyTankView.playerInAttackRange)
            enemyTankView.currentState.ChangeState(enemyTankView.attackingState);
        Patrolling();
    }
    public override void OnExitState()
    {
        base.OnExitState();
    }

    private void Patrolling()
    {
        if (!enemyTankView.walkPointSet)
        SearchWalkPoint();
        if (enemyTankView.walkPointSet)
        enemyTankView.navMeshAgent.SetDestination(enemyTankView.walkPoint);
        Vector3 distanceToWalkPoint = enemyTankView.transform.position - enemyTankView.walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        enemyTankView.walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-enemyTankView.walkPointRange, enemyTankView.walkPointRange);
        float randomX = Random.Range(-enemyTankView.walkPointRange, enemyTankView.walkPointRange);
        enemyTankView.walkPoint = new Vector3(enemyTankView.transform.position.x + randomX, enemyTankView.transform.position.y, enemyTankView.transform.position.z + randomZ);
        if (Physics.Raycast(enemyTankView.walkPoint, -enemyTankView.transform.up, 2f, enemyTankView.groundMask))
        enemyTankView.walkPointSet = true;

    }
}


