using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManagerUI : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    public static Action OnCoinCollected;

    private void Awake()
    {
        textComponent = GetComponentInChildren<TextMeshProUGUI>();
        textComponent.text = CurrencyManager.TotalCoins + "";
    }

    private void OnEnable()
    {
        OnCoinCollected += CoinCollected;
    }

    private void OnDisable()
    {
        OnCoinCollected -= CoinCollected;
    }



    private void CoinCollected()
    {
        textComponent.text = CurrencyManager.TotalCoins + "";
    }


}
