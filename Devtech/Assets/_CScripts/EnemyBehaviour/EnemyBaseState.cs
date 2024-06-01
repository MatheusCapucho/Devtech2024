using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateMachine stateMachine);
    public abstract void UpdateState(EnemyStateMachine stateMachine);
    public abstract void ExitState(EnemyStateMachine stateMachine);
    public abstract void CollisionEnter(EnemyStateMachine stateMachine, Collision2D other);
    public abstract void CollisionExit(EnemyStateMachine stateMachine, Collision2D other);
    public abstract void Die(EnemyStateMachine stateMachine);
}
