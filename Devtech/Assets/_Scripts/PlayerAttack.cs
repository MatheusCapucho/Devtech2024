using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    private Vector2 _cursorPosition;

    [Header("Events")]
    public GameEvent OnAttackPerformed;

    private void Awake()
    {
        _cursorPosition = _cursor.transform.position;
    }

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (InputManager2.Attack)
        {
        }
    }

    public void AttackPerformed()
    {
        int quadrant = _cursor.GetComponent<CursorMovement>().GetQuadrant();
        Debug.Log("Quadrant: " + quadrant);
        OnAttackPerformed.Raise(this, quadrant);
    }
}