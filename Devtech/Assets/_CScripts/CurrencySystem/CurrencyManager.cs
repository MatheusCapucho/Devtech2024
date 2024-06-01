using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager
{
    public static int TotalCoins => _totalCoins;
    private static int _totalCoins = 0;
    
    public static void AddCoins(int amount)
    {
        _totalCoins += amount;
    }

    public static void RemoveCoins(int amount)
    {
        _totalCoins -= amount;
        if (_totalCoins <= 0)
            _totalCoins = 0;
    }
    

}
