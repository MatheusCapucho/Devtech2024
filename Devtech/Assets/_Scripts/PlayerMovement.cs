using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    private Vector2 _movement;
    private Rigidbody2D _rb;
    [SerializeField] private MonumentSO speedMonument;
    private SpriteRenderer _sprRend;

    // Start is called before the first frame update
    private void Awake()
    {
        if (speedMonument.Restored)
            _speed++;
        _rb = GetComponent<Rigidbody2D>();
        _sprRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movement.Set(InputManager2.Movement.x, InputManager2.Movement.y);

        _rb.velocity = _movement * _speed;

        
    }
}