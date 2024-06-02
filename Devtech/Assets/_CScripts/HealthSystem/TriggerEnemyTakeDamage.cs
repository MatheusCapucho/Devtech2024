using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private MonumentSO damageMonument;
    private int damage = 1;

    private void Awake()
    {
        if (damageMonument.Restored)
            damage++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("DAMAGEEEE");
            GetComponent<ITakeDamage>().TakeDamage(damage);
        }
    }
  
}
