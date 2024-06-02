using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // public static SkillManager Instance { get; private set; }
    [Header("Events")]
    public GameEvent OnSkillChangedPerformed;

    [SerializeField] private List<BaseSkill> _skillOffer = new();
    private ArrayList _skillInfo = new ArrayList(2);

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (InputManager2.Skill1)
        {
            ChangeSkill(0);
        }
        else if (InputManager2.Skill2)
        {
            ChangeSkill(1);
        }
        else if (InputManager2.Skill3)
        {
            ChangeSkill(2);
        }
    }

    private void ChangeSkill(int index)
    {
        _skillInfo.Add(_skillOffer[index]);
        _skillInfo.Add(index);
        OnSkillChangedPerformed.Raise(this, _skillInfo);
        _skillInfo.Clear();
    }
}