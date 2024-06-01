using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int maxHealth = 3;
    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        PlayerHealthSystemUI.OnHealthChanged?.Invoke(currentHealth);
        if (currentHealth <= 0)
            Die();
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;
        
        PlayerHealthSystemUI.OnHealthChanged?.Invoke(currentHealth);
    }

    private void Die()
    {
        // die
        // startcoroutine: animation dying, fade out , UI, changescene
    }



}
