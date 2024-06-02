using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager2 : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool Attack;
    [HideInInspector] public bool Interact;
    public Vector2 MousePosition { get; private set; }
    public static InputManager2 Instance { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _interactAction;
    [SerializeField] private PlayerAttack _playerAttack;
    public PlayerAttack PlayerAttack => _playerAttack;

    private void OnEnable()
    {
        _attackAction.performed += AttackActionPerformed;
    }

    private void OnDisable()
    {
        _attackAction.performed -= AttackActionPerformed;
    }

    private void AttackActionPerformed(InputAction.CallbackContext obj)
    {
        if (_playerAttack != null)
        {
            _playerAttack.AttackPerformed();
            Debug.Log("atacou");
        }
    }

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
        _interactAction = _playerInput.actions["Interact"];
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    private void Start()
    {
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        if(_playerAttack == null) 
        { 
            _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        }
        Movement = _moveAction.ReadValue<Vector2>();
        MousePosition = Mouse.current.position.ReadValue();
       
        Interact = _interactAction.triggered;
    }
}