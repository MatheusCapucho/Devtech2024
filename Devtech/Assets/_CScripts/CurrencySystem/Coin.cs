using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Transform playerTransform;
    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, Time.deltaTime * 7f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            CurrencyManager.AddCoins(1);
            CurrencyManagerUI.OnCoinCollected?.Invoke();
            Destroy(gameObject);
        }
    }

}
