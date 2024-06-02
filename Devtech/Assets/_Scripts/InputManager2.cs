using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager2 : MonoBehaviour
{
    [HideInInspector] public static Vector2 Movement;
    [HideInInspector] public static bool Attack;
    [HideInInspector] public static bool Skill1;
    [HideInInspector] public static bool Skill2;
    [HideInInspector] public static bool Skill3;
    [HideInInspector] public bool Interact;
    public Vector2 MousePosition { get; private set; }
    public static InputManager2 Instance { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _interactAction;

    private InputAction _skillAction1;
    private InputAction _skillAction2;
    private InputAction _skillAction3;

    [SerializeField] private PlayerAttack _playerAttack;
    public PlayerAttack PlayerAttack => _playerAttack;

    //Animator
    private Animator _anim;
    [SerializeField] private float _magicAnimDuration = 0.1f;
    [SerializeField] private float _attackAnimTime = 0.1f;

    private float _lockedTill;
    private int _currentState;

    private static readonly int Idle = Animator.StringToHash("Isis_idle");
    private static readonly int Run = Animator.StringToHash("Isis_running");
    private static readonly int Magic = Animator.StringToHash("Isis_magic_front");
    private static readonly int Punch = Animator.StringToHash("Isis_punch");
    private void OnEnable()
    {
        if (_playerAttack == null)
        {
            _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();
        }
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
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        _playerInput = GetComponent<PlayerInput>();

        _moveAction = _playerInput.actions["Move"];
        _attackAction = _playerInput.actions["Attack"];
        _interactAction = _playerInput.actions["Interact"];
        _skillAction1 = _playerInput.actions["Skill1"];
        _skillAction2 = _playerInput.actions["Skill2"];
        _skillAction3 = _playerInput.actions["Skill3"];
        _playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();


        _anim = GameObject.Find("Player").GetComponent<Animator>();
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

        Skill1 = _skillAction1.triggered;
        Skill2 = _skillAction2.triggered;
        Skill3 = _skillAction3.triggered;

        //aniamtion
        var state = GetState();
        if (state == _currentState) return;
        _anim.CrossFade(state, 0, 0);
        _currentState = state;

       

    }
    //aniamtion pegar stado
    private int GetState()
    {
        if (Time.time < _lockedTill) return _currentState;

        if (_attackAction.triggered) return LockState(Punch, _attackAnimTime);
        if (Skill2) return LockState(Magic,_magicAnimDuration);
        if (Movement != new Vector2(0, 0)) return Run;
        else return Idle;


       
    }
    int LockState(int s, float t)
    {
        _lockedTill = Time.time + t;
        return s;
    }

}