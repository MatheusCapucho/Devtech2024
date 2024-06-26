using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool Attack;
    public Vector2 MousePosition { get; private set; }
    public static InputManager Instance { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _attackAction;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _attackAction = _playerInput.actions["Attack"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
        MousePosition = Mouse.current.position.ReadValue();
        Attack = _attackAction.triggered;
    }
}