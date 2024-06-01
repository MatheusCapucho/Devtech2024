using NavMeshPlus.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private Transform target;
    private float updatedRange;
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        target = stateMachine.PlayerTransform;
        updatedRange = stateMachine.Range;

    }
    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        stateMachine.NavMeshAgent.SetDestination(target.position);

        if (Vector3.Distance(stateMachine.transform.position, target.position) <= updatedRange)
        {
            if(stateMachine.CheckLOS())
                stateMachine.ChangeState(stateMachine.attackState);
            else
            {
                updatedRange -= 0.2f;
            }
        } else
        {
            updatedRange = stateMachine.Range;
        }

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
