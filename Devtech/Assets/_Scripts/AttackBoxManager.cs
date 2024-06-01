using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoxManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _attackBoxes = new List<GameObject>();
    [SerializeField] private int _attackBoxActiveFrames = 6; // Set this in the inspector

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
            float timeInSeconds = _attackBoxActiveFrames / (1.0f / Time.deltaTime);
            Invoke("DeactivateHitBox", timeInSeconds);
        }
    }

    private void DeactivateHitBox()
    {
        foreach (GameObject box in _attackBoxes)
        {
            box.SetActive(false);
        }
    }
}