using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public static bool MoreLifeMonument = false;
    public static bool MoreSpeedMonument = false;
    public static bool MoreDamageMonument = false;
    public static bool MoreCooldownMonument = false;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else if (_instance != this)
        {
            Destroy(this);
        }
    }

}
