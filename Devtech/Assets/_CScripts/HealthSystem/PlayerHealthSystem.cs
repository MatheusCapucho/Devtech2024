using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthSystem : MonoBehaviour, ITakeDamage
{
    [SerializeField]
    private int maxHealth = 3;
    private int currentHealth;
    [SerializeField]
    private float invulnerabilityTime = .5f;

    [SerializeField] private MonumentSO lifeMonument;

    private bool playerCanTakeDamage = true;

    void Awake()
    {
        if (lifeMonument.Restored)
            maxHealth++;

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
        GameObject.Find("Fade").GetComponent<Fade>().FadeIn();
        StartCoroutine(DieCR());
        
    }

    IEnumerator DieCR()
    {
        // startcoroutine: animation dying, fade out , UI, changescene
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainHUB");
    }

    IEnumerator InvulnerabilityFrames()
    {
        playerCanTakeDamage = false;
        yield return new WaitForSeconds(invulnerabilityTime);
        playerCanTakeDamage = true;
    }


}
