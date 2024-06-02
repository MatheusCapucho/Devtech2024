using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aniamtion_controller : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;

    // Start is called before the first frame update
    private void Awake()
    {

        _anim = GameObject.Find("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int quadrant = _cursor.GetComponent<CursorMovement>().GetQuadrant();
        if (quadrant == 1) {
            GetComponent<SpriteRenderer>().flipX = true;
        }else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //aniamtion
        var state = GetState();
        if (state == _currentState) return;
        _anim.CrossFade(state, 0, 0);
        _currentState = state;
    }


private Animator _anim;
[SerializeField] private float _magicAnimDuration = 0.1f;
[SerializeField] private float _attackAnimTime = 0.1f;

private float _lockedTill;
private int _currentState;

private static readonly int Idle = Animator.StringToHash("Isis_idle");
private static readonly int Run = Animator.StringToHash("Isis_running");
private static readonly int Magic = Animator.StringToHash("Isis_magic_front");
private static readonly int Punch = Animator.StringToHash("Isis_punch");





//aniamtion pegar stado
private int GetState()
{
    if (Time.time < _lockedTill) return _currentState;

    if (InputManager2.Attack) return LockState(Punch, _attackAnimTime);
    if (InputManager2.Skill2) return LockState(Magic, _magicAnimDuration);
    else return Idle;



}
int LockState(int s, float t)
{
    _lockedTill = Time.time + t;
    return s;
}

}

