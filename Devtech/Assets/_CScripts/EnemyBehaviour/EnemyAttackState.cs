using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float cooldown = 0f;
    public override void EnterState(EnemyStateMachine stateMachine)
    {
            stateMachine.GetComponent<IEnemyAttack>().Attack(stateMachine.AttackDamage);
            stateMachine.Animator.Play("Attack");
    }
    public override void UpdateState(EnemyStateMachine stateMachine)
    {
        cooldown += Time.deltaTime;
        if (cooldown >= stateMachine.AttackCD)
        {
            
            cooldown = 0f;
            stateMachine.ChangeState(stateMachine.chaseState);
        }
    }
    public override void ExitState(EnemyStateMachine stateMachine)
    {

    }

    public override void CollisionEnter(EnemyStateMachine stateMachine, Collision2D other)
    {
        // vida
    }

    public override void CollisionExit(EnemyStateMachine stateMachine, Collision2D other)
    {

    }

    public override void Die(EnemyStateMachine stateMachine)
    {

    }

}
