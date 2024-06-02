using UnityEngine;

public class BaseSkill : ScriptableObject
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private float cooldownTime;

    public virtual void Activate()
    { }
}