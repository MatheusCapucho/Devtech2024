using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Deusa : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject Dialogo;


    public void Interact(int coins)
    {
        Debug.Log("Interagiu");

        Dialogo.SetActive(true);
    }

}
