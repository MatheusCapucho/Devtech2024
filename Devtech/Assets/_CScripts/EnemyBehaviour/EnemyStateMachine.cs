using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : MonoBehaviour
{

    [Header("EnemyAttributes")]
    public float Velocity = 1f;
    public float AttackCD = .5f;
    public int AttackDamage = 1;
    public float Range = .3f;
    public LayerMask ObstacleMask;

    private EnemyBaseState currentState;
    public EnemyChaseState chaseState = new EnemyChaseState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyStaggerState staggerState = new EnemyStaggerState();
    public EnemyDeathState deathState = new EnemyDeathState();

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

    public bool CheckLOS()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (playerTransform.position - transform.position).normalized, Range, ObstacleMask);
        return (hit.collider != null) ? false : true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        currentState.CollisionEnter(this, other);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        currentState.CollisionExit(this, other);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }


}
