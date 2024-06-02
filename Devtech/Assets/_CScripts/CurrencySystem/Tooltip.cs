using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    [SerializeField] private string tooltipText;
    [SerializeField] private string tooltipCost;

    private void Awake()
    {
        textComponent =  GameObject.Find("Tooltip").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Tooltip"))
        {
            textComponent.text = tooltipText + "\n" + tooltipCost;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textComponent.text = "";
        }
    }

}
