using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int maxHealth = 2;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        var statemachine = GetComponent<EnemyStateMachine>();
        statemachine.ChangeState(statemachine.deathState);
    }

}
