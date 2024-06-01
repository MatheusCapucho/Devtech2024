using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : MonoBehaviour, IInteractable
{
    [SerializeField] private MonumentSO monumentSO;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

        if(monumentSO.Restored)
        {
            sr.sprite = monumentSO.restoredImage;
            //efeitos
        } else
        {
            sr.sprite = monumentSO.brokenImage;
        }
    }
    public void Interact(int coins)
    {
        if (monumentSO.Restored)
            return;

        if(coins > monumentSO.upgradeCost)
        {
            //Compra -= coins
            monumentSO.Restored = true;
            sr.sprite = monumentSO.restoredImage;
            //particles
            //sounds
        }

    }
}
