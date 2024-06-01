using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private Transform target;
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        target = stateMachine.PlayerTransform;

    }
    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.SetDestination(target.position);
    }     
    public override void ExitState(EnemyStateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.SetDestination(stateMachine.transform.position);
    }

    public override void CollisionEnter(EnemyStateMachine stateMachine, Collision2D other)
    {
        
    }

    public override void CollisionExit(EnemyStateMachine stateMachine, Collision2D other)
    {
        
    }

    public override void Die(EnemyStateMachine stateMachine)
    {
        
    }

}
