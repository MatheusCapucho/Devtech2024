using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CursorMovement : MonoBehaviour
{
    private Vector2 _mouseWorldPosition;
    private Camera _mainCamera;
    [SerializeField] private GameObject _player;
    private Vector2 _playerPosition;
    private Vector2 _direction;
    [SerializeField] private float _radius = 2;
    private float _angle;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(InputManager.Instance.MousePosition);
        _playerPosition = _player.transform.position;
        _direction = _mouseWorldPosition - _playerPosition;
        _direction.Normalize();
        this.transform.up = _direction;

        float x = _playerPosition.x + Mathf.Cos(_angle) * _radius;
        float y = _playerPosition.y + Mathf.Sin(_angle) * _radius;

        transform.position = new Vector2(x, y);

        _angle = Mathf.Atan2(_direction.y, _direction.x);
    }
}