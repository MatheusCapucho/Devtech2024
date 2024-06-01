using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    private float dieAnimationTimer;
    public override void EnterState(EnemyStateMachine stateMachine)
    {
        //dieAnimationTimer = tempo de anim
        //startAnimion
    }
    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        dieAnimationTimer -= Time.deltaTime;
        if (dieAnimationTimer < 0)
        {
            Die(stateMachine);
        }
    }
    public override void ExitState(EnemyStateMachine stateMachine)
    {

    }

    public override void CollisionEnter(EnemyStateMachine stateMachine, Collision2D other)
    {

    }

    public override void CollisionExit(EnemyStateMachine stateMachine, Collision2D other)
    {

    }

    public override void Die(EnemyStateMachine stateMachine)
    {
        Object.Destroy(stateMachine.gameObject);
    }
}
