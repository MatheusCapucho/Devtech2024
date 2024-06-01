using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedAttack : MonoBehaviour, IEnemyAttack
{
    private Transform attackDirectionPivot;
    private Transform playerTransForm;

    [SerializeField] private GameObject bulletPrefab;

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
        Instantiate(bulletPrefab, attackDirectionPivot.GetChild(0).transform.position, attackDirectionPivot.rotation);

    }
}

