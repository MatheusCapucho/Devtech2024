using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    private Vector2 _mouseWorldPosition;
    private Camera _mainCamera;
    [SerializeField] private GameObject _player;
    private Vector2 _playerPosition;
    private Vector2 _direction;
    [SerializeField] private float _radius;
    private float _angle;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        _mouseWorldPosition = _mainCamera.ScreenToWorldPoint(InputManager2.Instance.MousePosition);
        _playerPosition = _player.transform.position;
        _direction = _mouseWorldPosition - _playerPosition;
        _direction.Normalize();
        this.transform.up = _direction;

        float x = _playerPosition.x + Mathf.Cos(_angle) * _radius;
        float y = _playerPosition.y + Mathf.Sin(_angle) * _radius;

        transform.position = new Vector2(x, y);

        _angle = Mathf.Atan2(_direction.y, _direction.x);
    }

    public int GetQuadrant()
    {
        float adjustedAngle = _angle;
        if (adjustedAngle < 0)
        {
            adjustedAngle += 2 * Mathf.PI;
        }

        if (adjustedAngle >= Mathf.PI / 4 && adjustedAngle < 3 * Mathf.PI / 4)
        {
            return 1;
        }
        else if (adjustedAngle >= 3 * Mathf.PI / 4 && adjustedAngle < 5 * Mathf.PI / 4)
        {
            return 2;
        }
        else if (adjustedAngle >= 5 * Mathf.PI / 4 && adjustedAngle < 7 * Mathf.PI / 4)
        {
            return 3;
        }
        else // adjustedAngle >= 7 * Mathf.PI / 4 or adjustedAngle < Mathf.PI / 4
        {
            return 4;
        }
    }
}