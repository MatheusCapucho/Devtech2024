using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{

    private EnemyBaseState currentState;
    private EnemyChaseState chaseState = new EnemyChaseState();
    private EnemyAttackState attackState = new EnemyAttackState();
    private EnemyStaggerState staggerState = new EnemyStaggerState();
    private EnemyDeathState deathState = new EnemyDeathState();

    private Transform playerTransform;
    private NavMeshAgent navMeshAgent;
    public Transform PlayerTransform => playerTransform;
    public NavMeshAgent NavMeshAgent => navMeshAgent;


    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateUpAxis = false;
        navMeshAgent.updateRotation = false;
    }
    private void Start()
    {
        currentState = chaseState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void ChangeState(EnemyBaseState nextState)
    {
        currentState.ExitState(this);
        currentState = nextState;
        currentState.EnterState(this);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        currentState.CollisionEnter(this, other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        currentState.CollisionExit(this, other);
    }


}
