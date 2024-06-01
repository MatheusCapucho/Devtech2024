using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    private Vector2 _cursorPosition;

    private void Awake()
    {
        _cursorPosition = _cursor.transform.position;
        _cursor.GetComponent<CursorMovement>().GetQuadrant();
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}