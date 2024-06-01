using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Monument")]
public class MonumentSO : ScriptableObject
{
    public int upgradeCost = 0;
    public bool Restored = false;
    public Sprite brokenImage = null;
    public Sprite restoredImage = null;
}
