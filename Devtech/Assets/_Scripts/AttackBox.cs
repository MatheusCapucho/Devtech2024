using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy");
            collision.gameObject.GetComponent<EnemyHealthSystem>().TakeDamage(1);
        }
    }
}