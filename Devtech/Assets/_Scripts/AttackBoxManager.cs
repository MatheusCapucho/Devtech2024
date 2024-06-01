using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _attackBoxes = new List<GameObject>();

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void ActivateHitBox(Component sender, object data)
    {
        Debug.Log("Ativou a caixa de colisão" + data);
        if (data is int)
        {
            _attackBoxes[(int)data].SetActive(true);
        }
    }
}