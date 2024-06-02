using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private int dmg = 1;

    [SerializeField] private MonumentSO damageMonument;

    private void Awake()
    {
        if(damageMonument.Restored)
        {
            dmg =2;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            collision.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(dmg);
        }
    }
}