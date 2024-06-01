using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int maxHealth = 3;
    private int currentHealth;
    [SerializeField]
    private float invulnerabilityTime = .5f;

    private bool playerCanTakeDamage = true;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (!playerCanTakeDamage)
            return;

        StartCoroutine(InvulnerabilityFrames());
        currentHealth -= amount;
        PlayerHealthSystemUI.OnHealthChanged?.Invoke(currentHealth);
        Debug.Log(currentHealth + " current ");
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

    IEnumerator InvulnerabilityFrames()
    {
        playerCanTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTime);
        playerCanTakeDamage = true;
    }


}
