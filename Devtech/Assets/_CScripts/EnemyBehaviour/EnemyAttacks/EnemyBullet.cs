using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] private int damage = 1;

    private ParticleSystem particles;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        particles = GetComponent<ParticleSystem>();
       
    }
    void Start()
    {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealthSystem>().TakeDamage(damage);
            DestroyProjectile();
        }

        if (collision.gameObject.CompareTag("Tooltip"))
            DestroyProjectile();

    }

    private void DestroyProjectile()
    {
        particles.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        Destroy(this.gameObject, particles.main.duration);
    }
}
