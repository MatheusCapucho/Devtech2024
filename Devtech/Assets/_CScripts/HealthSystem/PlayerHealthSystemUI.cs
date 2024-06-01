using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSystemUI : MonoBehaviour
{
    public static Action<int> OnHealthChanged;
    private Image[] images;

    [SerializeField] private Sprite lifeSprite;
    [SerializeField] private Sprite damageSprite;
    [SerializeField] private MonumentSO lifeMonument;

    private void Awake()
    {

        if (lifeMonument.Restored)
        {
            transform.GetChild(3).gameObject.SetActive(true);
        }
        images = GetComponentsInChildren<Image>();

        foreach (Image image in images)
        {
            image.sprite = lifeSprite;
        }
      
    }

    private void OnEnable()
    {
        OnHealthChanged += HealthChanged;
    }
    private void OnDisable()
    {
        OnHealthChanged -= HealthChanged;
    }

    private void HealthChanged(int health)
    {
        for (int i = 0; i < images.Length; i++)
        {
            if(health > i)
                images[i].sprite = lifeSprite;
            else 
                images[i].sprite = damageSprite;
        }
    }
}
