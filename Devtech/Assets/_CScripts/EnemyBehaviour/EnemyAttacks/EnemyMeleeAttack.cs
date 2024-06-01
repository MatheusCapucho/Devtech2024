using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour, IEnemyAttack
{
    [SerializeField] private GameObject attackPrefab;

    private Transform attackDirectionPivot;
    private Transform playerTransForm;

    private void Awake()
    {
        attackDirectionPivot = transform.GetChild(0).transform;
        playerTransForm = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        //ta certo - attack direction
        attackDirectionPivot.rotation = Quaternion.RotateTowards(attackDirectionPivot.rotation, Quaternion.LookRotation(Vector3.forward, (playerTransForm.position - transform.position).normalized), Time.deltaTime * 200f);
    }
    public void Attack(int dmg)
    {
        //attack animation
        playerTransForm.GetComponent<PlayerHealthSystem>().TakeDamage(dmg);

    }

}
